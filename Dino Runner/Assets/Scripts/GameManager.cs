﻿/* GameManager.cs
 * Marvin & Harry
 * 4 February 2020
 * Manages game stuff like score and scroll speed
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<GameObject> terrainObjects;
    public static float ScrollSpeed = 10f;
    public static float TeleportDistance = 26f;
    public GameObject Score;
    public PlayerMove Player;
    private static float CurrentScore;
    private static float HighScore;
    private static bool playing = true;
    public static float cactusRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<PlayerMove>();
        CurrentScore = 0;
        HighScore = CurrentScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(playing)
        {
            CurrentScore += ScrollSpeed / 250f;
            string scoreString = "";
            for (int i = 1; i <= 5 - ((int)CurrentScore).ToString().Length; i++)
            {
                scoreString += '0';
            }
            scoreString += ((int)CurrentScore).ToString();
            Score.GetComponent<Text>().text = scoreString;
            HighScore = CurrentScore;
        }
    }

    public static void Pause()
    {
        playing = false;
    }

    public static void Resume()
    {
        playing = true;

    }

    public static bool GetPlaying()
    {
        return playing;
    }

    public static float getCactusRate()
    {
        return cactusRate;
    }

    public static float getScore()
    {
        return CurrentScore;
    }
}
