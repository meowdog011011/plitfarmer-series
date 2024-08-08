using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite playerNormal;
    [SerializeField] private Sprite playerBlinking;
    private bool firstFrame;
    private GameScript gameScript;
    private Vector3 pausePosition;
    private Vector2 pauseRigidbodyVelocity;

    void Start()
    {
        gameScript = GameObject.Find("Game Manager").GetComponent<GameScript>();
        StartCoroutine(Blink());
    }

    void Update()
    {
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
            firstFrame = true;
            transform.position = new Vector3(0, -6, 0);
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
        else if (gameScript.stage == 2)
        {
            spriteRenderer.color = new Color(0.1f, 0.1f, 0.1f, 1);
        }
        else if (gameScript.stage == 3)
        {
            rigidbody.velocity = new Vector2(0, 0);
        }
        if (gameScript.stage == 1 & rigidbody.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        if (gameScript.stage == 1 & firstFrame)
        {
            rigidbody.velocity = new Vector2(3, -3);
            firstFrame = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.EndsWith("Enemy"))
        {
            gameScript.DestroyedEnemy();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        StartCoroutine(ChangeDirection());
    }

    IEnumerator ChangeDirection()
    {
        yield return null;
        rigidbody.velocity += new Vector2(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f));
    }

    IEnumerator Blink()
    {
        while (true)
        {
            if (gameScript.stage != 5)
            {
                spriteRenderer.sprite = playerNormal;
            }
            yield return new WaitForSeconds(1.5f);
            if (gameScript.stage != 5)
            {
                spriteRenderer.sprite = playerBlinking;
            }
            yield return new WaitForSeconds(0.1f);
            if (gameScript.stage != 5)
            {
                spriteRenderer.sprite = playerNormal;
            }
            yield return new WaitForSeconds(0.5f);
            if (gameScript.stage != 5)
            {
                spriteRenderer.sprite = playerBlinking;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
