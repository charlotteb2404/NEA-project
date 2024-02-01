using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using NEA_Project.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var xdif = Position.X - player.Position.X;
            var ydif = Position.Y - player.Position.Y;
            //figure out angle 
            //if (movesBeforeChange == 0)
            //{
            //    movesBeforeChange = 5;

            //    if (turnsBeforeChange == 0)
            //    {
            //        turnsBeforeChange = 50;

            //        if (DateTime.Now.Ticks % 2 == 0)
            //        { 
            //            RotationAngle = RotationAngle * -1;
            //        }

            //    }
            //    else
            //    {
            //        turnsBeforeChange -= 1;
            //    }

            //    Rotation += RotationAngle;
            //}
            //else
            //{
               Position.Y -= Speed * (float)(Math.Cos(Rotation)) * (float)gameTime.ElapsedGameTime.TotalSeconds;
               Position.X += Speed * (float)(Math.Sin(Rotation)) * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //    movesBeforeChange -= 1;
            //}
            base.Update(gameTime);
        }

    }
}
    
