using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] GameObject _player, _spear;

    [SerializeField] float _spearSpeed;
    private bool isZoomed = false;


   


    void Update()
    {
        
        if (_player.gameObject.tag=="Player2")
        {
            isZoomed = !isZoomed;
        }
        if (isZoomed)
        {

            GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 2;
            _player.GetComponent<PlayerController>().enabled = false;
            _player.GetComponent<AnimatorController>().enabled = false;

            _spear.transform.position += new Vector3(-_spearSpeed*Time.deltaTime, 0);

            
        }

        
        

        

    }
}
