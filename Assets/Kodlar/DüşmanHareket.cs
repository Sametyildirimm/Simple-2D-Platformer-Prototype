using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DüşmanHareket : MonoBehaviour
{
    [SerializeField] float hız;
    int yon=-1; // false ise sağa gidicek,true ise sola gidicek.
    SpriteRenderer sr;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("düsmanengel"))
        {
            if (yon == -1)
            {
                sr.flipX = false;
                yon = 1;
            }

           else if (yon == 1)
            {
                sr.flipX = true;
                yon = -1;

            }
        }


    }





    void Start()
    {
        sr=gameObject.GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(yon* hız * Time.deltaTime, 0, 0);
    }

    


}
