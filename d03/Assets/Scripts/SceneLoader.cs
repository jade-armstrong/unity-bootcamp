using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject gameMngr;
    gameManager game;
    public GameObject[] pauseObjects;
    public GameObject[] confirmQuitObjects;
    public GameObject[] speedButtons;
    [HideInInspector] public bool paused = false;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            game = gameMngr.GetComponent<gameManager>();
        } 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            paused = true;
            game.pause(paused);
            foreach (GameObject obj in pauseObjects)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in speedButtons)
            {
                obj.SetActive(false);
            }
        }
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        paused = false;
        game.pause(paused);
        foreach (GameObject obj in pauseObjects)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in speedButtons)
        {
            obj.SetActive(true);
        }
    }

    public void ShowConfirmQuit()
    {
        foreach (GameObject obj in confirmQuitObjects)
        {
            obj.SetActive(true);
        }
    }

    public void NoQuit()
    {
        foreach (GameObject obj in confirmQuitObjects)
        {
            obj.SetActive(false);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
