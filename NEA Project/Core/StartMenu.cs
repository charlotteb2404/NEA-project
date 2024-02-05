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
        private bool editmode = false;
        private readonly ContentManager content;
        SpriteFont font;
        List<string> menuitems = new List<string>();
        private DateTime time = DateTime.Now;

        public StartMenu(ContentManager content)
        {
            this.content = content; 
            menuitems.Add("1.Start 1 Player");
            menuitems.Add("2.Start 2 Player");
            menuitems.Add("P.Create Profile");
            menuitems.Add("X.Exit");
            ShowMenu = true;
            
        }
        public bool ShowMenu { get; set; }
        public string ProfileName { get; set; } = "";
        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            if (ShowMenu)
            {
                if(ProfileName != "" && !editmode)
                {
                    spriteBatch.DrawString(font, $"WELCOME {ProfileName}", new Vector2(300, 300), Color.YellowGreen);
                }
                if (editmode)
                {
                    spriteBatch.DrawString(font, $"Enter Name:  {ProfileName}", new Vector2(300, 300), Color.YellowGreen);
                }



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
            if (!editmode)
            {
                if (kstate.IsKeyDown(Keys.D1))
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
                if (kstate.IsKeyDown(Keys.P))
                {
                    editmode = true;
                    time = DateTime.Now;
                    ProfileName = "";
                    return "";
                }
                if (kstate.IsKeyDown(Keys.X))
                {
                    return "Exit";
                }
            }
            else
            {
                if(kstate.GetPressedKeys().Count() > 0)
                {
                    if(time < DateTime.Now.AddSeconds(-1))
                    { 
                        ProfileName = ProfileName + kstate.GetPressedKeys()[0];
                        time = DateTime.Now;
                        if(ProfileName.Length == 3)
                        {
                            editmode = false;
                        }
                    }
                }
            }
            return "";

        
        }
    }

}
