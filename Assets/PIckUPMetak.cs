using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckUPMetak : MonoBehaviour
{
    // Start is called before the first frame update
   public  PuskaMenadzer menzader;
    public string Id;
    public int Kolicina;
    void Start()
    {
        menzader = GameObject.FindGameObjectWithTag("Puske").GetComponent<PuskaMenadzer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Igrac")
        {
            menzader.DodajMetak(Id, Kolicina);
            Destroy(gameObject);
        }
    }
}
