using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NEA_Project.models;
using NEA_Project.repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_Project.Core
{
    public class Levels
    {
        private readonly ContentManager content;
        private List<Level> _levels = new List<Level>();
        private int levelnum = 0;
        public Levels(ContentManager content) 
        {
            this.content = content;
            LevelsRepo repo = new LevelsRepo();

            List<DatabaseLevel> templevels = repo.getall();
            for (int maplevels = 0; maplevels < templevels.Count; maplevels++)
            {
                Level templevel = new Level(content, templevels[maplevels]);
                _levels.Add(templevel);

            }
            //levelnum = 4;
            
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
                if(levelnum < _levels.Count)
                {
                    return _levels[levelnum];
                }
                else
                {
                    return _levels[levelnum - 1];
                }
                
            }
        }
        public bool NextLevel()
        {
            if(levelnum < _levels.Count) 
            {
                levelnum = levelnum + 1;
                return true;
            }
            return false;
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
