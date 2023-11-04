using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenadzer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Meni;//menia objerakt ui
    public bool MeniAktivan = false;//dal ij  emeni aktivan
    public PuskaMenadzer puskaM;
    public GameObject PUskeMeni;
    public GameObject MetkoivMeni;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(MeniAktivan)
            {
                Meni.SetActive(false);
                MeniAktivan = false;
                puskaM.MozePucanje = true;
            }
            else
            {
                Meni.SetActive(true);
                MeniAktivan=true;
                puskaM.MozePucanje =false;
                puskaM.UpdejtujUIMetkoviInv();
            }

        }
    }
    public void PUske()
    {
        PUskeMeni.SetActive(true);
        MetkoivMeni.SetActive(false);
    }
    public void Metkovi()
    {
        PUskeMeni.SetActive(false);
        MetkoivMeni.SetActive(true);
        
    }
}
