using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personalizar : MonoBehaviour
{
    public Atributos.Personalizacion Atributos = new Atributos.Personalizacion();
    Android conexion = new Android();
    public GameObject compas;

    //public GameObject CanvInformacion;
    public GameObject CanvMenuPersonalizacion;
    public GameObject CanvCabezaPersonalizacion;
    public GameObject CanvTrajePersonalizacion;
    public GameObject CanvArmaPersonalizacion;
    public GameObject CanvCompaPersonalizacion;
    public GameObject CanvHabilidadesPersonalizacion;
    public GameObject CanvObjetos;
    protected GameObject Personaje;
    //protected GameObject PersonajeArma;
    public GameObject PersonajeClon;
    public GameObject PersonajeArmaClon;
    protected Animator anim;
    // Start is called before the first frame update

    void Start()
    {
        Personaje = GameObject.Find("0.1.Daga");
        if (PersonajeClon==null) {
            PersonajeClon = GameObject.Find("0.1.DagaClon");
        }
        anim = GameObject.Find("0.1.Daga").GetComponent<Animator>();
        //Actualizar();
    }
    //public void CambiarCasco(int Id,int IdCasco)
    //{
    //   var _idCasco = IdCasco.ToString() + ".";
    //    GameObject Personaje= GameObject.Find("0.Daga");
    //    Transform transform = Personaje.transform;
        
    //    foreach (Transform child in transform)
    //    {
    //        if (child.name.Substring(0, 2) == "3.")
    //        {
    //            if (child.name.Substring(2, 2) == _idCasco)
    //            {
    //                GameObject objeto = child.gameObject;
    //                objeto.SetActive(true);

    //            }
    //            else
    //            {
    //                GameObject objeto = child.gameObject;
    //                objeto.SetActive(false);

    //            }

    //        }
    //    }

    //}
    public void CambiarEquipo(int Id, int IdEquipo)
    {
        var _idEquipo = IdEquipo.ToString() + ".";
        var _id = Id.ToString() + ".";
        Personaje = GameObject.Find("0.1.Daga");//Si pongo start en el start() no lo encuentra porque la llamada a esta funcion viene de Scroll.cs
        Transform transform = Personaje.transform;       
        if (_id == "2.")
        {
           transform = transform.Find("metarig/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R");
                    
        }
        if (_id == "5.")
        {
            transform = transform.Find("Compas");

        }
        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 2) == _id)
            {
                if (child.name.Substring(2, 2) == _idEquipo)
                {
                    GameObject objeto = child.gameObject;
                    objeto.SetActive(true);

                }
                else
                {
                    GameObject objeto = child.gameObject;
                    objeto.SetActive(false);

                }

            }
        }

    }
    public void Atras()
    {
        //CanvInformacion.SetActive(false);
        CanvMenuPersonalizacion.SetActive(true);
        CanvCabezaPersonalizacion.SetActive(false);
        CanvArmaPersonalizacion.SetActive(false);
        anim.SetInteger("Accion", 0);
        //CanvTrajePersonalizacion.SetActive(false);      
        CanvCompaPersonalizacion.SetActive(false);
        compas.SetActive(false);
        //CanvObjetos.SetActive(false);
        //CanvArmaPersonalizacion.SetActive(false);
    }
    public void Cabeza()
    {
       // CanvInformacion.SetActive(false);
        CanvMenuPersonalizacion.SetActive(false);
        CanvCabezaPersonalizacion.SetActive(true);
    }
    public void Traje()
    {
       // CanvInformacion.SetActive(false);
        CanvMenuPersonalizacion.SetActive(false);
        CanvTrajePersonalizacion.SetActive(true);
    }
    public void Armas()
    {
       // CanvInformacion.SetActive(false);
        CanvMenuPersonalizacion.SetActive(false);
        CanvArmaPersonalizacion.SetActive(true);
        anim.SetInteger("Accion", 20);
    }
    public void Objetos()
    {
        //CanvInformacion.SetActive(false);
        CanvMenuPersonalizacion.SetActive(false);
        // CanvTrajePersonalizacion.SetActive(false);
        // CanvCabezaPersonalizacion.SetActive(false);
        //CanvCompaPersonalizacion.SetActive(true);
        CanvObjetos.SetActive(true);
    }
    public void Compa()
    {
        //CanvInformacion.SetActive(false);
        CanvMenuPersonalizacion.SetActive(false);
        compas.SetActive(true);
        // CanvTrajePersonalizacion.SetActive(false);
        // CanvCabezaPersonalizacion.SetActive(false);
       // CanvArmaPersonalizacion.SetActive(false);
        CanvCompaPersonalizacion.SetActive(true);
    }
    public void Habilidades()
    {
       // CanvInformacion.SetActive(false);
        CanvMenuPersonalizacion.SetActive(false);
        // CanvTrajePersonalizacion.SetActive(false);
        // CanvCabezaPersonalizacion.SetActive(false);
        // CanvArmaPersonalizacion.SetActive(false);
        CanvHabilidadesPersonalizacion.SetActive(true);
    }
     
    public void Guardar()
    {
        string DobleCifra;
        string idCasco = "0";
        string idCapucha = "0";
        string idArma = "0";
        string idTraje = "0";
        string idCompa = "0";
        Transform _transform;
        /* Recorrer con un for los objetos activo coger el nombre que tendra aqui 3 ids en el juego 2 o 1 ya veremos.
         * Aqui un id que representa que tipo de objeto es (un casco,un arma....) el segundo es el id del objeto.*/
        foreach (Transform child in Personaje.transform)//Aqui buscamos cascos,capuchas y, trajes
        {
            if (child.gameObject.activeInHierarchy)
            {
                string Tipo = child.name.Substring(0, 1);
                switch (Tipo)
                {
                    case "6"://Casco.
                        DobleCifra = child.name.Substring(3, 1);
                        if (DobleCifra == ".")
                        {
                            idCasco = child.name.Substring(2, 1);
                        }
                        else
                        {
                            idCasco = child.name.Substring(2, 2);
                        }
                        break;
                    case "4"://Capucha.
                        DobleCifra = child.name.Substring(3, 1);
                        if (DobleCifra == ".")
                        {
                            idCapucha = child.name.Substring(2, 1);
                        }
                        else
                        {
                            idCapucha = child.name.Substring(2, 2);
                        }
                        break;

                    case "7"://Traje.
                        DobleCifra = child.name.Substring(3, 1);
                        if (DobleCifra == ".")
                        {
                            idTraje = child.name.Substring(2, 1);
                        }
                        else
                        {
                            idTraje = child.name.Substring(2, 2);
                        }
                        break;                       
                }

            }
        }
        //Armas
        _transform = Personaje.transform.Find("metarig/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R");
        foreach (Transform child in _transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                string Tipo = child.name.Substring(0, 1);
                if (Tipo == "2")
                {
                    DobleCifra = child.name.Substring(3, 1);
                    if (DobleCifra == ".")
                    {
                        idArma = child.name.Substring(2, 1);
                    }
                    else
                    {
                        idArma = child.name.Substring(2, 2);
                    }
                }               

            }
        }
        //Compas
        _transform= Personaje.transform.Find("Compas");
        GameObject _compas = _transform.gameObject;
        _compas.SetActive(true);//Tengo que activarlos y desactivarlos para que encuentre el id con 6 compas no se nota habrá que ver que pasa con mas
        foreach (Transform child in _transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                string Tipo = child.name.Substring(0, 1);
                if (Tipo == "5")
                {
                    DobleCifra = child.name.Substring(3, 1);
                    if (DobleCifra == ".")
                    {
                        idCompa = child.name.Substring(2, 1);
                    }
                    else
                    {
                        idCompa = child.name.Substring(2, 2);
                    }
                }

            }
        }
        _compas.SetActive(false);

        //idPersonaje
        DobleCifra = Personaje.name.Substring(3, 1);
        string idPersonaje;
        if (DobleCifra == ".")
        {
            idPersonaje = Personaje.name.Substring(2, 1);
        }
        else
        {
            idPersonaje = Personaje.name.Substring(2, 2);
        }
        int _idpersonaje;
        int _idcasco;
        int _idcapucha;
        int _idarma;
        int _idtraje;
        int _idcompa;

        int.TryParse(idPersonaje, out _idpersonaje);
        int.TryParse(idCasco, out _idcasco);
        int.TryParse(idCapucha, out _idcapucha);
        int.TryParse(idArma, out _idarma);
        int.TryParse(idTraje, out _idtraje);
        int.TryParse(idCompa, out _idcompa);

        conexion.update_Personaje(_idpersonaje, _idcasco, _idarma, _idtraje, _idcompa, _idcapucha);
    }
    public void Actualizar()
    {
        string idCasco = "0";
        string idCapucha = "0";
        string idArma = "0";
        string idTraje = "0";
        string idCompa = "0";
        int Activar = 0;

        string DobleCifra = PersonajeClon.name.Substring(3, 1);
        string idPersonaje;
        if (DobleCifra == ".")
        {
            int.TryParse(PersonajeClon.name.Substring(2, 1), out Atributos.IdPersonaje);
        }
        else
        {
            int.TryParse(PersonajeClon.name.Substring(2, 2), out Atributos.IdPersonaje);
        }
        Atributos = conexion.CargarDatosPersonalizacion(Atributos.IdPersonaje);

        /* Recorrer con un for los objetos activo coger el nombre que tendra aqui 3 ids en el juego 2 o 1 ya veremos.
         * Aqui un id que representa que tipo de objeto es (un casco,un arma....) el segundo es el id del objeto.*/
        foreach (Transform child in PersonajeClon.transform)
        {
            string Tipo = child.name.Substring(0, 1);
            switch (Tipo)
            {
                case "6"://Casco.

                    DobleCifra = child.name.Substring(3, 1);
                    if (DobleCifra == ".")
                    {
                        idCasco = child.name.Substring(2, 1);
                    }
                    else
                    {
                        idCasco = child.name.Substring(2, 2);
                    }
                    Activar = 0;
                    int.TryParse(idCasco, out Activar);
                    if (Activar == Atributos.IdCasco)
                    {
                        child.gameObject.SetActive(true);
                    }
                    else
                    {
                        child.gameObject.SetActive(false);
                    }
                    break;
                case "4"://Capucha.

                    DobleCifra = child.name.Substring(3, 1);
                    if (DobleCifra == ".")
                    {
                        idCapucha = child.name.Substring(2, 1);
                    }
                    else
                    {
                        idCapucha = child.name.Substring(2, 2);
                    }
                    Activar = 0;
                    int.TryParse(idCapucha, out Activar);
                    if (Activar == Atributos.IdCapucha)
                    {
                        child.gameObject.SetActive(true);
                    }
                    else
                    {
                        child.gameObject.SetActive(false);
                    }
                    break;


                case "7"://Traje.

                    DobleCifra = child.name.Substring(3, 1);
                    if (DobleCifra == ".")
                    {
                        idTraje = child.name.Substring(2, 1);
                    }
                    else
                    {
                        idTraje = child.name.Substring(2, 2);
                    }
                    Activar = 0;
                    int.TryParse(idTraje, out Activar);
                    if (Activar == Atributos.IdTraje)
                    {
                        child.gameObject.SetActive(true);
                    }
                    else
                    {
                        child.gameObject.SetActive(false);
                    }
                    break;
                //case "4"://Compa.

                //    DobleCifra = child.name.Substring(3, 1);
                //    if (DobleCifra == ".")
                //    {
                //        idCompa = child.name.Substring(2, 1);
                //    }
                //    else
                //    {
                //        idCompa = child.name.Substring(2, 2);
                //    }
                //    Activar = 0;
                //    int.TryParse(idCompa, out Activar);
                //    if (Activar == Atributos.IdCompa)
                //    {
                //        child.gameObject.SetActive(true);
                //    }
                //    else
                //    {
                //        child.gameObject.SetActive(false);
                //    }
                //    break;
            }
        }
        Transform _transform = PersonajeClon.transform.Find("metarig/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R");
        foreach (Transform child in _transform)
        {          
                string Tipo = child.name.Substring(0, 1);
                if (Tipo == "2")
                {
                    DobleCifra = child.name.Substring(3, 1);
                    if (DobleCifra == ".")
                    {
                        idArma = child.name.Substring(2, 1);
                    }
                    else
                    {
                        idArma = child.name.Substring(2, 2);
                    }
                    Activar = 0;
                    int.TryParse(idArma, out Activar);
                    if (Activar == Atributos.IdArma)
                    {
                        child.gameObject.SetActive(true);
                    }
                    else
                    {
                        child.gameObject.SetActive(false);
                    }
                }

            
        }
        try
        {
            compas.SetActive(false);
        }
        catch
        {
            
        }
 
    }
}
