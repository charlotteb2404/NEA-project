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
        protected int _2playerscore;
        protected int _2playerlives;
        protected Vector2 _2playerposition;
        private bool TwoPlayerMode;

        public bool GameCompleted { get; set; }
        public Score(SpriteFont font, bool twoPlayerMode = false)
        {
            _font = font;
            _position = new Vector2(10, 10);
            _2playerposition = new Vector2(10, 60);
            gamecompleteposition = new Vector2(700, 800);
            TwoPlayerMode = twoPlayerMode;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, $"Player 1 score = {_score}, lives = {_lives}", _position, Color.White);
            if (TwoPlayerMode)
            {
                spriteBatch.DrawString(_font, $"Player 2 score = {_2playerscore}, lives = {_2playerlives}", _2playerposition, Color.White);
            }
            if (GameCompleted)
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
        public virtual void SetScore2(int score)
        {
            _2playerscore = score;

        }
        public virtual int GetScore2()
        {
            return _2playerscore;
        }
        public int Lives
        {
            set { _lives = value; }
        }
        public int Player2Lives
        {
            set { _2playerlives = value; }
        }
    }
}
