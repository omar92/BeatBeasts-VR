﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "GeneralSettings", menuName = "GameSettings/GeneralSettings", order = 1)]
public class GeneralSounds : ScriptableObject
{

    [Header("Weapons sounds")]
    [Header("Melee sounds")]
    public AudioClip MeleeSlash;
    public AudioClip MeleeMiss;
    public AudioClip MeleeSwing;
    [Header("Ranged sounds")]
    public AudioClip RangedShoot;
    public AudioClip RangedHit;
    [Header("Other sounds")]
    public AudioClip NoteMiss;
    public AudioClip GameWin;
    public AudioClip GameLose;
    public AudioClip ChangeWeapon;

}

