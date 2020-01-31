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

    [SerializeField] private Transform LevelPartStart;
    [SerializeField] private List<Transform> LevelPartList;
    [SerializeField] private GameObject Player;

    public const float PlayerDistance = 10f;
    private Vector3 EndPosition;
    
    private void Awake()
    {
        EndPosition = LevelPartStart.Find("EndPosition").position;
        int SpawnLevel = 1;
        for (int i = 0; i < SpawnLevel; i++)
        {
            SpawnPart();
        }
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, EndPosition) < PlayerDistance)
        {
            SpawnPart();

        }
    }

    private void SpawnPart()
    {
        Transform ChosenPart = LevelPartList[Random.Range(0, LevelPartList.Count)];
        Transform LastLevelPart = SpawnPart(ChosenPart, EndPosition);
        EndPosition = LastLevelPart.Find("EndPosition").position;
    }

    private Transform SpawnPart(Transform LevelPart, Vector3 Spawn)
    {
        Transform LevelPartTransform = Instantiate(LevelPart, Spawn, Quaternion.identity);
        return LevelPartTransform;
    }

}
