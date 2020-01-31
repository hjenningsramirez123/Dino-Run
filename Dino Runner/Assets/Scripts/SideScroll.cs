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
    public static float speed = 3f;
    Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x < -16)
        {
            transform.position = new Vector2(26, transform.position.y);
        }
        transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0);
        
    }
}
