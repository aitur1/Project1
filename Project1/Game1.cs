using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Levels;
using Project1.Sprites;
using System;
using System.Collections.Generic;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private int currentLevel = 1;

        private MainMenu mainMenu;
        private Level1 level1;
        private Level2 level2;

        List<Sprite> sprites;
        //AnimationManager am;

        Player player;
        Enemy enemy;

        Texture2D playerTexture;

        private enum GameState
        {
            MainMenu,
            InGame
        }
        private GameState gameState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            gameState = GameState.MainMenu;

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sprites = new();

            Texture2D buttonTexture = Content.Load<Texture2D>("start");
            Texture2D bgTexture = Content.Load<Texture2D>("backgroundTexture");
            Texture2D heartTexture = Content.Load<Texture2D>("heart");

            mainMenu = new MainMenu(bgTexture, buttonTexture);
            mainMenu.StartGameClicked += MainMenu_StartGameClicked;

            Texture2D playerTexture = Content.Load<Texture2D>("catx4");
            Texture2D enemyTexture = Content.Load<Texture2D>("dogx4");
            Texture2D platformTexture = Content.Load<Texture2D>("platform1");
            Texture2D coinTexture = Content.Load<Texture2D>("coin");

            level1 = new Level1(playerTexture, enemyTexture, platformTexture, coinTexture, bgTexture, heartTexture);
            level2 = new Level2(playerTexture, enemyTexture, platformTexture, coinTexture, bgTexture, heartTexture);

            //am = new(6, 6, new Vector2(92, 64));
        }

        private void MainMenu_StartGameClicked(object sender, EventArgs e)
        {
            gameState = GameState.InGame;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            switch (gameState)
            {
                case GameState.MainMenu:
                    mainMenu.Update(gameTime);
                    break;
                case GameState.InGame:
                    if (currentLevel == 1)
                    {
                        level1.Update(gameTime);
                        if (level1.PlayerTouchesRightEdge(GraphicsDevice))
                        {
                            currentLevel++;
                        }
                    }
                    else if (currentLevel == 2)
                    {
                        level2.Update(gameTime);
                    }
                    break;
            }
            //am.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            switch (gameState)
            {
                case GameState.MainMenu:
                    mainMenu.Draw(_spriteBatch);
                    break;
                case GameState.InGame:
                    if (currentLevel == 1)
                    {
                        level1.Draw(_spriteBatch);
                    }
                    else if (currentLevel == 2)
                    {
                        level2.Draw(_spriteBatch);
                    }
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
