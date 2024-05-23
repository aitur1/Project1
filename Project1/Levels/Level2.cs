using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Sprites;

namespace Project1.Levels
{
    internal class Level2 : LevelBase
    {
        public Level2(Texture2D playerTextureLeft, 
            Texture2D playerTextureRight, 
            Texture2D enemyTextureRight, 
            Texture2D enemyTextureLeft, 
            Texture2D platformTexture, 
            Texture2D coinTexture, 
            Texture2D backgroundTexture, 
            Texture2D heartTexture, 
            Texture2D buttonRestartTexture,
            SpriteFont font)
            : base(playerTextureLeft, 
                  playerTextureRight, 
                  backgroundTexture, 
                  heartTexture, 
                  buttonRestartTexture,
                  font)
        {
            AddSprite(new Platform(platformTexture, new Vector2(0, 441)));
            AddSprite(new Platform(platformTexture, new Vector2(230, 391)));
            AddSprite(new Platform(platformTexture, new Vector2(460, 341)));
            AddSprite(new Platform(platformTexture, new Vector2(690, 291)));

            AddSprite(new Enemy(enemyTextureRight, enemyTextureLeft, new Vector2(340, 350)));
            AddSprite(new Enemy(enemyTextureRight, enemyTextureLeft, new Vector2(570, 300)));

            AddSprite(new Coin(coinTexture, new Vector2(280, 320)));
            AddSprite(new Coin(coinTexture, new Vector2(510, 270)));
            AddSprite(new Coin(coinTexture, new Vector2(690, 220)));
        }
    }
}
