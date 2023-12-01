using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSibice : Item
{
    public PuskaMenadzer puskeM;
    public GameObject Efekat;

    public ItemSibice(string id, Sprite slika, int kolicina, int cena, GameObject Efekat, PuskaMenadzer puskeM):base(id,slika,kolicina,cena)
    {
        this.puskeM = puskeM;
        this.Efekat = Efekat;
    }
    public override void Iskoristi(Transform pozicija)
    {
        KLasaSpawnovanje.Spawnuj(Efekat, pozicija);
        puskeM.boost.DodajVatru(10);
        base.Iskoristi(pozicija);
    }

}
