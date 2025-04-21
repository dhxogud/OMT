using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenCover.Framework.Model;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;


[Serializable]
public abstract class BaseSkill : BaseUnit
{
    protected string name;
    public int needActivePoint;
    public Define.WorldObject targetType;

    // 스킬을 발동시킬때 필요한 자원들
    // 스킬을 시전하는 Unit의 transform, Stat 안의 ActivePoint 나 MoveSpeed
    // 스킬을 시전하는 대상의 Unit 스크립트 안의 Stat

    
    public abstract bool OnSkill();
}

public class Move : BaseSkill
{
    Transform _destPos;
    public override bool OnSkill()
    {
        name = "move";
        return false;
    }
}

public class AttackSkill : BaseSkill
{
    public AttackSkill()
    {
        
    }
    public override bool OnSkill()
    {
        return false;
    }
}