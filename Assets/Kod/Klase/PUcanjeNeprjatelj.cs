using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUcanjeNeprjatelj : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform puska;
    public float DMG;
    public float Brzina;
    public float Range;

    public float Coldown =2;
    public bool MozePucanje = true;
    public float DoPucanja = 0;
    public IgracNadjen nadjen;
    public GameObject Metak;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoPUcanjaFja(Time.deltaTime);
    }
    public void DoPUcanjaFja(float delta)
    {
        if(MozePucanje && nadjen.Nadjen)
        {
            DoPucanja += delta;
            if(DoPucanja>=Coldown)
            {
                Pucanj();
                DoPucanja = 0;
            }
        }
    }
    public void Pucanj()
    {
        GameObject pom = Instantiate(Metak);
        pom.GetComponent<Rigidbody2D>().velocity = puska.right * Brzina;
        pom.transform.position = transform.position;
        pom.transform.rotation = transform.rotation;
        pom.GetComponent<MetakNeprijatelj>().POstavi(DMG, Range);
    }


}
