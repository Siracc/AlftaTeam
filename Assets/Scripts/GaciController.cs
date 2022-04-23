using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GaciController : MonoBehaviour
{
    Animator _anim;

    [SerializeField] GameObject _player,_theEndImage;
    
 

 
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="spear")
        {
            Destroy(collision.gameObject);
            _anim.Play("GaciDead");
            _player.GetComponent<Animator>().Play("PlayerSasirma");
            
            StartCoroutine(OlumAnim());
        }
    }


    IEnumerator OlumAnim()
    {
        yield return new WaitForSeconds(4);
        _player.GetComponent<Animator>().Play("Harakiri");
        yield return new WaitForSeconds(10);
        _theEndImage.SetActive(true);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }
}
