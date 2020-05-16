using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {
    public GameObject Bala;
    GameObject Ataque;
    GameObject s;
    float SegActual = 0f;
    float SegTotal = 4.9f;
    Rigidbody rb;
    public float Fuerza;
    bool DispararOn = false;
    int t = 0;
    APlayer p;
    void Start()
    {
        Bala = GameObject.Find("2.Bala");
    }
    // Use this for initialization

    // Update is called once per frame
    void Update () {
        if (t == 1)
        {
            t=0;
            if (DispararOn)
            {

                //if (GameObject.Find("Capsule(Clone)") == null)
                //{
                    //s = GameObject.Find("Bala");
                    //Bala.SetActive(true);
                    Vector3 Posicion = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    
                    Ataque = Instantiate(Bala, Posicion, gameObject.transform.rotation /*, s.transform*/);
                //Ataque.transform.position = Posicion;
                Ataque.transform.parent = gameObject.transform;
                    Destroy(Ataque, 3);
                    rb = Ataque.GetComponent<Rigidbody>();
                    rb.AddForce(transform.forward * Fuerza, ForceMode.Impulse);
                       
                    //Ataque = null;
                //}
                //else if (GameObject.Find("Capsule(Clone)").gameObject.cou)
                //{

                //}
               

            }
        }

       

    }
    public void DisparoOn()
    {
        DispararOn = true;
        t++;
    }

    public void DisparoOff()
    {
        DispararOn = false;
        t = 0;

    }
}
