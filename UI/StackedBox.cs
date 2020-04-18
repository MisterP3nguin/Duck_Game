using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Duck_Game.UI
{
    class StackedBox : UIContainer, IResizeable
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
        public void Resize(int x, int y)
        {

        }
    }
}            