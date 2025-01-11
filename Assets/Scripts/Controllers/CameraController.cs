using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class CameraController : MonoBehaviour
{

    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField]
    float _dist = 10.0f;
    float _moveSpeed = 5.0f;
    Quaternion init_rot = Quaternion.Euler(50.0f, 0.0f, 0.0f);

    void Start() 
    {
        Init();

        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.Click)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Unit")
                {

                }
            }
        }
    }

    void OnKeyboard()
    {
        Vector3 axis = transform.position + transform.forward * _dist;
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += -transform.right * _moveSpeed * Time.deltaTime;
            transform.LookAt(axis);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.position += transform.right * _moveSpeed * Time.deltaTime;
            transform.LookAt(axis);
        }

        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            dir += transform.forward;
        if (Input.GetKey(KeyCode.A))
            dir += -transform.right;
        if (Input.GetKey(KeyCode.S))
            dir += -transform.forward;
        if (Input.GetKey(KeyCode.D))
            dir += transform.right;
        dir.y = 0.0f;
        transform.localPosition += dir.normalized * _moveSpeed * Time.deltaTime;
    }

    void LateUpdate() 
    {
        if (Input.mouseScrollDelta.y > 0 && transform.position.y > 5.0f)
        {
            transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        }
        else if (Input.mouseScrollDelta.y < 10.0f)
        {
            transform.position -= transform.forward * _moveSpeed * Time.deltaTime;
        }
    }

    void Init()
    {
        transform.rotation = init_rot;
    }
}
