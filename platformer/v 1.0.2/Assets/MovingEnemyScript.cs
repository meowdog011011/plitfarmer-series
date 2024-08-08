using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyScript : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriterenderer;
    private GameScript gamescript;
    public float x = 2;
    public float speed;
    private bool onground = false;

    void Start()
    {
        gamescript = GameObject.Find("Game Manager").GetComponent<GameScript>();
    }

    void FixedUpdate()
    {
        if (onground)
        {
            if (x == -2)
            {
                spriterenderer.flipX = true;
            }
            else
            {
                spriterenderer.flipX = false;
            }
            rigidbody.velocity = new Vector3(x, 0, 0) * speed * Time.fixedDeltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Left Platform" & collision.gameObject.name != "Right Platform")
        {
            x *= -1;
        }
        else
        {
            onground = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Left Platform" & collision.gameObject.name == "Right Platform")
        {
            onground = false;
        }
    }
}
