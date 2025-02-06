using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 여기는 유닛의 동작을 설계하는 것이 아니라, 정보를 정의하는 공간이라 봐야됨
public abstract class Unit : MonoBehaviour
{
    public Define.Side _side { get; protected set;}
    enum UnitState
    {
        Unknown,
        Idle,
        Action,
        Die
    }

    public abstract void Control(string s);
    public abstract void Init();
}
