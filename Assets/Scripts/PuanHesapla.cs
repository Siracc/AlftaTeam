using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PuanHesapla : MonoBehaviour
{
    [SerializeField] Text _coinText;
    [SerializeField] Image _img;
    



   public void OpenMarket()
    {
        _img.gameObject.SetActive(true);
    }

    public void CloseMarket()
    {
        _img.gameObject.SetActive(false);
    }
   
}
