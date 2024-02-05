using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NEA_Project.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_Project.Core
{
    public class Level
    {
        private int _numberOfPolice;
        private int _difficulty;
        protected Texture2D _map;
        protected Vector2 _position;
        public int LevelNumber = 1;
        protected string mapcontent;
        ContentManager _content;
        private int _numberOfPoliceOfficers;
        public int NumberOfCoins { get; set; }
        public int NumberOfPotions { get; set; }

        public Level(ContentManager content, DatabaseLevel data) 
        {
            _position = new Vector2(0, 0);
            mapcontent = data.MapSource;
            _numberOfPolice = data.NumberOfPolice;
            _difficulty = data.Difficulty;
            _content = content;
            NumberOfCoins = data.NumberOfCoins;
            _numberOfPoliceOfficers = data.NumberOfPoliceOfficers;
            NumberOfPotions = data.NumberOfPotions;
        
        }

        public virtual void LoadContent()
        {
            _map = _content.Load<Texture2D>(mapcontent);
            
        }

        public int NumberOfPolice 
        {
            get { return _numberOfPolice; }
        
        }
        public int Difficulty
        {
            get { return _difficulty; }
        }
        public int NumberOfPoliceOfficers
        {
            get { return _numberOfPoliceOfficers;  }
        }

     

        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(_map, _position, null, Color.White);
        }

    }
}
