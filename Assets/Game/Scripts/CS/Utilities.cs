﻿public class Utilities
{

    public static float[] track ={
        0,1,0,0/*|*/,.4f,
        0,0,1,0/*|*/,.4f,
        0,1,0,0/*|*/,.4f,
        0,0,1,0/*|*/,.4f,
        1,0,1,0/*|*/,.8f,
        0,1,1,0/*|*/,.5f,
        0,0,1,0/*|*/,.8f,
        0,0,1,1/*|*/,.4f,
        0,0,1,0/*|*/,.4f,
        0,0,0,1/*|*/,.4f,
        0,0,1,0/*|*/,.4f,
        1,1,0,0/*|*/,.8f,
        0,1,0,0/*|*/,.3f,
        1,0,0,0/*|*/,.3f,
        0,1,0,0/*|*/,.3f,
        1,0,0,0/*|*/,.4f,
        1,1,0,0/*|*/,.8f,
        0,1,0,0/*|*/,.4f,
        0,1,1,0/*|*/,.8f,
        0,0,1,1/*|*/,.8f,
        0,0,1,0/*|*/,.4f,
        0,1,1,0/*|*/,.7f,
        0,1,0,0/*|*/,.6f,
        1,1,0,0/*|*/,.4f,
        0,0,1,0/*|*/,.4f,
        0,0,0,1/*|*/,.4f,
        0,1,0,0/*|*/,.4f,
        1,0,0,0/*|*/,.4f,
        0,1,0,0/*|*/,.4f,
        0,0,1,0/*|*/,.4f,
        0,1,1,0/*|*/,1f,
        0,1,1,0/*|*/,1f,
        0,1,1,0/*|*/,1f,
    };



}
public enum VRControllersTypes
{
    LeftH, RightH, Head
}

public enum EmitterEvents
{
    StartBgMusic, PuseBgMusic, ResumeBgMusic, StopBgMusic
}

public enum HandStates
{
    Melee, Ranged, Empty
}

public enum Direction
{
    NONE, UP, DOWN, RIGHT, LEFT
}