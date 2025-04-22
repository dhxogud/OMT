using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagerEx
{
    public Action<Define.GameState> GameStateAction = null;

    Define.GameState State = Define.GameState.None;

    public void OnChangeGameState(Define.GameState newState)
    {
        if (State != newState)
        {
            State = newState;
            GameStateAction.Invoke(State);
        }
    }
    
    #region Players
    List<GameObject> _players = new List<GameObject>();
    public List<GameObject> GetPlayers() { return _players; }
    #endregion


    #region AIEnemys
    Dictionary<int, GameObject> _enemys = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> GetEnemys() { return _enemys; }

    #endregion
    
    public GameObject Spawn(Define.WorldObject type, string path, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);

        switch (type)
        {
            case Define.WorldObject.Player:
                _players.Add(go);
                break;
            case Define.WorldObject.Enemy:
                 _enemys.Add(_enemys.Count, go);
                break;
        }
        return go;
    }

    public Define.WorldObject GetWorldObjectType(GameObject go)
    {
        BaseUnit uc = go.GetComponent<BaseUnit>();
        if (uc == null)
        {
            return Define.WorldObject.None;
        }
        return uc.WorldObjectType;
    }
    public void Despawn(GameObject go)
    {
        Define.WorldObject type = GetWorldObjectType(go);

        switch (type)
        {
            case Define.WorldObject.Player:
                _players.Remove(go);
                if (_players.Count <= 0)
                {
                    OnChangeGameState(Define.GameState.Lose);
                }
                break;
            case Define.WorldObject.Enemy:
                _enemys.Remove(_enemys.FindFirstKeyByValue<int, GameObject>(go));
                if (_enemys.Count <= 0)
                {
                    OnChangeGameState(Define.GameState.Won); // 승리 조건
                }
                break;
        }
        Managers.Resource.Destroy(go);
    }

    public void Init()
    {
        State = Define.GameState.None;
    }
    public void OnUpdate()
    {
        Debug.Log(Enum.GetName(typeof(Define.GameState), State));
    }
}
