using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    GameObject _go;
    
    void MouseClickAction(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _go = hit.collider.gameObject;
        }
    }

    void Start() 
    {
        Init();
    }
    
    void Init()
    {
        Managers.Input.MouseAction -= MouseClickAction;
        Managers.Input.MouseAction += MouseClickAction;
        
        _go = null;
    }
}
