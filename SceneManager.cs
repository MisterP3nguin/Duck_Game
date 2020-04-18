using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO.Compression;
using Duck_Game.UI;

namespace Duck_Game
{
    public static class SceneManager
    {
        public static InputListener InputListener;
        public static List<Scene> scenes = new List<Scene>();
        public static Scene currentScene;
        public static void Init()
        {
            InputListener = new InputListener();
            currentScene = new Scene("main_menu",InputListener);                        
        }
        public static void UpdateCurrentScene(GameTime gameTime)
        {
            InputListener.UpdateInput();
            currentScene.Update(gameTime);
        }
        public static void DrawCurrentScene(GameTime gameTime,SpriteBatch spriteBatch)
        {
            currentScene.Draw(gameTime, spriteBatch);
        }
        public static void SwitchScene(string sceneName)
        {
            currentScene.Save();            
            currentScene.Dispose();
            InputListener = new InputListener();
            currentScene = new Scene(sceneName,InputListener);
        }
        public static void ResetScene()
        {

        }
    }
}
