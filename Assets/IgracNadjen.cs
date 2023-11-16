using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgracNadjen : MonoBehaviour
{
    // Start is called before the first frame update
    public NepriajteljPratiIgraca nepriajtelj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Igrac")
            nepriajtelj.PronadjenFja();
    }
}
