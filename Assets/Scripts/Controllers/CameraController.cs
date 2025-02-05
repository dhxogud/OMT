using System;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class CameraController
{
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    Transform transform;
    Vector3 _offset = new Vector3(0.0f, 15.0f, -30.0f);
    Vector3 _look;
    bool isTracking;
    Vector3 _destPos;

    public void OnLateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            if (isTracking)
            {
                transform.position = Vector3.Slerp(transform.position, _destPos, 0.1f);
                if (Vector3.Distance(transform.position, _destPos) < 0.01f)
                {
                    isTracking = false;
                }
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
        _look = targetPos;
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
    }
    public void Zoom(int scrollDir)
    {
        if (isTracking) 
            return;

        Vector3 dist = _look - transform.position;
        if ((scrollDir > 0 && dist.magnitude < 10.0f) || (scrollDir < 0 && dist.magnitude > 50.0f))
            return;
        transform.position += dist.normalized * scrollDir;
    }

    public void Init()
    {
        transform = Camera.main.transform;
        isTracking = false;
    }

    public void SetQuaterView(Vector3 look)
    {
        _mode = Define.CameraMode.QuarterView;
        transform.position = _offset - look;
        _look = look;
        transform.LookAt(_look);
    }
}
