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
        internal EventHandler<EventArgs> OnClickHandler;
        internal EventHandler<EventArgs> OnReleaseHandler;
        public UIElement(string textureName) : base(textureName)
        {
            
        }
        //Use this function when adding a method to Input.Onclick, not the eventhandler.
        public virtual void OnClick(object sender, EventArgs e)
        {
            
        }
        public virtual void OnRelease(object sender, EventArgs e)
        {
            
        }
        public virtual void Dispose()
        {

        }
    }
}
