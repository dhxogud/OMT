using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public abstract class BaseUnit : MonoBehaviour
{
    public Define.WorldObject WorldObjectType { get; protected set; } = Define.WorldObject.None;
    protected Define.UnitState State { get; private set; } = Define.UnitState.Idle;

    [SerializeField]
    Define.UnitName _name;
    #region Stat
    protected string _specie;
    protected int _level;
    protected int _hp;
    protected int _actionPoiont;
    protected int _moveSpeed;
    protected int _attack;
    protected int _sight;
    
    public string UnitName { get { return Enum.GetName(typeof(Define.UnitName), _name); }}
    public string Specie { get { return _specie; }}
    public int Level { get {return _level; } set { _level = value; }}
    public int Hp { get { return _hp; } set { _hp = value;}}
    public int ActionPoint { get {return _actionPoiont; } set { _actionPoiont = value; }}
    public int MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; }}
    public int Attack { get { return _attack; } set { _attack = value; }}
    public int Sight { get { return _sight; } set { _sight = value; }}
    #endregion

    #region Skill
    protected List<string> skillList;

    #endregion
    public BaseSkill currentSkill;

    void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        Data.Unit unit = Managers.Data.UnitDict[Enum.GetName(typeof(Define.UnitName), _name)];
        _specie = unit.specie;
        _level = unit.startLevel;
        _hp = unit.stats[_level].hp;
        _moveSpeed = unit.stats[_level].moveSpeed;
        _attack = unit.stats[_level].attack;
        _sight = unit.stats[_level].sight;

        // _skills = unit.skills[unit.startLevel].names;
    }

    protected void ClearSkill()
    {
        currentSkill = null;
    }

    void Update()
    {
        switch (State)
        {
            case Define.UnitState.Idle:
                UpdateIdle();
                break;
            case Define.UnitState.Skill:
                UpdateSkill();
                break;
            case Define.UnitState.Die:
                UpdateDie();
                break;
        }
    }
    // (1번 -> "move", 2번 -> "attack)
    public virtual void SetCurrentSkill(int option)
    {
        if (option < skillList.Count + 1)
        {
            
        }
    }
    public virtual void OnSkill(GameObject target)
    {
        currentSkill.OnSkill();

    }
    public virtual void OnAttack(BaseUnit attacker)
    {

    }
    public virtual void OnDead(BaseUnit attacker)
    {

    }
    
    public virtual void SetOrAddTarget(GameObject _target) {}
    protected virtual void UpdateIdle() 
    { 

    }
    protected virtual void UpdateSkill() 
    {
        // if (!currentSkill.OnSkill())
        //     State = Define.UnitState.Idle;
    }
    protected virtual void UpdateDie() 
    { 

    }
}