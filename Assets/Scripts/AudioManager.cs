using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource _audio;


    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }



   


}
