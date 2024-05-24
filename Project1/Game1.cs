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

        private MainMenu mainMenu;
        private WinMenu winMenu;
        private Level1 level1;
        private Level2 level2;
        private Level3 level3;
        private Level4 level4;

        private int currentLevel = 1;

        List<Sprite> sprites;
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
            gameState = GameState.MainMenu;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            sprites = new();

            SpriteFont font = Content.Load<SpriteFont>("scoreFont");
            Texture2D buttonTexture = Content.Load<Texture2D>("start");
            Texture2D bgTexture = Content.Load<Texture2D>("backgroundTexture");
            Texture2D heartTexture = Content.Load<Texture2D>("heart");
            Texture2D playerTextureLeft = Content.Load<Texture2D>("cat_left");
            Texture2D playerTextureRight = Content.Load<Texture2D>("cat_right");
            Texture2D enemyTextureRight = Content.Load<Texture2D>("dog_right");
            Texture2D enemyTextureLeft = Content.Load<Texture2D>("dog_left");
            Texture2D platformTexture = Content.Load<Texture2D>("platform1");
            Texture2D coinTexture = Content.Load<Texture2D>("coin");
            Texture2D buttonRestartTexture = Content.Load<Texture2D>("restart");

            mainMenu = new MainMenu(bgTexture, buttonTexture, font);
            mainMenu.StartGameClicked += MainMenu_StartGameClicked;

            winMenu = new WinMenu(bgTexture, font);

            level1 = new Level1(playerTextureLeft, 
                playerTextureRight, 
                enemyTextureRight, 
                enemyTextureLeft, 
                platformTexture, 
                coinTexture, 
                bgTexture, 
                heartTexture, 
                buttonRestartTexture, 
                font);
            level2 = new Level2(playerTextureLeft, 
                playerTextureRight, 
                enemyTextureRight, 
                enemyTextureLeft, 
                platformTexture, 
                coinTexture, 
                bgTexture, 
                heartTexture, 
                buttonRestartTexture, 
                font);
            level3 = new Level3(playerTextureLeft, 
                playerTextureRight, 
                enemyTextureRight, 
                enemyTextureLeft, 
                platformTexture, 
                coinTexture, 
                bgTexture, 
                heartTexture, 
                buttonRestartTexture, 
                font);
            level4 = new Level4(playerTextureLeft, 
                playerTextureRight, 
                enemyTextureRight, 
                enemyTextureLeft, 
                platformTexture, 
                coinTexture, 
                bgTexture, 
                heartTexture, 
                buttonRestartTexture, 
                font);
        }

        private void MainMenu_StartGameClicked(object sender, EventArgs e)
        {
            gameState = GameState.InGame;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
                        if (level2.PlayerTouchesRightEdge(GraphicsDevice))
                        {
                            currentLevel++;
                        }
                    }
                    else if (currentLevel == 3)
                    {
                        level3.Update(gameTime);
                        if (level3.PlayerTouchesRightEdge(GraphicsDevice))
                        {
                            currentLevel++;
                        }
                    }
                    else if (currentLevel == 4)
                    {
                        level4.Update(gameTime);
                        if (level4.PlayerTouchesRightEdge(GraphicsDevice))
                        {
                            currentLevel++;
                        }
                    }
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

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
                    else if (currentLevel == 3)
                    {
                        level3.Draw(_spriteBatch);
                    }
                    else if (currentLevel == 4)
                    {
                        level4.Draw(_spriteBatch);
                    }
                    else if (currentLevel == 5)
                    {
                        winMenu.Draw(_spriteBatch);
                    }
                    break;
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
