using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_Project.Core
{
    public class Bank
    {
        protected int _score;
        protected Vector2 _position;
        protected SpriteFont _font;

        public Bank(SpriteFont banktotal)
        {
            _banktotal = banktotal;
            _position = new Vector2(10, 30);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, $"Bank: £{_banktotal}", _position, Color.White);
        }
        public virtual void SetBank(int banktotal)
        {
            _banktotal = banktotal;
        }
    }
}
