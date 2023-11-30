using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boostovi 
{
    public int BrojVatre =0;
    public int BrojStruje =0;
    public int BrojLifeSteal =0;//life steal
    public int BrojOtrova =0;


    public Boostovi() { 
        this.BrojVatre = 0;
        this.BrojStruje = 0;
        this.BrojLifeSteal = 0;
        this.BrojStruje = 0;
    }
    public void DodajVatru(int kolicina)
    {
        this.BrojVatre += kolicina;
    }
    public void DodajOtrov(int kolicina)
    {
        this.BrojOtrova += kolicina;
    }
    public void DodajLifeSteal(int kolicina)
    {
        this.BrojLifeSteal += kolicina;
    }
    public void DodajStruju(int kolicina)
    {
        this.BrojStruje += kolicina;
    }
    public void Smanji()
    {
        if (this.BrojVatre > 0)
            this.BrojVatre--;
        if(this.BrojLifeSteal >0)
            this.BrojLifeSteal--;
        if(this.BrojOtrova>0)
            this.BrojOtrova--;
        if(this.BrojStruje>0)
            this.BrojStruje--;
    }
    public bool Ima_Vatru()
    {
        if (this.BrojVatre > 0)
            return true;
        return false;
    }
    public bool Ima_Struju()
    {
        if (this.BrojStruje > 0)
            return true;
        return false;
    }
    public bool Ima_Otrov()
    {
        if (this.BrojOtrova > 0)
            return true;
        return false;
    }
    public bool Ima_LifeSteal()
    {
        if (this.BrojLifeSteal > 0)
            return true;
        return false;
    }

}
