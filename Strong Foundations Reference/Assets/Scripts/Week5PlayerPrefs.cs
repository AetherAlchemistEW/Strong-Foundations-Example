using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week5PlayerPrefs : MonoBehaviour
{
    string playerName;
    int playerScore;

    void LoadPreferences()
    {
        if(PlayerPrefs.HasKey("PlayerName"))
        {
            playerName = PlayerPrefs.GetString("PlayerName");
        }
        if(PlayerPrefs.HasKey("PlayerScore"))
        {
            playerScore = PlayerPrefs.GetInt("PlayerScore");
        }
    }

    void SavePreferences()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("PlayerScore", playerScore);
    }
}
