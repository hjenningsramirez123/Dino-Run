/* Obstacles.cs
 * Marvin Chan
 * 11 February 2020
 * This manages spawning of new obstacles
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject cactus;
    public GameObject winterCactus;
    public GameObject pterodactyl;
    public GameObject winterPterodactyl;
    public GameObject summerFloor;
    public GameObject winterFloor;
    public static float nextSpawn = 35;
    public static float lowerSpawn = 10;
    public static float higherSpawn = 25;
    private static float lastScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFloor(new Vector3(-5, -3, 0));
        SpawnFloor(new Vector3(0, -3, 0));
        SpawnFloor(new Vector3(5, -3, 0));
        SpawnFloor(new Vector3(10, -3, 0));
        SpawnFloor(new Vector3(15, -3, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.getScore() > nextSpawn)
        {
            Spawn();
            nextSpawn += Random.Range(lowerSpawn, higherSpawn);
        }
        if (GameManager.getScore() % 4 < lastScore % 4)
        {
            SpawnFloor(new Vector3(16,-3,0));
        }
        lastScore = GameManager.getScore();
    }

    private void SpawnFloor(Vector3 pos)
    {
        GameObject newFloor = Instantiate(GameManager.getSummer() ? summerFloor : winterFloor);
        newFloor.transform.position = pos;
    }

    public void Spawn()
    {
        GameObject obstacle;
        if(Random.value < GameManager.getCactusRate())
        {
            // if summer use normal cactus otherwise use winter cactus
            obstacle = Instantiate(GameManager.getSummer() ? cactus : winterCactus);
            obstacle.GetComponent<SideScroll>().type = SideScroll.Type.Cactus;
            obstacle.transform.position = new Vector3(10, -2, 0);
        }
        else
        {
            // if summer use normal pterodactyl otherwise use winter vers
            obstacle = Instantiate(GameManager.getSummer() ? pterodactyl : winterPterodactyl);
            obstacle.GetComponent<SideScroll>().type = SideScroll.Type.Pterodactyl;
            double rand = Random.value;
            int yVal = 0;
            if (rand < 0.333)
            {
                yVal = -2;
            }
            else if(rand < 0.666)
            {
                yVal = -1;
            }
            else
            {
                yVal = 0;
            }
            obstacle.transform.position = new Vector3(10, yVal, 0);
        }
        
    }
}
