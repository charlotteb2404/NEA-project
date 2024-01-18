using NEA_Project.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;

namespace NEA_Project.Sprites
{
    public class Player : Sprite
    {
        //public Player(Texture2D texture,Texture2D crashtexture, Vector2 startPosition) : base(texture, crashtexture)
        //{
        //    this.Speed = 200f;
        //    this._startPosition = startPosition;
        //}
        public Player(ContentManager content, GraphicsDeviceManager graphics): base(content, graphics) 
        {
            Position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            _startPosition = Position;
            Speed = 200f;
            RotationAngle = 0.05f;
        }

        public override void LoadContent()
        {
            _texture = _content.Load<Texture2D>("playercar");
            noncrash = _content.Load<Texture2D>("playercar");
            crash = _content.Load<Texture2D>("crash");
        }
        public override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();
            if (Speed > 0)
            {

                if (kstate.IsKeyDown(Keys.Up))
                {
                    Position.Y -= Speed * (float)(Math.Cos(Rotation)) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Position.X += Speed * (float)(Math.Sin(Rotation)) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (kstate.IsKeyDown(Keys.Down))
                {
                    Position.Y += Speed * (float)(Math.Cos(Rotation)) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Position.X -= Speed * (float)(Math.Sin(Rotation)) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (kstate.IsKeyDown(Keys.Left))
                {
                    Rotation -= RotationAngle;
                }
                if (kstate.IsKeyDown(Keys.Right))
                {
                    Rotation += RotationAngle;
                }
                if (Rotation == -360f || Rotation == 360f)
                {
                    Rotation = 0f; //so rotation value doesn't go too high
                }
            }
                if (kstate.IsKeyDown(Keys.Space))
                {
                    if (Speed == 0f)
                    {
                        Rotation = 0f;
                        RotationAngle = 0.05f;
                        Speed = 200f;
                        _texture = noncrash;
                        Position = _startPosition;
                    }
                }
            base.Update(gameTime);
               
        }

    }
}
