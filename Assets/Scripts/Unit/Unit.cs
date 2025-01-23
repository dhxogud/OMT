using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    enum State
    {
        Idle,
        Move,
        Act,
        Die
    }
    public float _moveRange { get; protected set; }
    public float _dodgeChange { get; protected set; }
    public float _attackPoint { get; protected set; }

    public abstract void Init();
    protected abstract void Control(int choice);
}
