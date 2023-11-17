using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSokParadajz : Item
{
    public IgracHP HP;
    public ItemSokParadajz(string id, Sprite slika, int kolicina, int cena,IgracHP HP) : base(id, slika, kolicina, cena)
    {
        this.HP = HP;
    }
    public override void Iskoristi(Transform pozicija)
    {
        HP.HealujSokom();
        base.Iskoristi(pozicija);
    }
}
