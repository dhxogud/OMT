using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController
{
    // Member
    List<Unit> units = new List<Unit>();
    int _index;
    public Unit CurrentUnit { get { return units[_index]; } } 
    // 

    // functions
    public void Command(int option)
    {
        // if (unit.State == UnitState.Die)
            // return;
    }
    
    public Unit GetNextUnit()
    {
        _index++;
        if (_index > units.Count - 1)
            _index = 0;
        return units[_index];
    }

    public void Init()
    {
        foreach (Unit unit in GameObject.FindObjectsOfType<Unit>())
            units.Add(unit);

        _index = 0;
    }
}
