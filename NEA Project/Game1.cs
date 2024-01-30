﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NEA_Project.Core;
using NEA_Project.Sprites;
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
        //Texture2D map;
        //Vector2 mapposition;      
        float speed = 300f;
        List<Policecar> policecars;
        List<Coin> coins;
        int numofpolicecars = 5;
        Levels levels;
        int _health = 6;
        Health health;
        int _score = 0;
        Score score;
        
        int _bank = 0;
        int _banktotal;
        Bank banktotal;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 1800;
            _graphics.PreferredBackBufferWidth = 1800;
            Window.AllowUserResizing = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _menu = new StartMenu(Content);
            playercar = new Player(Content, _graphics);
            
            levels = new Levels(Content);
            
          
           SetUpLevel();


            base.Initialize();
        }
        private void SetUpLevel()
        {
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
        }

        protected override void LoadContent()
        {
            _menu.LoadContent();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            playercar.LoadContent();
       
            score = new Score(Content.Load<SpriteFont>("font"));
            banktotal = new Bank(0);

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


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();



            if (GameStarted)
            {
                if(kstate.IsKeyDown(Keys.M))
                {
                    GameStarted = false;
                    _menu.ShowMenu = true;
                }
                playercar.Update(gameTime);


                foreach (Policecar copcar in policecars)
                {
                    copcar.Update(gameTime);
                    bool CarCollision = playercar.DetectCollision(copcar);

                    if (CarCollision == true)
                    {
                        copcar.Speed = 0f;
                        copcar.RotationAngle = 0f;
                        _health--;
                        if (_health == 0)
                        {
                            speed = 0f;
                            //Exit();
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
                        levels.CurrentLevel.NumberOfCoins = levels.CurrentLevel.NumberOfCoins - 1;
                    }

                }
                score.Lives = playercar.NumberOfLives;
                if(playercar.NumberOfLives == 0)
                {
                    GameStarted = false; _menu.ShowMenu = true;
                }


                if(levels.CurrentLevel.NumberOfCoins == 0)
                {
                    
                    var success = levels.NextLevel();
                    if (success)
                    {
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
                if (_menu.Update(gameTime) == "Start")
                {
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
            score.Draw(_spriteBatch);
            foreach (Policecar copcar in policecars)
            {
                copcar.Draw(_spriteBatch);
            }
            foreach (Coin coin in coins)
            {
                coin.Draw(_spriteBatch);
            }
            _menu.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        
        }
    }
}