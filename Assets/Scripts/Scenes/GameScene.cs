using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        
        SceneType = Define.Scene.Game;
        gameObject.GetOrAddComponent<CursorController>();
        Camera.main.gameObject.GetOrAddComponent<CameraController>();
        // 
        GameObject Spawn = new GameObject { name = "@Spawn" };
        GameObject Spawn1 = new GameObject { name = "@Spawn1" };
        GameObject Spawn2 = new GameObject { name = "@Spawn2" };
        Spawn.transform.position = new Vector3(10.0f, 10.0f, 10.0f);
        Spawn1.transform.position = Vector3.zero;
        Spawn2.transform.position = new Vector3(-10.0f, 0.0f, -10.0f);
        // 
        Managers.Game.Spawn(Define.WorldObject.Player, "Unit/Cube", Spawn.transform);
        Managers.Game.Spawn(Define.WorldObject.Player, "Unit/Cube", Spawn1.transform);
        Managers.Game.Spawn(Define.WorldObject.Player, "Unit/Cube", Spawn2.transform);

    }

    public override void Clear()
    {
        Debug.Log("Clear GameScene!");
    }
}
