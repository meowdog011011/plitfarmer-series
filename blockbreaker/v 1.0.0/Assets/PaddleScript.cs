using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    private float x;
    private string recentXInput;
    private GameScript gameScript;

    void Start()
    {
        gameScript = GameObject.Find("Game Manager").GetComponent<GameScript>();
    }

    void Update()
    {
        if (gameScript.stage == 0 | gameScript.stage == 4)
        {
            transform.position = new Vector3(0, -9.5f, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x = -2f;
            recentXInput = "leftarrow";
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) & recentXInput == "leftarrow")
        {
            x = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = 2;
            recentXInput = "rightarrow";
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) & recentXInput == "rightarrow")
        {
            x = 0;
        }
    }

    void FixedUpdate()
    {
        if (x != 0 & gameScript.stage == 1)
        {
            transform.position += new Vector3(x, 0, 0) * 3.5f * Time.fixedDeltaTime;
        }
    }
}
