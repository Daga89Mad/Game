using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class MoviCompa : MonoBehaviour
{
    public GameObject Disparos;
    GameObject Ataque;
    int Cont = 0;
    Rigidbody rb;
    public float Fuerza;
    float SegActual=0f;
    float SegTotal=4.9f;
    int AtaquesTotales=3;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        SegActual += Time.deltaTime;
       // Debug.Log(SegActual.ToString());
        if (SegActual > SegTotal) {
            Magia();
            AtaquesTotales = 0;
            SegActual = 0f;
        }
       
    }

    public void Magia()
    {
        if (AtaquesTotales < 1)
        {
            Vector3 Posicion = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(Disparos, Posicion, Quaternion.identity);
            Ataque = GameObject.Find("Sphere(Clone)");
            Destroy(Ataque,3);
            rb = Ataque.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * Fuerza);
            AtaquesTotales++;
        }

    }
}
