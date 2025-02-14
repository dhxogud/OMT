using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Unit
[Serializable]
public class Unit
{
    public int unitId;
    public string name;
    public string model;
    public int level;
    public Stat stat;
}
[Serializable]
public class Stat
{
    public int HP;
    public int STR;
    public int AGL;
    public int DEX;
    public int INT;
}
public class UnitData : ILoader<int, Unit>
{
    public List<Unit> units = new List<Unit>();
    public Dictionary<int, Unit> MakeDict()
    {
        Dictionary<int, Unit> unitDict = new Dictionary<int, Unit>();

        foreach (Unit unit in units)
        {
            unitDict.Add(unit.unitId, unit);
        }
            
        return unitDict;
    }
}


#endregion

#region Behaviour
public class Behaviour
{
    public string name;
    public void Move(Vector3 dest)
    {

    }
    public void Attack(int range, int damage)
    {

    }
    public void Guard()
    {

    }
    public void Dodge()
    {

    }
    public void ClassSkill()
    {

    }
}
#endregion

#region Map
public class Map
{

}
public class MapData
{
    
}
#endregion