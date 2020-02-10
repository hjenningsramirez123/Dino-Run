using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject cactus;
    public GameObject pterodactyl;
    private static float nextSpawn = 35;
    public static float lowerSpawn = 10;
    public static float higherSpawn = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.getScore() > nextSpawn)
        {
            Spawn();
            nextSpawn += Random.Range(lowerSpawn, higherSpawn);
        }
    }

    public void Spawn()
    {
        GameObject obstacle;
        if(Random.value < GameManager.getCactusRate())
        {
            obstacle = Instantiate(cactus);
            obstacle.GetComponent<SideScroll>().type = SideScroll.Type.Cactus;
            obstacle.transform.position = new Vector3(10, -2, 0);
        }
        else
        {
            obstacle = Instantiate(pterodactyl);
            obstacle.GetComponent<SideScroll>().type = SideScroll.Type.Pterodactyl;
            obstacle.transform.position = new Vector3(10, 0, 0);
        }
        
    }
}
