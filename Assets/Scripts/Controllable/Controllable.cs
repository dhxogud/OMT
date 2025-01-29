using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllable
{
    enum Type
    {
        Creature,
        Environment
    }
    public void Move(Vector3 dest)
    {
        Debug.Log($"{dest} 로 이동!");
    }
    public void Attack(GameObject go)
    {
        Debug.Log($"{go}를 공격하라고 명령받음!");
    }
}
