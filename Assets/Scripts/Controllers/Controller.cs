using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    CameraController _camera = new CameraController();
    UnitController _unit = new UnitController();
    List<Controllable> MyUnits = new List<Controllable>();
    int index;
    
    void Start() 
    {
        Init();
    }
    void Update() 
    {
        _unit.OnUpdate();
    }
    void LateUpdate() 
    {
        _camera.OnLateUpdate();
    }
    void Init() 
    {
        index = 0;
        // Managers.Input.KeyAction -= KeyAction;
        // Managers.Input.KeyAction += KeyAction;
        // Managers.Input.MouseButtonAction -= OnMouseButtonAction;
        // Managers.Input.MouseButtonAction += OnMouseButtonAction;
        // Managers.Input.MouseWheelAction -= OnMouseWheelAction;
        // Managers.Input.MouseWheelAction += OnMouseWheelAction;
        _camera.Init();
        _unit.Init();
    }


}
