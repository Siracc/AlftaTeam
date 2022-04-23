using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject _controller;




    public void ControllerButton()
    {
        _controller.SetActive(true);
    }


    public void ControllerBackButton()
    {
        _controller.SetActive(false);
    }

    public void OptionsBackButton()
    {
        this.gameObject.SetActive(false);
    }

}
