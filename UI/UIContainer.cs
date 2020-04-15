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
    public class UIContainer
    {
        public Rectangle boundingBox;
        public List<UIElement> elements;
        
        public UIContainer(UILayout Layout,Rectangle boundingBox, List<UIElement> elements)
        {            
            this.elements = new List<UIElement>();
            this.boundingBox = boundingBox;
            //Evenly lay out all elements in the container.
            if (Layout == UILayout.EvenlySpaced)
            {
                //the container will be longer in height.
                if (this.boundingBox.Height >= this.boundingBox.Width)
                {
                    int offset = this.boundingBox.Height / elements.Count;
                    //draw out a diagram of what this look like to understand why the first element is
                    //divided by half 
                    elements[0].origin.Y = this.boundingBox.Y + offset / 2;
                    elements[0].origin.X = boundingBox.Center.X;
                    if (elements.Count > 1)
                    {
                        int counter = offset / 2;
                        for (int i = 1; i < elements.Count; i++)
                        {
                            counter += offset;
                            elements[i].origin.Y = counter;
                            elements[i].origin.X = boundingBox.Center.X;
                        }
                    }

                }
            }            
            this.elements = elements;
        }
        public void Update(GameTime gameTime)
        {
            foreach (UIElement element in elements)
            {
                element.Update(gameTime);                
            }
        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            foreach (UIElement element in elements)
            {
                element.Draw(gameTime, spriteBatch);
            }
        }
        public void ProcessOnClickEvents(Input input)
        {
            foreach (UIElement element in elements)
            {
                if (element is Button)
                {
                    if (element.collisionRectangle.Contains(input.mouse.Position))
                    {
                        element.OnMouseClick(input);
                    }
                }
            }
        }
        public void ProcessOnReleaseEvents(Input input)
        {

        }
    }
}
