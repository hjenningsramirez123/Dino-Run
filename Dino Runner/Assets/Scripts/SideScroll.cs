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
    private bool moving = true;
    public enum Type { Floor, Cactus, Pterodactyl }
    public Type type;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // move left by amount depending on scrollspeed
        transform.position = transform.position + new Vector3(-GameManager.ScrollSpeed * Time.deltaTime, 0);
        // when it gets off screen teleport forward or create new one
        if (transform.position.x < -16)
        {
            switch (type)
            {
                case Type.Floor:
                    Teleport();
                    
                    break;
                default:

                    break;

            }
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
