using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    Personalizar personalizar = new Personalizar();
    public List<Atributos.Equipo> Equipo;
    public RectTransform scroll;
    public RectTransform scrollCabeza;
    public RectTransform scrollCapucha;
    public GameObject InformacionObjeto;
    public GameObject Objetos;
    public GameObject Habilidad1;
    public GameObject Habilidad2;
    public GameObject Habilidad3;
    public GameObject Ataque;
    public GameObject Esquiva;
    public GameObject Panel;
    Android conexion = new Android();
    public Atributos.Player Atributos = new Atributos.Player();
    // Start is called before the first frame update
    void Start()
    {
        //Objetos = GameObject.Find("Button_resultado");
        //Habilidad1= GameObject.Find("ButtonHabilidad1");
        //Habilidad2 = GameObject.Find("ButtonHabilidad2");
        //Habilidad3 = GameObject.Find("ButtonHabilidad3");
        //Ataque= GameObject.Find("ButtonAtacar");
        //Esquiva= GameObject.Find("ButtonEsquivar");
        //Panel = GameObject.Find("Panel_Scroll");
        if (gameObject.name == "FondoCabeza")
        {
            VecesCabeza();
        }
        if (gameObject.name == "FondoArmas")
        {
            VecesArmas();
        }
        if (gameObject.name == "FondoCompas")
        {
            VecesCompa();
        }
        if (gameObject.name == "FondoTrajes")
        {
            VecesTrajes();
        }
        if (gameObject.name == "FondoObjetos")
        {
            VecesObjetos();
        }
        //scroll.offsetMin = new Vector2(1, -100);
        //scroll.offsetMax = new Vector2(0, 0);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void Veces(int veces, List<Atributos.Player> listaHabilidades,int Ventana=0)
    {
       // Vector3 PosicionPanel =  new Vector3(Panel.transform.position.x, Panel.transform.position.y, Panel.transform.position.z);
        int posicionmin = 1;
       // int posicionmax = 1;

        for (int i = 0; i < veces; i++)
        {
            //posicionmax = posicionmax + 100;
            GameObject ObjetoHijo= Instantiate(Objetos) as GameObject;
            ObjetoHijo.transform.SetParent(scroll.transform);
            ObjetoHijo.name = "Resultado" + i;
            RectTransform ResultadoPanel = ObjetoHijo.GetComponent<RectTransform>();
            //Reseteamos los valores
            ResultadoPanel.localScale = new Vector3(1f,1f,1f);
            ResultadoPanel.anchorMin = new Vector2(0f, 0f);
            ResultadoPanel.anchorMax = new Vector2(1f, 1f);
            ResultadoPanel.pivot = new Vector2(0.5f, 0.5f);
            ResultadoPanel.anchoredPosition3D = new Vector3(0f, 0f, 0f);
            ResultadoPanel.rotation = scroll.rotation;
            ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.x, 1);
            ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.x, 1);
            ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.y, posicionmin);
            ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.y, posicionmin);
            posicionmin = posicionmin - 140;
            //El primer numero representa si es la magia 1,2 o 3 el segundo repesenta en id de la habilidad.
            ObjetoHijo.name = Ventana.ToString() +"."+listaHabilidades[i].Habilidad1.ToString()+"."+ ObjetoHijo.name;
            Transform[] allChildren = ObjetoHijo.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.name == "Titulo")
                {
                    // GameObject Titulo = child.gameObject;
                    Text Titulo = child.GetComponent<Text>();
                    Titulo.text = listaHabilidades[i].NombreHabilidad1;
                }
                if (child.name == "Descripcion")
                {
                    // GameObject Titulo = child.gameObject;
                    Text Titulo = child.GetComponent<Text>();
                    Titulo.text = listaHabilidades[i].DescripcionHabilidad1;
                }
            }
        }
        //scroll.offsetMin = new Vector2(1, posicion.y);
        //scroll.offsetMax = new Vector2(0, 0);
    }
    public void CargarDatos()
    {
        Atributos = conexion.CargarDatosHabilidad(1);
        Transform[] allChildren = Habilidad1.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "Titulo") {
               // GameObject Titulo = child.gameObject;
                Text Titulo = child.GetComponent<Text>();
                Titulo.text = Atributos.NombreHabilidad1;
            }
            if (child.name == "Descripcion")
            {
                // GameObject Titulo = child.gameObject;
                Text Titulo = child.GetComponent<Text>();
                Titulo.text = Atributos.DescripcionHabilidad1;
            }
        }
        allChildren = Habilidad2.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "Titulo")
            {
                // GameObject Titulo = child.gameObject;
                Text Titulo = child.GetComponent<Text>();
                Titulo.text = Atributos.NombreHabilidad2;
            }
            if (child.name == "Descripcion")
            {
                // GameObject Titulo = child.gameObject;
                Text Titulo = child.GetComponent<Text>();
                Titulo.text = Atributos.DescripcionHabilidad2;
            }
        }
        allChildren = Habilidad3.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "Titulo")
            {
                // GameObject Titulo = child.gameObject;
                Text Titulo = child.GetComponent<Text>();
                Titulo.text = Atributos.NombreHabilidad3;
            }
            if (child.name == "Descripcion")
            {
                // GameObject Titulo = child.gameObject;
                Text Titulo = child.GetComponent<Text>();
                Titulo.text = Atributos.DescripcionHabilidad3;
            }
        }
        allChildren = Ataque.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "Titulo")
            {
                // GameObject Titulo = child.gameObject;
                Text Titulo = child.GetComponent<Text>();
                Titulo.text = Atributos.NombreAtacar;
            }
            if (child.name == "Descripcion")
            {
                // GameObject Titulo = child.gameObject;
                Text Titulo = child.GetComponent<Text>();
                Titulo.text = Atributos.DescripcionAtacar;
            }
        }
        allChildren = Esquiva.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "Titulo")
            {
                // GameObject Titulo = child.gameObject;
                Text Titulo = child.GetComponent<Text>();
                Titulo.text = Atributos.NombreEsquivar;
            }
            if (child.name == "Descripcion")
            {
                // GameObject Titulo = child.gameObject;
                Text Titulo = child.GetComponent<Text>();
                Titulo.text = Atributos.DescripcionEsquivar;
            }
        }
    }
    public void CargarDatosHabilidad123(int Ventana)//recibe  codigo para saber si es magia 1,2,3
    {
        LimpiarScroll();
        List<Atributos.Player> listaHabilidades = new List<Atributos.Player>();
        listaHabilidades = conexion.CargarDatosHabilidadDisponible(1);
        Veces(listaHabilidades.Count, listaHabilidades,Ventana);       
    }
    public void CargarDatosHabilidadAtacar()
    {
        LimpiarScroll();
        List<Atributos.Player> listaHabilidades = new List<Atributos.Player>();
        listaHabilidades = conexion.CargarDatosHabilidadDisponible(3);
        Veces(listaHabilidades.Count, listaHabilidades,4);//El 4 es quiere decir que se llama desde la opcion atacar
    }
    public void CargarDatosHabilidadEsquivar()
    {
        LimpiarScroll();
        List<Atributos.Player> listaHabilidades = new List<Atributos.Player>();
        listaHabilidades = conexion.CargarDatosHabilidadDisponible(2);
        Veces(listaHabilidades.Count, listaHabilidades,5);//El 5 es quiere decir que se llama desde la opcion Esquivar
    }
    public void LimpiarScroll()
    {
        //Transform[] allChildren = scroll.GetComponentsInChildren<Transform>();
        foreach (Transform child in scroll)
        {
            Destroy(child.gameObject);
        }
    }
    public void InsertarNuevaHabilidad()
    {
        int IdHabilidad;
        int Ventana;
        int.TryParse(gameObject.name.Substring(0, 1), out Ventana);
        int.TryParse(gameObject.name.Substring(2, 1), out IdHabilidad);
        conexion.update_Habilidad(1, IdHabilidad, Ventana);
        CargarDatos();
    }
    public void VecesPrueba(int veces)
    {
        Equipo = conexion.CargarEquipo(1,"Casco");
        // Vector3 PosicionPanel =  new Vector3(Panel.transform.position.x, Panel.transform.position.y, Panel.transform.position.z);
        int posicionmin = 1;
        // int posicionmax = 1;
        
        for (int i = 0; i < Equipo.Count; i++)
        {
            //posicionmax = posicionmax + 100;
            GameObject ObjetoHijo = Instantiate(Objetos) as GameObject;
            ObjetoHijo.transform.SetParent(scroll.transform);
            ObjetoHijo.name = "Resultado" + i;
            RectTransform ResultadoPanel = ObjetoHijo.GetComponent<RectTransform>();
            //Reseteamos los valores
            ResultadoPanel.localScale = new Vector3(1f, 1f, 1f);
            ResultadoPanel.anchorMin = new Vector2(0f, 0f);
            ResultadoPanel.anchorMax = new Vector2(1f, 1f);
            ResultadoPanel.pivot = new Vector2(0.5f, 0.5f);
            ResultadoPanel.anchoredPosition3D = new Vector3(0f, 0f, 0f);
            ResultadoPanel.rotation = scroll.rotation;
            ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.x, 1);
            ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.x, 1);
            ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.y, posicionmin);
            ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.y, posicionmin);
            posicionmin = posicionmin - 140;

            Transform[] allChildren = ObjetoHijo.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.name == "Titulo")
                {
                    // GameObject Titulo = child.gameObject;
                    Text Titulo = child.GetComponent<Text>();
                    Titulo.text = Equipo[i].Nombre;
                }
                if (child.name == "Descripcion")
                {
                    // GameObject Titulo = child.gameObject;
                    Text Titulo = child.GetComponent<Text>();
                    Titulo.text = Equipo[i].Descripcion;
                }
            }
            //var trigger = ObjetoHijo.name + "_Trigger";
            GameObject Btn = GameObject.Find(ObjetoHijo.name);
            int idObjeto = Equipo[i].Id;
            EventTrigger trigger = Btn.GetComponent<EventTrigger>();
            EventTrigger.Entry Evento = new EventTrigger.Entry();
            Evento.eventID = EventTriggerType.PointerDown;
            Evento.callback.AddListener((data) => { personalizar.CambiarEquipo(3, idObjeto); });
            trigger.triggers.Add(Evento);
        }
        //scroll.offsetMin = new Vector2(1, posicion.y);
        //scroll.offsetMax = new Vector2(0, 0);
    }
    public void VecesCabeza()
    {
        for (int j = 0; j < 2; j++)//Dos veces una por los cascos y otra por las capuchas
        {
            if (j == 0)
            {
                Equipo = conexion.CargarEquipo(1, "Casco");
            }
            else
            {
                Equipo = conexion.CargarEquipo(1, "Capucha");
            }
            // Vector3 PosicionPanel =  new Vector3(Panel.transform.position.x, Panel.transform.position.y, Panel.transform.position.z);
            int posicionmin = 1;
            // int posicionmax = 1;

            for (int i = 0; i < Equipo.Count; i++)
            {
                int id;
                //posicionmax = posicionmax + 100;
                GameObject ObjetoHijo = Instantiate(Objetos) as GameObject;
                if (j == 0)
                {
                    ObjetoHijo.transform.SetParent(scrollCabeza.transform);
                    id = 6;//casco
                    ObjetoHijo.name = "ResultadoCasco" + i;
                }
                else
                {
                    ObjetoHijo.transform.SetParent(scrollCapucha.transform);
                    id = 4;//capucha
                    ObjetoHijo.name = "ResultadoCapucha" + i;
                }
             
                
                RectTransform ResultadoPanel = ObjetoHijo.GetComponent<RectTransform>();
                //Reseteamos los valores
                ResultadoPanel.localScale = new Vector3(1f, 1f, 1f);
                ResultadoPanel.anchorMin = new Vector2(0f, 0f);
                ResultadoPanel.anchorMax = new Vector2(1f, 1f);
                ResultadoPanel.pivot = new Vector2(0.5f, 0.5f);
                ResultadoPanel.anchoredPosition3D = new Vector3(0f, 0f, 0f);
                ResultadoPanel.rotation = scroll.rotation;
                ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.x, 1);
                ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.x, 1);
                ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.y, posicionmin);
                ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.y, posicionmin);
                posicionmin = posicionmin - 140;

                Transform[] allChildren = ObjetoHijo.GetComponentsInChildren<Transform>();
                foreach (Transform child in allChildren)
                {
                    if (child.name == "Titulo")
                    {
                        // GameObject Titulo = child.gameObject;
                        Text Titulo = child.GetComponent<Text>();
                        Titulo.text = Equipo[i].Nombre;
                    }
                    if (child.name == "Descripcion")
                    {
                        // GameObject Titulo = child.gameObject;
                        Text Titulo = child.GetComponent<Text>();
                        Titulo.text = Equipo[i].Descripcion;
                    }
                }
                //var trigger = ObjetoHijo.name + "_Trigger";
                GameObject Btn = GameObject.Find(ObjetoHijo.name);
                int idObjeto = Equipo[i].Id;
                EventTrigger trigger = Btn.GetComponent<EventTrigger>();
                EventTrigger.Entry Evento = new EventTrigger.Entry();
                Evento.eventID = EventTriggerType.PointerDown;
                Evento.callback.AddListener((data) => { personalizar.CambiarEquipo(id, idObjeto); });
                trigger.triggers.Add(Evento);
            }
            //scroll.offsetMin = new Vector2(1, posicion.y);
            //scroll.offsetMax = new Vector2(0, 0);
        }
    }
    public void VecesArmas()
    {
        //for (int j = 0; j < 2; j++)//Dos veces una por los cascos y otra por las capuchas
        //{
        //if (j == 0)
        //{
        //    Equipo = conexion.CargarEquipo(1, "Casco");
        //}
        //else
        //{
        //    Equipo = conexion.CargarEquipo(1, "Capucha");
        //}
        Equipo = conexion.CargarEquipo(1, "Armas");
        // Vector3 PosicionPanel =  new Vector3(Panel.transform.position.x, Panel.transform.position.y, Panel.transform.position.z);
        int posicionmin = 1;
            // int posicionmax = 1;

            for (int i = 0; i < Equipo.Count; i++)
            {
                int id;
                //posicionmax = posicionmax + 100;
                GameObject ObjetoHijo = Instantiate(Objetos) as GameObject;
            //if (j == 0)
            //{
            //    ObjetoHijo.transform.SetParent(scrollCabeza.transform);
            //    id = 3;//casco
            //    ObjetoHijo.name = "ResultadoCasco" + i;
            //}
            //else
            //{
            //    ObjetoHijo.transform.SetParent(scrollCapucha.transform);
            //    id = 4;//capucha
            //    ObjetoHijo.name = "ResultadoCapucha" + i;
            //}

            ObjetoHijo.transform.SetParent(scrollCabeza.transform);
            id = 2;//Arma
            ObjetoHijo.name = "ResultadoArma" + i;
            RectTransform ResultadoPanel = ObjetoHijo.GetComponent<RectTransform>();
                //Reseteamos los valores
                ResultadoPanel.localScale = new Vector3(1f, 1f, 1f);
                ResultadoPanel.anchorMin = new Vector2(0f, 0f);
                ResultadoPanel.anchorMax = new Vector2(1f, 1f);
                ResultadoPanel.pivot = new Vector2(0.5f, 0.5f);
                ResultadoPanel.anchoredPosition3D = new Vector3(0f, 0f, 0f);
                ResultadoPanel.rotation = scroll.rotation;
                ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.x, 1);
                ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.x, 1);
                ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.y, posicionmin);
                ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.y, posicionmin);
                posicionmin = posicionmin - 140;

                Transform[] allChildren = ObjetoHijo.GetComponentsInChildren<Transform>();
                foreach (Transform child in allChildren)
                {
                    if (child.name == "Titulo")
                    {
                        // GameObject Titulo = child.gameObject;
                        Text Titulo = child.GetComponent<Text>();
                        Titulo.text = Equipo[i].Nombre;
                    }
                    if (child.name == "Descripcion")
                    {
                        // GameObject Titulo = child.gameObject;
                        Text Titulo = child.GetComponent<Text>();
                        Titulo.text = Equipo[i].Descripcion;
                    }
                }
                //var trigger = ObjetoHijo.name + "_Trigger";
                GameObject Btn = GameObject.Find(ObjetoHijo.name);
                int idObjeto = Equipo[i].Id;
                EventTrigger trigger = Btn.GetComponent<EventTrigger>();
                EventTrigger.Entry Evento = new EventTrigger.Entry();
                Evento.eventID = EventTriggerType.PointerDown;
                Evento.callback.AddListener((data) => { personalizar.CambiarEquipo(id, idObjeto); });
                trigger.triggers.Add(Evento);
            }
            //scroll.offsetMin = new Vector2(1, posicion.y);
            //scroll.offsetMax = new Vector2(0, 0);
       // }
    }
    public void VecesCompa()
    {
        
        Equipo = conexion.CargarEquipo(1, "Compa");
        // Vector3 PosicionPanel =  new Vector3(Panel.transform.position.x, Panel.transform.position.y, Panel.transform.position.z);
        int posicionmin = 1;
        // int posicionmax = 1;

        for (int i = 0; i < Equipo.Count; i++)
        {
            int id;
            //posicionmax = posicionmax + 100;
            GameObject ObjetoHijo = Instantiate(Objetos) as GameObject;
            //if (j == 0)
            //{
            //    ObjetoHijo.transform.SetParent(scrollCabeza.transform);
            //    id = 3;//casco
            //    ObjetoHijo.name = "ResultadoCasco" + i;
            //}
            //else
            //{
            //    ObjetoHijo.transform.SetParent(scrollCapucha.transform);
            //    id = 4;//capucha
            //    ObjetoHijo.name = "ResultadoCapucha" + i;
            //}

            ObjetoHijo.transform.SetParent(scrollCabeza.transform);
            id = 5;//Compa
            ObjetoHijo.name = "ResultadoCompa" + i;
            RectTransform ResultadoPanel = ObjetoHijo.GetComponent<RectTransform>();
            //Reseteamos los valores
            ResultadoPanel.localScale = new Vector3(1f, 1f, 1f);
            ResultadoPanel.anchorMin = new Vector2(0f, 0f);
            ResultadoPanel.anchorMax = new Vector2(1f, 1f);
            ResultadoPanel.pivot = new Vector2(0.5f, 0.5f);
            ResultadoPanel.anchoredPosition3D = new Vector3(0f, 0f, 0f);
            ResultadoPanel.rotation = scroll.rotation;
            ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.x, 1);
            ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.x, 1);
            ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.y, posicionmin);
            ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.y, posicionmin);
            posicionmin = posicionmin - 140;

            Transform[] allChildren = ObjetoHijo.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.name == "Titulo")
                {
                    // GameObject Titulo = child.gameObject;
                    Text Titulo = child.GetComponent<Text>();
                    Titulo.text = Equipo[i].Nombre;
                }
                if (child.name == "Descripcion")
                {
                    // GameObject Titulo = child.gameObject;
                    Text Titulo = child.GetComponent<Text>();
                    Titulo.text = Equipo[i].Descripcion;
                }
            }
            //var trigger = ObjetoHijo.name + "_Trigger";
            GameObject Btn = GameObject.Find(ObjetoHijo.name);
            int idObjeto = Equipo[i].Id;
            EventTrigger trigger = Btn.GetComponent<EventTrigger>();
            EventTrigger.Entry Evento = new EventTrigger.Entry();
            Evento.eventID = EventTriggerType.PointerDown;
            Evento.callback.AddListener((data) => { personalizar.CambiarEquipo(id, idObjeto); });
            trigger.triggers.Add(Evento);
        }
        //scroll.offsetMin = new Vector2(1, posicion.y);
        //scroll.offsetMax = new Vector2(0, 0);
        // }
    }
    public void VecesTrajes()
    {

        Equipo = conexion.CargarEquipo(1, "Trajes");
        // Vector3 PosicionPanel =  new Vector3(Panel.transform.position.x, Panel.transform.position.y, Panel.transform.position.z);
        int posicionmin = 1;
        // int posicionmax = 1;

        for (int i = 0; i < Equipo.Count; i++)
        {
            int id;
            //posicionmax = posicionmax + 100;
            GameObject ObjetoHijo = Instantiate(Objetos) as GameObject;
            //if (j == 0)
            //{
            //    ObjetoHijo.transform.SetParent(scrollCabeza.transform);
            //    id = 3;//casco
            //    ObjetoHijo.name = "ResultadoCasco" + i;
            //}
            //else
            //{
            //    ObjetoHijo.transform.SetParent(scrollCapucha.transform);
            //    id = 4;//capucha
            //    ObjetoHijo.name = "ResultadoCapucha" + i;
            //}

            ObjetoHijo.transform.SetParent(scrollCabeza.transform);
            id = 7;//Trajes
            ObjetoHijo.name = "ResultadoTrajes" + i;
            RectTransform ResultadoPanel = ObjetoHijo.GetComponent<RectTransform>();
            //Reseteamos los valores
            ResultadoPanel.localScale = new Vector3(1f, 1f, 1f);
            ResultadoPanel.anchorMin = new Vector2(0f, 0f);
            ResultadoPanel.anchorMax = new Vector2(1f, 1f);
            ResultadoPanel.pivot = new Vector2(0.5f, 0.5f);
            ResultadoPanel.anchoredPosition3D = new Vector3(0f, 0f, 0f);
            ResultadoPanel.rotation = scroll.rotation;
            ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.x, 1);
            ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.x, 1);
            ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.y, posicionmin);
            ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.y, posicionmin);
            posicionmin = posicionmin - 140;

            Transform[] allChildren = ObjetoHijo.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.name == "Titulo")
                {
                    // GameObject Titulo = child.gameObject;
                    Text Titulo = child.GetComponent<Text>();
                    Titulo.text = Equipo[i].Nombre;
                }
                if (child.name == "Descripcion")
                {
                    // GameObject Titulo = child.gameObject;
                    Text Titulo = child.GetComponent<Text>();
                    Titulo.text = Equipo[i].Descripcion;
                }
            }
            //var trigger = ObjetoHijo.name + "_Trigger";
            GameObject Btn = GameObject.Find(ObjetoHijo.name);
            int idObjeto = Equipo[i].Id;
            EventTrigger trigger = Btn.GetComponent<EventTrigger>();
            EventTrigger.Entry Evento = new EventTrigger.Entry();
            Evento.eventID = EventTriggerType.PointerDown;
            Evento.callback.AddListener((data) => { personalizar.CambiarEquipo(id, idObjeto); });
            trigger.triggers.Add(Evento);
        }
        //scroll.offsetMin = new Vector2(1, posicion.y);
        //scroll.offsetMax = new Vector2(0, 0);
        // }
    }
    public void VecesObjetos()
    {
       
        List<Atributos.Bolsa> _bolsa = conexion.CargarDatosBolsa(1);
        int posicionmin = 1;

        for (int i = 0; i < _bolsa.Count; i++)
        {
            int id;
            GameObject ObjetoHijo = Instantiate(Objetos) as GameObject;

            ObjetoHijo.transform.SetParent(scrollCabeza.transform);
            id = _bolsa[i].IdObjeto; ;//Idobjeto para funcion objeto bolsa
            ObjetoHijo.name = "ResultadoObjeto" + i;
            RectTransform ResultadoPanel = ObjetoHijo.GetComponent<RectTransform>();
            //Reseteamos los valores
            ResultadoPanel.localScale = new Vector3(1f, 1f, 1f);
            ResultadoPanel.anchorMin = new Vector2(0f, 0f);
            ResultadoPanel.anchorMax = new Vector2(1f, 1f);
            ResultadoPanel.pivot = new Vector2(0.5f, 0.5f);
            ResultadoPanel.anchoredPosition3D = new Vector3(0f, 0f, 0f);
            ResultadoPanel.rotation = scroll.rotation;
            ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.x, 1);
            ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.x, 1);
            ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.y, posicionmin);
            ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.y, posicionmin);
            posicionmin = posicionmin - 140;

            Transform[] allChildren = ObjetoHijo.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.name == "Titulo")
                {
                    // GameObject Titulo = child.gameObject;
                    Text Titulo = child.GetComponent<Text>();
                    Titulo.text = _bolsa[i].Nombre;
                }
                //if (child.name == "Descripcion")
                //{
                //    // GameObject Titulo = child.gameObject;
                //    Text Titulo = child.GetComponent<Text>();
                //    Titulo.text = _bolsa[i].Descripcion;
                //}
            }
            GameObject Btn = GameObject.Find(ObjetoHijo.name);
            int idObjeto = _bolsa[i].IdObjeto;
            EventTrigger trigger = Btn.GetComponent<EventTrigger>();
            EventTrigger.Entry Evento = new EventTrigger.Entry();
            Evento.eventID = EventTriggerType.PointerDown;
            Evento.callback.AddListener((data) => { this.ObjetoBolsa(id); });
            trigger.triggers.Add(Evento);
        }
    }
    public void ObjetoBolsa(int id)
    {
        foreach (Transform hijo in scrollCapucha.gameObject.transform)
        {
            Destroy(hijo.gameObject);
        }
        int posicionmin = 1;
        Atributos.Bolsa _bolsa;
        _bolsa = conexion.ElementoBolsa(id);
        //Activar canvas secundario.
        InformacionObjeto.SetActive(true);
        foreach (Transform hijo in InformacionObjeto.transform)
        {
            if (_bolsa.Tipo == 1)
            {
                if (hijo.gameObject.name == "Mezclar")
                {
                    hijo.gameObject.SetActive(false);
                }
                else
                {
                    hijo.gameObject.SetActive(true);
                }
                
            }
            else if(_bolsa.Tipo==2)
            {
                if (hijo.gameObject.name == "Usar")
                {
                    hijo.gameObject.SetActive(false);
                }
                else
                {
                    hijo.gameObject.SetActive(true);
                }
            }
        }
        GameObject ObjetoHijo = Instantiate(Objetos) as GameObject;
        ObjetoHijo.transform.SetParent(scrollCapucha.transform);
        ObjetoHijo.name = "ResultadoInformacionObjeto";
        RectTransform ResultadoPanel = ObjetoHijo.GetComponent<RectTransform>();
        //Reseteamos los valores
        ResultadoPanel.localScale = new Vector3(1f, 1f, 1f);
        ResultadoPanel.anchorMin = new Vector2(0f, 0f);
        ResultadoPanel.anchorMax = new Vector2(1f, 1f);
        ResultadoPanel.pivot = new Vector2(0.5f, 0.5f);
        ResultadoPanel.anchoredPosition3D = new Vector3(0f, 0f, 0f);
        ResultadoPanel.rotation = scroll.rotation;
        ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.x, 1);
        ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.x, 1);
        ResultadoPanel.offsetMin = new Vector2(ResultadoPanel.offsetMin.y, posicionmin);
        ResultadoPanel.offsetMax = new Vector2(ResultadoPanel.offsetMax.y, posicionmin);
        posicionmin = posicionmin - 140;

        Transform[] allChildren = ObjetoHijo.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "Titulo")
            {
                // GameObject Titulo = child.gameObject;
                Text Titulo = child.GetComponent<Text>();
                Titulo.text = _bolsa.Descripcion;
            }
            //if (child.name == "Descripcion")
            //{
            //    // GameObject Titulo = child.gameObject;
            //    Text Titulo = child.GetComponent<Text>();
            //    Titulo.text = _bolsa[i].Descripcion;
            //}
        }

    }
}
