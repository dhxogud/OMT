using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum CameraMode
    {
        QuarterView
    }
    
    public enum MouseEvent
    {
        Click,
        Press,
        Drag,
        Wheel,
        Move
    }

    public enum Objects
    {
        Unit,
        Enemy,
        Environment,
        Field
    }
}
