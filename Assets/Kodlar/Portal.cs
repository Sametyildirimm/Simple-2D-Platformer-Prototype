using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
 [SerializeField] Transform c�k�sportal;
    [SerializeField] Vector3 c�k�smesafe;    

public void �s�nlanma(GameObject oyuncu)
{

    oyuncu.transform.position = c�k�sportal.position+c�k�smesafe;

}



}


