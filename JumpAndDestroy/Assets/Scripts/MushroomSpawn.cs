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
        StartCoroutine(SpawnSistemi());//birlik içinde yürütmeyi belirli bir koþul saðlanana kadar durdurmak
                                       //ve kaldýðý yerden devam etmek için kullanýlan özel bir iþlev türüdür diyebiliriz.
    }

    IEnumerator SpawnSistemi()//IEnumerator, kontrolü ana sürece döndürebilen ve kontrol kendisine 
    {                         //döndüðünde kaldýðý yerden devam edebilen bir iþlev oluþturmak istediðinizde kullanýlýr.
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
