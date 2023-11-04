using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PuskaMenadzer : MonoBehaviour
{
    // Start is called before the first frame update
    public List<PuskaK> SvePuske = new List<PuskaK>();//lista koja sadzrzi bas sve puske
    public List<PuskaK>MojePuske = new List<PuskaK> ();//lista pusaka kojeje igrac otkljucao inventori
    public GameObject PUskaRoditelj;//ovde se dodaje  puska i ovo je roditelj puske to jest ovaj bojekat
    public PuskaK equipovana;//puska koja je trenutno equipovana
    public bool MozePucanje = true;//dali mzoe da s epuca ovo se koristi zbog ui -a ja da ne bi puska mogal da puca kada je u uui
    public List<MetkoviUIDeEQuipo> MetkoviUIDeEquip = new List<MetkoviUIDeEQuipo>();//lista u ui intrneotij uonih koji su equipivani

    public MetakK []metkoviEquipovani = new MetakK[3];
    public List<MetakK> sviMetkovi = new List<MetakK>();
    public List<MetakK>OtkljucaniMetkovi = new List<MetakK>();//metkovi koje je igrac otkljucao
    public int INdexEquipovanog = 0;//po ovome ornalzi metak koji je quipovan
    //UI
    [Header("UI")]
    public Image uiZaPusku;//ovde ce se nalazi ti prikaz equpiovane puske van menia u uigri
    public Transform InventoryContentPUske;//ovde ce se spawnovati dugmici
    public GameObject dugmeInventoryPrefabPuske;
    public Image MetakINdexSlika;//slika metka koji se trenutno koristi to ejs tmest ogde s epsrite stavja
    public Text MetakIndexKolicinaT;//tekst gde s epsie koliko metkova ima 
    public GameObject metkovidugmePrefab;//prefab dugme
    public Transform metkoviInventoryCOncent;//ovde s edugmici metkoi u uinventruj postavljaju
    //slike pusaka za ui
    [Header("SLike puske UI")]
    public Sprite AkSlika;
    public Sprite RevolverSlika;
   
    //objekti pusaka
    [Header("Objekti PUske")]
    public GameObject AkObj;
    public GameObject RevolverObj;


    //Metkovi
    [Header("Mekobi Obj")]
    public GameObject metakBase;
    public GameObject metakPierce;
    public GameObject metakFire;
    public GameObject metakOtrov;
    public GameObject metakElektricni;
    //Metkovi Slike
    [Header("metkovi Slike")]
    public Sprite metakObvicanSlika;
    public Sprite metakPIerceSlika;
    public Sprite metakFireSLika;
    public Sprite metakOtrovSlika;
    public Sprite metakElektricniSlika;
    void Start()
    {
        PUskaRoditelj = this.gameObject;
        PopuniPuske();
        OtkljucajPUska("ak");
        OtkljucajPUska("revolver");
        EquipujPUsku("ak");
        PopuniMetkove();
    }

    // Update is called once per frame
    void Update()
    {
        PromeniMetakIndex();
    }
    public void PopuniMetkove()
    {
        MetakK obican = new MetakK(metakObvicanSlika, metakBase, "obican",50);
        sviMetkovi.Add(obican);
        MetakK pierce = new MetakK(metakPIerceSlika, metakPierce, "pierce",10);
        sviMetkovi.Add(pierce);
        MetakK vatreni = new MetakK(metakFireSLika, metakFire, "fire",10);
        sviMetkovi.Add(vatreni);
        MetakK otrovni = new MetakK(metakOtrovSlika, metakOtrov, "otrov", 10);
        sviMetkovi.Add(otrovni);
        MetakK elektricni = new MetakK(metakElektricniSlika, metakElektricni, "elektricni", 10);
        sviMetkovi.Add(elektricni);

        DodajMetak("elektricni", 10);
        DodajMetak("otrov", 10);
       EquipujMetak("otrov");
       EquipujMetak("otrov");
        EquipujMetak("elektricni");
        DodajMetak("otrov", 50);
       DodajMetak("otrov", 50);
       DodajMetak("elektricni", 50);
        DodajMetak("fire", 50);
        DodajMetak("pierce", 50);
        DodajMetak("obican", 150);
        UpdejtujUIMetkoviInv();
    }
    public void MetakUIUpdate()
    {
        try
        {
            Debug.Log("Metak ui " + metkoviEquipovani[INdexEquipovanog].Id);
            MetakINdexSlika.sprite = metkoviEquipovani[INdexEquipovanog].Slika;
            MetakIndexKolicinaT.text = metkoviEquipovani[INdexEquipovanog].UzmiKOolicinu();

        }
        catch
        {
            MetakINdexSlika.sprite = null;
            MetakIndexKolicinaT.text = "";
        }
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
           InventoryUpdejtPUske();
        }
        


    }
    public void DeEquipujMetak(int i)//izbacuje metak iz equipa
    {
        try
        {
            OtkljucaniMetkovi.Add(metkoviEquipovani[i]);
            metkoviEquipovani[i] = null;
            UpdejtujUIMetkoviInv();

        }
        catch { };
    }
    public void EquipujMetak(string id)//dodaje metak iz otkljucanih  u equipovane
    {
        for(int i=0;i<OtkljucaniMetkovi.Count;i++)//prlazi kroz sve otkljucane emtkove i ikad nadje tka  metak
        {
            if (OtkljucaniMetkovi[i].Id ==  id)
            {
                for(int j=0;j<metkoviEquipovani.Length;j++)//prlazi kroz equipova dok ne nadje prazno mesto i i tu ubaci otkljucan metak
                {
                    if (metkoviEquipovani[j] == null)
                    {
                        try
                        {
                            metkoviEquipovani[j] = OtkljucaniMetkovi[i];
                            Debug.LogWarning("metka na J " + j + " je " + metkoviEquipovani[j].Id);
                            OtkljucaniMetkovi.Remove(OtkljucaniMetkovi[i]);
                            MetkoviUIDeEquip[j].Postavi(metkoviEquipovani[j].Slika, metkoviEquipovani[j].UzmiKOolicinu());
                            UpdejtujUIMetkoviInv();
                            return;
                        }
                        catch { }
                    }
                }
            }
        }
    }
    public void DodajMetak(string id,int kolicina)//odaje emtak
    {
            for (int i = 0; i < OtkljucaniMetkovi.Count; i++)//provera dal ije andjen metak u uotkljcuani  ii onda mu povecava kolicinu
            {
                if (OtkljucaniMetkovi[i].Id == id)
                {
                    OtkljucaniMetkovi[i].PovecajBrojMetkova(kolicina);
                return;
                }
            }
            for (int i = 0; i < metkoviEquipovani.Length; i++)//proverqa dal i je euqipovan metak i inejga dodaje
            {
                if (metkoviEquipovani[i] != null)
                    if (metkoviEquipovani[i].Id == id)
                    {
                        metkoviEquipovani[i].PovecajBrojMetkova(kolicina);
                        MetakUIUpdate();
                    return;
                    }
            }
            for (int i = 0; i < sviMetkovi.Count; i++)//proverava dali je equipovan emtak i inejga dodaje
            {
                if (sviMetkovi[i].Id == id)
                {
                    Debug.Log("Najdne u usvi mmetkovima " + id);
                sviMetkovi[i].POdesiKolicinu(kolicina);
                     OtkljucaniMetkovi.Add(sviMetkovi[i]);
                return;
                }
            }
        

    }
    public void PromeniMetakIndex()//ovo menja index koji je od equipovanih metkova aktivan
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (INdexEquipovanog == metkoviEquipovani.Length-1)
            {
                INdexEquipovanog = 0;
            }
            else
                INdexEquipovanog++;
            MetakUIUpdate();
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
               for(int i=0;i<PUskaRoditelj.transform.childCount;i++)//proclazi kroz svu decu objekat
                {
                    Destroy(PUskaRoditelj.transform.GetChild(i).gameObject);//unistava decu
                }
                GameObject pom = Instantiate(equipovana.objekat);//spawnuje pusku
                pom.transform.position = PUskaRoditelj.transform.position;//postavlja poziciju puske na roditeljki objekat
                pom.transform.parent = PUskaRoditelj.transform;//postavalja roditelja puske koja se sad spavnibvala
               
                pom.GetComponent<PuskaRafalBase>().SpremnoPucanje = true;//postavja da moze da s epuska puca  i puskarafalbase je glavna klasa za puske iz koje ostale ansledjuju
                pom.GetComponent<PuskaRafalBase>().puskaM = this;//dodavanj puske menadzera puski
                return;
            }
        }
    }
    public void InventoryUpdejtPUske()//updejtuje inv zsa puskama koje je igrac otkljucao
    {   

        for(int i=0;i<InventoryContentPUske.transform.childCount;i++)//ixbirse sve sdtara u uinvent0orij uda bi spawnolo nove
        {
            Destroy(InventoryContentPUske.transform.GetChild(i).gameObject);
        }
        for(int i=0;i<MojePuske.Count;i++)//prilazi kroz otkljcane psuke
        {

            GameObject novoDugmeInv = Instantiate(dugmeInventoryPrefabPuske, InventoryContentPUske);//spanjije dogme
            novoDugmeInv.GetComponent<DugmeInvPUska>().Podesi(MojePuske[i].id, MojePuske[i].slika,this);//posat6vlja m uslik u iisotale stvari
        }
    }
    public void UpdejtujUIMetkoviInv()
    {
        for (int i = 0; i < metkoviInventoryCOncent.transform.childCount; i++)//ixbirse sve sdtara u uinvent0orij uda bi spawnolo nove
        {
            Destroy(metkoviInventoryCOncent.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < OtkljucaniMetkovi.Count; i++)//prilazi kroz otkljcane metkove
        {

            GameObject novoDugmeInv = Instantiate(metkovidugmePrefab, metkoviInventoryCOncent);//spanjije dogme
            novoDugmeInv.GetComponent<MetakInventory>().Postavi(OtkljucaniMetkovi[i].Slika, OtkljucaniMetkovi[i].UzmiKOolicinu(), OtkljucaniMetkovi[i].Id, this);//posat6vlja m uslik u iisotale stvari
        }
    }
}
