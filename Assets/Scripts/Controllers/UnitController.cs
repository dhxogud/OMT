using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Define.UnitSide unitSide;
    public Define.ControlEntity entity = Define.ControlEntity.Player;
    [SerializeField]
    Define.UnitName Name;
    Unit unit;
    UnitState unitState;
    
    enum UnitState 
    {
        Idle,
        Action,
        Die
    }
    GameObject _target;
    

    void Start() 
    {
        Init();
        Debug.Log($"{unit.name}, {unit.model}");
    }
    // functions

    void KeyAction()
    {
        if (entity == Define.ControlEntity.Player)
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
    }
    void MouseButtonAction(Define.MouseEvent evt)
    {
        if (entity == Define.ControlEntity.Player)
        {
            
        }
    }
    void Init()
    {
        unitState = UnitState.Idle;
        unit = Managers.Data.UnitDict[(int) Name];

        Managers.Input.KeyAction -= KeyAction;
        Managers.Input.KeyAction += KeyAction;
        Managers.Input.MouseButtonAction -= MouseButtonAction;
        Managers.Input.MouseButtonAction += MouseButtonAction;
        
    }
}
