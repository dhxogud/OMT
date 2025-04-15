using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameScene : BaseScene
{
    CameraController cameraController;
    UnitController unitController; 
    SpawnController spawnController;

    public Action<GameObject> SwitchTargetAction = null;

    protected override void Init()
    {
        base.Init();
        
        SceneType = Define.Scene.Game;

        Managers.Game.GameStateAction -= OnGameStateAction;
        Managers.Game.GameStateAction += OnGameStateAction;


        gameObject.GetOrAddComponent<CursorController>();
        cameraController = Camera.main.gameObject.GetOrAddComponent<CameraController>();
        unitController = gameObject.GetOrAddComponent<UnitController>();
        spawnController = gameObject.GetOrAddComponent<SpawnController>();

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
                spawnController.Init();
                cameraController.Init();
                break;
            case Define.GameState.PlayerTurn:
                spawnController.Clear();
                unitController.Init();
                cameraController.Init();
                break;
            case Define.GameState.EnemyTurn:
                unitController.Clear();
                cameraController.Clear();
                break;
            case Define.GameState.Won:
                unitController.Clear();
                cameraController.Clear();
                spawnController.Clear();
                break;
            case Define.GameState.Lose:
                unitController.Clear();
                cameraController.Clear();
                spawnController.Clear();
                break;
        }
    }
}
