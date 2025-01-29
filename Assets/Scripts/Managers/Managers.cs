using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Managers : MonoBehaviour
{
    static Managers _instance;
    InputManager _input = new InputManager();
    SceneManagerEx _scene = new SceneManagerEx();

    static Managers Instance { get { Init(); return _instance; } }
    public static InputManager Input { get { return Instance._input; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }

    void Start() 
    {
        Init();
    }

    void Update() 
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
                go = new GameObject { name = "@Managers" };
            DontDestroyOnLoad(go);
            _instance = go.GetOrAddComponent<Managers>();
        }
    }
    
    public static void Clear()
    {
        Input.Clear();
        Scene.Clear();
    }
}
