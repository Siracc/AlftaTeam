using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    AudioSource _audio;
    [SerializeField] AudioSource _audioManager;
    [SerializeField] float _boatSpeed;
    [SerializeField] Transform _playerBody;

    [SerializeField] Vector3 _velocity;
    bool _moving;


    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        
    }


    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.tag != "Ground")
        {
            
            this.transform.position += new Vector3(1*_boatSpeed*Time.deltaTime, 0);
            
        }       
        else
        {         
            _boatSpeed = 0;
        }     
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(_audioManager);
            _audio.Play();
            _moving = true;
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
            _moving = false;
        }
    }


    private void FixedUpdate()
    {
        if (_moving)
        {
            transform.position += (_velocity * Time.deltaTime);
        }
    }


}
