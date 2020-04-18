using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Duck_Game.UI
{
    public class UIManager : IDisposable
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
        public void ProcessOnClickEvents(object sender, EventArgs e)
        {
            foreach (UIContainer uiContainer in uiContainers)
            {
                uiContainer.ProcessOnClickEvents(sender, e);
            }
        }
        public void ProcessOnReleaseEvents(object sender, EventArgs e)
        {
            foreach (UIContainer uiContainer in uiContainers)
            {
                uiContainer.ProcessOnReleaseEvents(sender, e);                
            }
        }
        public void ResizeUI()
        {
            foreach (UIContainer uiContainer in uiContainers)
            {
                uiContainer.RepositionUI();
            }
        }
        public void Dispose()
        {
            foreach(UIContainer container in uiContainers)
            {
                container.Dispose();
            }
        }
    }
}
