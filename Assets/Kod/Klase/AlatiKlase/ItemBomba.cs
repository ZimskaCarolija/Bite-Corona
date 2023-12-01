using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBomba : Item
{
    public GameObject Bomba;

    public ItemBomba(string id, Sprite slika, int kolicina, int cena,GameObject bomba):base(id,slika,kolicina,cena)
    {
        this.Bomba = bomba;
    }
    public override void Iskoristi(Transform pozicija)
    {
        KLasaSpawnovanje.Spawnuj(this.Bomba, pozicija);
        base.Iskoristi(pozicija);
    }
}
