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
            UIContainer MainMenu = new UIContainer(UILayout.EvenlySpaced,new Rectangle (),
                new List<UIElement>()
                {                    
                    new Button("duck",input)
                    {
                        OnClick = (x) =>
                        {
                            Console.WriteLine("This button has been clicked!");
                        }
                    },
                    new Button("duck",input)
                    {
                        OnClick = (x) =>
                        {
                            Console.WriteLine("This button has been clicked!");
                        }
                    },
                    new Button("duck",input)
                    {
                        OnClick = (x) =>
                        {
                            Console.WriteLine("This button has been clicked!");
                        }
                    }
                });
            uiManager.uiContainers.Add(MainMenu);

            return uiManager;
        }
    }
}
