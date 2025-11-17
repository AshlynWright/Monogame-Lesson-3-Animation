using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Lesson_3_Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D tribbleBrownTexture;
        Rectangle tribbleBrownRect;
        Vector2 tribbleBrownSpeed;

        Texture2D tribbleCreamTexture;
        Rectangle tribbleCreamRect;
        Vector2 tribbleCreamSpeed;

        Texture2D tribbleGreyTexture;
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;

        Texture2D tribbleOrangeTexture;
        Rectangle tribbleOrangeRect;
        Vector2 tribbleOrangeSpeed;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = " Monogame Lesson 3 Animation ";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width; 
            _graphics.PreferredBackBufferHeight = window.Height;   
            _graphics.ApplyChanges();

            tribbleGreyRect = new Rectangle(300, 10, 100, 100);
            tribbleGreySpeed = new Vector2(2, 0);

            tribbleCreamRect = new Rectangle(10, 200, 100, 100);
            tribbleCreamSpeed = new Vector2(3, 0);

            tribbleBrownRect = new Rectangle(400, 300, 100, 100);
            tribbleBrownSpeed = new Vector2(4, 0);

            tribbleOrangeRect = new Rectangle(200, 100, 100, 100);
            tribbleOrangeSpeed = new Vector2(5, 0);



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;

            if (tribbleGreyRect.Right > window.Width || tribbleGreyRect.X < 0)
                tribbleGreySpeed.X *= -1;
            if (tribbleGreyRect.Bottom > window.Height || tribbleGreyRect.Top < 0)
                tribbleGreySpeed.Y *= -1;

            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;

            if (tribbleCreamRect.Right > window.Width || tribbleCreamRect.X < 0)
                tribbleCreamSpeed.X *= -1;
            if (tribbleCreamRect.Bottom > window.Height || tribbleCreamRect.Top < 0)
                tribbleCreamSpeed.Y *= -1;

            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;

            if (tribbleBrownRect.Right > window.Width || tribbleBrownRect.X < 0)
                tribbleBrownSpeed.X *= -1;
            if (tribbleBrownRect.Bottom > window.Height || tribbleBrownRect.Top < 0)
                tribbleBrownSpeed.Y *= -1;

            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;

            if (tribbleOrangeRect.Right > window.Width || tribbleOrangeRect.X < 0)
                tribbleOrangeSpeed.X *= -1;
            if (tribbleOrangeRect.Bottom > window.Height || tribbleOrangeRect.Top < 0)
                tribbleOrangeSpeed.Y *= -1;



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Lavender);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            


            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
           

            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            

            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
           

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

