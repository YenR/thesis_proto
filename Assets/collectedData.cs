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
    public int gender; // 0 = f, 1 = m, 2 = other
    public string comments;

    public int mcx_lvl; // 1 = low, 2 = high
    public bool onMobile;

    public int[] answers_ingame = new int[4]; 
    // 0 = take money at home <0,+1>
    // 1 = deal with bandits <0,1,+2,+3>
    // 2 = get medicine <0,1,2,+3,+4>
    // 3 = give money back <0,+1>
    // + means only available at high mcx
}
