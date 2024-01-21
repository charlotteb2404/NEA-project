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
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Player playercar;
        //Texture2D map;
        //Vector2 mapposition;      
        float speed = 300f;
        List<Policecar> policecars;
        List<Coin> coins;
        int numofpolicecars = 5;
        Level level;
        int health = 6;
        int _score = 0;
        Score score;
        int _bank = 0;
        int _banktotal;
        Bank banktotal;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.PreferredBackBufferWidth = 1000;
            Window.AllowUserResizing = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            playercar = new Player(Content, _graphics);
          
            policecars = new List<Policecar>();
            for(int cars = 0; cars < 5; cars++)
            {
                Policecar copcar = new Policecar(Content, _graphics);
                policecars.Add(copcar);
            }
          
            coins = new List<Coin>();
            for(int money = 0; money < 10; money++)
            {
                Coin coin = new Coin(Content, _graphics);
                coins.Add(coin);
            }


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            playercar.LoadContent();
       
            score = new Score(Content.Load<SpriteFont>("font"));
            banktotal = new Bank(0);

            /*loading levels*/
            List<Texture2D> levels = new List<Texture2D>();
            levels.Add(Content.Load<Texture2D>("map"));
            levels.Add(Content.Load<Texture2D>("map2")); //need to make map2
            level =new Level(levels);

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


            //int scorevalue = score.GetScore();
            //score.SetScore(_score);
            
           // _score = (int)gameTime.TotalGameTime.TotalSeconds;
            
            //if (kstate.IsKeyDown(Keys.B))
            //{
            //    _bank = _bank + _score; //stores score in bank if B is pressed then restarts the count, need to make it start going up from 0 not just show that it does
            //    _score = 0;

                
            //}


            
            playercar.Update(gameTime);
            
       
            foreach (Policecar copcar in policecars)
            {
                copcar.Update(gameTime);
                playercar.DetectCollision(copcar);
            }
            foreach (Coin coin in coins)
            {
                coin.Update(gameTime);
                bool Collision = coin.DetectCollision(playercar);
                if(Collision == true)
                {
                    int tempscore = score.GetScore();
                    score.SetScore(tempscore + 1);
                }
                
            }
            //if (kstate.IsKeyDown(Keys.X))
            //{
            //    sprite.Rotation += 10;
            //}
            //sprite.DetectCollision(playercar, position, speed);
            //playercar.DetectCollision(coin);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //_spriteBatch.Draw(map, mapposition, null, Color.White);
            //foreach(var sprite in sprites)
            //{
            //    sprite.Draw(_spriteBatch);
            //}
            //player.Draw(_spriteBatch);
            level.Draw(_spriteBatch);
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
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}