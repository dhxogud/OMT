using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [SerializeField]
    public GameObject _target;

    void Start() 
    {
        Managers.Input.MouseButtonAction -= MouseClickAction;
        Managers.Input.MouseButtonAction += MouseClickAction;
        Managers.Input.MouseWheelAction -= MouseWheelAction;
        Managers.Input.MouseWheelAction += MouseWheelAction;
    }

    public abstract void MouseClickAction(Define.MouseButtonEvent evt);
    public abstract void MouseWheelAction(Define.MouseWheelEvent evt);
}
