using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMANAGER : MonoBehaviour
{
     public karakterkontrol karakter;
    public GameObject Tırmanmabutonu;
    public Text canText;

    void Start()
    {
        karakter.uiManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(karakter.tırmanabilir())
        {
            Tırmanmabutonu.SetActive(true);
        }

        else
        {
            Tırmanmabutonu.SetActive(false);
            karakter.tırmanmadurumu2(0);
        }

    }

    public void GuncelleCanText(int mevcutcan)
    {
        canText.text = "Can: " + mevcutcan.ToString();
    }

}
