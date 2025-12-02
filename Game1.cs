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

            screen = Screen.Intro;


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

            introTexture = Content.Load<Texture2D>("tribble_intro");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mousestate = Mouse.GetState();

            if (screen == Screen.Intro)
            {
                if (mousestate.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;


                
            }
            else if (screen == Screen.TribbleYard)
            {
                tribbleGreyRect.X += (int)tribbleGreySpeed.X;
                if (tribbleGreyRect.X > window.Width)
                {
                    tribbleGreyRect.X = -tribbleGreyRect.Width;
                }
                tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
                if (tribbleCreamRect.X > window.Width)
                {
                    tribbleCreamRect.X = -tribbleCreamRect.Width;
                }
                tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
                if (tribbleBrownRect.X > window.Width)
                {
                    tribbleBrownRect.X = -tribbleBrownRect.Width;
                }
                tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
                if (tribbleOrangeRect.X > window.Width)
                {
                    tribbleOrangeRect.X = -tribbleOrangeRect.Width;
                }


            }


                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Lavender);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, window, Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
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

