using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<GameObject> terrainObjects;
    public static float ScrollSpeed = 10f;
    public static float TeleportDistance = 26f;
    public Text Score;
    public PlayerMove Player;
    public float CurrentScore;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<PlayerMove>();
        CurrentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("down"))
        {
            CurrentScore += ScrollSpeed;
        }

        Score.text = "00000" +  (int)CurrentScore;
    }
}
