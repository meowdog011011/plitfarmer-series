using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public int maxObstacles;
    public static int obstaclesAlready;
    public int obstacleChance;
    public int maxEnemySpeed;
    [SerializeField] private GameObject spike;
    [SerializeField] private GameObject enemy;
    private Vector3 position;
    private int positionIteration = 0;
    private GameObject which;
    private int enemyDecider;

    void Start()
    {
        if (obstaclesAlready < maxObstacles & UnityEngine.Random.Range((int)0, obstacleChance) == 1)
        {
            switch (UnityEngine.Random.Range((int)0, (int)2))
            {
                case 0:
                    which = spike;
                    break;
                default:
                    which = enemy;
                    enemyDecider = 0;
                    foreach (Transform child in which.transform)
                    {
                        if (child.gameObject.name == "Moving Enemy")
                        {
                            child.gameObject.GetComponent<MovingEnemyScript>().speed = maxEnemySpeed;
                        }
                        else if (child.gameObject.name == "Shooting Enemy")
                        {
                            child.gameObject.GetComponent<ShootingEnemyScript>().speed = maxEnemySpeed;
                        }
                        else
                        {
                            child.gameObject.GetComponent<JumpingEnemyScript>().height = maxEnemySpeed;
                        }
                        child.gameObject.SetActive(false);
                    }
                    enemyDecider = UnityEngine.Random.Range((int)0, (int)3);
                    if (enemyDecider == 0 | enemyDecider == 2 | (enemyDecider == 1 & GameScript.level >= 3))
                    {
                        which.transform.GetChild(enemyDecider).gameObject.SetActive(true);
                    }
                    else
                    {
                        which.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    break;
            }
            do
            {
                position = transform.position + new Vector3(UnityEngine.Random.Range(-8.5f, 8.5f), 2, 0);
                positionIteration++;
            } while ((position.x < -17.75f | position.x > 17.75f) & positionIteration < 3);
            if (position.x < -17.75f | position.x > 17.75f)
            {
                if (transform.position.x < 0)
                {
                    position = new Vector3(-16, transform.position.x + 2, 0);
                }
                else
                {
                    position = new Vector3(16, transform.position.x + 2, 0);
                }
            }
            Instantiate(which, position, transform.rotation);
            obstaclesAlready++;
        }
    }
}
