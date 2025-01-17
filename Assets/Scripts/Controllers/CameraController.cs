using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    // 아래 멤버 변수들은 지울수도 잇음
    GameObject _target = null;
    Vector3 _dir = new Vector3(0.0f, 7.0f, -12.0f);
    float _moveSpeed = 30.0f;
    float _rotSpeed = 10.0f;

    enum GameState
    {
        Lobby,
        Game,

    }

    void Start() 
    {
        Managers.Input.MouseAction -= OnMouseClick;
        Managers.Input.MouseAction += OnMouseClick;
        Managers.Input.KeyAction -= OnKeyBoard;
        Managers.Input.KeyAction += OnKeyBoard;
    }

    void OnMouseClick(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.Click)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Unit")
                {
                    _target = hit.collider.gameObject;
                }
            }
        }
    }

    void OnKeyBoard()
    {
        _moveSpeed = Math.Clamp(_moveSpeed * Time.deltaTime, 0.5f, 3.0f);
        _rotSpeed = Math.Clamp(_rotSpeed * Time.deltaTime, 0.5f, 1.0f);

        Vector3 moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            moveDir += transform.forward;
        if (Input.GetKey(KeyCode.S))
            moveDir += transform.forward * -1;
        if (Input.GetKey(KeyCode.D))
            moveDir += transform.right;
        if (Input.GetKey(KeyCode.A))
            moveDir += transform.right * -1;
        
        if (moveDir.magnitude != 0.0f)
        {
            moveDir.y = 0.0f;
            transform.position += moveDir.normalized * _moveSpeed;
        }
        
        if (Input.GetKey(KeyCode.Q))
            transform.rotation = Quaternion.Euler(transform.eulerAngles + (Vector3.up * _rotSpeed));
        else if (Input.GetKey(KeyCode.E))
            transform.rotation = Quaternion.Euler(transform.eulerAngles + (Vector3.down * _rotSpeed));

    }
}
