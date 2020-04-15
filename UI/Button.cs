using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Duck_Game.UI
{
    public class Button : UIElement
    {
        public InputEvent OnClick;
        public InputEvent OnRelease;
        public InputEvent OnMouseClick;
        public Button(string textureName, Input input) : base(textureName)
        {   
            if (OnClick != null)
            {
                input.OnClick += this.OnClick;
            }
            if (OnRelease != null)
            {
                input.OnClick += this.OnRelease;
            }
            if (OnClick != null)
            {
                input.OnClick += this.OnMouseClick;
            }
        }
    }
}
