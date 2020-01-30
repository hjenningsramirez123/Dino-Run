/*********
 * LevelGenerator.cs
 * By: Harry Jennings-Ramirez & [blank]
 * Last Edited: 1/30/2020
 * Description: Generates terrain in front of the player, obstacles are created as well and are random
 ********/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private Transform LevelPart;

    private GameObject Player;
    private Vector3 EndPosition;

    private void Awake()
    {


    }

    private void SpawnPart(Vector2 Spawn)
    {
        //Transform Instantiate(LevelPart, Spawn, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
