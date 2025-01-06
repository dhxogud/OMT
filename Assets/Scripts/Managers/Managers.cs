using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Managers : MonoBehaviour
{
    static Managers _instance;
    InputManager _input = new InputManager();

    
    public static Managers Instance { get { Init(); return _instance; }}
    public static InputManager Input { get { return Instance._input; } }

    void Start() 
    {
        Init();
    }

    void Update() 
    {
        Input.OnUpdate();
    }

    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go.name = "@Managers";
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            _instance = go.GetComponent<Managers>();
        }
    }
}
