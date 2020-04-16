using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Duck_Game.UI
{
    class StackedBox : UIContainer
    {
        public StackedBox(Rectangle boundingBox, List<UIElement> elements) : base(boundingBox, elements)
        {
            this.elements = elements;
            RepositionUI();
        }
        public override void RepositionUI()
        {
            int offset = this.boundingBox.Height / elements.Count;
            //draw out a diagram of what this look like to understand why the first element is
            //divided by half 
            elements[0].origin.Y = this.boundingBox.Y + offset / 2;
            elements[0].origin.X = boundingBox.Center.X;
            if (elements.Count > 1)
            {
                int counter = this.boundingBox.Y + offset / 2;
                for (int i = 1; i < elements.Count; i++)
                {
                    counter += offset;
                    elements[i].origin.Y = counter;
                    elements[i].origin.X = boundingBox.Center.X;
                }
            }
            base.RepositionUI();
        }
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
    }
}
            //If the total height of all elements exceeds the height of the bounding box, resize all elements.
            /*
            int totalHeight = 0;
            for (int i = 0; i < elements.Count; i++)
            {
                totalHeight += elements[i].collisionRectangle.Height;
            }
            //Vector2 scale = new Vector2(0.1f, 0.1f);
            while (totalHeight > this.boundingBox.Height)
            {
                totalHeight = 0;

                for (int i = 0; i < elements.Count; i++)
                {
                    elements[i].collisionRectangle = new Rectangle(elements[i].collisionRectangle.X,
                                                                    elements[i].collisionRectangle.Y,
                                                                    (int)(elements[i].collisionRectangle.Width * 0.9),
                                                                    (int)(elements[i].collisionRectangle.Width * 0.9));
                    //elements[i].scale *= scale;
                    totalHeight += elements[i].collisionRectangle.Height;
                }
            }
            */
