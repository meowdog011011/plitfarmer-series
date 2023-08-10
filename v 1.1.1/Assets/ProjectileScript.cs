using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    public float direction;

    void Update()
    {
        if (transform.position.x < -50 | transform.position.x > 50)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(direction, 0, 0) * Time.fixedDeltaTime;
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
