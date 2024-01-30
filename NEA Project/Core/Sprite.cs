using Microsoft.Xna.Framework;
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
        //protected Texture2D _coin;
        //protected Texture2D _takencoin;
        public Vector2 Position;
        public float Speed = 50f;
        public float Rotation;
        public float RotationAngle = 0.05f;
        protected Vector2 _startPosition;
        protected ContentManager _content;
        protected GraphicsDeviceManager _graphics;
        protected int movesBeforeChange = 0;
        protected int turnsBeforeChange = 10;
        protected static Random random = new Random(Guid.NewGuid().GetHashCode());
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
            StayWithinScreen(_graphics);
        }
        public Rectangle Rectangle
        {
            
            get
            {
                if (_texture != null)
                {
                    return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
                }
                else
                {
                    return new Rectangle(0, 0, 0, 0);
                }
             
            }
        }
        public virtual bool DetectCollision(Sprite sprite)
        {
            if (sprite != null && _texture != null)



            {
                if (sprite.Position != Position)
                {


                  
                    if ((Position.Y - _texture.Height / 2f < sprite.Position.Y + sprite.Rectangle.Height / 2f)
                     && (Position.Y + _texture.Height / 2f > sprite.Position.Y - sprite.Rectangle.Height / 2f)
                     && (Position.X - _texture.Width / 2f < sprite.Position.X + sprite.Rectangle.Width / 2f)
                     && (Position.X + _texture.Width / 2f > sprite.Position.X - sprite.Rectangle.Width / 2f)
     )
                    {
                        Speed = 0f;
                        _texture = crash;
                        return true;
                        //Position = _startPosition;


                    }
                }

                
            }
            
                return false;
            
        }
        public virtual void StayWithinScreen(GraphicsDeviceManager _graphics)
        {
            if (_texture != null)
            {
                if (Position.X > _graphics.PreferredBackBufferWidth - _texture.Width / 2)
                {
                    Position.X = _graphics.PreferredBackBufferWidth - _texture.Width / 2;
                }
                else if (Position.X < _texture.Width / 2)
                {
                    Position.X = _texture.Width / 2;
                }
                if (Position.Y > _graphics.PreferredBackBufferHeight - _texture.Height / 2)
                {
                    Position.Y = _graphics.PreferredBackBufferHeight - _texture.Height / 2;
                }
                else if (Position.Y < _texture.Height / 2)
                {
                    Position.Y = _texture.Height / 2;
                }
            }
        }
    }
    
}
