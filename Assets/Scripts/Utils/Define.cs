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
        MiddleClick,
    }
    public enum MouseWheelEvent
    {
        Up,
        Down
    }

    public enum KeyCodes
    {
        Q,
        W,
        E,
        A,
        S,
        D
    }

    public enum Objects
    {
        Unit,
        Enemy,
        Environment,
        Field
    }
}
