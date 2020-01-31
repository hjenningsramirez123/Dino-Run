using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public string Left = "a";
    public string Right = "d";
    public string Jump = "space";
    public float Speed = 5;
    public float JumpPower = 10;
    public float FloatPower = 0.3f;
    public float Gravity = 0.6f;
    public float yValue = -2;
    private float momentum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(Left))
        {
            transform.position = transform.position + new Vector3(-Speed * Time.deltaTime, 0);
        }

        if(Input.GetKey(Right))
        {
            transform.position = transform.position + new Vector3(Speed * Time.deltaTime, 0);
        }
        if(Input.GetKey(Jump))
        {
            if(transform.position.y < yValue + 0.0001f)
            {
                momentum = JumpPower;
            }
            else
            {
                momentum += FloatPower;
            }
        }
        print(momentum);
        transform.position = transform.position + new Vector3(0, momentum * Time.deltaTime);
        if(transform.position.y > yValue + 0.0001f)
        {
            momentum -= Gravity;
        }
        else
        {
            momentum = 0;
            transform.position = new Vector3(transform.position.x, yValue);
        }
        
    }
}
