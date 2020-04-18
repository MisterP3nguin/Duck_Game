using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Duck_Game.Entities;

namespace Duck_Game.UI
{
    public abstract class UIContainer : IDisposable
    {
        public Rectangle boundingBox;
        public List<UIElement> elements;
        public List<UIContainer> uiContainers = new List<UIContainer>();
        public Texture2D texture = null;
        public Color color = Color.White;
        
        public UIContainer(Rectangle boundingBox, List<UIElement> elements)
        {
            Game1.textureAtlas.TryGetValue("empty",out texture);
            this.elements = new List<UIElement>();
            this.boundingBox = boundingBox;            
        }
        public virtual void Update(GameTime gameTime)
        {
            foreach (UIContainer container in uiContainers)
            {
                container.Update(gameTime);
            }
            foreach (UIElement element in elements)
            {
                element.Update(gameTime);                
            }
        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, boundingBox, color);
            foreach (UIContainer container in uiContainers)
            {
                container.Draw(gameTime, spriteBatch);
            }
            foreach (UIElement element in elements)
            {
                element.Draw(gameTime, spriteBatch);
            }
        }
        public void ProcessOnClickEvents(object sender, EventArgs e)
        {
            InputListener input = (InputListener)sender;   
            foreach (UIElement element in elements)
            {
                if (element is Button)
                {
                    input.OnClick += element.OnClick;
                }
            }
        }
        public void ProcessOnReleaseEvents(object sender, EventArgs e)
        {
            InputListener input = (InputListener)sender;
        }
        public virtual void RepositionUI()
        {

        }
        public void Dispose()
        {
            foreach (UIContainer container in uiContainers)
            {
                container.Dispose();
            }
            foreach (UIElement element in elements)
            {
                element.Dispose();
            }
        }
    }
}
