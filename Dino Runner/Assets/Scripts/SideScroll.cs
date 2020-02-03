/* SideScroll.cs
 * Marvin Chan
 * 31 Jan. 2020
 * Manages sideways scrolling of terrain objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroll : MonoBehaviour
{
<<<<<<< HEAD
    public static float speed = 3f;
=======
    public static float speed = 6f;
>>>>>>> 8fc12e2c6898a2e710edd26a4b72d8d55369e89e
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
                transform.position = new Vector2(26, transform.position.y);
            }
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0);
        }        
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
