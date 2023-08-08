using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsAndCreditsScript : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
