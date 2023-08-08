using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyScript : MonoBehaviour
{
    private Transform playertransform;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriterenderer;
    private GameScript gamescript;
    private Vector3 defaulttransform;
    public int height;

    void Start()
    {
        gamescript = GameObject.Find("Game Manager").GetComponent<GameScript>();
        playertransform = GameObject.Find("Player").transform;
        defaulttransform = transform.position;
    }

    void Update()
    {
        if (gamescript.stage == 0 | gamescript.stage == 4)
        {
            transform.position = defaulttransform;
        }
        if (playertransform.position.x < transform.position.x)
        {
            spriterenderer.flipX = true;
        }
        else
        {
            spriterenderer.flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.EndsWith("Platform"))
        {
            rigidbody.velocity = new Vector3(0, 2, 0) * height * 2 * Time.deltaTime;
        }
    }
}
