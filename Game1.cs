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
            sceneManager = new SceneManager(input);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textureAtlas.Add("duck", Content.Load<Texture2D>("duck"));


        }

        protected override void Update(GameTime gameTime)
        {

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
