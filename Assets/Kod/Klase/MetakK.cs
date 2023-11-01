using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetakK : MonoBehaviour//ova kalsa vodi racuna o osnovni mstavrima o oemtku u uinventoriju koliko ga ima itd
{
    private int brojMetkova;
    public Sprite Slika;
    public GameObject MetakObj;
    public string Id;//po ovome pronazli metkau u inv

    public MetakK(Sprite Slika,GameObject MetakObj,string Id)
    {
        this.Slika = Slika;
       this.MetakObj = MetakObj;
        this.brojMetkova  = 0;
        this.Id = Id;
    }
    public MetakK(Sprite Slika, GameObject MetakObj, string Id,int brojMetkova)
    {
        this.Slika = Slika;
        this.MetakObj = MetakObj;
        this.brojMetkova = brojMetkova;
        this.Id =Id;
    }
    public bool MozePucanjeKolicina(int Kolicina)//dali ima dovoljno metkova da pukne to jest da potrosi metkove
    {
        if(this.brojMetkova>=Kolicina)
        {
            return true;
        }
        return false;
    }
    public void SmanjiMetkove(int Kolicina)
    {
        this.brojMetkova -= Kolicina;
    }
    public void PovecajBrojMetkova(int Kolicina)
    {
        brojMetkova += Kolicina;
    }
    public string UzmiKOolicinu()//vraca koliko metkova ima kao string
    {
        return this.brojMetkova.ToString();
    }
}
