using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
{
    UnitController unitController = new UnitController();

    // Map
    Vector3 StartPos = Vector3.zero;
    // Turn
    // int turnCnt;

    void Update() 
    {
        
    }
    void LateUpdate() 
    {
        MainCamera.OnLateUpdate();
    }


    void KeyAction()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MainCamera.Move(unitController.GetNextUnit().gameObject);
        }

        MainCamera.Move(); // WASD
        MainCamera.Rotate(); // QE

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
        }
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
        MainCamera.Zoom(delta);
    }

    protected override void Init()
    {
        base.Init();
        
        SceneType = Define.Scene.Game;
        // turnCnt = 0;

        unitController.Init();
        MainCamera.SetQuaterView(Vector3.zero);

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
