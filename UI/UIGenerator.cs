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

        public static UIManager CreateMainMenu(InputListener input)
        {
            UIManager uiManager = new UIManager();
            UIContainer mainMenu = new StackedBox(new Rectangle (Game1.windowWidth/2-50,0,100,Game1.windowHeight),
                new List<UIElement>()
                {                    
                    new Button("play")
                    {
                        OnClickHandler = (x, e) =>
                        {
                            SceneManager.SwitchScene("game");
                        }
                    },
                    new Button("editor")
                    {
                        OnClickHandler = (x, e) =>
                        {
                            Console.WriteLine("Options");
                        }
                    },
                    new Button("exit")
                    {
                        OnClickHandler = (sender, e) =>
                        {
                            Game1.isRunning = false;
                        }                        
                    }
                });
            //Add evenhandlers to UIelements as needed.
            foreach (UIElement element in mainMenu.elements)
            {
                if (element is Button)
                {
                    input.OnClick += element.OnClick;
                }
            }
            
            uiManager.uiContainers.Add(mainMenu);
            return uiManager;
        }

        public static UIManager CreateGameMenu(InputListener input)
        {
            UIManager uiManager = new UIManager();

            UIContainer pauseMenu = new StackedBox(
                new Rectangle(Game1.windowWidth / 2 - 50, (int)(Game1.windowHeight * (0.25)), 100, (int)(Game1.windowHeight * 0.5)),
                new List<UIElement>()
                {
                    new Button("editor")
                    {
                        OnClickHandler = (x, e) =>
                        {
                            Console.WriteLine("Options");
                        }
                    },
                    new Button("exit")
                    {
                        OnClickHandler = (x, e) =>
                        {
                            Game1.isRunning = false;
                        }
                    },
                })
                {
                    color = Color.Black
                };
            foreach (UIElement element in pauseMenu.elements)
            {
                if (element is Button)
                {
                    input.OnClick += element.OnClick;
                }
            }
            uiManager.uiContainers.Add(pauseMenu);
            return uiManager;
        }
    }
}
