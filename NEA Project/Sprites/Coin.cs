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
    public class Coin : Sprite
    {

        public Coin(ContentManager content, GraphicsDeviceManager graphics) : base(content, graphics)
        {
            int randomx = random.Next(0, 1000);
            int randomy = random.Next(0, 1000);
            Position = new Vector2(randomx, randomy);
            _startPosition = Position;

        }
        public override void LoadContent()
        {
            _texture = _content.Load<Texture2D>("coin");//copy policecar
            crash = _content.Load<Texture2D>("takencoin");
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override bool DetectCollision(Sprite sprite)
        {
            if(_texture == crash)
            {
                return false;
            }
            return base.DetectCollision(sprite);
        }

    }
}
