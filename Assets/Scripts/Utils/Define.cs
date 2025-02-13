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
    public enum UnitSide
    {
        Friend,
        Host,
        Neutral,
    }
    public enum ControlEntity
    {
        Player,
        AI
    }
    public enum CameraMode
    {
        QuarterView,
        ShoulderView
    }
    public enum UnitName
    {
        Warrior,
        Archor,
        Caster,
        Beast,
        Dog,
        Goblin,
        Tauren
    }
}
