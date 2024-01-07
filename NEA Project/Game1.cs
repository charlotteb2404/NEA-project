using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();
            if(kstate.IsKeyDown(Keys.Up))
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
            if (position.Y <= 100 && position.X <= 100)
            {
                speed = 0f;
                ball = crash;
            }
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
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}