using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController
{
    public void OnUpdate()
    {

    }

    void MouseAction(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.Click)
        {

        }
    }
    void KeyAction()
    {

    }
    public void Init()
    {
        Managers.Input.MouseButtonAction -= MouseAction;
        Managers.Input.MouseButtonAction += MouseAction;
        Managers.Input.KeyAction -= KeyAction;
        Managers.Input.KeyAction += KeyAction;
    }
}
