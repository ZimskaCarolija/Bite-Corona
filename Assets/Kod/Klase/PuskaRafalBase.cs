using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuskaRafalBase : MonoBehaviour
{
    public float FireRate;//posle koliko vremena mzoe opet da pukne puska;
    public float TrajanjeEfekta;//koliko duge traje fekat pri pucanje dok se ne deaktivira  vreme do deaktivacije
    public float Range;//koliki je rang puske koliko vreman metka leti
    public GameObject Efekat;//efekat za pucanje
    public Transform poziciajSpawnovanjeMetka;//mesto gde se spavuje metak
    public bool MozePucanje = true;//dali mzoe da puca;;//da nije pod neki mefektom
    public bool SpremnoPucanje = true;//dali moze da puca ovo se odnosi na fire rate dali je spremno pucanje
    public float JacinaMetka;// koliko je jak metak
    public PuskaMenadzer puskaM;//manadzer puske
    public float MnozilacDMG;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MozePucanje && puskaM.MozePucanje)
        {
            if(SpremnoPucanje && Input.GetMouseButton(0))
            {
                SpremnoPucanje = false;
                Pucanj_Fja();
                PUstiEfekat();
                StartCoroutine(KrajCOldowna());
            }
        }
    }
    public void Pucanj_Fja()//ovde se spawnuje metak i idodaje mu se sila
    {
        GameObject pom = Instantiate(puskaM.EquipovanMetak);//soawnuje metak
        pom.transform.position = poziciajSpawnovanjeMetka.transform.position;//postavlja poziciju metku na mesto spawnivane metka
        pom.GetComponent<Rigidbody2D>().velocity = transform.right * JacinaMetka;
        pom.transform.rotation = transform.rotation;
        pom.GetComponent<Metak>().Podesi(Range, MnozilacDMG);

    }
    public void PUstiEfekat()//pusta efekat
    {
        Efekat.SetActive(true);
        StartCoroutine(KrajEfekta());  
    }
    public IEnumerator KrajEfekta()//kraj efekta
    {
        yield return new WaitForSeconds(TrajanjeEfekta);
        Efekat.SetActive(false);
    }
    public IEnumerator KrajCOldowna()
    {
        yield return new WaitForSeconds(FireRate);
        SpremnoPucanje = true;
    }
}
