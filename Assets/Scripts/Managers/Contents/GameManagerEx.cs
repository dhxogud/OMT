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
    public ref List<GameObject> GetPlayers() { return ref _players; }
    #endregion


    #region AIEnemys
    List<GameObject> _enemys = new List<GameObject>();
    public ref List<GameObject> GetEnemys() { return ref _enemys; }

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
                 _enemys.Add(go);
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
                break;
            case Define.WorldObject.Enemy:
                _enemys.Remove(go);
                break;
        }
        Managers.Resource.Destroy(go);
    }
}
