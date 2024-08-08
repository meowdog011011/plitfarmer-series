using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject nextLevelScreen;
    [SerializeField] private TextMeshProUGUI countdown;
    public static int level = 1;
    public int stage = 0;

    void Start()
    {
        levelText.text = "Level: " + level.ToString();
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        countdown.text = "3";
        yield return new WaitForSeconds(1);
        countdown.text = "2";
        yield return new WaitForSeconds(1);
        countdown.text = "1";
        yield return new WaitForSeconds(1);
        countdown.text = "Go!";
        stage = 1;
        yield return new WaitForSeconds(1);
        countdown.text = "";
    }

    public void Die()
    {
        if (stage != 3)
        {
            gameOverScreen.SetActive(true);
            stage = 2;
        }
    }

    public void Win()
    {
        nextLevelScreen.SetActive(true);
        stage = 3;
    }

    public void RestartLevel()
    {
        nextLevelScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        stage = 4;
        StartCoroutine(Countdown());
    }

    public void NewLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        level = 1;
        SceneManager.LoadScene("Game");
    }

    public void NextLevel()
    {
        level++;
        SceneManager.LoadScene("Game");
    }

    public void Pause()
    {
        if (stage == 1)
        {
            pauseScreen.SetActive(true);
            stage = 5;
        }
    }

    public void UnPause()
    {
        pauseScreen.SetActive(false);
        stage = 1;
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
