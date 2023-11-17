using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIljkaTurrent : PUcanjeNeprjatelj
{
    // Start is called before the first frame update
    public List<Transform> mete;
    public NeprijateljPUskaKod puskaKod;
    public float Trajanje;
    void Start()
    {
        List<Transform> mete = new List<Transform>();
        StartCoroutine(Unisti());
    }

    // Update is called once per frame
    void Update()
    {
        DoPUcanjaFja(Time.deltaTime);
        puskaKod.target = VratiNajblizi();
        
    }
    public override void Pucanj()
    {
        GameObject pom = Instantiate(Metak);
        pom.GetComponent<Rigidbody2D>().velocity = puska.right * Brzina;
        pom.transform.position = transform.position;
        pom.transform.rotation = transform.rotation;
        pom.GetComponent<Metak>().Podesi(Range,DMG);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<NeprijateljHP>())
        {
            mete.Add(collision.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<NeprijateljHP>())
        {
            mete.Remove(collision.transform);
        }
    }
    public Transform VratiNajblizi()
    {
        if (mete.Count < 1)
            return null;
        Transform najblizi = mete[0];

        foreach(Transform t in mete)
        {
            if (Vector3.Distance(this.transform.position, t.transform.position) < Vector3.Distance(this.transform.position, najblizi.position))
                najblizi = t;
        }
        return najblizi;
    }
    IEnumerator Unisti()
    {
        yield return new WaitForSeconds(Trajanje);
        Destroy(transform.parent.gameObject);
    }

}
