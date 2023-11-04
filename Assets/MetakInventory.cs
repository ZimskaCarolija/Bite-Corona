using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MetakInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public string Id;
    public Image slika;
    public Text textKolicina;
    public PuskaMenadzer menadzer;
    public void Postavi(Sprite SlikaP,string Kol,string id,PuskaMenadzer men)//postavalja stavri koje trbaju
    {
        Id = id;
        slika.sprite = SlikaP;

        textKolicina.text = Kol;
        menadzer = men;
    }
    public void Equip()
    {
        menadzer.EquipujMetak(Id);
    }
}
