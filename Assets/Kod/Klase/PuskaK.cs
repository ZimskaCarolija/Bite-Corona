using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuskaK : MonoBehaviour
{
    public string id;//id kojim pronalazimo istancu klase  u  listama
    public GameObject objekat;//objkaet ko jise spawnuje u rkama igraca
    public Sprite slika;//slika koja sluzi za ui

    public PuskaK(string id, GameObject objekat, Sprite slika)//konstruktor
    {
        this.id = id;
        this.objekat = objekat;
        this.slika = slika;
    }
}
