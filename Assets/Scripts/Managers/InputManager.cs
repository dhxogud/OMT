using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseButtonAction = null;
    public Action<int> MouseWheelAction = null;
    private bool _pressed;

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
                MouseButtonAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else 
            {
                if (_pressed)
                {
                    MouseButtonAction.Invoke(Define.MouseEvent.Click);
                    _pressed = false;
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
