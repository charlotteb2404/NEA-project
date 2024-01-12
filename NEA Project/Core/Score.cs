using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_Project.Core
{
    public class Score
    {
        protected int _score;
        protected Vector2 _position;
        protected SpriteFont _font;

        public Score(SpriteFont font)
        {
            _font = font;
            _position = new Vector2(10, 10);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, $"score = {_score}", _position, Color.White);
        }
        public virtual void SetScore(int score) 
        {
            _score = score;
        }
    }
}
