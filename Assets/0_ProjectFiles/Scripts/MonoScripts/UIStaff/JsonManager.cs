﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JsonManager : MonoBehaviour {

    public FloatVariable finalScore;
    public int maxNumOfBoard = 10;
    float newScore = -1f;
    public GameEvent LeaderboardChanged;
    string json;
    Player player;
    public ListVariable playerList;
    public StringVariable playerName;


    //void Awake()
    //{
    //    //if (PlayerPrefs.GetString("scoreJson") == null)
    //    //{
    //    //    playerList = new List<Player>();
    //    //}else
    //    //{
    //     //   playerList = JsonUtility.FromJson<ListVariable>(PlayerPrefs.GetString("scoreJson"));
    //    //}

    //} 

    public void SaveJson()
    {
        if (playerList.list.Count == 0 || playerList.list.Count < maxNumOfBoard)
        {
            //if (finalScore.value != newScore)
            //{
                player = new Player(playerName.value, finalScore.value);
                playerList.list.Add(player);
            //}
        }
        else
        {
            if (finalScore.value > playerList.list[playerList.list.Count-1].playerScore)
            {
                playerList.list[playerList.list.Count - 1].playerScore = finalScore.value;
                playerList.list[playerList.list.Count - 1].playerName = playerName.value;
            }
        }
        //newScore = finalScore.value;
        json = JsonUtility.ToJson(playerList);
        //PlayerPrefs.SetString("scoreJson", json);
        LeaderboardChanged.Raise();        
    }

}

