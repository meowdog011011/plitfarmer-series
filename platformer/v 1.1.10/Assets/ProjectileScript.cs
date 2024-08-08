using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    private GameScript gameScript;
    public float direction;

    void Start()
    {
        gameScript = GameObject.Find("Game Manager").GetComponent<GameScript>();
    }

    void Update()
    {
        if (transform.position.x < -50 | transform.position.x > 50)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (gameScript.stage != 5)
        {
            rigidbody.velocity = new Vector2(direction, 0) * Time.fixedDeltaTime;
        }
        else
        {
            rigidbody.velocity = new Vector2(0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DestroyThis());
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
