using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseButtonEvent> MouseButtonAction = null;
    public Action<Define.MouseWheelEvent> MouseWheelAction = null;
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
                MouseButtonAction.Invoke(Define.MouseButtonEvent.Press);
                _pressed = true;
            }
            else 
            {
                if (_pressed)
                {
                    MouseButtonAction.Invoke(Define.MouseButtonEvent.Click);
                    _pressed = false;
                }
            }
        }
        if (MouseWheelAction != null)
        {
            if (Input.mouseScrollDelta.y > 0)
                MouseWheelAction.Invoke(Define.MouseWheelEvent.Up);
            else if (Input.mouseScrollDelta.y < 0)
                MouseWheelAction.Invoke(Define.MouseWheelEvent.Down);
        }
    }
    public void Init()
    {
        _pressed = false;
    }
}
