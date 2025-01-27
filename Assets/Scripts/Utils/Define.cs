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
        Player,
        Friend,
        Enemy,

    }
    public enum CameraMode
    {
        QuarterView,
    }

}
