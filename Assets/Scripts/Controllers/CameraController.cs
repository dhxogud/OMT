using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    Vector3 _offset = new Vector3(0.0f, 15.0f, -20.0f);
    Vector3 _look = Vector3.zero;
    GameObject _target;

    // WASD : Parallel Motion On XZ-plane
    void Move() 
    {
        Vector3 moveDir = transform.forward * Input.GetKey(KeyCode.W).ConvertToInt()
            + -transform.forward * Input.GetKey(KeyCode.S).ConvertToInt()
            + transform.right * Input.GetKey(KeyCode.D).ConvertToInt()
            + -transform.right * Input.GetKey(KeyCode.A).ConvertToInt();
            
        moveDir.y = 0.0f;
        moveDir = moveDir.normalized * 30.0f * Time.deltaTime;
        transform.position += moveDir;
        _look += moveDir;
    }

    // QE : Orbital Motion From Y-axis
    void Rotate()
    {
        Vector3 delta = transform.position - _look;
        Vector3 axis = Vector3.up * Input.GetKey(KeyCode.Q).ConvertToInt() + Vector3.down * Input.GetKey(KeyCode.E).ConvertToInt();
        delta = Quaternion.AngleAxis(0.5f, axis) * delta;
        transform.position = _look + delta;
        transform.LookAt(_look);
    }

    void Zoom(int scrollDir)
    {
        Vector3 origin = transform.position;
        transform.position += new Vector3(0.0f, scrollDir, 0.0f) * 10.0f * Time.deltaTime;
        _look = transform.position + (_look - origin);
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

    void Start() 
    {
        Init();
    }

    void Init()
    {
        Managers.Input.KeyAction -= Move;
        Managers.Input.KeyAction += Move;
        Managers.Input.KeyAction -= Rotate;
        Managers.Input.KeyAction += Rotate;
        Managers.Input.MouseWheelAction -= Zoom;
        Managers.Input.MouseWheelAction += Zoom;

        _look = transform.position - _offset;
        _target = null;
    }
}
