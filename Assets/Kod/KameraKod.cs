using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKod : MonoBehaviour
{
    //kopirao kod sa neta
    public Transform target;
    public Vector3 offset;
    public float smoothTime = 0.3f;

    private Vector3 velocity;


    public Camera kamera;
    public float minimalniZoom = 2.0f;  // Najmanja vrednost za zoom kamere
    public float maksimalniZoom = 10.0f; // Najveća vrednost za zoom kamere
    public float brzinaZooma = 2.0f;
    private void Start()
    {
        kamera = GetComponent<Camera>();
    }
    public void Update()
    {
        // Dobijamo vrednost skrolovanja miša
        float skrol = Input.GetAxis("Mouse ScrollWheel");

        // Računamo novu vrednost za veličinu kamere (zoom)
        float novaVelicina = kamera.orthographicSize - skrol * brzinaZooma;

        // Ograničavamo veličinu kamere unutar zadatih granica
        novaVelicina = Mathf.Clamp(novaVelicina, minimalniZoom, maksimalniZoom);

        // Postavljamo novu veličinu kamere
        kamera.orthographicSize = novaVelicina;
    }
    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x,target.position.y,-10) + offset, ref velocity, smoothTime);
    }
}
