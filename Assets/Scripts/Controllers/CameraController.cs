using System;
using UnityEngine;

public class CameraController : BaseController
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    Vector3 _look = Vector3.zero;
    GameObject _target;
    KeyCode[] _keyCodes = new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Q, KeyCode.E };

    public override void Init()
    {
        KeyCodes = _keyCodes;

        base.Init();
    }

    public override void OnKeyAction()
    {
        base.OnKeyAction();

        Move();
    }

    void Move()
    {
        Vector3 moveDir = transform.forward * KeyCodesDict[KeyCode.W]
            + -transform.forward * KeyCodesDict[KeyCode.S] 
            + transform.right * KeyCodesDict[KeyCode.D]
            + -transform.right * KeyCodesDict[KeyCode.A];
        moveDir.y = 0.0f;
        moveDir = moveDir.normalized * 30.0f * Time.deltaTime;
        transform.position += moveDir;
        _look += moveDir;

        Vector3 delta = transform.position - _look;
        Vector3 axis = Vector3.up * KeyCodesDict[KeyCode.Q] + Vector3.down * KeyCodesDict[KeyCode.E];
        delta = Quaternion.AngleAxis(1.0f, axis) * delta;
        transform.position = _look + delta;
        transform.LookAt(_look);
    }

    public override void MouseWheelAction(Define.MouseWheelEvent evt)
    {
        if (evt == Define.MouseWheelEvent.Up)
            Zoom(1);
        else if (evt == Define.MouseWheelEvent.Down)
            Zoom(-1);
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
                MoveToTarget();
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

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
}
