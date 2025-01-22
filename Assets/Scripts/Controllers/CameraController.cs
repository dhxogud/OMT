using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    Vector3 _look = Vector3.zero;
    [SerializeField]
    GameObject _target;

    const float _minYPos = 5.0f, _maxYPos = 30.0f;

    void Start() 
    {
        Managers.Input.MouseAction -= MouseClickAction;
        Managers.Input.MouseAction += MouseClickAction;
    }
    void MouseClickAction(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.tag == "Unit")
            {
                _target = hit.collider.gameObject;
            }
        }
    }
    void LateUpdate() 
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            if (_target != null)
            {
                ParallelMove();
                OrbitalMove();
                Zoom();
            }
            else
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

        Debug.DrawLine(transform.position, _look, Color.red, 10.0f);

        if (Vector3.Distance(transform.position, dest) < 0.001f)
        {
            _target = null;
        }
    }
    void ParallelMove()
    {
        Vector3 moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            moveDir += transform.forward;
        if (Input.GetKey(KeyCode.S))
            moveDir += transform.forward * -1;
        if (Input.GetKey(KeyCode.D))
            moveDir += transform.right;
        if (Input.GetKey(KeyCode.A))
            moveDir += transform.right * -1;

        moveDir.y = 0.0f;
        moveDir = moveDir.normalized * 30.0f * Time.deltaTime;
        transform.position += moveDir;
        _look += moveDir; // 
    }
    
    void OrbitalMove()
    {
        Vector3 delta = transform.position - _look;
        if (Input.GetKey(KeyCode.Q))
            delta = Quaternion.AngleAxis(1.0f, Vector3.up) * delta;
        else if (Input.GetKey(KeyCode.E))
            delta = Quaternion.AngleAxis(1.0f, Vector3.down) * delta;

        transform.position = _look + delta;
        transform.LookAt(_look);
    }
    void Zoom()
    {
        float delta = Input.mouseScrollDelta.y;
        if (delta > 0 && transform.position.y < _maxYPos)
        {
            Vector3 dir = new Vector3(0.0f, delta, 0.0f) * 30.0f * Time.deltaTime;
            transform.position += dir;
            _look += dir;
        }
        else if (delta < 0 && transform.position.y > _minYPos)
        {
            Vector3 dir = new Vector3(0.0f, delta, 0.0f) * 30.0f * Time.deltaTime;
            transform.position += dir;
            _look += dir;
        }
    }
}
