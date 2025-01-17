using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    // 아래 멤버 변수들은 지울수도 잇음
    GameObject _target = null;
    Vector3 _dir = new Vector3(0.0f, 7.0f, -12.0f);
    float _moveSpeed = 10.0f;
    float _rotAngle = 10.0f;

    private enum Keys  {   w, a, s, d, q, e   }
    bool[] onKeys = new bool[ Enum.GetValues(typeof(Keys)).Length ];

    void Start() 
    {
        for (int i = 0; i < Enum.GetValues(typeof(Keys)).Length; i++)
            onKeys.SetValue(false, i);

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
        if (Input.GetKey(KeyCode.W))
            onKeys[(int) Keys.w] = true;
        if (Input.GetKey(KeyCode.S))
            onKeys[(int) Keys.s] = true;
        if (Input.GetKey(KeyCode.D))
            onKeys[(int) Keys.d] = true;
        if (Input.GetKey(KeyCode.A))
            onKeys[(int) Keys.a] = true;
        if (Input.GetKey(KeyCode.Q))
            onKeys[(int) Keys.q] = true;
            
        if (Input.GetKey(KeyCode.E))
            onKeys[(int) Keys.e] = true;

        

        _rotAngle = Math.Clamp(_rotAngle * Time.deltaTime, 0.5f, _rotAngle);

        if (Input.GetKey(KeyCode.Q))
            transform.rotation = Quaternion.Euler(transform.eulerAngles + (Vector3.up * _rotAngle));
        else if (Input.GetKey(KeyCode.E))
            transform.rotation = Quaternion.Euler(transform.eulerAngles + (Vector3.down * _rotAngle));
    }

    void LateUpdate() 
    {
        Move();
    }
    void Move()
    {
        _moveSpeed = Math.Clamp(_moveSpeed * Time.deltaTime, 0.5f, _moveSpeed);

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
        transform.position += moveDir.normalized * _moveSpeed;
    }
}
