using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
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
    public enum UIEvent
    {
        Click,
        Press,
        Drag
    }
    public enum Scene
    {
        Unknown,
        Game,
        Lobby
    }
    public enum CameraMode
    {
        QuarterView,
    }

}
