using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    [SerializeField] int _maxHealth = 100;
    [SerializeField] int _currentHealth , _Enemydamage;
    [SerializeField] HealthBar healthBar;
    Animator _animator;
    [SerializeField] Image _deadimage;
    PlayerController _playercont;
    AnimatorController _animcol;
    PuanHesapla _puan;
    int _coin;
    [SerializeField] Text _coinText , _menuCoinText;
    
    private void Awake()
    {
       
        

        _animator = GetComponent<Animator>();
        _playercont = GetComponent<PlayerController>();
        _animcol = GetComponent<AnimatorController>();
        healthBar = GetComponentInChildren<HealthBar>();
        _puan = GetComponentInChildren<PuanHesapla>();
    }
    private void Start()
    {
        _coinText.text = PlayerPrefs.GetString("Coins");
        _coin = int.Parse(_coinText.text);
        _currentHealth = _maxHealth;
        healthBar.PlayerMaxHealth(_maxHealth);
        
    }

   

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        healthBar.PlayerHealth(_currentHealth);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyShuriken"))
        {
            TakeDamage(_Enemydamage);
        }
        if (_currentHealth <= 0)
        {
            _animator.Play("dead");
            _playercont.enabled = false;
            _animcol.enabled = false;
            StartCoroutine(_playerdead());
        }

        if (collision.gameObject.tag == "ates")
        {
            _animator.Play("dead");
            TakeDamage(100);
            _playercont.enabled = false;
            _animcol.enabled = false;
            StartCoroutine(_playerdead());
            
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            _coin += 5;
            _coinText.text = _coin.ToString();
            PlayerPrefs.SetString("Coins", _coinText.text);
            Destroy(collision.gameObject);
        }
    }

    public void CanIksiri()
    {
        if (_coin >= 10)
        {
            _coin -= 10;
            _currentHealth += 20;
            _coinText.text = _coin.ToString();
            PlayerPrefs.SetString("Coins", _coinText.text);
            healthBar.PlayerHealth(_currentHealth);
        }
        else if (_coin < 10 )
        {
            _menuCoinText.text = "Yetersiz Coin !";
        }

    }

    public void KosmaIksiri()
    {
        if (_coin >= 20)
        {
            _coin -= 20;
            _playercont.Yesiliksir();
            _coinText.text = _coin.ToString();
            PlayerPrefs.SetString("Coins", _coinText.text);
        }
        else if (_coin < 20)
        {
            _menuCoinText.text = "Yetersiz Coin !";
        }
    }

    IEnumerator _playerdead()
    {
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetString("Coins", 0.ToString());
        _coinText.text = PlayerPrefs.GetString("Coins");
        Time.timeScale = 0;
        _deadimage.gameObject.SetActive(true);
    }
}
