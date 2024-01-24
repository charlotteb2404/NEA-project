using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_Project.Core
{
    public class Levels
    {
        private List<Level> _levels = new List<Level>();
        private int levelnum = 0;
        public Levels() 
        {
        }
        public Levels(List<Level> levels)
        {
            _levels = levels;
            
        }
        public int CurrentLevelNum
        {
            get
            {
                return levelnum + 1;
            }
            set
            {
               levelnum = value - 1;
            }
        }
        public Level CurrentLevel
        {
            get
            {
                return _levels[levelnum];
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            CurrentLevel.Draw(spriteBatch);
        }
        public virtual void LoadContent()
        {
            foreach (Level level in _levels)
            {
                level.LoadContent();
            }

            
        }

    }
}
