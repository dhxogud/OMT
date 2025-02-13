using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Unit
[Serializable]
public class Unit
{
    public string name;
    public string specie;
    public List<Stat> stats;
}
[Serializable]
public class Stat
{
    public int level;
    public int HP;
    public int STR;
    public int AGL;
    public int DEX;
    public int INT;
}
public class UnitData : ILoader<string, Unit>
{
    public List<Unit> units = new List<Unit>();
    public Dictionary<string, Unit> MakeDict()
    {
        Dictionary<string, Unit> unitDict = new Dictionary<string, Unit>();

        foreach (Unit unit in units)
            unitDict.Add(unit.name, unit);

        Debug.Log(units.Count);
            
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