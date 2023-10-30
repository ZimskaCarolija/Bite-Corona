using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metak : MonoBehaviour
{
    // Start is called before the first frame update
    public float DMGMetka;//base dmg
    public bool Vatra;//dal inanosi vatreni mdg
    public bool Otrov;//dali nanosi otrov
    public bool Struja;//dal inanso ielektricni dmg
    public bool LifeSteal;//dal inanso ilife steal
    public float ProcenatLifeSteala;
    public GameObject Efekat;//efekat koji se spawnuje akda se unisti metak
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Podesi(float Range,float Mnozilac)//u ovoj funckiji postavlja speciifcne stvari za pusku
    {
        DMGPrenos prenos = new DMGPrenos(DMGMetka, Vatra, Otrov, Struja, LifeSteal, ProcenatLifeSteala);//pravi objekqat z aprenos dmg
         prenos.IzracunaDMG(Mnozilac);//izracunava ukupan dmg po puski
        StartCoroutine(Unisti_Vrme(Range));//zoive vremsnk u funkih koja unistava objekat po rang4eu
    }
    IEnumerator Unisti_Vrme(float range)//unisit objeka TPOSLE NEKOG VREMENA , RANGE
    {
        yield return new WaitForSeconds(range);
        Unisit_fja();//poziva fukciju koja unisgfava objaket
    }
    public void Unisit_fja()//ova funckiaj sapwnuje efekat ii unistava objakrt
    {
         GameObject pom = Instantiate(Efekat);
        pom.transform.position = this.transform.position;
        Destroy(gameObject);
    }
}
