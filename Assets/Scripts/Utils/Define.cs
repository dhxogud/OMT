using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum CameraMode
    {
        QuarterView
    }
    
    public enum MouseButtonEvent
    {
        Click,
        Press,
        Drag,
        Move
    }

    public enum MouseWheelEvent
    {
        Up,
        Down,
        Click
    }


    public enum Objects
    {
        Unit,
        Enemy,
        Environment,
        Field
    }
}
