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
        public int NumberOfLives { get; set; }
        private bool IsCrashed = false;
        private bool TwoPlayerMode;
        public override bool DetectCollision(Sprite sprite)
        {
            var collided = base.DetectCollision(sprite);
            if (collided && !IsCrashed)
            {
                NumberOfLives -= 1;
                IsCrashed = true;
            }
            return collided;
            
        }
        //public Player(Texture2D texture,Texture2D crashtexture, Vector2 startPosition) : base(texture, crashtexture)
        //{
        //    this.Speed = 200f;
        //    this._startPosition = startPosition;
        //}
        public Player(ContentManager content, GraphicsDeviceManager graphics, bool twoplayermode = false): base(content, graphics) 
        {
            Position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            _startPosition = Position;
            Speed = 200f;
            RotationAngle = 0.05f;
            NumberOfLives = 3;
            TwoPlayerMode = twoplayermode;
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
            if (!IsCrashed && !TwoPlayerMode)
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
            if (!IsCrashed && TwoPlayerMode)
            {

                if (kstate.IsKeyDown(Keys.W))
                {
                    Position.Y -= Speed * (float)(Math.Cos(Rotation)) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Position.X += Speed * (float)(Math.Sin(Rotation)) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (kstate.IsKeyDown(Keys.S))
                {
                    Position.Y += Speed * (float)(Math.Cos(Rotation)) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Position.X -= Speed * (float)(Math.Sin(Rotation)) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (kstate.IsKeyDown(Keys.A))
                {
                    Rotation -= RotationAngle;
                }
                if (kstate.IsKeyDown(Keys.D))
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
                    if (IsCrashed && NumberOfLives > 0)
                    {
                        Rotation = 0f;
                        RotationAngle = 0.05f;
                        Speed = 200f;
                        _texture = noncrash;
                        Position = _startPosition;
                        IsCrashed = false;
                    }
                    
                } // need to do collecting coins
            base.Update(gameTime);
               
        }

    }
}
