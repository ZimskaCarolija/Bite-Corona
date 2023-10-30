using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unisti : MonoBehaviour
{
    // Start is called before the first frame update
    public float Vreme;//vreme z akoje s eunisti objekat
    private void Start()
    {
        StartCoroutine(Unisti_fja());
    }
    IEnumerator Unisti_fja()
    {
        yield return new WaitForSeconds(Vreme);
        Destroy(gameObject);
    }
}
