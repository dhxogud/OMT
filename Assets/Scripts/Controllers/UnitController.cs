using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    Controllable Self = new Controllable();
    // Dictionary<KeyCode, Skill> _skills = new Dictionary<KeyCode, Skill>();

    void Start() 
    {
        Managers.Input.MouseAction -= MouseAction;
        Managers.Input.MouseAction += MouseAction;
        Managers.Input.KeyAction -= KeyAction;
        Managers.Input.KeyAction += KeyAction;
    }


    void MouseAction(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.Click)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Self.Attack(hit.collider.gameObject);
            }
        }
    }
    void KeyAction()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(KeyCode.Alpha1);
        }
    }
}
