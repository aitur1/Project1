﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Sprites
{
    public class Button
    {
        Texture2D texture;
        Vector2 position;
        Rectangle bounds;

        public event EventHandler Click;

        private bool isVisible = true;

        public bool Visible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public Button(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (bounds.Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Click?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }
    }
}