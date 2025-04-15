using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    string path = "";
    GameObject _spawnPos;

    void Start() 
    {
        _spawnPos = new GameObject { name = "@PlayerUnit" };
    }
    
    int _mask = 1 << (int) Define.Layer.Field;
    public void OnKeyAction() 
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            path = "Unit/HellHound";
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            path = "Unit/John";
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            path = "Unit/Moo";
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Managers.Game.GetPlayers().Count < 1)
            {
                Debug.Log("최소 유닛 1기를 배치해야 합니다.");
                return;
            }
            Managers.Game.OnChangeGameState(Define.GameState.PlayerTurn);
        }
    }

    public void OnMouseButtonAction(Define.MouseEvent evt) 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _mask) == false) return; // 나도 알고 있다 이거 개구린 코드라는거


        switch (evt)
        {
            case Define.MouseEvent.LeftButtonClick:
                if (path == "")
                {
                    Debug.Log("스폰할 유닛을 1,2,3번 중에서 선택한다음 눌러주세요");
                    return;
                }
                GameObject go = Managers.Game.Spawn(Define.WorldObject.Player, path, _spawnPos.transform);
                go.transform.position = hit.point;
                break;
            case Define.MouseEvent.LeftButtonPress:
                break;
            case Define.MouseEvent.LeftButtonCDrag:
                break;
        }
    }

    public void Init()
    {
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
