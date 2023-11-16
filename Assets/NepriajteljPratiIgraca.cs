using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NepriajteljPratiIgraca : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    NavMeshAgent agent;
    public bool Pronadjen = false;
    public Animator anim;
    public float razdaljina_Vrednost;//koliku razadljinu odrzava nepriajtelj
    public bool razdaljinaT = true;

    public Vector3 proslipolozaj;//ovo uporedjuje dalis e krece
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        proslipolozaj = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pronadjen)
            ProveriRazdaljinu();
        kretanje();
        ANiamcija();
    }
    public void kretanje()
    {

        if (Pronadjen && razdaljinaT)
            agent.SetDestination(target.position);
        else
            agent.SetDestination(transform.position);
    }
    public void PronadjenFja()
    {
        Pronadjen = true;
    }
    public void ProveriRazdaljinu()
    {
        if(Vector3.Distance(transform.position,target.position) < razdaljina_Vrednost)
        {
            razdaljinaT = false;
        }
        else
            razdaljinaT=true;
    }
    public void ANiamcija()
    {
       
        if(transform.position == proslipolozaj)
        {
            anim.SetBool("Kretanje", false);
        }
        else
        {
            anim.SetBool("Kretanje", true);
        }
        proslipolozaj = transform.position;
    }
}
