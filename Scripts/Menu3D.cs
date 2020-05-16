using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu3D : MonoBehaviour
{

    public GameObject CanvPersonalizacion;
    public GameObject CanvMisiones;
    public GameObject Personaje;
    public GameObject Compas;
    float i = 0;
    //Personaje Atributos;
    public bool especial = false;
    public GameObject Seleccion;
    public float speed;
    //public GameObject Disparo;
    public GameObject Info;
    public GameObject CachedPosition;
    int Parar = 0;
    Animator animCamara;
    // Start is called before the first frame update
    void Start()
    {
        animCamara = GameObject.Find("Main Camera").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {

            PointerEventData pointerData = new PointerEventData(EventSystem.current);

            pointerData.position = Input.GetTouch(0).position;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {

                Debug.Log("Pantalla tocada");

                if (raycastHit.collider.name == "hologram_LOD0" || raycastHit.collider.name == "projector")
                {
                    string Nombre = raycastHit.collider.name.ToString();

                    CanvMisiones.SetActive(true);
                    CanvPersonalizacion.SetActive(false);
                    Personaje.SetActive(false);
                    animCamara.SetInteger("Desplegar", 1);

                }
                if (raycastHit.collider.name == "0.1.DagaClon")
                {
                    string Nombre = raycastHit.collider.name.ToString();
                    CanvMisiones.SetActive(false);
                    CanvPersonalizacion.SetActive(true);
                    Personaje.SetActive(true);
                    animCamara.SetInteger("Desplegar", 1);
                    //Compas.SetActive(true);


                }
            }
        }
    }
    public void Volver()
    {
        animCamara.SetInteger("Desplegar", 0);
    }
}
