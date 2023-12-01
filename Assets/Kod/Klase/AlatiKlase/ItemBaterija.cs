using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBaterija : Item
{

    public PuskaMenadzer puskeM;
    public GameObject Efekat;

    public ItemBaterija(string id, Sprite slika, int kolicina, int cena, GameObject Efekat, PuskaMenadzer puskeM) : base(id, slika, kolicina, cena)
    {
        this.puskeM = puskeM;
        this.Efekat = Efekat;
    }
    public override void Iskoristi(Transform pozicija)
    {
        
        //pozicija.position = new Vector2(pozicija.position.x,pozicija.position.y+1);
        KLasaSpawnovanje.Spawnuj(Efekat, pozicija);
        puskeM.boost.DodajStruju(10);
        base.Iskoristi(pozicija);
    }
}
