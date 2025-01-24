using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : BaseController
{
    Unit unit;

    public override void Init()
    {
        KeyCodes = new KeyCode[] { KeyCode.T, KeyCode.Y, KeyCode.U};

        base.Init();
    }

    public override void OnKeyAction()
    {
        base.OnKeyAction();

    }
    public override void MouseClickAction(Define.MouseButtonEvent evt)
    {
        throw new System.NotImplementedException();
    }

    public override void MouseWheelAction(Define.MouseWheelEvent evt)
    {
        throw new System.NotImplementedException();
    }

}
