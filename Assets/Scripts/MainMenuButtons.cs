using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    //PlayerHealth _playerHealth;
    [SerializeField] GameObject _image,_levelImage, _aboutImage;
    public void StartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        //_playerHealth.enabled = true;

    }


    public void LevelSelectButton()
    {
        _levelImage.SetActive(true);


    }

    public void OptionsButton()
    {

        _image.SetActive(true);




    }

    public void AboutButton()
    {
        _aboutImage.SetActive(true);
    }

    public void ExitButton() 
    {

        Application.Quit();
    
    }


}
