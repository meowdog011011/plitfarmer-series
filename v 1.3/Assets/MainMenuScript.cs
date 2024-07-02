using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Choose Difficulty");
    }

    public void GoInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void GoCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
