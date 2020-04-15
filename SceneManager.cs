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
    public class SceneManager
    {
        List<Scene> scenes = new List<Scene>();
        Scene currentScene;        
        public SceneManager(Input input)
        {
            //This will load the main menu , unless specified otherwise.
            Scene currentScene = new Scene("main_menu");
            currentScene.uiManager = UIGenerator.CreateMainMenu(input);
        }
        public void UpdateCurrentScene(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }
        public void DrawCurrentScene(GameTime gameTime,SpriteBatch spriteBatch)
        {
            currentScene.Draw(gameTime, spriteBatch);
        }
        public void SwitchScene(string sceneName)
        {
            currentScene.Save();
            currentScene = new Scene(sceneName);
        }
        public void ResetScene()
        {

        }
    }
}
