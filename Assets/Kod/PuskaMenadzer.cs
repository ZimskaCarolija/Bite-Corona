using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuskaMenadzer : MonoBehaviour
{
    // Start is called before the first frame update
    public List<PuskaK> SvePuske = new List<PuskaK>();//lista koja sadzrzi bas sve puske
    public List<PuskaK>MojePuske = new List<PuskaK> ();//lista pusaka kojeje igrac otkljucao inventori
    public PuskaK equipovana;//puska koja je trenutno equipovana
    //UI
    public Image uiZaPusku;//ovde ce se nalazi ti prikaz equpiovane puske van menia u uigri

    //slike pusaka za ui
    public Sprite AkSlika;
    public Sprite RevolverSlika;

    //objekti pusaka
    public GameObject AkObj;
    public GameObject RevolverObj;

    void Start()
    {
        PopuniPuske();
        OtkljucajPUska("revolver");
        EquipujPUsku("revolver");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopuniPuske()
    {
        PuskaK reovlver = new PuskaK("revolver",RevolverObj,RevolverSlika);
        SvePuske.Add(reovlver);
        PuskaK ak = new PuskaK("ak", AkObj, AkSlika);
        SvePuske.Add(ak);
    }
    public void OtkljucajPUska(string id)//dodaje pusku  u invcentory prima id ii po to midju nalazi pusku
    {
        PuskaK pom = SvePuske[0];
        foreach(PuskaK puskaK in SvePuske)
        {
            if (puskaK.id == id)
            {
                pom = puskaK;
            }
        }
      
            if(!DaLiImaPusku(id))//proverta dali vec ima tu pusk uu u inventoru
             {
                MojePuske.Add(pom);//ak onema dodjaen je
            }
     
    }
    public bool DaLiImaPusku(string id)//pretrauzje ivnentor puske ii vraca booolean u uzavisnoti dla iima pusk usa tim id  u uinv
    {
        bool ima = false;
        foreach(PuskaK puska in MojePuske)
        {
            if (puska.id == id)
                return true;
        }
        return ima;
    }
    public void EquipujPUsku(string id)
    {
        if(MojePuske.Count > 0)
        equipovana = MojePuske[0];

        foreach(PuskaK puska in MojePuske)
        {
            if(puska.id == id)
            {
                equipovana = puska;
                uiZaPusku.sprite = equipovana.slika;
                return;
            }
        }
    }
}
