using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eksplozija : MonoBehaviour
{
    public float DMGMetka=10;//base dmg
    public bool Vatra=false;//dal inanosi vatreni mdg
    public bool Otrov = false;//dali nanosi otrov
    public bool Struja = false;//dal inanso ielektricni dmg
    public bool LifeSteal = false;//dal inanso ilife steal
    public float ProcenatLifeSteala = 0;
    DMGPrenos prenos;
    public float Mnozilac = 4;
    public float Trahjanje = 0.25f;
    void Start()
    {

        PuskaMenadzer men = GameObject.FindGameObjectWithTag("Puske").GetComponent<PuskaMenadzer>();
        if (men.boost == null)
            Debug.LogWarning("Boost je null");

        if (men.boost.Ima_Vatru())
            Vatra = true;
        if (men.boost.Ima_Otrov())
            Otrov = true;
        if (men.boost.Ima_Struju())
            Struja = true;
        if (men.boost.Ima_LifeSteal())
            LifeSteal = true;



        prenos = new DMGPrenos(DMGMetka, Vatra, Otrov, Struja, LifeSteal, ProcenatLifeSteala);//pravi objekqat z aprenos dmg
        prenos.IzracunaDMG(Mnozilac);//izracunava ukupan dmg po puski
        StartCoroutine(Unisti());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IgracHP>())
        {
            collision.gameObject.GetComponent<IgracHP>().Udaren((DMGMetka*Mnozilac)/1.5f);
        }
        if(collision.gameObject.GetComponent<NeprijateljHP>())
        {
            collision.gameObject.GetComponent<NeprijateljHP>().Udari(prenos);
        }
    }
    IEnumerator Unisti()
    {
        yield return new WaitForSeconds(Trahjanje);
        Destroy(this.gameObject);
    }
}
