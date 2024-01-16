using Microsoft.Xna.Framework;
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
        Policecar bat;
        float speed = 300f;
        Policecar policecar;
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
            policecar = new Policecar(Content, _graphics);
            bat = new Policecar(Content, _graphics);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            playercar.LoadContent();
            //map = Content.Load<Texture2D>("map");
            bat.LoadContent();
            policecar.LoadContent();
            score = new Score(Content.Load<SpriteFont>("font"));
            banktotal = new Bank(0);

            /*loading levels*/
            List<Texture2D> levels = new List<Texture2D>();
            levels.Add(Content.Load<Texture2D>("map"));
            levels.Add(Content.Load<Texture2D>("map2")); //need to make map2
            level =new Level(levels);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();
            //if (kstate.IsKeyDown(Keys.L))// level change
            //{
            //    if (level.LevelNumber == 1)
            //    {
            //        level.SetLevel(2);
            //    }
            //    else
            //    {
            //        level.SetLevel(1);
            //    }
            //}
            //if(kstate.IsKeyDown(Keys.Up)) //moving in directions
            //{ 
            //    position.Y = position.Y - speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //}
            //if(kstate.IsKeyDown(Keys.Left))
            //{
            //    position.X = position.X - speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //}
            //if(kstate.IsKeyDown(Keys.Down))
            //{
            //    position.Y = position.Y + speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //}
            //if(kstate.IsKeyDown(Keys.Right))
            //{
            //    position.X = position.X + speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //}
            //if(health == 0)
            //{
            //    speed = 0f;
            //    playercar = crash;  

            //}

            //if((position.Y - playercar.Height/2f< batposition.Y + bat.Height/2f)
            //    && (position.Y + playercar.Height/2f > batposition.Y - bat.Height/2f)
            //    && (position.X - playercar.Width/2f < batposition.X + bat.Width/2f)
            //    &&(position.X + playercar.Width/2f > batposition.X - bat.Width/2f))
            //{
            //    speed = 0f;
            //    playercar = crash;
            //    _score = 0;


            //}
            //if (kstate.IsKeyDown(Keys.Space)&& health > 0)
            //{
            //    speed = 300f;
            //    position.X = _graphics.PreferredBackBufferWidth / 2;
            //    position.Y = _graphics.PreferredBackBufferHeight / 2;
            //    playercar = playercarreset;
            //    //health = health - 1;
                
            //}
            score.SetScore(_score);
            _score = (int)gameTime.TotalGameTime.TotalSeconds;
            
            if (kstate.IsKeyDown(Keys.B))
            {
                _bank = _bank + _score; //stores score in bank if B is pressed then restarts the count, need to make it start going up from 0 not just show that it does
                _score = 0;

                
            }



            playercar.Update(gameTime);
            policecar.Update(gameTime);
            bat.Update(gameTime);
            //if (kstate.IsKeyDown(Keys.X))
            //{
            //    sprite.Rotation += 10;
            //}
            //sprite.DetectCollision(playercar, position, speed);
            playercar.DetectCollision(policecar);
            playercar.DetectCollision(bat);

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
            policecar.Draw(_spriteBatch);
            bat.Draw(_spriteBatch);
            playercar.Draw(_spriteBatch);
            score.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}