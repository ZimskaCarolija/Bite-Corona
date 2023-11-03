using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGPrenos : MonoBehaviour
{

    public float DMGMetka;//base dmg
    private float DMG;//ukupan dmg racunas e uu metodi
    public bool Vatra;//dal inanosi vatreni mdg
    public bool Otrov;//dali nanosi otrov
    public bool Struja;//dal inanso ielektricni dmg
    public bool LifeSteal;//dal inanso ilife steal
    public float ProcenatLifeSteala;//broj kao mnizlica 1 je 100% 0.5je 50% itd
    public DMGPrenos(float DMGMetka, bool Vatra, bool Otrov, bool Struja, bool LifeSteal, float ProcenatLifeSteala)
    {
        this.DMG = DMGMetka;
        this.DMGMetka = DMGMetka;
        this.Vatra = Vatra;
        this.Otrov = Otrov;
        this.Struja = Struja;
        this.LifeSteal = LifeSteal;
        this.ProcenatLifeSteala = ProcenatLifeSteala;
    }
   /* public DMGPrenos()
    {
        this.DMG = 0;
        this.DMGMetka = 0;
        this.Vatra = false;
        this.Otrov = false;
        this.Struja = false;
        this.LifeSteal = false;
        this.ProcenatLifeSteala = 0;
    }*/
    public void IzracunaDMG(float Mnozilac)//ova funckija izracunava uku0pan dmg metak  
    {
        this.DMG = DMGMetka * Mnozilac;
    }
    public float UzmiDMG()
    {
        return this.DMG;
    }
}
