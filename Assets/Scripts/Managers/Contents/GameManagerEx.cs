using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx
{
    // Players
    List<GameObject> Players = new List<GameObject>();
    public List<GameObject> GetPlayers() { return Players; }
    int _index = 0;
    public GameObject GetNextPlayer()
    {
        if (Players.Count == 0)
            return null;

        _index++;
        if (_index > Players.Count - 1)
            _index = 0;
        return Players[_index];
    }

    // Enemys
    List<GameObject> Enemys = new List<GameObject>();
    public List<GameObject> GetEnemys() { return Enemys; }

    // Start Game
    int _turnCnt;
    bool _isProcessing = false;

    public GameObject Spawn(Define.WorldObject type, string path, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);
        
        switch (type)
        {
            case Define.WorldObject.Player:
                Players.Add(go);
                break;
            case Define.WorldObject.Enemy:
                Enemys.Add(go);
                break;
        }

        return go;
    }
}
