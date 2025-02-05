using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
{
    UnitController unitController = new UnitController();
    // Map
    Vector3 StartPos = Vector3.zero;
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

        cameraController.Move(); // WASD
        cameraController.Rotate(); // QE

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

        unitController.Init();
        cameraController.SetQuaterView(Vector3.zero);

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
