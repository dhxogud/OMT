using System;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class CameraController
{
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    Transform transform;
    Vector3 _look = Vector3.zero; // 나중에 이 _look 위치가 내 유닛들의 Start position 위치를 넣으면 됨
    Vector3 _offset = new Vector3(0.0f, 15.0f, -30.0f);
    bool isTracking;
    Vector3 _destPos;

    public void OnLateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            if (isTracking)
            {
                Vector3 origin = transform.position;
                transform.position = Vector3.Slerp(transform.position, _destPos, 0.1f);
                _look += transform.position - origin;
                
                if (Vector3.Distance(transform.position, _destPos) < 0.01f)
                    isTracking = false;
            }
        }
    }

    public void Move()
    {
        if (isTracking) 
            return;

        // WASD : Parallel Motion On XZ-plane
        Vector3 moveDir = transform.forward * Input.GetKey(KeyCode.W).ConvertToInt()
            + -transform.forward * Input.GetKey(KeyCode.S).ConvertToInt()
            + transform.right * Input.GetKey(KeyCode.D).ConvertToInt()
            + -transform.right * Input.GetKey(KeyCode.A).ConvertToInt();
            
        moveDir.y = 0.0f;
        moveDir = moveDir.normalized * 30.0f * Time.deltaTime;
        transform.position += moveDir;
        _look += moveDir;
    }

    public void Move(GameObject target)
    {
        Vector3 targetPos = target.gameObject.transform.position;
        _destPos = targetPos + transform.position - _look;
        isTracking = true;
    }

    public void Rotate()
    {
        if (isTracking) 
            return;

        // QE : Orbital Motion From Y-axis
        Vector3 delta = transform.position - _look;
        Vector3 axis = Vector3.up * Input.GetKey(KeyCode.Q).ConvertToInt() + Vector3.down * Input.GetKey(KeyCode.E).ConvertToInt();
        delta = Quaternion.AngleAxis(0.5f, axis) * delta;
        transform.position = _look + delta;
        transform.LookAt(_look);

        // // QE : Orbital Motion From Y-axis
        // Vector3 delta = transform.position - transform.forward;
        // Vector3 axis = Vector3.up * Input.GetKey(KeyCode.Q).ConvertToInt() + Vector3.down * Input.GetKey(KeyCode.E).ConvertToInt();
        // delta = Quaternion.AngleAxis(0.5f, axis) * delta;
        // transform.position = transform.forward + delta;
        // transform.LookAt(transform.forward);
    }
    public void Zoom(int scrollDir)
    {
        if (isTracking) 
            return;

        Vector3 origin = transform.position;
        transform.position += new Vector3(0.0f, scrollDir, 0.0f) * 10.0f * Time.deltaTime;
        _look = transform.position + (_look - origin);
    }

    public void Init()
    {
        transform = Camera.main.transform;
        isTracking = false;
    }

    // public void SetQuaterView(Vector3 look)
    // {
    //     _mode = Define.CameraMode.QuarterView;
    //     _look = look;
    //     transform.LookAt(_look);
    //     isTracking = false;
    // }
}
