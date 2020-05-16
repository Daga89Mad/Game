using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    bool volveramenu = false;
    bool jugar = false;
    bool misiones = false;
    bool online = false;
    bool nuevapartida = false;
    bool equipo = false;
    bool objetos = false;
    bool opciones = false;
    bool boton = false;
    bool boton2 = false;
    bool dejarjugar = false;
    Animator animJugar;
    Animator animOnline;
    Animator animMisiones;
    Animator animNuevaPartida;
    Animator animEquipo;
    Animator animObjetos;
    Animator animOpciones;
    Animator animCamara;

    // Start is called before the first frame update
    void Start()
    {
       // animJugar = GameObject.Find("Jugar").GetComponent<Animator>();
        animOnline = GameObject.Find("Online").GetComponent<Animator>();
        animMisiones = GameObject.Find("Misiones").GetComponent<Animator>();
        animNuevaPartida = GameObject.Find("NuevaPartida").GetComponent<Animator>();
        animEquipo = GameObject.Find("Equipo").GetComponent<Animator>();
        animObjetos = GameObject.Find("Objetos").GetComponent<Animator>();
        animOpciones = GameObject.Find("Opciones").GetComponent<Animator>();
        animCamara = GameObject.Find("Main Camera").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jugar)
        {
            jugar = false;
            //animJugar.SetInteger("Desplegar",1);
            animOnline.SetInteger("Desplegar", 1);
            animMisiones.SetInteger("Desplegar", 1);
            animNuevaPartida.SetInteger("Desplegar", 1);
            animEquipo.SetInteger("Desplegar", 1);
            animObjetos.SetInteger("Desplegar", 1);
            animOpciones.SetInteger("Desplegar", 1);

        }
        if(dejarjugar)
        {
            dejarjugar = false;
            //animJugar.SetInteger("Desplegar",0);
            animOnline.SetInteger("Desplegar", 0);
            animMisiones.SetInteger("Desplegar", 0);
            animNuevaPartida.SetInteger("Desplegar", 0);
            animEquipo.SetInteger("Desplegar", 0);
            animObjetos.SetInteger("Desplegar", 0);
            animOpciones.SetInteger("Desplegar", 0);
        }
        if (misiones)
        {

            misiones = false;
            animCamara.SetInteger("Desplegar", 1);

        }
        if (volveramenu)
        {
            volveramenu = false;
            animCamara.SetInteger("Desplegar", 0);

        }
        
    }
    public void Jugar()
    {
        int desplegar= animOnline.GetInteger("Desplegar");

        if (desplegar==1)
        {
            dejarjugar = true;

        }
        else
        {
            jugar = true;
        }
 
       
    }
    public void DejarJugar()
    {
         dejarjugar = true;

    }
    public void Misiones()
    {
        misiones = true;
        volveramenu = false;
    }
    public void VolverAMenu()
    {
        volveramenu = true;
        misiones = false;
    }
    public void Online()
    {
        online = true;
    }
    public void NuevaPartida()
    {
        nuevapartida = true;
    }
    public void Equipo()
    {
        equipo = true;
    }
    public void Objetos()
    {
        objetos = true;
    }
    public void Opciones()
    {
        opciones = true;
    }
    public void Boton()
    {
        boton = true;
    }
    public void Boton2()
    {
        boton2 = true;
    }

}
