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
        List<UIElement> elements;
        public UIContainer(UILayout Layout,Rectangle rectangle, List<UIElement> elements)
        {            
            this.elements = new List<UIElement>();
            this.boundingBox = rectangle;
            //Evenly lay out all elements in the container.
            if(Layout == UILayout.EvenlySpaced)
            {                       
                //the container will be longer in height.
                if (boundingBox.Height >= boundingBox.Width)
                {
                    int offset = boundingBox.Height / elements.Count;
                    //draw out a diagram of what this look like to understand why the first element is
                    //divided by half 
                    elements[0].position.Y = offset / 2;
                    elements[0].position.X = boundingBox.Width / 2;
                    int counter = offset / 2;
                    if (elements.Count > 1)
                    {
                        for (int i = 1; i < elements.Count; i++)
                        {
                            counter += offset;
                            elements[i].position.Y = counter;
                            elements[i].position.X = boundingBox.Width / 2;
                        }
                    }

                }
                else //The container is longer in width TODO:
                {

                }
            }
            this.elements = elements;
        }
        public void Update(GameTime gameTime)
        {

        }

    }
}
