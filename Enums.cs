using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Duck_Game
{
    public enum UILayout{EvenlySpaced}
    public delegate void EventHandler(object s, EventArgs e);
    interface IResizeable
    {
        public void Resize(int x, int y);
    }
}
