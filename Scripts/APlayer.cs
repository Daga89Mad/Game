using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class APlayer : Photon.Pun.MonoBehaviourPun
{
    public GameObject VidaPorcentaje;
    public Atributos.Player Atributos = new Atributos.Player();
    Android conexion = new Android();
    Atributos bbdd = new Atributos();
    Atributos.NPC enemigo;
    float MaxHp;
    float Hp;
    public bool atacar = false;
    bool TiempoDanio = false;
    bool PuertaDanio = true;
    public GameObject BarraVida;
    public GameObject Estamina;
    public GameObject Carga;
    public GameObject BotonEnergia;
    public bool pruen = false;
    float currenTime = 0;
    float maxTime = 4f;
    float currenTime2 = 0;
    float maxTime2 = 1.3f;
    float estamin;
    float EstaminaMax;
    float Energia;
    float CargaMax;
    private Animator anim;
    CharacterController controller;
    public GameObject CargarBolsa;
    bool MirarBolsa = false;
    public Image VidaImagen; public GameObject aceptarMision;
    //DBConector conector = new DBConector();
    // Use this for initialization
    void Start()
    {
        #region ConBBDD
        //Atributos.Nombre = gameObject.name;
        //int.TryParse(Atributos.Nombre.Substring(2, 1), out Atributos.Id);
        //Atributos = conexion.CargarDatos(Atributos.Id);
        //Atributos.VidaCombate = Atributos.Vida;
        //conexion.update_function(Atributos.Id, Atributos.VidaCombate);
        #endregion

        #region SinBBDD
        Atributos.Fuerza = 50;
        Atributos.Estamina = 500;
        Atributos.Vida = 500;
        Atributos.Defensa = 20;
        Atributos.Nivel = 15;
        Atributos.Velocidad = 2;
        Atributos.VidaCombate = 500;
        #endregion
        if (photonView.IsMine)
        {
           
            //this.transform.position = PosInicial;
            anim = GetComponent<Animator>();
            Atributos.Nombre = gameObject.name;
            BarraVida = GameObject.Find("Salud");
            VidaImagen = BarraVida.GetComponent<Image>();
          
            //   MaxHp = Atributos.Vida;
            // Atributos.VidaCombate = MaxHp;
            EstaminaMax = Atributos.Estamina;
            estamin = EstaminaMax;
            Energia = 0;
            CargaMax = 500;

        }
        //Estamina.transform.localScale = new Vector2(estamin / EstaminaMax, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //if (estamin < EstaminaMax)
        //{
        //    currenTime += Time.deltaTime;
        //    if (currenTime >= maxTime)
        //    {
        //        currenTime = 0;
        //        estamin = Mathf.Clamp(estamin + 100, 0f, EstaminaMax);
        //        Estamina.transform.localScale = new Vector2(estamin / EstaminaMax, 0.5f);
        //    }

        //}
        //if (Energia == 500)
        //{
        //    BotonEnergia.SetActive(true);

        //}
        if (TiempoDanio)
        {
            currenTime2 += Time.deltaTime;
            if (currenTime2 >= maxTime2)
            {
                currenTime2 = 0;
                PuertaDanio = true;
                TiempoDanio = false;
            }

        }
        if (Atributos.VidaCombate == 0)
        {
            //ControlDePersonaje controlDePersonaje = new ControlDePersonaje();
            //controlDePersonaje.MorirOn();
            anim.SetTrigger("Muerte");

        }
        //if (MirarBolsa)
        //{
        //    MirarBolsa = false;
        //    //Atributos.Nombre = gameObject.name;
        //    //Atributos.Nombre = gameObject.name;
        //    //int.TryParse(Atributos.Nombre.Substring(0, 1), out Atributos.Id);
        //    //Atributos = conexion.CargarDatos(Atributos.Id);
        //    CargarBolsa.SetActive(true);
        //    string Objetos = "-" + Atributos.NombreObjeto + ": " +
        //        "" +
        //        Atributos.DescripcionObjeto;
        //    CargarBolsa.SendMessage("CargarBolsa", Objetos);

        //}

        //Atributos = conexion.CargarDatos(1);
        //Vida.transform.localScale = new Vector2(Atributos.VidaCombate / Atributos.Vida, 0.5f);
        //float PorCiento = (Atributos.VidaCombate * 100.00f) / Atributos.Vida;
        //VidaPorcentaje.GetComponent<Text>().text = PorCiento.ToString() + "%";
        //PorCiento = PorCiento * Atributos.Vida;
    }


    //void OnCollisionEnter(Collision Colision)
    //{

    //    if ((Colision.gameObject.name != "Terrain") && (Colision.gameObject.name != "EsferaEspecial") && (Colision.gameObject.name != "EsferaEspecial(Clone)") && (Colision.gameObject.name != "Plane"))

    //    {
    //        //llamada a Script de Barras funcion DanioRecibido(Float)
    //        //BarraVida.SendMessage("DanioRecibido", 20f);// Con esto se restarian 20 vida
    //        //Destroy(o.gameObject);  // Destroy(o.gameObject);
    //        //Barras Barras = new Barras();

    //        // Enemigo = GameObject.Find("Cat_Warrior");
    //        // Enemigo = new Cat().Atributos;

    //        enemigo.Nombre = Colision.gameObject.name;

    //        #region ConBBDD
    //        //enemigo = conexion.CargarAtributos(enemigo);
    //        #endregion

    //        #region SinBBDD
    //        enemigo.Fuerza = 50;
    //        #endregion

    //        float danio;
    //        danio = enemigo.Fuerza - Atributos.Defensa;
    //        Hp = Mathf.Clamp(Hp - danio, 0f, MaxHp);
    //        Vida.transform.localScale = new Vector2(Hp / MaxHp, 1);
    //        Debug.Log("daño final -" + danio);
    //        //BarrasVida.DanioRecibido();
    //        //int Fuerza = AEnemigo.Fuerza;
    //        //int Defensa = Atributos.Defensa;
    //        //llamadas a Script de barras funcion DanioRecibido(Float,Float)
    //        // BarraVida.SendMessage("DanioRecibido", 20f);// Con esto se restarian 20 vida
    //        // Barras.DanioRecibido(Fuerza, Defensa);
    //        //Destroy(Colision.gameObject);
    //        Debug.Log("daño a Player colision");
    //    }
    //}
    //public void GastoRecibido()
    //{
    //    estamin = Mathf.Clamp(estamin - 50, 0f, EstaminaMax);
    //    Estamina.transform.localScale = new Vector2(estamin / EstaminaMax, 0.5f);
    //}
    //public void LiberarEnergia()
    //{
    //    Energia = 0;
    //    BotonEnergia.SetActive(false);
    //    Carga.transform.localScale = new Vector2(Energia / CargaMax, 0.5f);
    //}
    //public void ConsultarBolsa()
    //{
    //    MirarBolsa = true;
    //}
    //public void CerrarBolsa()
    //{

    //    CargarBolsa.SetActive(false);

    //}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Substring(0, 2) == "3.")//1 es arma enemigo
        {
            if (Vector3.Distance(col.gameObject.transform.position, gameObject.transform.position) < 3.5f)
            {
                //anim.SetBool("Perseguir", false);
                GameObject Agresor = col.gameObject;
                GameObject PadreAgresor = col.gameObject;
                //anim.SetInteger("Atacar", 0);
                Agresor = col.gameObject;
                do
                {
                    PadreAgresor = PadreAgresor.transform.parent.gameObject; //Personaje.gameObject.name;
                    enemigo.Nombre = PadreAgresor.gameObject.name;
                } while (enemigo.Nombre.Substring(0, 2) != "1.");// 1 es enemigo


                
                if (PadreAgresor.GetComponent<Diablos>() == null)
                {
                    Ogro _ogro = PadreAgresor.GetComponent<Ogro>();
                    enemigo.Fuerza = _ogro.fuerza;
                }
                else
                {
                    Diablos _diablos = PadreAgresor.GetComponent<Diablos>();
                    enemigo.Fuerza = _diablos.fuerza;
                }


                //int.TryParse(player.Nombre.Substring(2, 1), out player.Id);

                //#region ConBBDD
                //player = conexion.CargarDatos(player.Id);
                //#endregion

                #region SinBBDD

               // enemigo.Fuerza = 50;
                #endregion

                //GameObject Agresor = GameObject.Find(player.Id + "." + player.Nombre.ToString());
                Animator An = PadreAgresor.GetComponent<Animator>();
                int EstadoActual = An.GetInteger("Atacar");
                if (EstadoActual == 1)
                {
                   
                    if (PuertaDanio)//Prueba porque el coll detecta dos golpes del arma el de ida y el de vuelta
                    {
                        TiempoDanio = true;
                        PuertaDanio = false;
                        float danio;
                        danio = enemigo.Fuerza - Atributos.Defensa;

                        Atributos.VidaCombate = Mathf.Clamp(Atributos.VidaCombate - danio, 0f, Atributos.Vida);
                        Vida();
                        //Vida.transform.localScale = new Vector2(Atributos.VidaCombate / Atributos.Vida, 0.5f);
                        //int.TryParse(gameObject.name.Substring(0, 1), out Atributos.Id);
                        // conexion.update_functionEnemigo(Atributos.Id, Atributos.VidaCombate);
                        // ObjetoDanio.SetActive(true);
                        //danioRecibido.text = danio.ToString();
                        // Vector3 daniopos = Camera.main.WorldToScreenPoint(PosicionDanio.transform.position);
                        // ObjetoDanio.transform.position = daniopos;
                        // anim.SetTrigger("Danio");
                    }                   
                }


                //if (Atributos.VidaCombate <= 0)
                //{
                //    conexion.update_Asesino(Atributos, player);
                //}
                // conector.UpdateEnemigos(1, Hp);
                //Debug.Log("daño final -" + danio);
            }

        }
    }
    public void Vida()
    {
        if (photonView.IsMine)
        {
            VidaImagen.fillAmount = Atributos.VidaCombate / Atributos.Vida;
        }
    }
}
    //private void OnCollisionEnter(Collision Colision)
    //{
    //    if ((Colision.gameObject.name != "Terrain") && (Colision.gameObject.name != "EsferaEspecial") && (Colision.gameObject.name != "EsferaEspecial(Clone)") && (Colision.gameObject.name != "Plane"))

    //    {
    //        //llamada a Script de Barras funcion DanioRecibido(Float)
    //        //BarraVida.SendMessage("DanioRecibido", 20f);// Con esto se restarian 20 vida
    //        //Destroy(o.gameObject);  // Destroy(o.gameObject);
    //        //Barras Barras = new Barras();

    //        // Enemigo = GameObject.Find("Cat_Warrior");
    //        // Enemigo = new Cat().Atributos;

    //        enemigo.Nombre = Colision.gameObject.name;

    //        #region ConBBDD
    //        //enemigo = conexion.CargarAtributos(enemigo);
    //        #endregion

    //        #region SinBBDD
    //        enemigo.Fuerza = 50;
    //        #endregion

    //        float danio;
    //        danio = enemigo.Fuerza - Atributos.Defensa;
    //        Atributos.VidaCombate = Mathf.Clamp(Atributos.VidaCombate - danio, 0f, Atributos.Vida);
    //        //Vida.transform.localScale = new Vector2(Hp / MaxHp, 1);
    //        //Debug.Log("daño final -" + danio);
    //        //BarrasVida.DanioRecibido();
    //        //int Fuerza = AEnemigo.Fuerza;
    //        //int Defensa = Atributos.Defensa;
    //        //llamadas a Script de barras funcion DanioRecibido(Float,Float)
    //        // BarraVida.SendMessage("DanioRecibido", 20f);// Con esto se restarian 20 vida
    //        // Barras.DanioRecibido(Fuerza, Defensa);
    //        //Destroy(Colision.gameObject);
    //       // Debug.Log("daño a Player colision");
    //    }
    //}

//}
