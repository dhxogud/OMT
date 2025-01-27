using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        
        SceneType = Define.Scene.Game;
    }

    public override void Clear()
    {
        Debug.Log("Clear GameScene!");
    }
}
