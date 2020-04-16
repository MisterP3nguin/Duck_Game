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
        public static Input input;
        public static List<Scene> scenes = new List<Scene>();
        public static Scene currentScene;
        public static void Init()
        {
            input = new Input();
            currentScene = new Scene("main_menu",input);                        
        }
        public static void UpdateCurrentScene(GameTime gameTime)
        {
            input.UpdateInput();
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
            input = new Input();
            currentScene = new Scene(sceneName,input);
        }
        public static void ResetScene()
        {

        }
    }
}
