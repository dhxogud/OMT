using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : BaseController
{
    PlayerUnit _unit;
    int _mask = (1 << (int) Define.Layer.Field) | (1 << (int) Define.Layer.Unit);
    KeyCode[] usingKeyCodes = 
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };

    int _playerIndex = 0;
    public void OnKeyAction() 
    {
        if (_unit != null && _unit.UnitStateType == Define.UnitState.Idle)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                GetNextUnit();
            }
            foreach (KeyCode key in usingKeyCodes)
            {
                if (Input.GetKeyDown(key))
                {
                    _unit.AttachSkillToUnit((int) key);
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                _unit.OnSkill();
                _camera.SetTarget(_unit.gameObject);
            }
        }
    }
    
    void GetNextUnit()
    {
        _playerIndex = (_playerIndex < UnitList.Count - 1) ? (_playerIndex + 1) : 0;
        _camera.SetTarget(UnitList[_playerIndex]);
        _unit = UnitList[_playerIndex].GetComponent<PlayerUnit>();
    }

    public void OnMouseButtonAction(Define.MouseEvent evt) 
    {
        if (_unit != null && _unit.UnitStateType == Define.UnitState.Idle)
        {
            if (evt == Define.MouseEvent.LeftButtonClick)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, _mask))
                {
                    _unit.SetTarget(hit);
                }
            }
            else if (evt == Define.MouseEvent.RightButtonClick)
            {
                _unit.UndoTarget();
            }
        }
    }

    protected override void Init()
    {
        base.Init();

        UnitList = Managers.Game.GetPlayers();
        _unit = UnitList[0].GetComponent<PlayerUnit>();
        _camera.SetTarget(_unit.gameObject);

        Managers.Input.KeyAction -= OnKeyAction;
        Managers.Input.KeyAction += OnKeyAction;
        Managers.Input.MouseButtonAction -= OnMouseButtonAction;
        Managers.Input.MouseButtonAction += OnMouseButtonAction;
    }

    protected override void Clear()
    {
        Managers.Input.KeyAction -= OnKeyAction;
        Managers.Input.MouseButtonAction -= OnMouseButtonAction;
    }
}
