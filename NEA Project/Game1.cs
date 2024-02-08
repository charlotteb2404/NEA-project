using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NEA_Project.Core;
using NEA_Project.repos;
using NEA_Project.Sprites;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace NEA_Project
{
    public class Game1 : Game
    {
        private StartMenu _menu;
        private bool GameStarted = false;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Player playercar;
        Player playercar2;
        //Texture2D map;
        //Vector2 mapposition;      
        float speed = 300f;
        List<Policecar> policecars;
        List<Coin> coins;
        Levels levels;
        int _score = 0;
        Score score;
        private bool TwoPlayerMode;
        List<Policeman> policemen;
        int numofpoliceofficers = 1;
        List<ExtraLifePotion> extralifePotion;
     
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 1800;
            _graphics.PreferredBackBufferWidth = 1800;
            Window.AllowUserResizing = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //setting screen display size
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _menu = new StartMenu(Content);
            playercar = new Player(Content, _graphics);
            if(TwoPlayerMode == true)
            {
                playercar2 = new Player(Content, _graphics, true);
                playercar2.Position = new Vector2(100, 100);
            }
            //loading content for players
            
            levels = new Levels(Content);
            
          
           SetUpLevel();


            base.Initialize();
        }
        private void SetUpLevel()
        {
            //setting up levels by adding each level's set amount of sprites 
            policecars = new List<Policecar>();
            for (int cars = 0; cars < levels.CurrentLevel.NumberOfPolice; cars++)
            {
                Policecar copcar = new Policecar(Content, _graphics);
                copcar.LoadContent();
                policecars.Add(copcar);

            }

            coins = new List<Coin>();
            for (int money = 0; money < levels.CurrentLevel.NumberOfCoins; money++)
            {
                Coin coin = new Coin(Content, _graphics);
                coin.LoadContent();
                coins.Add(coin);
            }
            policemen = new List<Policeman>();
            for (int officers = 0; officers < levels.CurrentLevel.NumberOfPoliceOfficers; officers++)
            {
                Policeman policeman = new Policeman(Content, _graphics);
                policeman.LoadContent();
                policemen.Add(policeman);
            }
            extralifePotion = new List<ExtraLifePotion>();
            for(int potions = 0; potions < levels.CurrentLevel.NumberOfPotions; potions++)
            {
                ExtraLifePotion extralifepotion = new ExtraLifePotion(Content, _graphics);
                extralifepotion.LoadContent();
                extralifePotion.Add(extralifepotion);
            }
        }

        protected override void LoadContent()
        {
            _menu.LoadContent();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            playercar.LoadContent();
            if(TwoPlayerMode == true) 
            {
                playercar2.LoadContent();
            }
       
            score = new Score(Content.Load<SpriteFont>("font"),TwoPlayerMode);
           
            /*loading levels*/
            levels.LoadContent();


            foreach(Policecar copcar in policecars)
            {
                copcar.LoadContent();
            }
            foreach(Coin coin in coins)
            {
                coin.LoadContent();
            }
            foreach(Policeman officer in policemen)
            {
                officer.LoadContent();
            }
            foreach(ExtraLifePotion potion in extralifePotion)
            {
                potion.LoadContent();
            }


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();
            var x = kstate.GetPressedKeys();


            if (GameStarted)
            {
                if(kstate.IsKeyDown(Keys.M)) //returning to menu
                {
                    GameStarted = false;
                    _menu.ShowMenu = true;
                }
                playercar.Update(gameTime);
                if(TwoPlayerMode) 
                {
                    playercar2.Update(gameTime);
                }

                //detecting player collisions to certain sprites 
                foreach (Policecar copcar in policecars)
                {
                    copcar.Update(gameTime);
                    bool CarCollision = playercar.DetectCollision(copcar);
                   
                    if (CarCollision == true)
                    {
                        copcar.Speed = 0f;
                        copcar.RotationAngle = 0f; //player and cop car collision stops cop car movement 

                    }
                    if (TwoPlayerMode)//setting same for two player mode
                    {
                        bool CarCollision2 = playercar2.DetectCollision(copcar);
                        if (CarCollision2 == true)
                        {
                            copcar.Speed = 0f;
                            copcar.RotationAngle = 0f;

                        }
                    }

                }
                foreach (Policeman officer in policemen)
                {
                    officer.Update(gameTime, playercar);
                    bool CarCollision = playercar.DetectCollision(officer);

                    if (CarCollision == true)
                    {
                        officer.Speed = 0f;
                        officer.RotationAngle = 0f;

                    }
                    if (TwoPlayerMode)
                    {
                        bool CarCollision2 = playercar2.DetectCollision(officer);
                        if (CarCollision2 == true)
                        {
                            officer.Speed = 0f;
                            officer.RotationAngle = 0f;

                        }
                    }

                }
                foreach (Coin coin in coins)
                {
                    coin.Update(gameTime);
                    bool Collision = coin.DetectCollision(playercar);
                    if (Collision == true)
                    {
                        int tempscore = score.GetScore();
                        score.SetScore(tempscore + 1);
                        playercar.CurrentLevelScore += 1; //collecting a coin adds one to the score
                        levels.CurrentLevel.NumberOfCoins = levels.CurrentLevel.NumberOfCoins - 1;

                    }
                    if(TwoPlayerMode)
                    {
                        bool Collision2 = coin.DetectCollision(playercar2);
                        if (Collision2 == true)
                        {
                            int tempscore = score.GetScore2();
                            score.SetScore2(tempscore + 1);
                            playercar2.CurrentLevelScore += 1;
                            levels.CurrentLevel.NumberOfCoins = levels.CurrentLevel.NumberOfCoins - 1;
                        }
                    }
                    foreach(ExtraLifePotion extralifepotion in extralifePotion)
                    {
                        extralifepotion.Update(gameTime);
                        bool PotionCollision = extralifepotion.DetectCollision(playercar);
                        if (PotionCollision == true)
                        {
                            playercar.NumberOfLives += 1; //extra life potion adds one to life
                        }
                        if (TwoPlayerMode)
                        {
                            bool PotionCollision2 = extralifepotion.DetectCollision(playercar2);
                            if (PotionCollision2 == true)
                            {
                                playercar2.NumberOfLives += 1;
                                
                            }
                        }
                    }

                }
                score.Lives = playercar.NumberOfLives;
                if(playercar.NumberOfLives == 0 && !TwoPlayerMode)
                {
                    ProfileRepo profileRepo = new ProfileRepo();
                    profileRepo.Update(score.GetScore(), _menu.GetProfileName()); //this is storing data for the highscore table
                    GameStarted = false; _menu.ShowMenu = true;
                }
                if(TwoPlayerMode)
                {
                    score.Player2Lives = playercar2.NumberOfLives;
                    if (playercar.NumberOfLives == 0 && playercar2.NumberOfLives == 0 && TwoPlayerMode)
                    {
                        GameStarted = false; _menu.ShowMenu = true;
                    }

                }
               

                if (levels.CurrentLevel.NumberOfCoins == 0)
                { 
                    
                    var success = levels.NextLevel();
                    if (success)
                    {
                        if (TwoPlayerMode)
                        {
                            //when all coins collected in two player mode whichever player collected more coins gets 5 bonus points
                            if (playercar.CurrentLevelScore > playercar2.CurrentLevelScore)
                            {
                                int tempscore = score.GetScore();
                                score.SetScore(tempscore + 5);
                            }
                            else
                            {
                                int tempscore = score.GetScore2();
                                score.SetScore2(tempscore + 5);
                            }
                            playercar.CurrentLevelScore = 0;
                            playercar2.CurrentLevelScore = 0;

                        }
                            SetUpLevel();
                        
                    }
                    else
                    {
                        score.GameCompleted = true;
                    }
                }

                base.Update(gameTime);
            }
            else
            {
                //menu options starting or ending the game
                if (_menu.Update(gameTime) == "Start 1 Player")
                {
                    TwoPlayerMode = false;
                    Initialize();
                    LoadContent();
                    GameStarted = true;
                }
                if (_menu.Update(gameTime) == "Start 2 Player")
                {
                    TwoPlayerMode = true;
                    Initialize();
                    LoadContent();
                    GameStarted = true;
                }
                if (_menu.Update(gameTime)== "Exit")
                {
                    Exit();
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            

            levels.Draw(_spriteBatch);
            playercar.Draw(_spriteBatch);
            if(TwoPlayerMode) 
            {
                playercar2.Draw(_spriteBatch);
            
            }
            score.Draw(_spriteBatch);
            foreach (Policecar copcar in policecars)
            {
                copcar.Draw(_spriteBatch);
            }
            foreach (Coin coin in coins)
            {
                coin.Draw(_spriteBatch);
            }
            foreach(Policeman officer in policemen)
            {
                officer.Draw(_spriteBatch); 
            }
            foreach(ExtraLifePotion potion in extralifePotion)
            {
                potion.Draw(_spriteBatch);
            }
            _menu.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        
        }
    }
}