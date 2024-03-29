﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using NEA_Project.Core;
using Microsoft.Xna.Framework.Graphics;

namespace NEA_Project.Sprites
{
    public class ExtraLifePotion : Sprite
    {
        public ExtraLifePotion(ContentManager content, GraphicsDeviceManager graphics) : base(content, graphics)
        {
            int randomx = random.Next(0, graphics.PreferredBackBufferWidth);
            int randomy = random.Next(0, graphics.PreferredBackBufferHeight);
            Position = new Vector2(randomx, randomy);
            _startPosition = Position;
        }
        public override void LoadContent()
        {
            _texture = _content.Load<Texture2D>("potion");
            crash = _content.Load<Texture2D>("takenpotion");
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override bool DetectCollision(Sprite sprite)
        {
            if (_texture == crash)
            {
                return false;
            }
            return base.DetectCollision(sprite);
        }
    }
}