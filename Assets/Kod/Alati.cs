using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alati : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Item> SviItemi = new List<Item>();
    public List<Item> Inventori = new List<Item>();

    public MetakInventory[] metakUIAktivni = new MetakInventory[3];
    public Item[] ItemiAktivni = new Item[3];
    public ItemSokParadajz SokParadajz;


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
    void Start()
    {
        SokParadajz = new ItemSokParadajz("SokParadajz", SokOdParadajzaSlika, 1, 10, hp);
        ItemiAktivni[0] = SokParadajz;
        ItemiAktivni[1] = null;
        ItemiAktivni[2] = null;
        PopuniSve();
        Dodaj("BijklaTurrent");
        Equipuj("BijklaTurrent");
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

    }
    public void Dodaj(string zaDodavanje)
    {
        for (int i = 0; i < ItemiAktivni.Length; i++)
        {
            if (ItemiAktivni[i]!=null)
            if (ItemiAktivni[i].id == zaDodavanje)
            {
                ItemiAktivni[i].kolicina++;
                return;
            }
        }
        for(int i = 0;i<Inventori.Count;i++)
        {
            if (Inventori[i].id == zaDodavanje)
            {
                Inventori[i].kolicina++;
                return;
            }
        }
        for(int i = 0;i<SviItemi.Count;i++) {
            if (SviItemi[i].id == zaDodavanje)
            {
                Inventori.Add(SviItemi[i]);
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
                   
                    return;
                }
                else if (ItemiAktivni[2] == null)
                {
                    ItemiAktivni[2] = Inventori[i];
                    Inventori.RemoveAt(i);
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
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha1) && ItemiAktivni[1]!=null)
        {
            if (ItemiAktivni[1].ProveriKolicnu())
            {
                ItemiAktivni[1].Iskoristi(transform);
            }
        }
    }
}


