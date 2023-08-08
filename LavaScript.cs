using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    private GameScript gamescript;

    void Start()
    {
        gamescript = GameObject.Find("Game Manager").GetComponent<GameScript>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gamescript.Die();
        }
    }
}
