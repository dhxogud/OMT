using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    public GameObject Target;
    public KeyCode[] KeyCodes;
    public Dictionary<KeyCode, int> KeyCodesDict = new Dictionary<KeyCode, int>();

    void Start() 
    {
        Init();

        Managers.Input.KeyAction -= OnKeyAction;
        Managers.Input.KeyAction += OnKeyAction;
        Managers.Input.MouseButtonAction -= MouseClickAction;
        Managers.Input.MouseButtonAction += MouseClickAction;
        Managers.Input.MouseWheelAction -= MouseWheelAction;
        Managers.Input.MouseWheelAction += MouseWheelAction;
    }
    public virtual void Init()
    {
        foreach (KeyCode key in KeyCodes)
        {
            KeyCodesDict.Add(key, 0);
        }
    }
    public virtual void OnKeyAction()
    {
        if (KeyCodesDict != null)
        {
            foreach (KeyCode key in KeyCodes)
            {
                if (Input.GetKey(key))
                    KeyCodesDict[key] = 1;
                else
                    KeyCodesDict[key] = 0;
            }
        }
    }
    public abstract void MouseClickAction(Define.MouseButtonEvent evt);
    public abstract void MouseWheelAction(Define.MouseWheelEvent evt);
}
