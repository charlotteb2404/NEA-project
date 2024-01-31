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
            menuitems.Add("1.Start 1 Player");
            menuitems.Add("2.Start 2 Player");
            menuitems.Add("X.Exit");
            ShowMenu = true;
            
        }
        public bool ShowMenu { get; set; }
        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            if (ShowMenu)
            {


                spriteBatch.DrawString(font, $"Collect coins and try your best to avoid the police", new Vector2(300, 500), Color.White);
                spriteBatch.DrawString(font, $"Player 1 Controls: Up, Down, Left, Right Arrows", new Vector2(300, 600), Color.White);
                spriteBatch.DrawString(font, $"Player 2 Controls: W - Up, S - Down, A - Left, D - Right", new Vector2(300, 700), Color.White);
                spriteBatch.DrawString(font, $"Press M to return to Menu", new Vector2(300, 400), Color.White);
                spriteBatch.DrawString(font, $"Press Space to reset your character", new Vector2(300, 800), Color.White);
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
            if(kstate.IsKeyDown(Keys.D1)) 
            {
                //create profile
                ShowMenu = false;
                return "Start 1 Player";

            }
            if (kstate.IsKeyDown(Keys.D2))
            {
                ShowMenu = false;
                return "Start 2 Player";
            }
            if(kstate.IsKeyDown(Keys.X))
            {
                return "Exit";
            }
            return "";
        
        }
    }

}
