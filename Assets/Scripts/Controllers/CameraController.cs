using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CameraController : MonoBehaviour
{
    Define.CameraMode _mode;
    Vector3 _offset = new Vector3(0.0f, 15.0f, -20.0f);
    Vector3 _look = Vector3.zero;
    GameObject _target;

    void Start() 
    {
        Managers.Input.MouseAction -= ClickTarget;
        Managers.Input.MouseAction += ClickTarget;
        Managers.Input.KeyAction -= Move;
        Managers.Input.KeyAction += Move;
        Managers.Input.MouseWheelAction -= Zoom;
        Managers.Input.MouseWheelAction += Zoom;
    }
    void LateUpdate() 
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            if (_target != null)
            {
                MoveToTarget();
            }
        }
    }
    void ClickTarget(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.Click)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, LayerMask.GetMask("Unit")))
            {
                _target = hit.collider.gameObject;
            }
        }
    }
    void Move()
    {
        // WASD : Parallel Motion On XZ-plane
        Vector3 moveDir = transform.forward * Input.GetKey(KeyCode.W).ConvertToInt()
            + -transform.forward * Input.GetKey(KeyCode.S).ConvertToInt()
            + transform.right * Input.GetKey(KeyCode.D).ConvertToInt()
            + -transform.right * Input.GetKey(KeyCode.A).ConvertToInt();
            
        moveDir.y = 0.0f;
        moveDir = moveDir.normalized * 30.0f * Time.deltaTime;
        transform.position += moveDir;
        _look += moveDir;

        // QE : Orbital Motion From Y-axis
        Vector3 delta = transform.position - _look;
        Vector3 axis = Vector3.up * Input.GetKey(KeyCode.Q).ConvertToInt() + Vector3.down * Input.GetKey(KeyCode.E).ConvertToInt();
        delta = Quaternion.AngleAxis(0.5f, axis) * delta;
        transform.position = _look + delta;
        transform.LookAt(_look);
    }

    // mouseScrolldelta.y
    void Zoom(int scrollDir)
    {
        Vector3 origin = transform.position;
        transform.position += new Vector3(0.0f, scrollDir, 0.0f) * 10.0f * Time.deltaTime;
        _look = transform.position + (_look - origin);
    }
    void MoveToTarget()
    {
        Vector3 prev = transform.position;
        Vector3 dest = _target.transform.position - _look;
        transform.position = Vector3.Slerp(transform.position, dest, 0.1f);
        _look += transform.position - prev;

        if (Vector3.Distance(transform.position, dest) < 0.001f)
        {
            _target = null;
        }
    }
    public void Init(Define.Scene sceneType)
    {
        if (sceneType == Define.Scene.Game)
            _mode = Define.CameraMode.QuarterView;

        _look = transform.position - _offset;
        _target = null;
    }
}
