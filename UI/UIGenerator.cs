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
            UIContainer MainMenu = new UIContainer(UILayout.EvenlySpaced,new Rectangle (Game1.windowWidth/2-50,0,100,Game1.windowHeight),
                new List<UIElement>()
                {                    
                    new Button("play")
                    {
                        OnClick = (x) =>
                        {
                            Console.WriteLine("Play");
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

            input.OnClick += uiManager.ProcessOnClickEvents;
            input.OnRelease += uiManager.ProcessOnReleaseEvents;
            uiManager.uiContainers.Add(MainMenu);
            return uiManager;
        }
    }
}
