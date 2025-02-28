using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    GameObject _target;

    void Start()
    {
        Init();
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _target = hit.collider.gameObject;
        }

    }

    void OnKeyAction()
    {

    }
    
    void OnMouseButtonAction(Define.MouseEvent evt)
    {

    }

    public void Init()
    {
        Managers.Input.KeyAction -= OnKeyAction;
        Managers.Input.KeyAction += OnKeyAction;
        Managers.Input.MouseButtonAction -= OnMouseButtonAction;
        Managers.Input.MouseButtonAction += OnMouseButtonAction;
    }
}
