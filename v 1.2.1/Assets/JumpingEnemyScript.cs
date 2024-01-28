using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyScript : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite playerNormal;
    [SerializeField] private Sprite playerBlinking;
    private GameScript gameScript;
    private Vector3 defaultTransform;
    public int height;
    private bool reset = false;
    private Vector3 pausePosition;
    private Vector2 pauseRigidbodyVelocity;

    void Start()
    {
        gameScript = GameObject.Find("Game Manager").GetComponent<GameScript>();
        StartCoroutine(Blink());
        playerTransform = GameObject.Find("Player").transform;
        defaultTransform = transform.position;
    }

    void Update()
    {
        if (gameScript.stage == 0 | gameScript.stage == 4)
        {
            if (!reset)
            {
                transform.position = defaultTransform;
                reset = true;
            }
        }
        else
        {
            reset = false;
        }
        if (gameScript.stage != 0 & gameScript.stage != 4 & gameScript.stage != 5)
        {
            if (playerTransform.position.x < transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.EndsWith("Platform") & gameScript.stage != 5)
        {
            rigidbody.velocity = new Vector3(0, 2, 0) * 400 * Time.deltaTime;
        }
    }

    IEnumerator Blink()
    {
        for (int i = 0; i < 1; i += 0)
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
