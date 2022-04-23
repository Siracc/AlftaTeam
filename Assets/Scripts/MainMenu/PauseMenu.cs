using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject _pauseMenu;
    

    private void Update()
    {
        Pause();
    }


    public void Pause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _pauseMenu.SetActive(true);
            Time.timeScale=0;
        }

    }


    public void ResumeButton()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }

    public void QuitGameButton()
    {
        Application.Quit();
    }





    public void RestartButtonLevel1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void RestartButtonLevel2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }


    


}
