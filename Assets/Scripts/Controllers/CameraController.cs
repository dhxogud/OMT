using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    [SerializeField]
    Vector3 _look = Vector3.zero;

    GameObject _target;

    const float _minHeight = 3.0f, _maxHeight = 10.0f;
    float _speed = 10.0f;
    float _angle = 1.0f;

    void Start() 
    {
        Managers.Input.MouseAction -= TargetOn;
        Managers.Input.MouseAction += TargetOn;
    }

    void TargetOn(Define.MouseEvent evt)
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
                Vector3 prev = transform.position;
                Vector3 dest = transform.position + (_target.transform.position - _look);
                transform.position = Vector3.Slerp(transform.position, dest, 0.1f);
                _look += transform.position - prev;

                if (Vector3.Distance(_target.transform.position, _look) < 0.001f)
                {
                    _target = null;
                }
            }

            else
            {
                ParallelMove();
                OrbitalMove();
                Zoom();
            }
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
        moveDir = moveDir.normalized * _speed * Time.deltaTime;

        transform.position += moveDir;
        _look += moveDir;
    }
    
    void OrbitalMove()
    {
        Vector3 delta = transform.position - _look;
        if (Input.GetKey(KeyCode.Q))
            delta = Quaternion.AngleAxis(_angle, Vector3.up) * delta;
        else if (Input.GetKey(KeyCode.E))
            delta = Quaternion.AngleAxis(_angle, Vector3.down) * delta;

        transform.position = _look + delta;
        transform.LookAt(_look);
    }

    void Zoom()
    {
        float delta = Input.mouseScrollDelta.y;
        if (delta == 0) return;

        if (delta > 0 && transform.position.y < _maxHeight)
            transform.position += Vector3.up;
        else if (delta < 0 && transform.position.y > _minHeight)
            transform.position += Vector3.down;
        transform.LookAt(_look);
    }
}
