using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgracKretanje : MonoBehaviour
{
    // Start is called before the first frame update
    public float Brzina;//kolika je brzina kretanje
    public bool MozeKretanje = true;//dali iggrac moze d as e krece  ako je u cutsceni ili pod nekim efektom ovo ce biti false
    private Rigidbody2D rb;//rigid body komponeta
    private Animator animator;//animator zaduzen za aniaciju kretanje
    public GameObject prasinaPart;//partikle prasina koja se ukljucuje kada s eigrac krece
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();//nalazi komponetu rigidbody od igraca
        animator = GetComponent<Animator>();//nalazi komponentu animator od igraca
    }

    // Update is called once per frame
    void Update()
    {
        if (MozeKretanje)
            Kretanje_Fja();
        else
            ZaustaviKrtanje();


        KretanjeAnimacija_Fja();

    }
    public void Kretanje_Fja()//ova funcija je zaduzaenj z apomeranje igraca pomocu rigidbodija
    {
        float X = Input.GetAxis("Horizontal");//uzima x osu -a,d
        float Y = Input.GetAxis("Vertical");//uzima y osu -w,s
        Vector2 vek = new Vector2(X, Y) * Brzina;//racuna novi vektor za kretanje
     
        rb.velocity = vek;//dodeljuje silu igraci
    }
    public void ZaustaviKrtanje()//ova fukcija postavlja jacinu sile rb na 0
    {
        rb.velocity = Vector2.zero;//postavlja krtanje na 0
    }
    public  void KretanjeAnimacija_Fja()//funckija postavlju odredjenu aniamciju igracu za kretanje
    {
        if (rb.velocity != Vector2.zero)//provera dal ise igrac krece to jest dla i mi je sila 0
        {
            animator.SetBool("kretanje", true);//postavlja krtanje - na true
            prasinaPart.SetActive(true);//ukljucuje partikle prasiu z aefekat kretanje
        }
        else
        {
            animator.SetBool("kretanje", false);
            prasinaPart.SetActive(false);
        }
    }
}
