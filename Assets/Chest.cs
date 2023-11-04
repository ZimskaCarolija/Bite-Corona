using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject>listaDrop = new List<GameObject>();
    public Animator animator;
    public bool UsaoIgrac = false;
    public GameObject interactE;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UsaoIgrac && Input.GetKeyDown(KeyCode.E)) {
            animator.SetBool("Otvara", true);
            StartCoroutine(Unisti());
            foreach (GameObject go in listaDrop) {
                GameObject pom = Instantiate(go);
                float X = Random.Range(-1.0f, 1.0f);
                float Y = Random.Range(-1.0f, 1.0f);
                Debug.Log("X je :" + X + ", Y je " + Y);
                Vector3 randomPosition = transform.position + new Vector3(X, Y, 0);
                pom.transform.position = randomPosition;

            }
        
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Igrac")
        {
            UsaoIgrac = true;
            interactE.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Igrac")
        {
            UsaoIgrac = false;
            interactE.SetActive(false);
        }
    }
    IEnumerator Unisti()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
