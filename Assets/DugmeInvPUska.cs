using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DugmeInvPUska : MonoBehaviour
{
    // Start is called before the first frame update
    public string idPUske;//id psuke 
    public Image SlikaPuskje;//slika puske koja je equipovana to jest meesto za nju
    public PuskaMenadzer menadzerPuska;//menadzerPUske;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Podesi(string id,Sprite slika,PuskaMenadzer medazer)//ova fumnckija podesava parametre 
    {
        idPUske = id;
        SlikaPuskje.sprite = slika;
        menadzerPuska = medazer;

    }
    public void Klik_Fja()//ovo je fja koja se zove kad se dugme klikne
    {
        menadzerPuska.EquipujPUsku(idPUske);
      
    }
}
