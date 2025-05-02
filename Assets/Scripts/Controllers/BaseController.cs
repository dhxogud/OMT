using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    protected List<GameObject> UnitList;
    protected CameraController _camera;
    void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        _camera = Camera.main.GetComponent<CameraController>();
    }

    protected abstract void Clear();
}
