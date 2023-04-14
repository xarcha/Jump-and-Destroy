using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawn : MonoBehaviour
{
    public GameObject spawnlanacakYaratik;
    public Transform spawnNoktasi;
    float spawnSuresi;

    void Start()
    {
        StartCoroutine(SpawnSistemi());//birlik i�inde y�r�tmeyi belirli bir ko�ul sa�lanana kadar durdurmak
                                       //ve kald��� yerden devam etmek i�in kullan�lan �zel bir i�lev t�r�d�r diyebiliriz.
    }

    IEnumerator SpawnSistemi()//IEnumerator, kontrol� ana s�rece d�nd�rebilen ve kontrol kendisine 
    {                         //d�nd���nde kald��� yerden devam edebilen bir i�lev olu�turmak istedi�inizde kullan�l�r.
                              //IEnumerator there isn't a function, it's a return type
        while (true)
        {
            spawnSuresi = Random.Range(1, 4);
            yield return new WaitForSeconds(spawnSuresi);//tells Unity to pause the script and continue on the next frame.
            NesneOlustur();

        }

    }
    void NesneOlustur()
    {
        GameObject temp = Instantiate(spawnlanacakYaratik);
        temp.transform.position = spawnNoktasi.position;
    }

}
