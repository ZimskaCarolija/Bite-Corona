using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KOmpjuterMeni : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Usao = false;//dal ije gkrqac usao
    public UIMenadzer menadzer;
    public GameObject interact;//slka na kojo j pise da treba da pritisne e
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Usao)
        {
            menadzer.AktivirajDeaktiviraj();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Igrac")
        {
            Usao = true;
            interact.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Igrac")
        {
            Usao = false;
            interact.SetActive(false);
            menadzer.DeaktivirajMeni();
        }
    }
}
