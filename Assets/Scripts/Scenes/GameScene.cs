using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
{
    UnitController controller;
    protected override void Init()
    {
        base.Init();
        
        SceneType = Define.Scene.Game;
        Camera.main.AddComponent<CameraController>().Init(SceneType);
    }
    
    public override void Clear()
    {
        Debug.Log("Clear GameScene!");
    }
}
