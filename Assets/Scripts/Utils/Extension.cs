using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static int ConvertToInt(this bool value)
    {
        return value ? 1 : 0;
    }
}
