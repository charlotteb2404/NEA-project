using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using NEA_Project.Core;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace NEA_Project.Sprites
{
    public class Policeman : Sprite
    {
        public Policeman(ContentManager content, GraphicsDeviceManager graphics) : base(content, graphics)
        {
            int randomx = random.Next(0, graphics.PreferredBackBufferWidth);
            int randomy = random.Next(0, graphics.PreferredBackBufferHeight);
            Position = new Vector2(randomx, randomy);
            _startPosition = Position;

        }
        public override void LoadContent()
        {
            _texture = _content.Load<Texture2D>("policeofficer");
            noncrash = _content.Load<Texture2D>("policeofficer");
            crash = _content.Load<Texture2D>("crash");
        }
        public override void Update(GameTime gameTime, Sprite player)
        {
            //getting the ploliceman to follow the player
            var xdif = player.Position.X - Position.X;
            var ydif = player.Position.Y - Position.Y;
            var gradient = ydif/xdif;
                Vector2 Direction = new Vector2(xdif, ydif);
                Direction.Normalize();
                RotationAngle = (float)Math.Atan2(ydif, xdif);
                Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
          
            base.Update(gameTime);
        }

    }
}
    
