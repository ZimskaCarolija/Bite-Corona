using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foliage : MonoBehaviour
{
    // Start is called before the first frame update
    public List<SpriteRenderer> renderers = new List<SpriteRenderer>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Foliage")
        {
            SmanjiLeyerPrikaza();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Foliage")
        {
            PovecajLeyerPrikaza();
        }
    }
    public void SmanjiLeyerPrikaza()//smanuje  rendes sloj koji s epriakzuju na 4
    {

        foreach (SpriteRenderer renderer in renderers)
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
