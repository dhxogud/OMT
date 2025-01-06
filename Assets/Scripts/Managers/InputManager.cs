using System;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager
{
    public Action KeyAction;
    public Action<Define.MouseEvent> MouseAction = null;
    private bool _pressed;

    public void OnUpdate()
    {
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else 
            {
                if (_pressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                    _pressed = false;
                }
            }
            if (Input.mouseScrollDelta.magnitude > 0)
            {
                MouseAction.Invoke(Define.MouseEvent.Wheel);
            }
        }
    }
}
