using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameScript gamescript;
    [SerializeField] private GameObject lava;
    [SerializeField] private new Camera camera;
    private static float speed = 0.02f;

    void Start()
    {
        gamescript = GameObject.Find("Game Manager").GetComponent<GameScript>();
        camera.backgroundColor = new Color32(190, 215, 255, 255);
        transform.position = new Vector3(0, 0, -10);
        if (GameScript.level > 9)
        {
            speed += 0.005f;
        }
        else
        {
            speed = 0.02f;
        }
    }

    void Update()
    {
        if (gamescript.stage == 1)
        {
            if (transform.position.y < 55)
            {
                transform.position += new Vector3(0, 1, 0) * speed * 40 * Time.deltaTime;
            }
            else
            {
                lava.transform.localScale += new Vector3(0, 2, 0) * speed * 40 * Time.deltaTime;
            }
        }
        else if (gamescript.stage == 2)
        {
            camera.backgroundColor = new Color(0.5f, 0.5f, 0.5f, 1);
        }
        else if (gamescript.stage == 4)
        {
            transform.position = new Vector3(0, 0, -10);
            lava.transform.localScale = new Vector3(100, 1, 1);
            camera.backgroundColor = new Color32(190, 215, 255, 255);
        }
    }
}
