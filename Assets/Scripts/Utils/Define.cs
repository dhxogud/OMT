using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum MouseEvent
    {
        LeftButtonClick,
        LeftButtonPress,
        LeftButtonCDrag,
        RightButtonClick,
        RightButtonPress,
        RightButtonDrag,
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
    public enum Layer
    {
        Unit = 8,
        Field = 9,
        Block = 10,
    }
    public enum GameState
    {
        None,
        Ready,
        Start,
        PlayerTurn,
        EnemyTurn,
        Won,
        Lose
    }
    public enum UnitState
    {
        None,
        Idle,
        Skill,
        Die
    }
    public enum WorldObject
    {
        None,
        Player,
        Enemy,
    }
    public enum UnitName
    {
        John,
        HellHound,
        Moo
    }
    public enum SkillType
    {
        None,
        Move,
        Attack,
        Heal,
        Buff
    }
}
