using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyTriggerScript : MonoBehaviour
{
    private MovingEnemyScript enemyscript;
    public bool left;

    void Start()
    {
        enemyscript = transform.parent.gameObject.GetComponent<MovingEnemyScript>();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (left)
        {
            enemyscript.x = 2;
        }
        else
        {
            enemyscript.x = -2;
        }
    }
}

