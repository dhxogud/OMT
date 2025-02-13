using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
{
    // Units
    List<UnitController> units = new List<UnitController>();
    public UnitController CurrentUnit { get { return units[_index]; }}
    int _index;

    // Map
    Vector3 StartPos = Vector3.zero;
    int turnCnt;

    void KeyAction()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _index++;
            if (_index > units.Count)
                _index = 0;
        }
    }

    protected override void Init()
    {
        base.Init();
        
        SceneType = Define.Scene.Game;


        foreach (UnitController unit in GameObject.FindObjectsOfType<UnitController>())
            units.Add(unit);
        _index = 0;

        Managers.Input.KeyAction -= KeyAction;
        Managers.Input.KeyAction += KeyAction;
    }

    public override void Clear()
    {
        Debug.Log("Clear GameScene!");
    }
}
