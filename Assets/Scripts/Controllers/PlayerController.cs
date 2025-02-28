using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Define.UnitName Name;
    Unit _unit;
    List<Stat> _stats;

    enum UnitState 
    {
        Idle,
        Moving,
        Die,
        Skill
    }
    UnitState _state;

    void Update() 
    {
        switch (_state)
        {
            case UnitState.Idle:
                UpdateIdle();
                break;
            case UnitState.Moving:
                UpdateMoving();
                break;
            case UnitState.Die:
                UpdateDie();
                break;
            case UnitState.Skill:
                UpdateSkill();
                break;
        }
    }
    public Vector3 _dest;
    void UpdateIdle()
    {
        // Idle animation
    }
    void UpdateMoving()
    {
        if (Vector3.Distance(transform.position, _dest) > 0.01f)
        {
            Vector3 dir = _dest - transform.position;
            transform.Translate(dir * Time.deltaTime , relativeTo : Space.Self);
            return;
        }
        _state = UnitState.Idle;
    }
    void UpdateDie()
    {

    }
    void UpdateSkill()
    {
        
    }
    void Start() 
    {
        Init();
    }

    void Init()
    {
        _state = UnitState.Idle;
        _unit = Managers.Data.UnitDict[(int) Name];
        _stats = _unit.stats;
    }
}
