using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Duck_Game.UI
{
    public class UIManager
    {
        public List<UIContainer> uiContainers = new List<UIContainer>();
        public void Update(GameTime gameTime)
        {
            foreach (UIContainer uiContainer in uiContainers)
            {
                uiContainer.Update(gameTime);
            }
        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            foreach (UIContainer uiContainer in uiContainers)
            {
                uiContainer.Draw(gameTime,spriteBatch);
            }
        }       
        public void ProcessOnClickEvents(Input input)
        {
            foreach (UIContainer uiContainer in uiContainers)
            {
                uiContainer.ProcessOnClickEvents(input);
            }
        }
        public void ProcessOnReleaseEvents(Input input)
        {
            foreach (UIContainer uiContainer in uiContainers)
            {
                uiContainer.ProcessOnReleaseEvents(input);                
            }
        }
    }
}
