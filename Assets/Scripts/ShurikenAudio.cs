using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenAudio : MonoBehaviour
{
    public AudioClip _sound;
    AudioSource _audio;


    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _audio.PlayOneShot(_sound, 3f);
            
        }
    }
   
}
