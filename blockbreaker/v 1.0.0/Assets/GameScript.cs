using System.Collections;
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
    [SerializeField] private GameObject enemyPrefab;
    private GameObject spawnEnemy;
    public static int level = 1;
    public int stage = 0;
    public int enemiesInGame = 0;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            level = 1;
            Destroy(gameObject);
        }
        else
        {
            levelText.text = "Level: " + level.ToString();
            StartCoroutine(Countdown());
        }
    }

    void Update()
    {
        if (enemiesInGame == 0)
        {
            nextLevelScreen.SetActive(true);
            stage = 3;
        }
    }

    IEnumerator Countdown()
    {
        if (stage == 0)
        {
            for (int i = 0; i < 3 + level * 2; i++)
            {
                spawnEnemy = enemyPrefab;
                spawnEnemy.transform.GetChild(0).gameObject.SetActive(false);
                spawnEnemy.transform.GetChild(1).gameObject.SetActive(false);
                spawnEnemy.transform.GetChild(2).gameObject.SetActive(false);
                spawnEnemy.transform.GetChild(Random.Range(0, 3)).gameObject.SetActive(true);
                Instantiate(spawnEnemy, new Vector2(Random.Range(-16, 17), Random.Range(-2, 10)), Quaternion.identity);
            }
            enemiesInGame = 3 + level * 2;
        }
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

    public void RestartLevel()
    {
        nextLevelScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        enemiesInGame = 3 + level * 2;
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

    public void DestroyedEnemy()
    {
        enemiesInGame--;
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
