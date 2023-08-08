using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatformScript : MonoBehaviour
{
    private GameScript gamescript;
    [SerializeField] private GameObject platformprefab;
    private GameObject platformclone;
    private Vector3 nexttransform;
    private Vector3 prevtransform;
    private ObstacleSpawnerScript clonedchildscript;

    void Start()
    {
        gamescript = GameObject.Find("Game Manager").GetComponent<GameScript>();
        prevtransform = new Vector3(UnityEngine.Random.Range((int)-8, (int)8), 63, 0);
        ObstacleSpawnerScript.obstaclesalready = 0;
        for (float i = 0; i < 8; i++)
        {
            do
            {
                nexttransform = prevtransform + new Vector3(UnityEngine.Random.Range((int)-2, (int)3), -8, 0);
            } while (nexttransform.x > 10 | nexttransform.x < -10);
            platformclone = Instantiate(platformprefab, nexttransform, transform.rotation);
            prevtransform = nexttransform;
            foreach (Transform child in platformclone.transform)
            {
                clonedchildscript = child.gameObject.GetComponent<ObstacleSpawnerScript>();
                switch (GameScript.level)
                {
                    case 1:
                        clonedchildscript.maxobstacles = 2;
                        clonedchildscript.obstaclechance = 5;
                        clonedchildscript.maxenemyspeed = 300;
                        break;

                    case 2:
                        clonedchildscript.maxobstacles = 4;
                        clonedchildscript.obstaclechance = 4;
                        clonedchildscript.maxenemyspeed = 300;
                        break;

                    case 3:
                        clonedchildscript.maxobstacles = 6;
                        clonedchildscript.obstaclechance = 4;
                        clonedchildscript.maxenemyspeed = 400;
                        break;

                    case 4:
                        clonedchildscript.maxobstacles = 7;
                        clonedchildscript.obstaclechance = 3;
                        clonedchildscript.maxenemyspeed = 400;
                        break;

                    case 5:
                        clonedchildscript.maxobstacles = 9;
                        clonedchildscript.obstaclechance = 3;
                        clonedchildscript.maxenemyspeed = 400;
                        break;

                    case 6:
                        clonedchildscript.maxobstacles = 9;
                        clonedchildscript.obstaclechance = 3;
                        clonedchildscript.maxenemyspeed = 400;
                        break;

                    case 7:
                        clonedchildscript.maxobstacles = 11;
                        clonedchildscript.obstaclechance = 3;
                        clonedchildscript.maxenemyspeed = 400;
                        break;

                    case 8:
                        clonedchildscript.maxobstacles = 12;
                        clonedchildscript.obstaclechance = 2;
                        clonedchildscript.maxenemyspeed = 500;
                        break;

                    case 9:
                        clonedchildscript.maxobstacles = 12;
                        clonedchildscript.obstaclechance = 2;
                        clonedchildscript.maxenemyspeed = 500;
                        break;

                    default:
                        clonedchildscript.maxobstacles = 14;
                        clonedchildscript.obstaclechance = 2;
                        clonedchildscript.maxenemyspeed = 500;
                        break;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gamescript.Win();
        }
    }
}
