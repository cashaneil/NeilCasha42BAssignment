using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 1.5f;

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator WaitAndLoadWin()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("WinnerScene");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("2DCarGame");

        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadWinnerScene()
    {
        StartCoroutine(WaitAndLoadWin());
    }

    public void LoadQuitGame()
    {
        Application.Quit();
    }
}
