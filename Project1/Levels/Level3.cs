using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Sprites;

namespace Project1.Levels
{
    internal class Level3 : LevelBase
    {
        public Level3(Texture2D playerTextureLeft, 
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
            AddSprite(new Platform(platformTexture, new Vector2(0, 450)));
            AddSprite(new Platform(platformTexture, new Vector2(230, 400)));
            AddSprite(new Platform(platformTexture, new Vector2(460, 350)));
            AddSprite(new Platform(platformTexture, new Vector2(690, 300)));

            AddSprite(new Enemy(enemyTextureRight, enemyTextureLeft, new Vector2(290, 360)));
            AddSprite(new Enemy(enemyTextureRight, enemyTextureLeft, new Vector2(520, 310)));

            AddSprite(new Coin(coinTexture, new Vector2(280, 330)));
            AddSprite(new Coin(coinTexture, new Vector2(510, 280)));
            AddSprite(new Coin(coinTexture, new Vector2(690, 230)));
        }
    }
}
