using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
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
