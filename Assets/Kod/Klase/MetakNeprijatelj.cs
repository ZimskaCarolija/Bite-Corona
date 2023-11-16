using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetakNeprijatelj : MonoBehaviour
{
    // Start is called before the first frame update
    public float DMG;
    public Rigidbody2D rb;
    public GameObject efekat;

    public void POstavi(float dmg,float rng)
    {
        DMG = dmg;
    }
    IEnumerator Unisti_Vreme(float vreme)
    {
    yield return new WaitForSeconds(vreme);
        Unisti_Fja();
    }
    public void Unisti_Fja()
    {
        Destroy(gameObject);
        Instantiate(efekat).transform.position = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.GetComponent<IgracHP>() != null)
        {
            collision.gameObject.GetComponent<IgracHP>().Udaren(DMG);
            Unisti_Fja();

        }
         if(collision.gameObject.tag == "Mapa")
        {
            Unisti_Fja();
        }
    }

}
