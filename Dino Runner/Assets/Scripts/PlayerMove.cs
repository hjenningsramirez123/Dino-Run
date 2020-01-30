using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public string Left = "a";
    public string Right = "d";
    public string Jump = "space";
    public float Speed = 5;
    public float JumpPower = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(Left))
        {
            transform.position = transform.position + new Vector3(-Speed * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey(Right))
        {
            transform.position = transform.position + new Vector3(Speed * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey(Jump))
        {
            transform.position = transform.position + new Vector3(0, JumpPower * Time.deltaTime, 0);
        }
    }
}
