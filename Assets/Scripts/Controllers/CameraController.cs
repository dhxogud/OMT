using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraController
{
    Define.CameraMode _mode;
    Vector3 _offset = new Vector3(0.0f, 15.0f, -20.0f);
    Vector3 _look = Vector3.zero;
    Transform _transform;
    GameObject target;

    public void OnLateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            if (target != null)
            {
                Vector3 prev = _transform.position;
                Vector3 dest = target.transform.position - _look;
                _transform.position = Vector3.Slerp(_transform.position, dest, 0.1f);
                _look += _transform.position - prev;
                if (Vector3.Distance(_transform.position, dest) < 0.001f)
                {
                    target = null;
                }
            }
        }
    }

    // Focusing
    void OnMouseButtonAction(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.Click)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, LayerMask.GetMask("Unit")))
            {
                target = hit.collider.gameObject;
            }
        }
    }
    
    // Move & Rotate
    void KeyAction()
    {
        // WASD : Parallel Motion On XZ-plane
        Vector3 moveDir = _transform.forward * Input.GetKey(KeyCode.W).ConvertToInt()
            + -_transform.forward * Input.GetKey(KeyCode.S).ConvertToInt()
            + _transform.right * Input.GetKey(KeyCode.D).ConvertToInt()
            + -_transform.right * Input.GetKey(KeyCode.A).ConvertToInt();
            
        moveDir.y = 0.0f;
        moveDir = moveDir.normalized * 30.0f * Time.deltaTime;
        _transform.position += moveDir;
        _look += moveDir;

        // QE : Orbital Motion From Y-axis
        Vector3 delta = _transform.position - _look;
        Vector3 axis = Vector3.up * Input.GetKey(KeyCode.Q).ConvertToInt() + Vector3.down * Input.GetKey(KeyCode.E).ConvertToInt();
        delta = Quaternion.AngleAxis(0.5f, axis) * delta;
        _transform.position = _look + delta;
        _transform.LookAt(_look);
    }

    // Zoom
    void OnMouseWheelAction(int scrollDir)
    {
        Vector3 origin = _transform.position;
        _transform.position += new Vector3(0.0f, scrollDir, 0.0f) * 10.0f * Time.deltaTime;
        _look = _transform.position + (_look - origin);
    }
    public void Init()
    {
        _transform = Camera.main.transform;
        Managers.Input.KeyAction -= KeyAction;
        Managers.Input.KeyAction += KeyAction;
        Managers.Input.MouseButtonAction -= OnMouseButtonAction;
        Managers.Input.MouseButtonAction += OnMouseButtonAction;
        Managers.Input.MouseWheelAction -= OnMouseWheelAction;
        Managers.Input.MouseWheelAction += OnMouseWheelAction;
        _look = _transform.position - _offset;
        _transform.LookAt(_look);
    }
}
