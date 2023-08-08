using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public int maxobstacles;
    public static int obstaclesalready;
    public int obstaclechance;
    public int maxenemyspeed;
    [SerializeField] private GameObject spike;
    [SerializeField] private GameObject enemy;
    private Vector3 position;
    private GameObject which;

    void Start()
    {
        if (obstaclesalready < maxobstacles & UnityEngine.Random.Range((int)0, obstaclechance) == 1)
        {
            switch (UnityEngine.Random.Range((int)0, (int)2))
            {
                case 0:
                    which = spike;
                    break;
                default:
                    which = enemy;
                    foreach (Transform child in which.transform)
                    {
                        if (child.gameObject.name == "Moving Enemy")
                        {
                            child.gameObject.GetComponent<MovingEnemyScript>().speed = maxenemyspeed;
                        }
                        else if (child.gameObject.name == "Shooting Enemy")
                        {
                            child.gameObject.GetComponent<ShootingEnemyScript>().rate = maxenemyspeed;
                        }
                        else
                        {
                            child.gameObject.GetComponent<JumpingEnemyScript>().height = maxenemyspeed;
                        }
                        child.gameObject.SetActive(false);
                    }
                    which.transform.GetChild(UnityEngine.Random.Range((int)0, (int)3)).gameObject.SetActive(true);
                    break;
            }
            do
            {
                position = transform.position + new Vector3(UnityEngine.Random.Range((int)-8, (int)9), 2, 0);
            } while (position.x < -17.75 | position.x > 17.75);
            Instantiate(which, position, transform.rotation);
            obstaclesalready++;
        }
    }
}
