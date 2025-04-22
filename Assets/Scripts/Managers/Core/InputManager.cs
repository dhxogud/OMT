using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseButtonAction = null;
    public Action<int> MouseWheelAction = null;
    private bool _leftPressed;
    private bool _rightPressed;

    public void OnUpdate()
    {
        if (Input.anyKey && KeyAction != null)
        {
            KeyAction.Invoke();
        }
        
        if (MouseButtonAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseButtonAction.Invoke(Define.MouseEvent.LeftButtonPress);
                _leftPressed = true;
            }
            else 
            {
                if (_leftPressed)
                {
                    MouseButtonAction.Invoke(Define.MouseEvent.LeftButtonClick);
                    _leftPressed = false;
                }
            }

            if (Input.GetMouseButton(1))
            {
                MouseButtonAction.Invoke(Define.MouseEvent.RightButtonPress);
                _rightPressed = true;
            }
            else 
            {
                if (_rightPressed)
                {
                    MouseButtonAction.Invoke(Define.MouseEvent.RightButtonClick);
                    _rightPressed = false;
                }
            }
        }

        if (MouseWheelAction != null)
        {
            if (Input.mouseScrollDelta.y > 0)
                MouseWheelAction.Invoke(1);
            else if (Input.mouseScrollDelta.y < 0)
                MouseWheelAction.Invoke(-1);
        }

    }
    public void Clear()
    {
        KeyAction = null;
        MouseButtonAction = null;
        MouseWheelAction = null;
    }
}
