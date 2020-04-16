using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Duck_Game.UI
{
    public static class UIGenerator
    {

        public static UIManager CreateMainMenu(Input input)
        {
            UIManager uiManager = new UIManager();
            UIContainer MainMenu = new StackedBox(new Rectangle (Game1.windowWidth/2-50,0,100,Game1.windowHeight),
                new List<UIElement>()
                {                    
                    new Button("play")
                    {
                        OnClick = (x) =>
                        {
                            SceneManager.SwitchScene("game");
                        }
                    },
                    new Button("editor")
                    {
                        OnClick = (x) =>
                        {
                            Console.WriteLine("Editor");
                        }
                    },
                    new Button("exit")
                    {
                        OnClick = (x) =>
                        {
                            Console.WriteLine("Exit");
                        }
                    }
                });

            uiManager.uiContainers.Add(MainMenu);
            input.OnClick += uiManager.ProcessOnClickEvents;
            input.OnRelease += uiManager.ProcessOnReleaseEvents;
            return uiManager;
        }

        public static UIManager CreateGameMenu(Input input)
        {
            UIManager uiManager = new UIManager();

            UIContainer pauseMenu = new StackedBox(
                new Rectangle(Game1.windowWidth / 2 - 50, 0, 100, (int)(Game1.windowHeight * 0.40)),
                new List<UIElement>()
                {
                    new Button("exit")
                    {
                        OnClick = (x) =>
                        {
                            Console.WriteLine("Exit");
                        }
                    },
                    new Button("exit")
                    {
                        OnClick = (x) =>
                        {
                            Console.WriteLine("Exit");
                        }
                    },
                })
                {
                    color = Color.Black
                };
            uiManager.uiContainers.Add(pauseMenu);
            input.OnClick += uiManager.ProcessOnClickEvents;
            input.OnRelease += uiManager.ProcessOnReleaseEvents;
            return uiManager;
        }
    }
}
