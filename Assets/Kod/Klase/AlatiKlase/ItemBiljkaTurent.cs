using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBiljkaTurent : Item
{
    public GameObject SpawnovanjeTurent;
    public ItemBiljkaTurent(string id, Sprite slika, int kolicina, int cena,GameObject SpawnovanjeTurent) :base(id,slika,kolicina,cena)
    {
        this.SpawnovanjeTurent = SpawnovanjeTurent;
    }
    public override void Iskoristi(Transform pozicija)
    {
        KLasaSpawnovanje.Spawnuj(SpawnovanjeTurent,pozicija);
        base.Iskoristi(pozicija);
    }
}
