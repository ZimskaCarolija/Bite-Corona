using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLasaSpawnovanje : MonoBehaviour
{
    // Start is called before the first frame update
 
   public static void Spawnuj(GameObject zaspawnovanje,Transform pozicija)
    {
        Instantiate(zaspawnovanje.transform).transform.position = pozicija.position;
    }
}
