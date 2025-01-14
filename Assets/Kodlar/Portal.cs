using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
 [SerializeField] Transform cýkýsportal;
    [SerializeField] Vector3 cýkýsmesafe;    

public void ýsýnlanma(GameObject oyuncu)
{

    oyuncu.transform.position = cýkýsportal.position+cýkýsmesafe;

}



}


