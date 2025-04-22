using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Math
{
    public static Vector3 GetBezierCurveOnPoint(Vector3 start, Vector3 end, float t, Vector3[] controls)
    {
        Vector3[] Points = new Vector3[controls.Length + 2];
        Points[0] = start;
        Points[controls.Length + 1] = end;
        for (int i = 0; i < controls.Length; i++)
            Points[i + 1] = controls[i];
        return DeCasteljau(Points, t);
    }
    public static Vector3 DeCasteljau(Vector3[] vectors, float t)
    {
        if (vectors.Length == 1)
            return vectors[0];

        Vector3[] next = new Vector3[vectors.Length - 1];
        for (int i = 0; i < vectors.Length - 1; i++)
            next[i] = Vector3.Lerp(vectors[i], vectors[i+1], t);
        
        return DeCasteljau(next, t);
    }
}
