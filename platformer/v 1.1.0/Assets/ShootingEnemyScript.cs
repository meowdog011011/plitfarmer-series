using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject projectileprefab;
    private GameObject projectileclone;
    [SerializeField] private SpriteRenderer spriterenderer;
    private GameScript gamescript;
    private Vector3 defaulttransform;
    public int rate;
    private float direction;
    private float timer = 0;

    void Start()
    {
        gamescript = GameObject.Find("Game Manager").GetComponent<GameScript>();
        defaulttransform = transform.position;
        if (UnityEngine.Random.Range((int)0, (int)2) == 0)
        {
            spriterenderer.flipX = true;
            direction = -2;
        }
        else
        {
            spriterenderer.flipX = false;
            direction = 2;
        }
    }

    void Update()
    {
        if (gamescript.stage == 0 | gamescript.stage == 4)
        {
            transform.position = defaulttransform;
        }
        if (gamescript.stage != 5)
        {
            if (timer < 300 / rate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                projectileclone = Instantiate(projectileprefab, transform.position + new Vector3(direction, 0, 0), transform.rotation);
                projectileclone.GetComponent<ProjectileScript>().direction = direction;
            }
        }
    }
}
