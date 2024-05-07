﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    internal class Coin : Sprite
    {
        public bool IsCollected { get; private set; } = false;

        public Coin(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public void Collect()
        {
            IsCollected = true;
        }
    }
}
