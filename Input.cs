using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Duck_Game
{
    public delegate void InputEvent(Input Input);
    public class Input
    {
        public event InputEvent OnClick;
        public event InputEvent OnRelease;
        public KeyboardState keyboard;
        public MouseState mouse;
        bool isLeftMouseButtonPressed = false;
        bool isRightMouseButtonPressed = false;
        bool isLeftMouseButtonReleased = true;
        bool isRightMouseButtonReleased = true;
        public void UpdateInput()
        {
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();
            //Make sure onClick event fires once when the mouse button is clicked (not when button is held down).
            if (mouse.LeftButton == ButtonState.Pressed && !isLeftMouseButtonPressed)
            {
                isLeftMouseButtonReleased = false;
                isLeftMouseButtonPressed = true;                
                OnClick(this);
            }
            else if (mouse.LeftButton == ButtonState.Released && !isLeftMouseButtonReleased)
            {
                isLeftMouseButtonReleased = true;
                isLeftMouseButtonPressed = false;
            }

            if (mouse.RightButton == ButtonState.Pressed && !isRightMouseButtonPressed)
            {
                isRightMouseButtonPressed = true;
                isRightMouseButtonReleased = false;
                OnClick(this);
            }
            else if (mouse.RightButton == ButtonState.Released && !isRightMouseButtonReleased)
            {
                isRightMouseButtonReleased = true;
                isRightMouseButtonPressed = false;
                OnRelease(this);
            }
        }
        
    }
}
