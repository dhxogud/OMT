using System;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    Vector3 _offset = new Vector3(0.0f, 15.0f, -30.0f);
    Vector3 _look;
    bool isTracking;
    Vector3 _destPos;

    public void LateUpdate()
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
    void Move()
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

        // QE : Orbital Motion From Y-axis
        Vector3 delta = transform.position - _look;
        Vector3 axis = Vector3.up * Input.GetKey(KeyCode.Q).ConvertToInt() + Vector3.down * Input.GetKey(KeyCode.E).ConvertToInt();
        delta = Quaternion.AngleAxis(0.5f, axis) * delta;
        transform.position = _look + delta;
        transform.LookAt(_look);
    }

    public void Move(GameObject target)
    {
        Vector3 targetPos = target.gameObject.transform.position;
        _destPos = targetPos + transform.position - _look;
        _look = targetPos;
        isTracking = true;
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
    
    void Start() 
    {
        Init();
    }
    void Init()
    {
        isTracking = false;

        Managers.Input.KeyAction -= Move;
        Managers.Input.KeyAction += Move;
        Managers.Input.MouseWheelAction -= Zoom;
        Managers.Input.MouseWheelAction += Zoom;
    }
}
