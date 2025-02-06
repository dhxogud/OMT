using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;
    protected CameraController MainCamera = new CameraController();
    void Awake() 
    {
        Init();
    }

    protected virtual void Init()
    {
        // Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        // if (obj == null)
        // {
        //     Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
        // }
        MainCamera.Init();
    }
    public abstract void Clear();
}
