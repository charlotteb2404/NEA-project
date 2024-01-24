using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_Project.Core
{
    public class Level
    {
        protected Texture2D _map;
        protected Vector2 _position;
        public int LevelNumber = 1;
        protected string mapcontent;
        ContentManager _content;

        public Level(ContentManager content, string contentname) 
        {
            _position = new Vector2(0, 0);
            mapcontent = contentname;
            _content = content;
        
        }

        public virtual void LoadContent()
        {
            _map = _content.Load<Texture2D>(mapcontent);
            
        }

       

     

        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(_map, _position, null, Color.White);
        }

    }
}
