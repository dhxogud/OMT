using System;
using System.Collections;
using System.Collections.Generic;
using Skill;
using UnityEngine;

[Serializable]
public abstract class BaseUnit : MonoBehaviour
{
    public Define.WorldObject WorldObjectType;
    public Define.UnitState UnitStateType { get; private set; } = Define.UnitState.Idle;

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

    #region "Skill"

    protected Dictionary<int, Skill.BaseSkill> SkillDict = new Dictionary<int, BaseSkill>();
    protected Skill.BaseSkill GetSkillByIntKey(int key) 
    {
        return SkillDict.ContainsKey(key) ?  SkillDict[key] : null;
    }
    protected Skill.BaseSkill currentSkill;

    #endregion
    
    protected GameObject _lockTarget;

    void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        WorldObjectType = Define.WorldObject.Enemy;

        Data.Unit unit = Managers.Data.UnitDict[Enum.GetName(typeof(Define.UnitName), _name)];
        _specie = unit.specie;
        _level = unit.startLevel;
        _hp = unit.stats[_level].hp;
        _moveSpeed = unit.stats[_level].moveSpeed;
        _attack = unit.stats[_level].attack;
        _sight = unit.stats[_level].sight;

        // SkillDict;
    }

    public virtual void OnAffactBySkill(BaseSkill skill)
    {
        
    }
    public virtual void OnDead(BaseSkill skill)
    {
        
    }
    public void AttachSkillToUnit(int key)
    {
        if (UnitStateType == Define.UnitState.Idle)
        {
            // currentSkill = GetSkillByIntKey(key);
            currentSkill = new Move(this);
        }
    }

    public virtual void SetTarget(GameObject go) {}
    public virtual void SetTarget(RaycastHit hit) {}
    public virtual void UndoTarget() {}
    public void OnSkill()
    {
        if (currentSkill != null && currentSkill.IsPossible)
        {
            Debug.Log("스킬 실행!");
            ActionPoint -= currentSkill.needActivePoint; // AP 결제

            UnitStateType = Define.UnitState.Skill;
        }
    }

    void Update()
    {
        switch (UnitStateType)
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

    protected virtual void UpdateIdle() 
    {
        // Idle Animation
    }
    protected virtual void UpdateSkill() 
    {
        //Skill Animation
        if (!currentSkill.IsPossible)
        {
            UnitStateType = Define.UnitState.Idle;
            currentSkill = null;
            return;
        }
        currentSkill.OnUpdate();
    }
    protected virtual void UpdateDie() 
    { 
        //Die Animation
    }
}