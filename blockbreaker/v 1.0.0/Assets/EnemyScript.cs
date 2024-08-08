using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameScript gameScript;

    void Start()
    {
        gameScript = GameObject.Find("Game Manager").GetComponent<GameScript>();
    }

    void Update()
    {
        if (gameScript.stage == 4)
        {
            gameObject.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
