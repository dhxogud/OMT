using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : BaseController
{
    KeyCode[] _keys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 };
    Controllable _control;
    public override void Init()
    {
        base.Init();

        BindKeysToDict(_keys);

        if (Target != null)
            _control = Target.GetComponent<Controllable>();
    }
}
