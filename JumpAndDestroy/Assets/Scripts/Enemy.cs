using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float hareketHizi;
    bool yasiyor;
    Animator anim;

    GameObject oyuncu;
    SpriteRenderer sr;
    void Start()
    {
        oyuncu = GameObject.Find("Hero");
        yasiyor= true;
        anim = this.GetComponent<Animator>();
        sr = this.GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        if (yasiyor==true)
        {
            if (oyuncu.GetComponent<Hero>().yasiyorMu()==true)
            {
                IleriGit();
            }
            else
            {
                GeriGit();
            }
            
            //ölüyse geri git
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Ol();
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
    public void Ol()
    {
        //ölme animasnyonu çalýþþsýn
        anim.SetTrigger("oldur");
        //enemy yok olsun.
        yasiyor = false;
        Destroy(gameObject,0.4f);
        //hero nun puaný arttsýn
        oyuncu.GetComponent<Hero>().SkorArttir();

    }
    void IleriGit()
    {
        sr.flipX= true;
        transform.Translate(-hareketHizi*Time.deltaTime, 0, 0);
    }
    void GeriGit()
    {
        sr.flipX= false;
        transform.Translate(hareketHizi * Time.deltaTime, 0, 0);
        Destroy(gameObject,0.7f);
    }
}
