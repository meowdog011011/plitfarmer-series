using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsAndCreditsScript : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
