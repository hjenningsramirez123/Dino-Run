/*
 * PlayerMove.cs
 * Marvin Chan & Harry Jennings-Ramirez
 * 7 Feb. 2020
 * This controls the player movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public static string[] Jump = new string[2] { "space", "up" };
    public float JumpPower = 16;
    public float FloatPower = 1.5f;
    public float Gravity = 1.5f;
    public float yValue = -2;
    private float momentum = 0;
    private bool releasedSpace = false;
    private bool canJump = true;
    public AudioClip[] jumpClips;
    public AudioClip[] deadClips;
    private RandomContainer randomCon;
    private SpriteRenderer SpriteRen;
    public Sprite DinosaurDead;
    public Sprite DinoStill;
    public Animation DinoDuck;
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        randomCon = GetComponent<RandomContainer>();
        SpriteRen = GetComponent<SpriteRenderer>();
        DinoDuck = GetComponent<Animation>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.GetPlaying())
        {
            if ((Input.GetKey(Jump[0]) || Input.GetKey(Jump[1])) && !Input.GetKey("down") && canJump)
            {
                if (transform.position.y < yValue + 0.0001f)
                {
                    momentum = JumpPower;
                    randomCon.clips = jumpClips;
                    randomCon.PlaySound();
                    Anim.gameObject.GetComponent<Animator>().enabled = false;
                    SpriteRen.sprite = DinoStill;
                }
                else
                {
                    if (!releasedSpace && transform.position.y < yValue + 2)
                    {
                        momentum += FloatPower;
                    }
                }
            }
            else if (Input.GetKey("down"))
            {
                momentum = -15f;
            }
            if (Input.GetKey("down") && transform.position.y > 0.0001f)
            {
                canJump = false;
                // Anim.SetTrigger("Dino Duck");
            }
            else
            {
                if (!Input.GetKey(Jump[0]) && !Input.GetKey(Jump[1]))
                {
                    canJump = true;
                }
            }
            transform.position = transform.position + new Vector3(0, momentum * Time.deltaTime);
            if (transform.position.y > yValue + 0.0001f)
            {
                if (!(Input.GetKey(Jump[0]) || Input.GetKey(Jump[1])))
                {
                    releasedSpace = true;
                }
                momentum -= Gravity;
            }
            else
            {
                Anim.gameObject.GetComponent<Animator>().enabled = true;
                releasedSpace = false;
                momentum = 0;
                transform.position = new Vector3(transform.position.x, yValue);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If Dinosaur collides with a cactus or bird the game stops
        if (collision.gameObject.tag == "Obstacle")
        {
            GameManager.Pause();
            randomCon.clips = deadClips;
            randomCon.PlaySound();
            // Changes the dinosaur sprite to his dead sprite
            Anim.gameObject.GetComponent<Animator>().enabled = false;
            SpriteRen.sprite = DinosaurDead;
            momentum = 0;

        }
    }

}
