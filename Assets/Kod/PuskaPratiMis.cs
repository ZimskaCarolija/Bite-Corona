using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuskaPratiMis : MonoBehaviour
{
    // Start is called before the first frame update
    public float X;//scale x
    public float Y;//scala Y
    void Start()
    {
        
    }

    // Update is called once per frame

        void Update()
        {
            // Uzmite trenutnu poziciju misa
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // vektor racuna 
            Vector3 direction = (mousePosition - transform.position).normalized;

            // izracubnava roaicj
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //rotira
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
           if(angle>90 ||  angle<-90)//provera dal ije puska da drugo jstrani to jest naopacke
            transform.localScale = new Vector2(X, -Y);//menja sclau
           else
            transform.localScale = new Vector2(X, Y);
    }
    
}
