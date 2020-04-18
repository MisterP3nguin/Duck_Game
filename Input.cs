using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Duck_Game
{
    public class InputListener : IDisposable
    {
        public event EventHandler<EventArgs> OnClick;
        public event EventHandler<EventArgs> OnRelease;
        public KeyboardState keyboard;
        public MouseState mouse;
        bool isLeftMouseButtonPressed = false;
        bool isRightMouseButtonPressed = false;
        bool isLeftMouseButtonReleased = true;
        bool isRightMouseButtonReleased = true;
        public InputListener()
        {

        }
        public void UpdateInput()
        {
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();
            //Make sure OnClick event fires once when the mouse button is clicked (not when button is held down).
            if (mouse.LeftButton == ButtonState.Pressed && !isLeftMouseButtonPressed)
            {
                isLeftMouseButtonReleased = false;
                isLeftMouseButtonPressed = true;                
                OnClick?.Invoke(this,new EventArgs());                
            }
            else if (mouse.LeftButton == ButtonState.Released && !isLeftMouseButtonReleased)
            {
                isLeftMouseButtonReleased = true;
                isLeftMouseButtonPressed = false;
                OnRelease?.Invoke(this, new EventArgs());
            }

            if (mouse.RightButton == ButtonState.Pressed && !isRightMouseButtonPressed)
            {
                isRightMouseButtonPressed = true;
                isRightMouseButtonReleased = false;
                OnClick?.Invoke(this, new EventArgs());
            }
            else if (mouse.RightButton == ButtonState.Released && !isRightMouseButtonReleased)
            {
                isRightMouseButtonReleased = true;
                isRightMouseButtonPressed = false;
                OnRelease?.Invoke(this, new EventArgs());
            }
        }
        public void Dispose()
        {
            OnClick -= OnClick;
            OnRelease -= OnRelease;
        }                
    }
}
