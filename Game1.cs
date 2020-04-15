using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Duck_Game
{
    public class Game1 : Game
    {
        public static Dictionary<string, Texture2D> textureAtlas = new Dictionary<string, Texture2D>();
        public static int windowWidth;
        public static int windowHeight;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SceneManager sceneManager;
        Input input;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            input = new Input();
        }

        protected override void Initialize()
        {
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

            sceneManager = new SceneManager(input);            
        }

        protected override void Update(GameTime gameTime)
        {
            windowHeight = Window.ClientBounds.Height;
            windowWidth = Window.ClientBounds.Width;
            input.UpdateInput();

            sceneManager.UpdateCurrentScene(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            sceneManager.DrawCurrentScene(gameTime,spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
