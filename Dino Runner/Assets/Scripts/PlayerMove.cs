/*
 * PlayerMove.cs
 * Marvin Chan
 * 31 Jan. 2020
 * This controls the player movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static string[] Jump = new string[2]{ "space", "up" };
    public float Speed = 5;
    public float JumpPower = 16;
    public float FloatPower = 1.5f;
    public float Gravity = 1.5f;
    public float yValue = -2;
    private float momentum = 0;
    private bool releasedSpace = false;
    private bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print((Input.GetKeyDown(Jump[0]) || Input.GetKeyDown(Jump[1])));
        if ((Input.GetKey(Jump[0]) || Input.GetKey(Jump[1])) && !Input.GetKey("down") && canJump)
        {
            if(transform.position.y < yValue + 0.0001f)
            {
                momentum = JumpPower;
            }
            else
            {
                if (!releasedSpace && transform.position.y < yValue + 2)
                {
                    momentum += FloatPower;
                }
            }
        }
        else if(Input.GetKey("down"))
        {
            momentum = -15f;
        }
        if (Input.GetKey("down") && transform.position.y > 0.0001f)
        {
            canJump = false;
        }
        else
        {
            if(!Input.GetKey(Jump[0]) && !Input.GetKey(Jump[1]))
            {
                canJump = true;
            }
        }
        transform.position = transform.position + new Vector3(0, momentum * Time.deltaTime);
        if(transform.position.y > yValue + 0.0001f)
        {
            if(!(Input.GetKey(Jump[0]) || Input.GetKey(Jump[1])))
            {
                releasedSpace = true;
            }
            momentum -= Gravity;
        }
        else
        {
            releasedSpace = false;
            momentum = 0;
            transform.position = new Vector3(transform.position.x, yValue);
        }
        
    }
}
