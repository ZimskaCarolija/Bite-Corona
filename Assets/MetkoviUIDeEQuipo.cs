using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MetkoviUIDeEQuipo : MonoBehaviour
{
    // Start is called before the first frame update
    public PuskaMenadzer menadzer;
    public int Index;//koji je index u incwenotiju
    public Image slika;
    public Text Kolicina;

    public void Postavi(Sprite Slika,string KolicinaB)
    {
        slika.sprite = Slika;
        Kolicina.text = KolicinaB;
    }
    public void DeEquipuj()
    {
        menadzer.DeEquipujMetak(Index);
        slika.sprite = null;
        Kolicina.text = "";
    }
}
