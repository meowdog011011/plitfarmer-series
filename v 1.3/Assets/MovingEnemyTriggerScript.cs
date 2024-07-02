using UnityEngine;

public class MovingEnemyTriggerScript : MonoBehaviour
{
    private MovingEnemyScript enemyScript;
    public bool left;

    void Start()
    {
        enemyScript = transform.parent.gameObject.GetComponent<MovingEnemyScript>();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.EndsWith("Platform"))
        {
            if (left)
            {
                enemyScript.x = 2;
            }
            else
            {
                enemyScript.x = -2;
            }
        }
    }
}

