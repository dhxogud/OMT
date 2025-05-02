using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : BaseController
{
    BaseUnit _unit;

    protected override void Init()
    {
        base.Init();

        UnitList = Managers.Game.GetEnemys();
        _unit = UnitList[0].GetComponent<BaseUnit>();
        _camera.SetTarget(_unit.gameObject);
    }
    protected override void Clear()
    {
        
    }
}
