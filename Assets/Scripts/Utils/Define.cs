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
        WheelClick,
        WheelPress,
    }

    public enum Objects
    {
        Unit,
        Enemy,
        Environment,
        Field
    }
}
