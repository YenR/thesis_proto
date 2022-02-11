using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class collectedData
{

    // collected vars for the research part of the game

    public float starttime, endtime;
    public bool enter_draw;
    public string email;
    public string mac_ad;

    public int[] answers_mct = new int[27];

    public float start_game, end_game;
    public int[] answers_guss = new int[16];

    public string country;
    public int age;
    public int gender; // 0 = m, 1 = f, 2 = other
    public string comments;
}
