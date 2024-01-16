﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_Project.Core
{
    public class Sprite
    {
        protected Texture2D _texture;
        protected Texture2D noncrash;
        protected Texture2D crash;
        protected Texture2D playercar;
        public Vector2 Position;
        public float Speed = 50f;
        public float Rotation;
        public float RotationAngle;
        protected Vector2 _startPosition;
        protected ContentManager _content;
        protected GraphicsDeviceManager _graphics;
        public Sprite()
        {

        }


        

        public Sprite(ContentManager content, GraphicsDeviceManager graphics)
        {
            _content = content;
            _graphics = graphics;
        }
        public virtual void LoadContent()
        {

        }


        public virtual void Draw (SpriteBatch spritebatch)
        {
            if (_texture != null)
            {
                spritebatch.Draw(_texture, Position, null, Color.White, Rotation, new Vector2(_texture.Width/2f, _texture.Height/2f), Vector2.One, SpriteEffects.None, 0f);
            }
        }
        public virtual void Update(GameTime gameTime)
        {
            //var KeyboardState = Keyboard.GetState();
            //if(KeyboardState.IsKeyDown(Keys.X))
            //{
              //  Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
               // Rotation += 0.05f;
            //}
        }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        public virtual void DetectCollision(Sprite sprite)
        {
            if (sprite != null && _texture != null)


            {
                if ((sprite.Position.Y - sprite.Rectangle.Height / 2f < Position.Y + _texture.Height / 2f) //collision stops movement
               && (sprite.Position.Y + sprite.Rectangle.Height / 2f > Position.Y - _texture.Height / 2f)
               && (sprite.Position.X - sprite.Rectangle.Width / 2f < Position.X + _texture.Width / 2f)
               && (sprite.Position.X + sprite.Rectangle.Width / 2f > Position.X - _texture.Width / 2f))
                {
                    Speed = 0f;
                    _texture = crash;
                    //Position = _startPosition;


                }
            }
        }
    }
    
}
