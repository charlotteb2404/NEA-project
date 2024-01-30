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
        protected Vector2 gamecompleteposition;
        protected SpriteFont _font;
        protected int _lives;

        public bool GameCompleted { get; set; }
        public Score(SpriteFont font)
        {
            _font = font;
            _position = new Vector2(10, 10);
            gamecompleteposition = new Vector2(700, 800);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, $"score = {_score}, lives = {_lives}", _position, Color.White);
            if(GameCompleted)
            {
                spriteBatch.DrawString(_font, $"GAME COMPLETE", gamecompleteposition, Color.Gold);
            }
        }
        public virtual void SetScore(int score) 
        {
            _score = score;
        }
        public virtual int GetScore()
        {
            return _score;
        }
        public int Lives
        {
            set { _lives = value; }
        }
    }
}
