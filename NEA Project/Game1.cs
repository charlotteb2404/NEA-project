using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NEA_Project.Core;

namespace NEA_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D ball;
        Vector2 position;
        Texture2D map;
        Vector2 mapposition;
        Texture2D bat;
        Vector2 batposition;
        float speed = 300f;
        Texture2D crash;
        Texture2D ballreset;
        Sprite sprite;
        int health = 6;
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
            position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            mapposition = new Vector2(0, 0);
            batposition = new Vector2(100, 100);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ball = Content.Load<Texture2D>("ball");
            map = Content.Load<Texture2D>("map");
            bat = Content.Load<Texture2D>("ball");
            crash = Content.Load<Texture2D>("crash");
            ballreset = Content.Load<Texture2D>("ball");
            sprite = new Sprite(ball, crash);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();
            if(kstate.IsKeyDown(Keys.Up)) //moving in directions
            { 
                position.Y = position.Y - speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }
            if(kstate.IsKeyDown(Keys.Left))
            {
                position.X = position.X - speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if(kstate.IsKeyDown(Keys.Down))
            {
                position.Y = position.Y + speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if(kstate.IsKeyDown(Keys.Right))
            {
                position.X = position.X + speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if(health == 0)
            {
                speed = 0f;
                ball = crash;
            }

            if((position.Y - ball.Height/2f< batposition.Y + bat.Height/2f)
                && (position.Y + ball.Height/2f > batposition.Y - bat.Height/2f)
                && (position.X - ball.Width/2f < batposition.X + bat.Width/2f)
                &&(position.X + ball.Width/2f > batposition.X - bat.Width/2f))
            {
                speed = 0f;
                ball = crash;
               

            }
            if (kstate.IsKeyDown(Keys.Space)&& health > 0)
            {
                speed = 300f;
                position.X = _graphics.PreferredBackBufferWidth / 2;
                position.Y = _graphics.PreferredBackBufferHeight / 2;
                ball = ballreset;
                //health = health - 1;
                
            }
            sprite.Update(gameTime);
            //if (kstate.IsKeyDown(Keys.X))
            //{
            //    sprite.Rotation += 10;
            //}
            sprite.DetectCollision(ball, position);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(map, mapposition, null, Color.White);
            _spriteBatch.Draw(ball, position, null, Color.White);
            _spriteBatch.Draw(bat, batposition, null, Color.White);
            sprite.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}