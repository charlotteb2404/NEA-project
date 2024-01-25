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
                Level templevel = new Level(content, templevels[maplevels].MapSource);
                _levels.Add(templevel);

            }

            
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
