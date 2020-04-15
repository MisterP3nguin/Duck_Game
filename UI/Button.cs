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
        public Button(string textureName) : base(textureName)
        {
            OnClick += (input) =>
            {
                Console.WriteLine("This button does nothing!");
            };
        }
        public override void OnMouseClick(Input input)
        {
            OnClick(input);
        }
    }
}
