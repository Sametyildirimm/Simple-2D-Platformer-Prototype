using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
 [SerializeField] Transform cıkısportal;
    [SerializeField] Vector3 cıkısmesafe;    

public void ısınlanma(GameObject oyuncu)
{

    oyuncu.transform.position = cıkısportal.position+cıkısmesafe;

}



}


