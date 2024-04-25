    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;

    namespace Project1
    {
        public class Game1 : Game
        {
            private GraphicsDeviceManager _graphics;
            private SpriteBatch _spriteBatch;

            List<Sprite> sprites;
            AnimationManager am;

            Player player;
            Enemy enemy;
            Texture2D playerTexture;

            public Game1()
            {
                _graphics = new GraphicsDeviceManager(this);
                //_graphics.IsFullScreen = true;
                _graphics.PreferredBackBufferWidth = 1920;
                _graphics.PreferredBackBufferHeight = 1080;
                Content.RootDirectory = "Content";
                IsMouseVisible = true;
            }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sprites = new();

            Texture2D platformTexture = Content.Load<Texture2D>("platform1");
            Texture2D enemyTexture = Content.Load<Texture2D>("dogx4");
            Texture2D playerTexture = Content.Load<Texture2D>("catx4");

            sprites.Add(new Sprite(platformTexture, new Vector2(0, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(230, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(460, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(690, 1000)));

            sprites.Add(new Enemy(enemyTexture, new Vector2(100, 960)));
            sprites.Add(new Enemy(enemyTexture, new Vector2(400, 960)));
            sprites.Add(new Enemy(enemyTexture, new Vector2(250, 960)));

            player = new Player(playerTexture, new Vector2(500, 940), sprites);
            sprites.Add(player);

            //am = new(6, 6, new Vector2(92, 64));
            //playerTexture = Content.Load<Texture2D>("catrun");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            List<Sprite> killList = new List<Sprite>();
            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime);
                if (sprite != player && sprite.Rect.Intersects(player.Rect))
                {
                    if (sprite is Enemy)
                        killList.Add(player);
                    player.OnCollision(sprite);
                }
            }

            foreach (var sprite in killList)
            {
                sprites.Remove(sprite);
            }

            //am.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            foreach (var sprite in sprites)
            {
                sprite.Draw(_spriteBatch);
            }

            //_spriteBatch.Draw(
            //    playerTexture,
            //    new Rectangle(100, 100, 100, 100),
            //    am.GetFrame(),
            //    Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
