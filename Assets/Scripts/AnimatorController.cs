using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimatorController : MonoBehaviour
{
    Animator _anim;
    [SerializeField] Image _deadScene;
    PlayerController _playercont;
    AnimatorController _animcol;
    PlayerHealth _playerhealth;
    bool isOnGround = true;
    bool isOnStairs = false;
    bool isBoat = false;
    

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _playercont = GetComponent<PlayerController>();
        _animcol = GetComponent<AnimatorController>();
        _playerhealth = GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {

        //PlayerWalk();
   
    }

    private void Update()
    {
        PlayerWalk();
    }

    void PlayerWalk()
    {
        if (Input.GetKey(KeyCode.A) && isOnGround  || Input.GetKey(KeyCode.D) && isOnGround || Input.GetKey(KeyCode.RightArrow) && isOnGround || Input.GetKey(KeyCode.LeftArrow) && isOnGround)
        {
            _anim.Play("walk");
            
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            _anim.Play("jump");

        }
        else if (!isOnGround && !isOnStairs && !isBoat)
        {
            _anim.Play("Glide");
        }
        else if (!isOnStairs && isOnGround)
        {
            _anim.Play("idle");
        }
        else if (Input.GetKey(KeyCode.W) && isOnStairs)
        {
            _anim.Play("climb");            
        }
    }

  




    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Boat"))
        {
            isBoat = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
        if (collision.gameObject.CompareTag("Boat"))
        {
            isBoat = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOnGround = true;
        if (collision.gameObject.CompareTag("merdiven"))
        {
            isOnStairs = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("merdiven"))
        {
            isOnStairs = false;
        }
    }


  

    




}
