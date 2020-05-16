using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Camara : MonoBehaviour
{
    Android conexion = new Android();
    public GameObject aceptarMision;
    public GameObject cerrarVentana;
    float i = 0;
    //Personaje Atributos;
    public bool especial = false;
    public GameObject Seleccion;
    public float speed;
    //public GameObject Disparo;
    public GameObject Info;
    public GameObject PanelMision;
    public GameObject CachedPosition;
    int Parar = 0;
    // Use this for initialization
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

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
                //Buscar por Name//
                try
                {
                    if (results[0].gameObject.layer == LayerMask.NameToLayer("UI"))
                    {
                        string dbg = "Root Element: {0} \n GrandChild Element: {1}";
                        Debug.Log(string.Format(dbg, results[results.Count - 1].gameObject.name, results[0].gameObject.name));
                        //Debug.Log("Root Element: "+results[results.Count-1].gameObject.name);
                        //Debug.Log("GrandChild Element: "+results[0].gameObject.name);
                        if ((results[0].gameObject.name == "MobileJoystick") || (results[0].gameObject.name == "AtacarBtn") || (results[0].gameObject.name == "DispararBtn") || (results[0].gameObject.name == "Recoger") || (results[0].gameObject.name == "EsquivarBtn") || (results[0].gameObject.name == "Bolsa") || (results[0].gameObject.name == "Magia2"))
                        {
                            Debug.Log("PararGiro");
                            Parar = 1;                           
                        }
                        else if(results[0].gameObject.name == "BarraVidaEnemigo" || results[0].gameObject.name == "EstaminaEnemigo" || results[0].gameObject.name == "TextoInfo")
                        {
                            Info.SetActive(false);
                        }
                        else
                        {
                            Parar = 0;
                        }

                        results.Clear();
                    }

                }
                catch
                {
                    results.Clear();
                    Parar = 0;
                }
                #region Con Name

                if ((raycastHit.collider.name.Substring(0,2) == "00") || (raycastHit.collider.name.Substring(0, 2) == "01"))
                {
                    string Nombre = raycastHit.collider.name.ToString();

                    //Atributos.Nombre = Nombre;
                    //APersonaje aPersonaje = new APersonaje();
                    //Atributos= aPersonaje.CargarDatos(Atributos);

                    //Vector3 SeleccionPosicion = raycastHit.collider.transform.position;
                    Debug.Log(Nombre);
                    //Nombre = Atributos.Fuerza.ToString();
                    //Llamada a Script Disparar en gameobject Bola funcion Seleccionar(Vector3)
                    //Disparo.SendMessage("Seleccionar", SeleccionPosicion);
                    //Llamada a Script InfoSeleccion en Canvas InfoSelecion funcion seleccion(String)
                    Info.SetActive(true);
                    foreach (Transform h in Info.transform)
                    {
                        GameObject j = h.gameObject;
                      
                            j.SetActive(true);
                        
                    }
                    //SpawnArmor(Info.transform, true);
                    //SpawnArmor(Info.transform, true);
                    //GameObject BarraEnemigo = GameObject.Find("BarraVidaEnemigo");
                    //BarraEnemigo.SetActive(true);
                    Info.SendMessage("seleccion", Nombre);


                }
# endregion
                else if (raycastHit.collider.name == "1.Compa")
                  {
                    string mision = "¿Qué quieres?,No es el mejor momento";
                    Info.SetActive(true);
                    foreach (Transform h in Info.transform)
                    {
                        GameObject j = h.gameObject;
                        if (h.name== "Text")
                        {
                            j.SetActive(true);
                        }
                        else
                        {
                            j.SetActive(false);
                        }                  
                    }
                    Info.SendMessage("seleccion", mision);

                 }
                else if (raycastHit.collider.name.Substring(5,3) == "NPC")
                {

                    GameObject CanvasMenu = GameObject.Find("CanvasMenu");
                    CanvasMenu.SetActive(true);
                    GameObject PanelMisiones=new GameObject();
                    foreach (Transform h in CanvasMenu.transform)
                    {
                        if (h.name == "PanelMisiones")
                        {
                            h.gameObject.SetActive(true);
                            PanelMisiones = h.gameObject;
                        }


                    }

                        int id = 0;
                    string DobleCifra = raycastHit.collider.name.Substring(4, 1);
                    if (DobleCifra == ".")
                    {
                        int.TryParse(raycastHit.collider.name.Substring(3, 1), out id);
                    }
                    else
                    {
                        int.TryParse(raycastHit.collider.name.Substring(3, 2), out id);
                    }
                    
                    Atributos.NPC npc= conexion.CargarDatosNPC(id);
                    foreach (Transform h in PanelMisiones.transform)
                    {

                        if (h.name == "Nombre")
                        {
                            Text Titulo = h.GetComponent<Text>();
                            Titulo.text = npc.Nombre;
                        }
                        else if (h.name == "TituloMision")
                        {
                            Text Titulo = h.GetComponent<Text>();
                            Titulo.text = npc.nombreMision;
                        }
                        else if (h.name == "DescripcionMision")
                        {
                            Text Titulo = h.GetComponent<Text>();
                            Titulo.text = npc.descripcionMision;
                        }
                        else if (h.name == "AceptarMision")
                        {
                            aceptarMision = h.gameObject;
                        }
                        else if (h.name == "CerrarMision")
                        {
                            cerrarVentana = h.gameObject;
                        }
                    }
                    //aceptarMision = GameObject.Find("AceptarMision");
                    //cerrarVentana= GameObject.Find("CerrarMision"); 

                    EventTrigger trigger = aceptarMision.GetComponent<EventTrigger>();
                    EventTrigger.Entry aceptar = new EventTrigger.Entry();
                    aceptar.eventID = EventTriggerType.PointerDown;
                    aceptar.callback.AddListener((data) => { conexion.insertMision(npc.idMision); });
                    trigger.triggers.Add(aceptar);

                    EventTrigger trigger2 = cerrarVentana.GetComponent<EventTrigger>();
                    EventTrigger.Entry cerrar = new EventTrigger.Entry();
                    cerrar.eventID = EventTriggerType.PointerDown;
                    cerrar.callback.AddListener((data) => { this.CerrarVentana(CanvasMenu);});
                    trigger2.triggers.Add(cerrar);
                    //Info.SendMessage("seleccionNPC", mision);

                }
                else if ((raycastHit.collider.name.Substring(2, 3) == "OBJ") || (raycastHit.collider.name.Substring(3, 3) == "OBJ"))
                {
                    string mision = raycastHit.collider.name;
                    Info.SetActive(true);
                    foreach (Transform h in Info.transform)
                    {
                        GameObject j = h.gameObject;
                        if (h.name == "TextoInfo")
                        {
                            j.SetActive(true);
                        }
                        else
                        {
                            j.SetActive(false);
                        }
                    }
                    Info.SendMessage("seleccionObjeto", mision);

                }
                else
                {
                    Debug.Log("Camara else");
                }

               
                   
            }


        }
        //if ((Input.touchCount > 1) && (Input.GetTouch(1).phase == TouchPhase.Moved))
        //{
        //    Debug.Log("dos dedos Si hay giro");
        //    Touch touch0 = Input.GetTouch(0);
        //    GameObject pers = GameObject.Find("1.Daga");
        //    Debug.Log(touch0.deltaPosition.x.ToString());
        //    float pos;
        //    //Si es menor que cero giro a la izquierda
        //    if (touch0.deltaPosition.x < 0)
        //    {
        //        pos = touch0.deltaPosition.x + 2f;
        //        pers.transform.Rotate(0f, pos, 0f);
        //        //i=i-0.7f;
        //        //pers.transform.Rotate(0, i, 0);
        //    }
        //    else
        //    {
        //        pos = touch0.deltaPosition.x - 2f;
        //        pers.transform.Rotate(0f, pos, 0f);
        //        //i = i + 0.7f;

        //        //pers.transform.Rotate(0, i, 0);
        //    }

        //}

        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            if (Parar == 0)
            {
                Debug.Log("Si hay giro");
                Touch touch0 = Input.GetTouch(0);
                GameObject pers ;
                Transform persPadre;

                do
                {
                    persPadre = gameObject.transform.parent; //Personaje.gameObject.name;
                    pers = persPadre.gameObject;
                } while (pers.name.Substring(0, 1) != "0");


                Debug.Log(touch0.deltaPosition.x.ToString());
                float pos;
                //Si es menor que cero giro a la izquierda
                if (touch0.deltaPosition.x < 0)
                {
                    pos = touch0.deltaPosition.x + 2f;
                    pers.transform.Rotate(0f, pos, 0f);
                    //i=i-0.7f;
                    //pers.transform.Rotate(0, i, 0);
                }
                else
                {
                    pos = touch0.deltaPosition.x - 2f;
                    pers.transform.Rotate(0f, pos, 0f);
                }
            }
        }
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            i = 0;
        }
    }
    void DragObject(Vector3 posMoved)
    {
        //Debug.Log(posMoved);
        //Debug.Log("Funcion Dragobject");

        //CachedPosition.transform.position = new Vector3(Mathf.Clamp((posMoved.x * Velocidad) + CachedPosition.transform.position.x, posInicial.x - LimiteHorizontal, posInicial.x * LimiteHorizontal),
        //    Mathf.Clamp((posMoved.y * Velocidad) + CachedPosition.transform.position.y, posInicial.y - LimiteVertical, posInicial.y * LimiteVertical),
        //    CachedPosition.transform.position.z);
        Debug.Log(CachedPosition.transform.position);
        //aux = new Vector3(Mathf.Clamp((deltapos.x * Velocidad) + CachedPosition.position.x, posInicial.x - LimiteHorizontal, posInicial.x * LimiteHorizontal),
        //    Mathf.Clamp((deltapos.y * Velocidad) + CachedPosition.position.y, posInicial.y - LimiteVertical, posInicial.y * LimiteVertical),
        //    CachedPosition.position.z);

        //aux.y = 0;
        //CachedPosition.position = aux;
    }
    public void PararGiro(string parar)
    {
        Debug.Log("Parando Giro Camara");
        int.TryParse(parar, out Parar);
       
    }
    public void CerrarVentana(GameObject cerrar)
    {
        cerrar.SetActive(false);

    }
    //private void SpawnArmor(Transform transform, bool value)
    //{
    //        foreach (Transform child in transform)
    //        {
    //            if (child.name == "BarraVidaEnemigo")
    //            {
    //                child.gameObject.SetActive(value);

    //            }
    //            SpawnArmor(child, value);
    //        }

    //}
}


    


