using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    private GameObject projectileClone;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private GameScript gameScript;
    private Vector3 defaultTransform;
    public int speed;
    private float direction;
    private bool reset = false;
    private Vector3 pausePosition = new Vector3(0, 0, 0);
    private Vector2 pauseRigidbodyVelocity = new Vector2(0, 0);

    void Start()
    {
        gameScript = GameObject.Find("Game Manager").GetComponent<GameScript>();
        StartCoroutine(Shoot());
        StartCoroutine(Blink());
        defaultTransform = transform.position;
        if (UnityEngine.Random.Range((int)0, (int)2) == 0)
        {
            spriteRenderer.flipX = true;
            direction = -2;
        }
        else
        {
            spriteRenderer.flipX = false;
            direction = 2;
        }
    }

    void Update()
    {
        if (gameScript.stage == 0 | gameScript.stage == 4)
        {
            transform.position = defaultTransform;
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

    IEnumerator Shoot()
    {
        for (int i = 0; i < 1; i--)
        {
            if (gameScript.stage != 0 & gameScript.stage != 4 & gameScript.stage != 5)
            {
                projectileClone = Instantiate(projectilePrefab, transform.position + new Vector3(direction, 0, 0), transform.rotation);
                projectileClone.GetComponent<ProjectileScript>().direction = direction * speed;
            }
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 0f));
        GetComponent<Animator>().enabled = true;
    }
}
