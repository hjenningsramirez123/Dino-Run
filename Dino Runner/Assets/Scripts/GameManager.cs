/* GameManager.cs
 * Marvin & Harry
 * 12 February 2020
 * Manages game stuff like score and scroll speed
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<GameObject> terrainObjects;
    public static float ScrollSpeed = 10f;
    public static float TeleportDistance = 26f;
    public GameObject Score;
    public GameObject HighestScore;
    public GameObject summerPlayer;
    public GameObject winterPlayer;
    public static float seasonInterval = 50f;
    private static bool isSummer = true;
    private static GameObject GameOver;
    private static GameObject Restart;
    private static float CurrentScore;
    private static float HighScore;
    private static bool playing = true;
    public static float cactusRate = 1.0f;
    public AudioClip[] scoreClips;
    private RandomContainer randomCon;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = GameObject.Find("Game Over");
        Restart = GameObject.Find("Restart");
        GameOver.SetActive(false);
        Restart.SetActive(false);
        CurrentScore = 0;
        HighScore = 0;
        randomCon = GetComponent<RandomContainer>();
        ChangeSeason();
    }

    // Update is called once per frame
    void Update()
    {
        if(playing)
        {
            float lastScore = CurrentScore;
            CurrentScore += ScrollSpeed / 250f;
            // to tell when it passes a 100 score benchmark
            if(CurrentScore % 100 < lastScore % 100)
            {
                ScrollSpeed *= 1.03f;
                if (cactusRate > 0.5f)
                {
                    cactusRate *= 0.95f;
                    print("cactus rate is now "+ cactusRate);
                }
                randomCon.clips = scoreClips;
                randomCon.PlaySound();
            }
            // change seasons every 500 score
            if (CurrentScore % seasonInterval < lastScore % seasonInterval)
            {
                isSummer = !isSummer;
            }
            if ((CurrentScore - 17f) % seasonInterval < (lastScore - 17f) % seasonInterval)
            {
                ChangeSeason();
            }
            string scoreString = "";
            for (int i = 1; i <= 5 - ((int)CurrentScore).ToString().Length; i++)
            {
                scoreString += '0';
            }
            scoreString += ((int)CurrentScore).ToString();
            Score.GetComponent<Text>().text = scoreString;

            HighScore += ScrollSpeed / 250f;
            string highscoreString = "HI ";
            for (int i = 1; i <= 5 - ((int)HighScore).ToString().Length; i++)
            {
                highscoreString += '0';
            }
            highscoreString += ((int)HighScore).ToString();
            HighestScore.GetComponent<Text>().text = highscoreString;

        }
        else
        {
            if (Input.GetKey("space"))
            {
                Resume();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public static void Pause()
    {
        playing = false;
        GameOver.SetActive(true);
        Restart.SetActive(true);
    }

    public static void Resume()
    {
        playing = true;
        Obstacles.nextSpawn = 35;
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

    public static bool getSummer()
    {
        return isSummer;
    }

    void ChangeSeason()
    {
        if (isSummer)
        {
            summerPlayer.transform.position = winterPlayer.transform.position;
            summerPlayer.GetComponent<PlayerMove>().momentum = winterPlayer.GetComponent<PlayerMove>().momentum;
        }
        else
        {
            winterPlayer.transform.position = summerPlayer.transform.position;
            winterPlayer.GetComponent<PlayerMove>().momentum = summerPlayer.GetComponent<PlayerMove>().momentum;
        }
        winterPlayer.SetActive(!isSummer);
        summerPlayer.SetActive(isSummer);
    }
}
