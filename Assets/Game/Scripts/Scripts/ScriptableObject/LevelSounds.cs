﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Data", menuName = "GameSettings/LevelSounds", order = 1)]
public class LevelSounds : ScriptableObject
{
    [Header("Defence Mode")]
    public AudioClip DefenceBG;
    public string DefenceMIDI= "/Assets/Game/Resources/Tracks/[MidiFile.midi]";

    [Header("Attack Mode")]
    public AudioClip AttackBG;
    public string AttackMIDI = "/Assets/Game/Resources/Tracks/[MidiFile.midi]";

    [Header("Lanes sounds")]
    public AudioClip LaneSound1;
    public AudioClip LaneSound2;
    public AudioClip LaneSound3;
    public AudioClip LaneSound4;
    public AudioClip LaneSound5;
    public AudioClip LaneSound6;
    public AudioClip LaneSound7;
    public AudioClip LaneSound8;


}