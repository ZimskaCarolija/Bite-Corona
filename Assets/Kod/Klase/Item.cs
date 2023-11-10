using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public string id;
    public Sprite slika;
    public int kolicina;
    public int maxKolicina;
    public int cena;

    public Item(string id, Sprite slika, int kolicina, int maxKolicina, int cena)
    {
        this.id = id;
        this.slika = slika;
        this.kolicina = kolicina;
        this.maxKolicina = maxKolicina;
        this.cena = cena;
    }
    public void Iskoristi()//koriscenje abiltija
    {
        kolicina--;
        return;
    }
}
