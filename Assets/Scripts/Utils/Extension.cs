using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public static class Extension
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
    {
        return Util.GetOrAddComponent<T>(go);
    }
    public static bool IsValid(this GameObject go)
	{
		return go != null && go.activeSelf;
	}
    public static int ConvertToInt(this bool value)
    {
        return value ? 1 : 0;
    }
    public static Key FindFirstKeyByValue<Key, Value>(this Dictionary<Key, Value> dict, Value value)
    {
        return dict.FirstOrDefault(entry => 
            EqualityComparer<Value>.Default.Equals(entry.Value, value)).Key;
    }
}
