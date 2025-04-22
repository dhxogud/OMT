using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : BaseUnit
{
    protected float _gold;
    protected int _killCount;

    public float Gold { get { return _gold; } set { Gold = value; }}
    public int KillCount { get { return _killCount; } set { _killCount = value; }}

    protected override void Init()
    {
        base.Init();

        WorldObjectType = Define.WorldObject.Player;
    }
    // public override Skill.BaseSkill GenerateSkill(int option)
    // {
        
    // }
    protected override void UpdateIdle() 
    { 

    }
    protected override void UpdateSkill() 
    {

    }
    protected override void UpdateDie() 
    { 

    }
}