using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
{
    // Map
    CameraController cameraController = new CameraController();
    UnitController unitController = new UnitController();
    // int turnCnt;

    void LateUpdate() 
    {
        cameraController.OnLateUpdate();
    }


    void KeyAction()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cameraController.Move(unitController.GetNextUnit().gameObject);
        }

        cameraController.Move();
        cameraController.Rotate();

    }

    void MouseButtonAction(Define.MouseEvent evt)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Unit")))
        {
            
        }
    }

    void MouseWheelAction(int delta)
    {
        cameraController.Zoom(delta);
    }

    protected override void Init()
    {
        base.Init();
        
        SceneType = Define.Scene.Game;
        // turnCnt = 0;

        cameraController.Init();
        unitController.Init();

        Managers.Input.KeyAction -= KeyAction;
        Managers.Input.KeyAction += KeyAction;
        Managers.Input.MouseButtonAction -= MouseButtonAction;
        Managers.Input.MouseButtonAction += MouseButtonAction;
        Managers.Input.MouseWheelAction -= MouseWheelAction;
        Managers.Input.MouseWheelAction += MouseWheelAction;
    }

    public override void Clear()
    {
        Debug.Log("Clear GameScene!");
    }
}
