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
    public class UIElement : Sprite ,IDisposable
    {
        public UIElement(string textureName) : base(textureName)
        {

        }
        public virtual void OnMouseClick(Input input)
        {
            
        }
        public virtual void OnMouseRelease (Input input)
        {

        }
        public virtual void Dispose()
        {

        }
    }
}
