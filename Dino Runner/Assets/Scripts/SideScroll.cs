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
    public List<Sprite> sprites;
    public enum Type { Floor, Cactus, Pterodactyl , Cloud }
    public float TeleLocation = 24f;
    public Type type;
    // Start is called before the first frame update
    void Start()
    {
        transform.position.Set(transform.position.x, -2, 0);
        GetComponent<SpriteRenderer>().sprite = sprites[(int)(Random.value * sprites.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        // move left by amount depending on scrollspeed
        if (GameManager.GetPlaying())
        {
            if (type == Type.Cloud)
            {
                transform.position = transform.position + new Vector3(-GameManager.ScrollSpeed * Time.deltaTime * 0.6f, 0);
            }
            else
            {
                transform.position = transform.position + new Vector3(-GameManager.ScrollSpeed * Time.deltaTime, 0);
            }
            
        }
        // when it gets off screen teleport forward or create new one

        switch (type)
        {
            case Type.Floor:
                if (transform.position.x < -16)
                {
                    Teleport();
                }
                break;
            default:
                if (transform.position.x < -10)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }

    private void Teleport()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[(int)(Random.value * sprites.Count)];
        transform.position = new Vector2(TeleLocation, transform.position.y);
    }
}
