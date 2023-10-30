using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuskaSIngleFire : PuskaRafalBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (MozePucanje && puskaM.MozePucanje)
        {
            if (SpremnoPucanje && Input.GetMouseButtonDown(0))
            {
                SpremnoPucanje = false;
                Pucanj_Fja();
                PUstiEfekat();
                StartCoroutine(KrajCOldowna());
            }
        }
    }
}
