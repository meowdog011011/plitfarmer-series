using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatformScript : MonoBehaviour
{
    private GameScript gameScript;
    [SerializeField] private GameObject platformPrefab;
    private GameObject platformClone;
    private Vector3 nextTransform;
    private Vector3 prevTransform;
    private ObstacleSpawnerScript clonedChildScript;
    private int transformIteration = 0;

    void Start()
    {
        gameScript = GameObject.Find("Game Manager").GetComponent<GameScript>();
        prevTransform = new Vector3(UnityEngine.Random.Range((int)-8, (int)9), 63, 0);
        ObstacleSpawnerScript.obstaclesAlready = 0;
        for (float i = 0; i < 8; i++)
        {
            do
            {
                nextTransform = prevTransform + new Vector3(UnityEngine.Random.Range((int)-2, (int)3), -8, 0);
                transformIteration++;
            } while ((nextTransform.x > 10 | nextTransform.x < -10) & transformIteration < 3);
            if (nextTransform.x > 10 | nextTransform.x < -10)
            {
                nextTransform = prevTransform - new Vector3(0, -8, 0);
            }
            platformClone = Instantiate(platformPrefab, nextTransform, transform.rotation);
            prevTransform = nextTransform;
            foreach (Transform child in platformClone.transform)
            {
                clonedChildScript = child.gameObject.GetComponent<ObstacleSpawnerScript>();
                switch (GameScript.level)
                {
                    case 1:
                        clonedChildScript.maxObstacles = 2;
                        clonedChildScript.obstacleChance = 5;
                        clonedChildScript.maxEnemySpeed = 200;
                        break;

                    case 2:
                        clonedChildScript.maxObstacles = 3;
                        clonedChildScript.obstacleChance = 4;
                        clonedChildScript.maxEnemySpeed = 200;
                        break;

                    case 3:
                        clonedChildScript.maxObstacles = 5;
                        clonedChildScript.obstacleChance = 4;
                        clonedChildScript.maxEnemySpeed = 300;
                        break;

                    case 4:
                        clonedChildScript.maxObstacles = 6;
                        clonedChildScript.obstacleChance = 3;
                        clonedChildScript.maxEnemySpeed = 300;
                        break;

                    case 5:
                        clonedChildScript.maxObstacles = 8;
                        clonedChildScript.obstacleChance = 3;
                        clonedChildScript.maxEnemySpeed = 400;
                        break;

                    case 6:
                        clonedChildScript.maxObstacles = 9;
                        clonedChildScript.obstacleChance = 3;
                        clonedChildScript.maxEnemySpeed = 400;
                        break;

                    case 7:
                        clonedChildScript.maxObstacles = 11;
                        clonedChildScript.obstacleChance = 3;
                        clonedChildScript.maxEnemySpeed = 400;
                        break;

                    case 8:
                        clonedChildScript.maxObstacles = 12;
                        clonedChildScript.obstacleChance = 2;
                        clonedChildScript.maxEnemySpeed = 500;
                        break;

                    case 9:
                        clonedChildScript.maxObstacles = 13;
                        clonedChildScript.obstacleChance = 2;
                        clonedChildScript.maxEnemySpeed = 500;
                        break;

                    default:
                        clonedChildScript.maxObstacles = 14;
                        clonedChildScript.obstacleChance = 2;
                        clonedChildScript.maxEnemySpeed = 500;
                        break;
                }
            }
            transformIteration = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameScript.Win();
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -2;
        }
    }
}
