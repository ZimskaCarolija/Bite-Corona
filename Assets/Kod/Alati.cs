using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Alati : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Item> SviItemi = new List<Item>();
    public List<Item> Inventori = new List<Item>();

    public UIINventoriPOlje[] metakUIAktivni = new UIINventoriPOlje[3];
    public Item[] ItemiAktivni = new Item[3];
    public ItemSokParadajz SokParadajz;
    public PuskaMenadzer puskaM;
    [Header("UIStvari")]
    public GameObject uiPrefabUnventori;
    public Transform contentInventori;

    public UIINventoriPOlje polje1;
    public UIINventoriPOlje polje2;
    //Slike
    [Header("UISlike")]
    public Sprite BiljkaTurrentSlika;
    public Sprite SibicaSlika;
    public Sprite BaterijaSlika;
    public Sprite BombaSlika;
    public Sprite SokOdParadajzaSlika;
    [Header("Za iteme")]
    public GameObject SpawnTurrent;
    public IgracHP hp;
    public GameObject SIbiceEfekat;
    public GameObject baterijaEfekat;
    public GameObject SpawnovanjeBomba;
    void Start()
    {
        SokParadajz = new ItemSokParadajz("SokParadajz", SokOdParadajzaSlika, 3, 10, hp);
        ItemiAktivni[0] = SokParadajz;
        ItemiAktivni[1] = null;
        ItemiAktivni[2] = null;
        PopuniSve();
        Dodaj("BijklaTurrent");
        Dodaj("Sibice");
        Dodaj("Sibice");
        Dodaj("Baterija");
        Dodaj("Bomba");
        Dodaj("Bomba");
        Dodaj("Bomba");
        Dodaj("Bomba");
        UpdejtujAktivanMeni();
       // Equipuj("BijklaTurrent");
    }

    // Update is called once per frame
    void Update()
    {
        InputIskoristi();
    }
    public void PopuniSve()
    {
        ItemBiljkaTurent biljkaTurent = new ItemBiljkaTurent("BijklaTurrent", BiljkaTurrentSlika, 1, 150, SpawnTurrent);
        SviItemi.Add(biljkaTurent);

        ItemSibice sibice = new ItemSibice("Sibice", SibicaSlika, 1, 70, SIbiceEfekat, puskaM); 
        SviItemi.Add(sibice);

        ItemBaterija baterija = new ItemBaterija("Baterija", BaterijaSlika, 1, 90, baterijaEfekat, puskaM);
        SviItemi.Add(baterija);

        ItemBomba bomba = new ItemBomba("Bomba", BombaSlika, 1, 120, SpawnovanjeBomba);
        SviItemi.Add(bomba);

    }
    public void Dodaj(string zaDodavanje)
    {
        for (int i = 0; i < ItemiAktivni.Length; i++)
        {
            if (ItemiAktivni[i]!=null)
            if (ItemiAktivni[i].id == zaDodavanje)
            {
                ItemiAktivni[i].kolicina++;
                 UpdejtujAktivanMeni();
                return;
            }
        }
        for(int i = 0;i<Inventori.Count;i++)
        {
            if (Inventori[i].id == zaDodavanje)
            {
                Inventori[i].kolicina++;
                InventoryUpdejtAlati(); 

                return;
            }
        }
        for(int i = 0;i<SviItemi.Count;i++) {
            if (SviItemi[i].id == zaDodavanje)
            {
                Inventori.Add(SviItemi[i]);
                InventoryUpdejtAlati();
                return;
            }
        }
    }
    public void Equipuj(string zaEquipuj)
    {
        for(int i = 0;i<Inventori.Count;i++)
        {
            if (Inventori[i].id == zaEquipuj)
            {
                if (ItemiAktivni[1] == null)
                {
                    ItemiAktivni[1] = Inventori[i];
                    Inventori.RemoveAt(i);
                    UpdejtujAktivanMeni();
                    InventoryUpdejtAlati();
                    return;
                }
                else if (ItemiAktivni[2] == null)
                {
                    ItemiAktivni[2] = Inventori[i];
                    Inventori.RemoveAt(i);
                    UpdejtujAktivanMeni();
                    InventoryUpdejtAlati();
                    return;
                }
            }
        }
    }
    public void InputIskoristi()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (ItemiAktivni[0].ProveriKolicnu())
            {
                ItemiAktivni[0].Iskoristi(transform);
                UpdejtujAktivanMeni();
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha1) && ItemiAktivni[1]!=null)
        {
            if (ItemiAktivni[1].ProveriKolicnu())
            {
                ItemiAktivni[1].Iskoristi(transform);
                UpdejtujAktivanMeni();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && ItemiAktivni[2] != null)
        {
            if (ItemiAktivni[2].ProveriKolicnu())
            {
                ItemiAktivni[2].Iskoristi(transform);
                UpdejtujAktivanMeni();
            }
        }
    }
    public void UpdejtujAktivanMeni()
    {
        for(int i=0;i<ItemiAktivni.Length;i++)
        {
            if (ItemiAktivni[i] != null)
            {
                metakUIAktivni[i].Postavi(ItemiAktivni[i].slika, ItemiAktivni[i].kolicina.ToString(), ItemiAktivni[i].id, this);
            }
            else
                metakUIAktivni[i].Isprazni();
        }
    }


    public void InventoryUpdejtAlati()//updejtuje inv zsa puskama koje je igrac otkljucao
    {

        for (int i = 0; i < contentInventori.transform.childCount; i++)//ixbirse sve sdtara u uinvent0orij uda bi spawnolo nove
        {
            Destroy(contentInventori.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < Inventori.Count; i++)//prilazi kroz otkljcane psuke
        {

            GameObject novoDugmeInv = Instantiate(uiPrefabUnventori, contentInventori);//spanjije dogme
            novoDugmeInv.GetComponent<UIINventoriPOlje>().Postavi(Inventori[i].slika, Inventori[i].kolicina.ToString(), Inventori[i].id,this);//posat6vlja m uslik u iisotale stvari
        }
        UpdejtujINvenoriAktivne();
    }
    public void UpdejtujINvenoriAktivne()
    {
        if (ItemiAktivni[1] != null)
        {
            polje1.Postavi(ItemiAktivni[1].slika, ItemiAktivni[1].kolicina.ToString(), ItemiAktivni[1].id, this);
        }
        else
            polje1.Isprazni();

        if (ItemiAktivni[2] != null)
        {
            polje2.Postavi(ItemiAktivni[2].slika, ItemiAktivni[2].kolicina.ToString(), ItemiAktivni[2].id, this);
        }
        else
            polje2.Isprazni();
    }
    public void DeEquipuj(int i)
    {
        if (ItemiAktivni[i]!=null)
        {
            Item a = ItemiAktivni[i];
            Inventori.Add(a);
            ItemiAktivni[i] = null;
            InventoryUpdejtAlati();

        }
    }
}


