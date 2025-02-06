using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Unit
{
    public override void Control(string s)
    {
        Debug.Log($"{gameObject.GetInstanceID()}가 {s}를 명령받음");
    }

    public override void Init()
    {
        Debug.Log($"{gameObject.GetInstanceID()}가 초기화 되었음을 알림");
    }
}   
