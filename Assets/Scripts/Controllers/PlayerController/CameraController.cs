using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : BaseController
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    Vector3 _look = Vector3.zero;
    KeyCode[] _keys = { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Q, KeyCode.E };

    void LateUpdate() 
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            if (Target != null)
            {
                MoveToTarget();
            }
        }
    }
    public override void OnKeyAction()
    {
        base.OnKeyAction();
        
        // WASD : Parallel Motion On XZ-plane
        Vector3 moveDir = transform.forward * KeyCodesDict[KeyCode.W]
            + -transform.forward * KeyCodesDict[KeyCode.S] 
            + transform.right * KeyCodesDict[KeyCode.D]
            + -transform.right * KeyCodesDict[KeyCode.A];
        moveDir.y = 0.0f;
        moveDir = moveDir.normalized * 30.0f * Time.deltaTime;
        transform.position += moveDir;
        _look += moveDir;

        // QE : Orbital Motion From Y-axis
        Vector3 delta = transform.position - _look;
        Vector3 axis = Vector3.up * KeyCodesDict[KeyCode.Q] + Vector3.down * KeyCodesDict[KeyCode.E];
        delta = Quaternion.AngleAxis(1.0f, axis) * delta;
        transform.position = _look + delta;
        transform.LookAt(_look);
    }

    void MoveToTarget()
    {
        Vector3 prev = transform.position;
        Vector3 dest = Target.transform.position - _look;
        transform.position = Vector3.Slerp(transform.position, dest, 0.1f);
        _look += transform.position - prev;

        if (Vector3.Distance(transform.position, dest) < 0.001f)
        {
            Target = null;
        }
    }

    public override void Init()
    {
        base.Init();

        Managers.Input.MouseWheelAction -= Zoom;
        Managers.Input.MouseWheelAction += Zoom;

        BindKeysToDict(_keys);

    }

    void Zoom(int scrollDir)
    {
        Vector3 origin = transform.position;
        transform.position += new Vector3(0.0f, scrollDir, 0.0f) * 10.0f * Time.deltaTime;
        _look = transform.position + (_look - origin);
    }
}
