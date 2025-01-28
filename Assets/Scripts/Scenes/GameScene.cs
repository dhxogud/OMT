using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
{
    Controllable[] units;
    Ray ray;
    protected override void Init()
    {
        base.Init();
        
        SceneType = Define.Scene.Game;
        Managers.Input.MouseAction -= SelectTarget;
        Managers.Input.MouseAction += SelectTarget;
    }

    void Update() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    void SelectTarget(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.tag == "Unit")
            {
                
            }
        }

    }
    public override void Clear()
    {
        Debug.Log("Clear GameScene!");
    }
}
