﻿using Microsoft.Xna.Framework;
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
        protected Texture2D crash;
        protected Texture2D playercar;
        public Vector2 Position;
        public float Speed = 50f;
        public float Rotation;
        public float RotationAngle;


        public Sprite()
        {

        }


        public Sprite(Texture2D texture)
        {
            _texture = texture;
            playercar = texture;
        }

        public Sprite(Texture2D texture, Texture2D crashtexture)
        {
            _texture = texture;
            playercar = texture;
            crash = crashtexture;
            Position = new Vector2(300, 300);
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
                Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Rotation += 0.05f;
            //}
        }
        public virtual void DetectCollision(Texture2D playercar, Vector2 position, float speed)
        {
            if (playercar != null && _texture != null)


            {
                if ((position.Y - playercar.Height / 2f < Position.Y + _texture.Height / 2f) //collision stops movement
               && (position.Y + playercar.Height / 2f > Position.Y - _texture.Height / 2f)
               && (position.X - playercar.Width / 2f < Position.X + _texture.Width / 2f)
               && (position.X + playercar.Width / 2f > Position.X - _texture.Width / 2f))
                {
                    Speed = 0f;
                    _texture = crash;


                }
                if (_texture == crash)
                {
                    Rotation = 0f;
                }
            }
        }
    }
    
}
