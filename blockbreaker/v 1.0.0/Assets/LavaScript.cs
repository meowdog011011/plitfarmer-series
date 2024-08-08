using UnityEngine;

public class LavaScript : MonoBehaviour
{
    private GameScript gameScript;

    void Start()
    {
        gameScript = GameObject.Find("Game Manager").GetComponent<GameScript>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameScript.Die();
        }
    }
}
