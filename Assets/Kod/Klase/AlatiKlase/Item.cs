using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public string id;
    public Sprite slika;
    public int kolicina;
    public int cena;

    public Item(string id, Sprite slika, int kolicina, int cena)
    {
        this.id = id;
        this.slika = slika;
        this.kolicina = kolicina;
        this.cena = cena;
    }
    public virtual void Iskoristi(Transform pozicija)//koriscenje abiltija
    {
        kolicina--;
        return;
    }
    public bool ProveriKolicnu() //dali mzoe da se iskoristi kod kolicine
    {
        if (kolicina > 0)
            return true;
        else
            return false;
    }
}
