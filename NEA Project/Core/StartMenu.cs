using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using NEA_Project.Core;



namespace NEA_Project.Core
{
    public class StartMenu
    {
        private readonly ContentManager content;
        SpriteFont font;
        List<string> menuitems = new List<string>();

        public StartMenu(ContentManager content)
        {
            this.content = content; 
            menuitems.Add("1.Create Profile");
            menuitems.Add("S.Start Game");
            menuitems.Add("X.Exit");
            ShowMenu = true;
            
        }
        public bool ShowMenu { get; set; }
        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            if (ShowMenu)
            {
                

                
                int VerticalPosition = 900;
                foreach (var item in menuitems)
                {

                    spriteBatch.DrawString(font, $"{item}", new Vector2(800, VerticalPosition), Color.White);
                    VerticalPosition += 50;
                }
            }
        }
        public virtual void LoadContent() {font = content.Load<SpriteFont>("font"); }
        public virtual string Update(GameTime gameTime) 
        { 
            var kstate = Keyboard.GetState();
            if(kstate.IsKeyDown(Keys.NumPad1)) 
            {
                //create profile
                ShowMenu = false;
                return "Start";

            }
            if(kstate.IsKeyDown(Keys.S))
            {
                ShowMenu = false;
                return "Start";
            }
            if(kstate.IsKeyDown(Keys.X))
            {
                return "Exit";
            }
            return "";
        
        }
    }

}
