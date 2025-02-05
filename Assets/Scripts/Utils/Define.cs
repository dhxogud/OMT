using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum MouseEvent
    {
        Click,
        Press,
        Drag,
        MiddleClick,
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
    public enum Side
    {
        
        Friendly,
        Hostility,
        neutrality
    }
    public enum CameraMode
    {
        QuarterView,
        ShoulderView
    }

}
