using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private float ziplamaGucu;
    Rigidbody2D rb;
    public GameObject kilicSaldirmaYeri;
    public TextMeshProUGUI skorText;
    Animator anim;

    bool yasiyor;
    public GameObject canvas;
    public GameObject startCanvas;
    private string myNumber;
    public GameObject hero;




    private int skor;
    void Start()
    {
        yasiyor = false;
        rb= gameObject.GetComponent<Rigidbody2D>();
        anim= gameObject.GetComponent<Animator>();
        startCanvas.SetActive(true);
        hero = gameObject.GetComponent<GameObject>();
        

    }
    
    public void StartButton()
    {
        
        yasiyor= true;
        startCanvas.SetActive(false);
        SoundManagerScript.PlaySound("maintheme");
    }
    public void TryAgainButton()
    {
        yasiyor = true;
        canvas.SetActive(false);
        anim.SetTrigger("beklemek");
        PlayerPrefs.DeleteAll();
        skor = 0;
    }
    public void AdContinueGame()
    {
        
        yasiyor = true;
        canvas.SetActive(false);
        anim.SetTrigger("beklemek");
        //LoadNumber();
    }
    public void SaveNumber()
    {
        PlayerPrefs.SetInt("myNumber", skor);
    }
    public void LoadNumber()
    {
        
        int loadedNumber = PlayerPrefs.GetInt(myNumber);
    }
    public void SkorArttir()
    {
        skor++;
    }
    public int SkoruOgren()
    {
        return skor;
    }
    public bool yasiyorMu()
    {
        return yasiyor;
    }
    

    void Update()
    {
        skorText.text = skor.ToString();
    

    }
    bool YerdeMi()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0,-0.25f, 0), Vector2.down, 0.1f);
        if (hit.collider)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Mushroom"))
    //    {
            
    //        //mantarý yok et.
    //        //collision.gameObject.GetComponent<Enemy>().Ol();
            
    //        //Zipla();

    //    }
        
       
    //}
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mushroom")||collision.gameObject.CompareTag("FlyingEye"))
        {
            
            yasiyor = false;
            anim.SetTrigger("olmek");
            canvas.SetActive(true);
            SoundManagerScript.PlaySound("gameover");


        }
    }
    public void Zipla()
    {
        if (yasiyor)
        {
            if (YerdeMi())
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * ziplamaGucu);
                SoundManagerScript.PlaySound("jump");
            }

        }
        
        
    }
    public void AsagiIn()
    {
        if (yasiyor)
        {
            if (!YerdeMi())
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.down * ziplamaGucu);
            }

        }
        
    }
    public void Saldir()
    {
        if (yasiyor)
        {
            anim.SetTrigger("saldir");
            
            StartCoroutine(KilicAcKapat());
            SoundManagerScript.PlaySound("swordattack");

        }
        
    }
    IEnumerator KilicAcKapat()
    {
        kilicSaldirmaYeri.SetActive(true);
        yield return new WaitForSeconds(1f);
        kilicSaldirmaYeri.SetActive(false);
    } 
}
