using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Comora;
using Duck_Game.UI;

namespace Duck_Game
{
    public class Game1 : Game
    {
        const int DEFAULT_SCREEN_WIDTH = 1024;
        const int DEFAULT_SCREEN_HEIGHT = 576;
        public static Dictionary<string, Texture2D> textureAtlas = new Dictionary<string, Texture2D>();
        public static Vector2 scale = new Vector2(1,1);
        public static int windowWidth;
        public static int windowHeight;

        Camera camera;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.AllowAltF4 = true;
            graphics.PreferredBackBufferWidth = DEFAULT_SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = DEFAULT_SCREEN_HEIGHT;
        }
        protected override void Initialize()
        {
            this.camera = new Camera(graphics.GraphicsDevice);
            this.camera.LoadContent();
            //The camera is move in regards to its origin. this moves the cameras top left corner to the
            //origin.
            this.camera.Position = new Vector2(DEFAULT_SCREEN_WIDTH / 2, DEFAULT_SCREEN_HEIGHT/ 2);
            Window.ClientSizeChanged += OnWindowResize;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textureAtlas.Add("play", Content.Load<Texture2D>("play"));
            textureAtlas.Add("editor", Content.Load<Texture2D>("editor"));
            textureAtlas.Add("exit", Content.Load<Texture2D>("exit"));
            textureAtlas.Add("empty", Content.Load<Texture2D>("empty"));

            windowHeight = Window.ClientBounds.Height;
            windowWidth = Window.ClientBounds.Width;
            SceneManager.Init();            
        }
        protected override void Update(GameTime gameTime)
        {
            this.camera.Update(gameTime);
            camera.Debug.IsVisible = Keyboard.GetState().IsKeyDown(Keys.F1);
            //Temporary for testing
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                ResizeWindow(1600, 900);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                ResizeWindow(DEFAULT_SCREEN_WIDTH, DEFAULT_SCREEN_HEIGHT);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                ResizeWindow(1920, 1080);
            }
            //^That is temporary.

            windowHeight = Window.ClientBounds.Height;
            windowWidth = Window.ClientBounds.Width;
            SceneManager.UpdateCurrentScene(gameTime);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Draw(this.camera.Debug);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(this.camera);
            SceneManager.DrawCurrentScene(gameTime,spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        protected void OnWindowResize(object sender, EventArgs e)
        {
            SceneManager.currentScene.uiManager.ResizeUI();
            ResizeWindow(Window.ClientBounds.Width,Window.ClientBounds.Height);
        }
        protected void ResizeWindow(int width, int height)
        {
            //None of this works, go fix. 
            //Both dimensions changed.      
            if (width != graphics.PreferredBackBufferWidth && height != graphics.PreferredBackBufferWidth) 
            {
                if (width > graphics.PreferredBackBufferWidth)
                    camera.Zoom = width / graphics.PreferredBackBufferWidth;
                else
                    camera.Zoom = graphics.PreferredBackBufferWidth / width;
            }
            else if (height != graphics.PreferredBackBufferWidth) 
            {
                if (height > graphics.PreferredBackBufferHeight)                
                    camera.Zoom = height / graphics.PreferredBackBufferHeight;                
                else
                    camera.Zoom = graphics.PreferredBackBufferHeight / height;
            }
            else
            {
                if (width > graphics.PreferredBackBufferWidth)
                    camera.Zoom = width / graphics.PreferredBackBufferWidth;
                else
                    camera.Zoom = graphics.PreferredBackBufferWidth / width;
            }

            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            if (width == 1920 && height == 1080)
                graphics.IsFullScreen = true;
            else
                graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }
    }
}
