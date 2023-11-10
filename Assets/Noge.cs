using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Noge : MonoBehaviour
{
    // Start is called before the first frame update
    public List<SpriteRenderer> renderers = new List<SpriteRenderer>();
    public bool UVodi = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Voda")
        {
            SmanjiLeyerPrikaza();
            UVodi = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Voda")
        {
            PovecajLeyerPrikaza();
            UVodi = false;
        }
    }
    public void SmanjiLeyerPrikaza()//smanuje  rendes sloj koji s epriakzuju na 4
    {
       
        foreach(SpriteRenderer renderer in renderers)
        {
            renderer.sortingOrder = 4;
        }
    }
    public void PovecajLeyerPrikaza()//smanuje  rendes sloj koji s epriakzuju na 7
    {
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.sortingOrder = 7;
        }
    }
}
