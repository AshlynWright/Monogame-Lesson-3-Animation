using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml;

namespace Monogame_Lesson_3_Animation
     
{

    enum Screen
    {
        Intro,
        TribbleYard
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Screen screen;

        MouseState mousestate;

        Texture2D introTexture;
        Texture2D tribbleTexture;

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

        Color tribbleHitDetection;

        // Added variable
        private Texture2D backgroundTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            this.Window.Title = " Monogame Lesson 3 Animation ";

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width; 
            _graphics.PreferredBackBufferHeight = window.Height;   
            _graphics.ApplyChanges();

            screen = Screen.Intro;

            tribbleGreyRect = new Rectangle(0, 0, 100, 100);
            tribbleGreySpeed = new Vector2(3, 0);

            tribbleCreamRect = new Rectangle(100, 100, 100, 100);
            tribbleCreamSpeed = new Vector2(0, 2);

            tribbleBrownRect = new Rectangle(400, 500, 100, 100);
            tribbleBrownSpeed = new Vector2(-3, 2);

            tribbleOrangeRect = new Rectangle(300, 300, 100, 100);
            tribbleOrangeSpeed = new Vector2(-2, -2);

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

            introTexture = Content.Load<Texture2D>("tribble_intro");

            backgroundTexture = new Texture2D(GraphicsDevice, 1, 1);
            backgroundTexture.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //TODO: Add your update logic here

            mousestate = Mouse.GetState();

            if (screen == Screen.Intro)
            {
                if (mousestate.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;

            }
            else if (screen == Screen.TribbleYard)
            {

                tribbleGreyRect.X += (int)tribbleGreySpeed.X;
                if (tribbleGreyRect.Right > _graphics.PreferredBackBufferWidth || tribbleGreyRect.Left < 0)
                {
                    tribbleHitDetection = Color.Gray;
                    tribbleGreySpeed.X *= -1;
                }

                tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
                if (tribbleGreyRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleGreyRect.Top < 0)
                {
                    tribbleHitDetection = Color.Gray;
                    tribbleGreySpeed.Y *= -1;
                }


                tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
                if (tribbleCreamRect.Right > _graphics.PreferredBackBufferWidth || tribbleCreamRect.Left < 0)
                {
                    tribbleHitDetection = Color.Beige;
                    tribbleCreamSpeed.X *= -1;
                }
                    
                tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
                if (tribbleCreamRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleCreamRect.Top < 0)
                {
                    tribbleHitDetection = Color.Beige;
                    tribbleCreamSpeed.Y *= -1;
                }

                tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
                if (tribbleBrownRect.Right > _graphics.PreferredBackBufferWidth || tribbleBrownRect.Left < 0)
                { 
                    tribbleHitDetection = Color.SaddleBrown;
                    tribbleBrownSpeed.X *= -1;
                }

                tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
                if (tribbleBrownRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleBrownRect.Top < 0)
                {
                    tribbleHitDetection = Color.SaddleBrown;
                    tribbleBrownSpeed.Y *= -1;
                }

                tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
                if (tribbleOrangeRect.Right > _graphics.PreferredBackBufferWidth || tribbleOrangeRect.Left < 0)
                {
                    tribbleHitDetection = Color.SandyBrown;
                    tribbleOrangeSpeed.X *= -1;
                }

                tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
                if (tribbleOrangeRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleOrangeRect.Top < 0)
                {
                    tribbleHitDetection = Color.SandyBrown;
                    tribbleOrangeSpeed.Y *= -1;
                }

            }


                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(tribbleHitDetection);

            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, window, Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                //_spriteBatch.Draw(backgroundTexture, window, Color.White);
                _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
                _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
                _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
                _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

