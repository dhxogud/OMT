using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    #region Unit
    [Serializable]
    public class Unit
    {
        public string name;
        public string specie;
        public int startLevel;
        public Dictionary<int, Stat> stats;
    }
    public class Stat
    {
        public int hp;
        public int actionPoint;
        public int moveSpeed;
        public int attack;
        public int sight;
    }

    public class UnitData : ILoader<string, Unit>
    {
        public List<Unit> units = new List<Unit>();
        public Dictionary<string, Unit> MakeDict()
        {
            Dictionary<string, Unit> unitDict = new Dictionary<string, Unit>();

            foreach (Unit unit in units)
            {
                unitDict.Add(unit.name, unit);
            }
            return unitDict;
        }
    }
    #endregion
}
