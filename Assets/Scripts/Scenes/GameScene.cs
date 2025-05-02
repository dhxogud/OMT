using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameScene : BaseScene
{
    PlayerController _PlayerController;
    GameObject _players;
    AIController _AIController;
    GameObject _enemys;
    string[] allUnitNames = { "Unit/HellHound", "Unit/John", "Unit/Moo" };



    protected override void Init()
    {
        base.Init();
        
        SceneType = Define.Scene.Game;

        Managers.Game.GameStateAction -= OnGameStateAction;
        Managers.Game.GameStateAction += OnGameStateAction;

        gameObject.GetOrAddComponent<CursorController>();
        Camera.main.gameObject.GetOrAddComponent<CameraController>();

        _players = new GameObject { name = "@Players" };
        _enemys = new GameObject { name = "@Enemys" };


        Managers.Game.OnChangeGameState(Define.GameState.Ready);

    }

    public override void Clear()
    {
        Debug.Log("Clear GameScene!");
    }

    public void OnGameStateAction(Define.GameState gameState)
    {
        switch (gameState)
        {
            case Define.GameState.Ready:
                OnGameReady();
                break;
            case Define.GameState.Start:
                OnGameStart();
                break;
            case Define.GameState.PlayerTurn:
                OnGamePlayerTurn();
                break;
            case Define.GameState.EnemyTurn:
                OnGameEnemyTurn();
                break;
            case Define.GameState.Won:
                break;
            case Define.GameState.Lose:
                break;
        }
    }
    void OnGameReady()
    {
        TestSpawnEnemeys();
        Managers.Input.MouseButtonAction -= OnMouseButtonAction;
        Managers.Input.MouseButtonAction += OnMouseButtonAction;
    }

    void TestSpawnEnemeys()
    {
        foreach (string name in allUnitNames)
        {
            GameObject go = Managers.Game.Spawn(Define.WorldObject.Enemy, name, _enemys.transform);
            float randomFloat = UnityEngine.Random.Range(-30.0f, 30.0f);
            go.transform.position = new Vector3(randomFloat, 0.0f , randomFloat);
        }
    }
    public void OnMouseButtonAction(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.LeftButtonClick)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject go = Managers.Game.Spawn(Define.WorldObject.Player, "Unit/Moo", _players.transform );
                go.transform.position = hit.point;
            }
        }
        if (evt == Define.MouseEvent.RightButtonClick)
        {
            Managers.Game.OnChangeGameState(Define.GameState.Start);
        }
    }

    void OnGameStart()
    {
        Managers.Input.MouseButtonAction -= OnMouseButtonAction;

        _PlayerController = gameObject.GetOrAddComponent<PlayerController>();

        _AIController = gameObject.GetOrAddComponent<AIController>();

        Managers.Game.OnChangeGameState(Define.GameState.PlayerTurn);
    }
    void OnGamePlayerTurn()
    {
        _PlayerController.enabled = true;
        _AIController.enabled = false;
    }
    void OnGameEnemyTurn()
    {
        _PlayerController.enabled = false;
        _AIController.enabled = true;
        // enemyController 에게 이 소식을 전달해야됨
    }
}
