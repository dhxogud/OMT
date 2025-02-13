using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Dictionary<string, Unit> unitDict;
    protected Define.UnitSide unitSide;
    Define.ControlEntity entity;
    UnitState unitState;
    protected enum UnitState {
        Idle,
        Action,
        Die
    }
    GameObject _target;
    

    void Start() 
    {
        Init();
    }
    // functions

    void KeyAction()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Move();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Attack();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
        }
    }
    void MouseButtonAction(Define.MouseEvent evt)
    {

    }
    void Init()
    {
        unitState = UnitState.Idle;
        unitDict = Managers.Data.UnitDict;

        Managers.Input.KeyAction -= KeyAction;
        Managers.Input.KeyAction += KeyAction;
        Managers.Input.MouseButtonAction -= MouseButtonAction;
        Managers.Input.MouseButtonAction += MouseButtonAction;
        
    }
}
