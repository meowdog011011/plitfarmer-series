using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leveltext;
    [SerializeField] private GameObject pausescreen;
    [SerializeField] private GameObject gameoverscreen;
    [SerializeField] private GameObject nextlevelscreen;
    [SerializeField] private TextMeshProUGUI countdown;
    public static int level = 1;
    public int stage = 0;

    void Start()
    {
        leveltext.text = "Level: " + level.ToString();
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
        gameoverscreen.SetActive(true);
        stage = 2;
    }

    public void Win()
    {
        nextlevelscreen.SetActive(true);
        stage = 3;
    }

    public void RestartLevel()
    {
        nextlevelscreen.SetActive(false);
        gameoverscreen.SetActive(false);
        stage = 4;
        StartCoroutine(Countdown());
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
            pausescreen.SetActive(true);
            stage = 5;
        }
    }

    public void UnPause()
    {
        pausescreen.SetActive(false);
        stage = 1;
    }
}
