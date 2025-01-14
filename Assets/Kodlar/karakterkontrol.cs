using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;


public class karakterkontrol : MonoBehaviour
{
    [SerializeField]
    private float hýz;
    private Animator anim;
    private SpriteRenderer srenderer;
    private int maxcan = 100;
    private int mevcutcan;
    private float dusmek = 8.67f;
    private bool dustuMu;
    private Vector3 lastcheckpoint;
    private bool resetting;


    public UIMANAGER uiManager;


    [SerializeField]
    private float zýplamagücü;

    [SerializeField]
    private float týrmanmahýzý;


    Rigidbody2D rb;


    int yon;
    bool cifzýplama;
    int týrmanmadurumu;
    bool týrmanabilirmi;
    void Start()
    {
        lastcheckpoint = transform.position;
        anim = gameObject.GetComponent<Animator>();    
        srenderer = gameObject.GetComponent<SpriteRenderer>();  
        rb= gameObject.GetComponent<Rigidbody2D>();
        mevcutcan = maxcan;
        dustuMu = false;
        uiManager.GuncelleCanText(mevcutcan);
        resetting = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(yon * hýz * Time.deltaTime, 0, 0);
        rb.gravityScale = 1 - týrmanmadurumu;
       
        if(týrmanabilirmi)
        {
            transform.Translate(0,týrmanmadurumu * týrmanmahýzý* Time.deltaTime, 0);
        }





        if (yon != 0)
        {
            anim.SetBool("kosuyor", true);

            if(yon>0) 
            {
                srenderer.flipX = false;
            }

            else
            {
                srenderer.flipX=true;
            }


        }
        else
        {
            anim.SetBool("kosuyor", false);
        }

        if (transform.position.y<dusmek)
        {
            CanAzalt(1); 
            dustuMu = true; // Düþme durumunu true yaparak tekrar can kaybýný önle
            
        }

        else
        {
            dustuMu = false;
        }


    }


 



    public void CanAzalt(int miktar)
    {
        mevcutcan -= miktar;
        uiManager.GuncelleCanText(mevcutcan);
        if (mevcutcan <= 0)
        {
            mevcutcan = 0;
            ResetToCheckpoint();
        }
    }

   




    private void OyunBitti()
    {
       
        Debug.Log("Oyun Bitti!");
       
    }



    public void týrmanmadurumu2(int týrmanmadurumu)
    {
        this.týrmanmadurumu=týrmanmadurumu ;
    }

    bool yerdemi()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, 1 << LayerMask.NameToLayer("Zemin"));
        if (hit.collider != null)
        {
            return true;
        }

        else
        {
            return false;
        }

    }


    public void yonkarar( int kosmafonksiyonu)
    {
        this.yon = kosmafonksiyonu;
    }

    public void zýplama()
    {
        if (cifzýplama==false)
        { 
        if(yerdemi()==true)
        { 
        Vector2 vektor = new Vector2(0, 1) * zýplamagücü;
        rb.AddForce(vektor);
        anim.SetTrigger("Zýplama");
         cifzýplama = true; 
        }
        }
        else if(cifzýplama ==true) 
        {
            
           Vector2 vektor = new Vector2(0, 1) * zýplamagücü;
           rb.AddForce(vektor);
           anim.SetTrigger("Zýplama");
            cifzýplama =false;     
            
        }

    }


    public bool týrmanabilir()
    {
        return týrmanabilirmi;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("merdivenler"))
        {
            týrmanabilirmi=true;
        }

        if (collision.gameObject.CompareTag("levelgec"))
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        if (collision.gameObject.CompareTag("Portal"))
        {
            collision.gameObject.GetComponent<Portal>().ýsýnlanma(this.gameObject);
        }

        if (collision.gameObject.CompareTag("kontrolnoktasý"))
        {
            lastcheckpoint = collision.transform.position; 
            Debug.Log("Checkpoint kaydedildi: " + lastcheckpoint);
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("merdivenler"))
        {
            týrmanabilirmi = true;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("merdivenler"))
        {
            týrmanabilirmi = false;
        }
    }


    public void ResetToCheckpoint()
    {
        transform.position = lastcheckpoint;
        mevcutcan = 100; 
        rb.velocity = Vector2.zero;
        Debug.Log("Karakter son checkpoint'e geri döndü.");
    }



}
