using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossKey : MonoBehaviour
{
    [SerializeField] AudioSource _boatAudio;
    [SerializeField] GameObject _keys, _theEndImage;
    [SerializeField] Image _keyImage;
    [SerializeField] int _keyCount = 0;
    [SerializeField] SpriteRenderer _door, _doorOpen;


    AudioSource _audio;


    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("kafeskey"))
        {
            _keyCount = 1;
            Destroy(collision.gameObject);
            _keyImage.gameObject.SetActive(true);

        }

        if (collision.gameObject.CompareTag("kafes") && _keyCount == 1)
        {
            Destroy(_door);
            _doorOpen.gameObject.SetActive(true);
            Destroy(_boatAudio);
            _audio.Play();

            //TheEnd();
            
        }
    }

   //IEnumerator TheEnd()
   // {
   //     yield return new WaitForSeconds(10);
   //     _theEndImage.SetActive(true);
   // }
}
