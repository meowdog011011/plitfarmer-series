using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriterenderer;
    private GameScript gamescript;
    private float x;
    private float y;
    private string recentxinput;
    private float force;
    private bool onground = false;

    void Start()
    {
        gamescript = GameObject.Find("Game Manager").GetComponent<GameScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x = -2f;
            recentxinput = "leftarrow";
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) & recentxinput == "leftarrow")
        {
            x = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = 2;
            recentxinput = "rightarrow";
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) & recentxinput == "rightarrow")
        {
            x = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            y = 2;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            y = 0;
        }
        if (y == 2)
        {
            force = 900;
            if (x != 0)
            {
                if (x == 2)
                {
                    x = 1.1f;
                }
                else if (x == -2)
                {
                    x = -1.1f;
                }
            }
        }
        else
        {
            force = 500;
            if (x == 1.1f)
            {
                x = 2;
            }
            else if (x == -1.1f)
            {
                x = -2;
            }
        }
        if (gamescript.stage == 0 | gamescript.stage == 4)
        {
            transform.position = new Vector3(0, -6, 0);
            spriterenderer.color = new Color(1, 1, 1, 1);
        }
        else if (gamescript.stage == 2)
        {
            spriterenderer.color = new Color(0.1f, 0.1f, 0.1f, 1);
        }
    }

    void FixedUpdate()
    {
        if ((x != 0 | y != 0) & onground & gamescript.stage == 1)
        {
            if (recentxinput == "leftarrow")
            {
                spriterenderer.flipX = true;
            }
            else if (recentxinput == "rightarrow")
            {
                spriterenderer.flipX = false;
            }
            rigidbody.velocity = new Vector2(x, y) * force * Time.fixedDeltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Spike(Clone)" | collision.gameObject.name == "Projectile(Clone)" | collision.gameObject.name.EndsWith("Enemy"))
        {
            gamescript.Die();
        }
        if ((collision.gameObject.name == "Left Platform" | collision.gameObject.name == "Right Platform") & transform.position.y < collision.gameObject.transform.position.y)
        {
            onground = false;
        }
        else
        {
            onground = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        onground = false;
    }
}
