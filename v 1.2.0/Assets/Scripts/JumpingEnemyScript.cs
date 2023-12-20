using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyScript : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private GameScript gameScript;
    private Vector3 defaultTransform;
    public int height;
    private Vector3 pausePosition = new Vector3(0, 0, 0);
    private Vector2 pauseRigidbodyVelocity = new Vector2(0, 0);

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
            transform.position = defaultTransform;
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
        if (gameScript.stage == 5)
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

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.EndsWith("Platform") & gameScript.stage != 5)
        {
            rigidbody.velocity = new Vector3(0, 2, 0) * height * 2 * Time.deltaTime;
        }
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 0f));
        GetComponent<Animator>().enabled = true;
    }
}
