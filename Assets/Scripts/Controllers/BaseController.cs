using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Dictionary<KeyCode, int> KeyCodesDict = null;
    public GameObject Target;
    Ray mousePosRay;

    void Start() 
    {
        Init();
    }

    void Update()
    {
        mousePosRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    public virtual void OnKeyAction()
    {
        if (KeyCodesDict != null)
        {
            KeyCode[] keys = KeyCodesDict.Keys.ToArray<KeyCode>();
            for (int i = 0; i < keys.Length; i++)
            {
                if (Input.GetKey(keys[i]))
                    KeyCodesDict[keys[i]] = 1;
                else
                    KeyCodesDict[keys[i]] = 0;
            }
        }
    }

    public void BindKeysToDict(KeyCode[] keys)
    {
        KeyCodesDict = new Dictionary<KeyCode, int>();
        foreach (KeyCode key in keys)
            KeyCodesDict.Add(key, 0);
    }

    public void MouseClickAction(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.Click)
        {
            if (Physics.Raycast(mousePosRay, out RaycastHit hit))
            {
                if (hit.collider.gameObject)
                {
                    Target = hit.collider.gameObject;
                }
            }
        }
    }

    public virtual void Init()
    {
        Managers.Input.KeyAction -= OnKeyAction;
        Managers.Input.KeyAction += OnKeyAction;
        Managers.Input.MouseAction -= MouseClickAction;
        Managers.Input.MouseAction += MouseClickAction;
    }
}
