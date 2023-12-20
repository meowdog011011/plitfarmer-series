using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private GameScript gameScript;
    private float x;
    private float y;
    private string recentXInput;
    private float force;
    private bool onGround = false;
    private Vector3 pausePosition;
    private Vector2 pauseRigidbodyVelocity;

    void Start()
    {
        gameScript = GameObject.Find("Game Manager").GetComponent<GameScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x = -2f;
            recentXInput = "leftarrow";
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) & recentXInput == "leftarrow")
        {
            x = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = 2;
            recentXInput = "rightarrow";
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) & recentXInput == "rightarrow")
        {
            x = 0;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            y = 2;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            y = 0;
        }
        if (y == 2)
        {
            force = 500;
            if (x != 0)
            {
                if (x == 2)
                {
                    x = 1;
                }
                else if (x == -2)
                {
                    x = -1;
                }
            }
        }
        else
        {
            force = 250;
            if (x == 1)
            {
                x = 2;
            }
            else if (x == -1)
            {
                x = -2;
            }
        }
        if (gameScript.stage != 5)
        {
            pausePosition = new Vector3(0, 0, 0);
            pauseRigidbodyVelocity = new Vector2(0, 0);
        }
        else
        {
            if (pausePosition == new Vector3(0, 0, 0))
            {
                pausePosition = transform.position;
            }
            if (pauseRigidbodyVelocity == new Vector2(0, 0))
            {
                pauseRigidbodyVelocity = rigidbody.velocity;
            }
            transform.position = pausePosition;
            rigidbody.velocity = pauseRigidbodyVelocity;
        }
        if (gameScript.stage == 0 | gameScript.stage == 4)
        {
            transform.position = new Vector3(0, -6, 0);
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
        else if (gameScript.stage == 2)
        {
            spriteRenderer.color = new Color(0.1f, 0.1f, 0.1f, 1);
        }
    }

    void FixedUpdate()
    {
        if ((x != 0 | y != 0) & onGround & gameScript.stage == 1)
        {
            if (recentXInput == "leftarrow")
            {
                spriteRenderer.flipX = true;
            }
            else if (recentXInput == "rightarrow")
            {
                spriteRenderer.flipX = false;
            }
            rigidbody.velocity = new Vector2(x, y) * force * Time.fixedDeltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Spike(Clone)" | collision.gameObject.name == "Projectile(Clone)" | collision.gameObject.name.EndsWith("Enemy"))
        {
            gameScript.Die();
        }
        if ((collision.gameObject.name == "Left Platform" | collision.gameObject.name == "Right Platform") & transform.position.y < collision.gameObject.transform.position.y)
        {
            onGround = false;
        }
        else
        {
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }
}
