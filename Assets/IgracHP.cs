using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IgracHP : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHp;
    public float TrenutniHP;
    public float BaseMax;//koliko je base bez boostova
    public Image hpSLika;
    public bool MozeUdaren = true;//dal imoze igrac da bude udaren
    public ParticleSystem UdarenPart;//efekat kad primi dmg


    [Header("Sok")]
    public float BaseKolicina;
    public int NivoSoka;
    public float PONIvou;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdejtujBasr()
    {
        hpSLika.fillAmount = TrenutniHP / MaxHp;
    }
    public void PostaviTrenutni()
    {
        TrenutniHP = MaxHp;
    }
    public void Udaren(float DMG)
    {
        if(MozeUdaren)
        {
            MozeUdaren = false;
            StartCoroutine(ZavrsiCOldownPrimanjaDMG());
            TrenutniHP -= DMG;
             UpdejtujBasr();
            UdarenPart.Play();
            if(TrenutniHP <= 0)
            {
                HpNaNuli();
            }
        }
    }
    public void HpNaNuli()
    {
        return;
    }
    public IEnumerator ZavrsiCOldownPrimanjaDMG()//ova funkciaj prekida iframe da igrac ne moze d aprima dmg
    {
        yield return new WaitForSeconds(0.4f);
        MozeUdaren = true;
    }
    public void HealujSokom()
    {
        float kolicina = BaseKolicina + (NivoSoka * PONIvou);
        healuj(kolicina);
    }
    public void healuj(float Kolicina)
    {
        TrenutniHP += Kolicina;
        if(TrenutniHP>MaxHp)
            TrenutniHP = MaxHp;
        UpdejtujBasr();
    }
}
