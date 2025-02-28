using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    Vector3 _delta = new Vector3(0.0f, 15.0f, -30.0f);
    const float minDistanceDelta = 10.0f, maxDistanceDelta = 40.0f;

    [SerializeField]
    GameObject _target = null;
    public void SetTarget(GameObject target) { _target = target; }

    public void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            Debug.DrawLine(_delta, Vector3.zero, Color.red);
            if (_target.IsValid() == false)
                return;

            Vector3 dest = _target.transform.position + _delta;
            transform.position = Vector3.Slerp(transform.position, dest, 0.01f);
        }
    }
    void OnKeyAction()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                _target = Managers.Game.GetNextPlayer();

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                _target = null;

                Vector3 moveDir = transform.forward * Input.GetKey(KeyCode.W).ConvertToInt()
                    + -transform.forward * Input.GetKey(KeyCode.S).ConvertToInt()
                    + transform.right * Input.GetKey(KeyCode.D).ConvertToInt()
                    + -transform.right * Input.GetKey(KeyCode.A).ConvertToInt();

                moveDir.y = 0.0f;
                moveDir = moveDir.normalized * 30.0f * Time.deltaTime;
                transform.position += moveDir;
            }
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
            {
                Vector3 pivot = transform.position - _delta;
                Vector3 axis = Vector3.up * Input.GetKey(KeyCode.Q).ConvertToInt() + Vector3.down * Input.GetKey(KeyCode.E).ConvertToInt();
                _delta = Quaternion.AngleAxis(0.5f, axis) * _delta;
                transform.position = _delta + pivot;
                transform.LookAt(pivot);
            }
        }
    }

    public void OnMouseWheelAction(int scrollDir)
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            if ((scrollDir > 0 && _delta.magnitude <= minDistanceDelta) || (scrollDir < 0 && _delta.magnitude >= maxDistanceDelta))
                return;
            Vector3 dir = _delta.normalized * scrollDir * -1;
            transform.position += dir;
            _delta += dir;
        }
    }
    
    void Start() 
    {
        Init();
    }
    void Init()
    {
        Managers.Input.KeyAction -= OnKeyAction;
        Managers.Input.KeyAction += OnKeyAction;
        Managers.Input.MouseWheelAction -= OnMouseWheelAction;
        Managers.Input.MouseWheelAction += OnMouseWheelAction;

        _delta = _delta.normalized * maxDistanceDelta;
        transform.position = _delta;
        transform.LookAt(transform.position - _delta);
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta.normalized * maxDistanceDelta;
    }
}
