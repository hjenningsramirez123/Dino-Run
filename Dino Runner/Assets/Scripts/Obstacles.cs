using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject cactus;
    public GameObject pterodactyl;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Spawn()
    {
        Instantiate(cactus);
        first.GetComponent<SideScroll>().type = SideScroll.Type.Cactus;
        first.transform.position = new Vector3(50, -2, 0);
    }
}
