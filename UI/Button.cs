using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Duck_Game.UI
{
    public class Button : UIElement , IDisposable ,IResizeable
    {        
        public Button(string textureName) : base(textureName)
        {
           
        }
        public override void OnClick(object sender, EventArgs e)
        {
            InputListener input = (InputListener)sender;
            if (this.collisionRectangle.Contains(input.mouse.Position))
            {
                OnClickHandler?.Invoke(sender, e);
            }
            base.OnClick(sender, e);
        }
        public override void Dispose ()
        {

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
        public void Resize(int x, int y)
        {

        }
    }
}
