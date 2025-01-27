using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField]
    Ray MouseRay;
    GameObject Target;


    void Update() 
    {
        MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    
    protected override void Init()
    {
        base.Init();
        
        SceneType = Define.Scene.Game;

        Managers.Input.MouseButtonAction -= MouseClickAction;
        Managers.Input.MouseButtonAction += MouseClickAction;
    }

    public override void Clear()
    {
        Debug.Log("Clear GameScene!");
    }

    void MouseClickAction(Define.MouseButtonEvent evt)
    {
        if (evt != Define.MouseButtonEvent.Click) return;

        if (Physics.Raycast(MouseRay, out RaycastHit hit))
        {
            if (hit.collider.gameObject.tag == "Unit")
            {
                GameObject.FindObjectOfType<CameraController>().SetTarget(hit.collider.gameObject);
                Controllable controller = hit.collider.gameObject.GetComponent<Controllable>();
                
            }
        }
    }
}
