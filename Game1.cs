using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Comora;

namespace Duck_Game
{
    public class Game1 : Game
    {
        public static Dictionary<string, Texture2D> textureAtlas = new Dictionary<string, Texture2D>();
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
            
        }

        protected override void Initialize()
        {
            this.camera = new Camera(graphics.GraphicsDevice);
            this.camera.LoadContent();
            this.camera.Position = new Vector2(camera.Width / 2, camera.Height / 2);
            windowHeight = Window.ClientBounds.Height;
            windowWidth = Window.ClientBounds.Width;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textureAtlas.Add("play", Content.Load<Texture2D>("play"));
            textureAtlas.Add("editor", Content.Load<Texture2D>("editor"));
            textureAtlas.Add("exit", Content.Load<Texture2D>("exit"));
            textureAtlas.Add("empty", Content.Load<Texture2D>("empty"));

            SceneManager.Init();            
        }

        protected override void Update(GameTime gameTime)
        {
            this.camera.Update(gameTime);
            camera.Debug.IsVisible = Keyboard.GetState().IsKeyDown(Keys.F1);
            if (SceneManager.input.keyboard.IsKeyDown(Keys.Q))
            {
                camera.Zoom = 2;
            }

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
    }
}
