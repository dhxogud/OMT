using System;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager
{
    public Action KeyAction;
    public Action<Define.MouseButtonEvent> MouseButtonAction = null;
    public Action<Define.MouseWheelEvent> MouseWheelAction = null;
    private bool _pressed;

    public void OnUpdate()
    {
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

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
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                MouseWheelAction.Invoke(Define.MouseWheelEvent.Up);
            }
            else
            {
                MouseWheelAction.Invoke(Define.MouseWheelEvent.Down);
            }
        }
    }
}
