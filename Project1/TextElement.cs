using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class TextElement
    {
        SpriteFont font;
        string text;
        Vector2 position;

        public TextElement(SpriteFont font, string text, Vector2 position)
        {
            this.font = font;
            this.text = text;
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, Color.Black);
        }
    }
}
