using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        protected Texture2D ball;
        public Vector2 Position;
        public float Speed;
        public float Rotation;
        public float RotationAngle;


        public Sprite()
        {

        }


        public Sprite(Texture2D texture)
        {
            _texture = texture;
            ball = texture;
        }

        public Sprite(Texture2D texture, Texture2D crashtexture)
        {
            _texture = texture;
            ball = texture;
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
    }
    
}
