using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMANAGER : MonoBehaviour
{
     public karakterkontrol karakter;
    public GameObject T�rmanmabutonu;
    public Text canText;

    void Start()
    {
        karakter.uiManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(karakter.t�rmanabilir())
        {
            T�rmanmabutonu.SetActive(true);
        }

        else
        {
            T�rmanmabutonu.SetActive(false);
            karakter.t�rmanmadurumu2(0);
        }

    }

    public void GuncelleCanText(int mevcutcan)
    {
        canText.text = "Can: " + mevcutcan.ToString();
    }

}
