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
        // @Controller 오브젝트 인스턴스 및 초기화 작업 들어갈 예정?
    }

    public override void Clear()
    {
        Debug.Log("Clear GameScene!");
    }
}
