using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitController : MonoBehaviour // 나중에 enemyUnit들을 컨트롤하는 EnemyController 를 따로 만들거임 지금은 일단 PlayerController
{
    PlayerUnit _unit;
    GameObject _lockTarget;

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

    void Update() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _mask))
        {
            _lockTarget = hit.collider.gameObject;
            Debug.Log($"{_lockTarget.name} 을 보고 있는중");
        }
    }

    int _playerIndex = 0;
    public void OnKeyAction() 
    {
        foreach (KeyCode key in usingKeyCodes)
        {
            if (Input.GetKeyDown(key))
            {
                _unit.SetCurrentSkill((int) key - (int)(KeyCode.Alpha0));
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            List<GameObject> players = Managers.Game.GetPlayers();
            _playerIndex++;
            if (_playerIndex < players.Count)
            {
                _playerIndex = 0;
            }
            GameObject go = players[_playerIndex];
            Camera.main.GetComponent<CameraController>().SetTarget(go);
            _unit = go.GetComponent<PlayerUnit>();
        }
    }

    public void OnMouseButtonAction(Define.MouseEvent evt) 
    {
        if (evt == Define.MouseEvent.LeftButtonClick)
        {
            _unit.OnSkill(_lockTarget);
        }
    }

    public void Init()
    {
        _unit = Managers.Game.GetPlayers()[0].GetComponent<PlayerUnit>(); // 이거 바꾸자 GameManagerEx로부터 받아오는식으로

        Managers.Input.KeyAction -= OnKeyAction;
        Managers.Input.KeyAction += OnKeyAction;
        Managers.Input.MouseButtonAction -= OnMouseButtonAction;
        Managers.Input.MouseButtonAction += OnMouseButtonAction;
    }
    public void Clear()
    {
        Managers.Input.KeyAction -= OnKeyAction;
        Managers.Input.MouseButtonAction -= OnMouseButtonAction;
    }
}
