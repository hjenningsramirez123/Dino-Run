﻿/* SideScroll.cs
 * Marvin Chan
 * 31 Jan. 2020
 * Manages sideways scrolling of terrain objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroll : MonoBehaviour
{
    public List<Sprite> sprites;
    bool moving = true;
    Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (transform.position.x < -16)
            {
                Teleport();
            }
            transform.position = transform.position + new Vector3(-GameManager.ScrollSpeed * Time.deltaTime, 0);
        }
    }

    private void Teleport()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[(int)(Random.value * sprites.Count)];
        transform.position = new Vector2(GameManager.TeleportDistance, transform.position.y);
    }

    public void Pause()
    {
        moving = false;
    }

    public void Resume()
    {
        moving = true;
    }
}
