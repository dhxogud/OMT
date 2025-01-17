using System;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager
{
    public Action KeyAction;
    public Action<Define.MouseEvent> MouseAction = null;
    private bool _pressed;
    public Vector3 _startDragPoint;

    public void OnUpdate()
    {
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        if (MouseAction != null)
        {
            if (Input.GetMouseButtonDown(0))
                _startDragPoint = Input.mousePosition;

            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                MouseAction.Invoke(Define.MouseEvent.Drag);
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
        }
    }
}
