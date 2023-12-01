using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnovanje : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pozicija;
    public GameObject OBjekatZaSpavnovanje;
    public float Trajanje = 0.45f;
    void Start()
    {
        POkreni(OBjekatZaSpavnovanje);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void POkreni(GameObject zaPSawn)
    {
        StartCoroutine(Spawnuj(zaPSawn));
    }
    IEnumerator Spawnuj(GameObject zaSpawn)
    {
        yield return new WaitForSeconds(Trajanje);
        Instantiate(zaSpawn).transform.position = transform.position;
        Destroy(gameObject);
    }
}
