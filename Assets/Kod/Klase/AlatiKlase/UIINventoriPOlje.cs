using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIINventoriPOlje : MonoBehaviour
{
    public string Id;
    public Image slika;
    public Text textKolicina;
    public Alati alati;
    public void Postavi(Sprite SlikaP, string Kol, string id, Alati alatiPOm)//postavalja stavri koje trbaju
    {
        Id = id;
        slika.sprite = SlikaP;

        textKolicina.text = Kol;
       alati = alatiPOm;
    }
    public void Equip()
    {
        alati.Equipuj(Id);
    }
    public void Isprazni()
    {
        textKolicina.text = "";
        slika.sprite = null;
        Id = "";
    }
    public void DeqEUIPUJ(int i)
    {
        alati.DeEquipuj(i);
    }
}

