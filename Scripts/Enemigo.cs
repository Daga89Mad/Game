using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    //Android conexion = new Android();
    private Animator anim;
    bool Perseguir=false;
    public Text danioRecibido;
    public GameObject ObjetoDanio;
    public GameObject PosicionDanio;
    bool DanioActivo = false;
    [HideInInspector]//cpn esto es publica pero no se ve en unity
    public Transform Personaje;
    public Transform Referencia;
    //private NavMeshAgent nav;
    float random;
    Atributos.NPC Atributos;
    float Hp;
    float MaxHp;
    public float gravity = 20.0F;
    //public GameObject Vida;
    Atributos.Player player;
    bool Muerto = false;
    public int MoveSpeed;
    public float MaxDist=10;
    public float MinDist=1.5f;
    CharacterController controller;
    float currenTime = 0;
    float maxTime = 2;
    //DBConector conector = new DBConector();
    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        //Personaje = GameObject.Find("1.Daga").transform;
        //Referencia= GameObject.Find("Referencia").transform;
       // nav = GetComponent<NavMeshAgent>();
        Atributos.Nombre = gameObject.name;
        //string DobleCifra = Atributos.Nombre.Substring(1, 1);
        //if (DobleCifra == ".")
        //{
        //    int.TryParse(Atributos.Nombre.Substring(0, 1), out Atributos.Id);
        //}
        //else
        //{
        //    int.TryParse(Atributos.Nombre.Substring(0, 2), out Atributos.Id);
        //}

        //int.TryParse(Atributos.Nombre.Substring(0,1), out Atributos.Id);
        //Atributos.Id = Atributos.Nombre.Substring(0, 1);
        //#region ConBBDD
        //Atributos = conexion.CargarDatosEnemigos(Atributos.Id);
        //Atributos.VidaCombate = Atributos.Vida;
        //conexion.update_functionEnemigo(Atributos.Id, Atributos.VidaCombate);
        //#endregion

        #region SinBBDD
        Atributos.Fuerza = 300;
        Atributos.Estamina = 200;
        Atributos.Vida = 500;
        Atributos.Defensa = 10;
        Atributos.Nivel = 8;
        Atributos.Velocidad = 1;
        Atributos.VidaCombate = 500;
        #endregion

        //MaxHp = Atributos.Vida;
        //Atributos.VidaCombate = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        Muerto = anim.GetBool("Muerte");
        if (!Muerto)
        {

            //Transform Player = GameObject.Find("1.Daga").transform;
            Vector3 EnemyPos = transform.position;
            //Vector3 PlayerPos = Player.position;
            //float distancia = Vector3.Distance(EnemyPos, PlayerPos);

            //if (distancia >= MinDist && distancia <= MaxDist)
            //{
            //    anim.SetBool("Perseguir", true);
            //    anim.SetInteger("Atacar", 0);
            //    this.transform.position.y -= gravity * Time.deltaTime;
            //    Vector3 targetPos = new Vector3(Player.position.x,
            //    this.transform.position.y,
            //    Player.position.z);
            //    targetPos.y -= gravity * Time.deltaTime;
            //    transform.LookAt(targetPos);
            //    transform.position += transform.forward * MoveSpeed * Time.deltaTime;


            //}

            //if (distancia > 0 && distancia < MinDist)
            //{
            //    Vector3 targetPos = new Vector3(Player.position.x,
            //    this.transform.position.y,
            //    Player.position.z);
            //    transform.LookAt(targetPos);
            //    anim.SetBool("Perseguir", false);
            //    anim.SetInteger("Atacar", 1);
            //    Vector3 targetPos = new Vector3(Player.position.x,
            //    this.transform.position.y,
            //    Player.position.z);
            //    transform.LookAt(targetPos);
            //    transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            //}
            //}
            if (Atributos.VidaCombate == 0)
            {
                //ControlDePersonaje controlDePersonaje = new ControlDePersonaje();
                //controlDePersonaje.MorirOn();
                anim.SetBool("Muerte", true);

            }
            Atributos.Nombre = gameObject.name;
            string DobleCifra = Atributos.Nombre.Substring(1, 1);
            if (DobleCifra == ".")
            {
                int.TryParse(Atributos.Nombre.Substring(0, 1), out Atributos.Id);
            }
            else
            {
                int.TryParse(Atributos.Nombre.Substring(0, 2), out Atributos.Id);
            }
            //Atributos = conexion.CargarDatosEnemigos(Atributos.Id);

            //Vector3 daniopos = PosicionDanio.transform.position;
            //danioRecibido.transform.position = PosicionDanio.transform.position;
            if (ObjetoDanio)
            {
                currenTime += Time.deltaTime;
                if (currenTime >= maxTime)
                {
                    currenTime = 0;
                    ObjetoDanio.SetActive(false);
                }

            }
            //// Vida.SetActive(true);
            // //Vida.transform.localScale = new Vector2(Atributos.VidaCombate / Atributos.Vida, 0.5f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //if (col.name=="1.Daga") {
        //    Perseguir = true;

        //}

        if (col.gameObject.name == "1.Capsule(Clone)")
        {
            if (Vector3.Distance(col.gameObject.transform.position, gameObject.transform.position) < 3.5f)
            {
                player.Nombre = Personaje.gameObject.name;
                int.TryParse(player.Nombre.Substring(0, 1), out player.Id);

                //#region ConBBDD
                //player = conexion.CargarDatos(player.Id);
                //#endregion

                #region SinBBDD
                player.Fuerza = 50;
                #endregion

                float danio;
                
                //Vida.transform.localScale = new Vector2(Atributos.VidaCombate / Atributos.Vida, 0.5f);
                Atributos.Nombre = gameObject.name;
                string DobleCifra = Atributos.Nombre.Substring(1, 1);
                if (DobleCifra == ".")
                {
                    int.TryParse(Atributos.Nombre.Substring(0, 1), out Atributos.Id);
                }
                else
                {
                    int.TryParse(Atributos.Nombre.Substring(0, 2), out Atributos.Id);
                }

                //int.TryParse(Atributos.Nombre.Substring(0,1), out Atributos.Id);
                //Atributos.Id = Atributos.Nombre.Substring(0, 1);
                //Atributos = conexion.CargarDatosEnemigos(Atributos.Id);
                danio = player.Fuerza - Atributos.Defensa;
                Atributos.VidaCombate = Mathf.Clamp(Atributos.VidaCombate - danio, 0f, Atributos.Vida);
                //conexion.update_functionEnemigo(Atributos.Id, Atributos.VidaCombate);
                ObjetoDanio.SetActive(true);
                danioRecibido.text = danio.ToString();
                Vector3 daniopos = Camera.main.WorldToScreenPoint(PosicionDanio.transform.position);
                ObjetoDanio.transform.position = daniopos;
                anim.SetTrigger("Danio");
                //if (Atributos.VidaCombate <= 0)
                //{
                //    conexion.update_Asesino(Atributos, player);
                //}
                //Destroy(col.gameObject);
                
               
                // conector.UpdateEnemigos(1, Hp);
                //Debug.Log("daño final -" + danio);
            }

        }
        if (col.gameObject.name.Substring(0,2) == "2.")
        {
            if (Vector3.Distance(col.gameObject.transform.position, gameObject.transform.position) < 3.5f)
            {
                //anim.SetBool("Perseguir", false);

                //anim.SetInteger("Atacar", 0);
                //player.Nombre = Personaje.gameObject.name;

                //int.TryParse(player.Nombre.Substring(0, 1), out player.Id);

                //#region ConBBDD
                //player = conexion.CargarDatos(player.Id);
                //#endregion

                #region SinBBDD
                player.Fuerza = 50;
                #endregion

                //GameObject Agresor = GameObject.Find(player.Id + "." + player.Nombre.ToString());
                //Animator An = Agresor.GetComponent<Animator>();
                //bool EstadoActual = An.GetBool("Atacar");
                //if (EstadoActual)
                //{
                    Atributos.Nombre = gameObject.name;
                    //string DobleCifra = Atributos.Nombre.Substring(1, 1);
                    //if (DobleCifra == ".")
                    //{
                    //    int.TryParse(Atributos.Nombre.Substring(0, 1), out Atributos.Id);
                    //}
                    //else
                    //{
                    //    int.TryParse(Atributos.Nombre.Substring(0, 2), out Atributos.Id);
                    //}

                    //int.TryParse(Atributos.Nombre.Substring(0,1), out Atributos.Id);
                    //Atributos.Id = Atributos.Nombre.Substring(0, 1);
                    //Atributos = conexion.CargarDatosEnemigos(Atributos.Id);
                    float danio;
                    danio = player.Fuerza - Atributos.Defensa;

                    Atributos.VidaCombate = Mathf.Clamp(Atributos.VidaCombate - danio, 0f, Atributos.Vida);
                //Vida.transform.localScale = new Vector2(Atributos.VidaCombate / Atributos.Vida, 0.5f);
                //int.TryParse(gameObject.name.Substring(0, 1), out Atributos.Id);
                //conexion.update_functionEnemigo(Atributos.Id, Atributos.VidaCombate);
                ObjetoDanio.SetActive(true);
                danioRecibido.text = Atributos.VidaCombate.ToString();
                //Vector3 daniopos = Camera.main.WorldToScreenPoint(PosicionDanio.transform.position);
                ObjetoDanio.transform.position = PosicionDanio.transform.position;
                //anim.SetTrigger("Danio");
                //}


                // if (Atributos.VidaCombate <= 0)
                //{
                //    conexion.update_Asesino(Atributos, player);
                //}
                // conector.UpdateEnemigos(1, Hp);
                //Debug.Log("daño final -" + danio);
            }

        }
        //if (col.gameObject.name == "Aire(Clone)")
        //{
        //    if (Vector3.Distance(col.gameObject.transform.position, gameObject.transform.position) < 3.5f)
        //    {
        //        anim.SetBool("Perseguir", false);

        //        anim.SetInteger("Atacar", 0);
        //        anim.SetTrigger("Danio");
        //        Atributos.Magia atributos = new Atributos.Magia();
        //        //atributos = conexion.CargarDatosMagias(1);
        //        float danio;
        //        danio = atributos.Fuerza - Atributos.Defensa;

        //        Atributos.VidaCombate = Mathf.Clamp(Atributos.VidaCombate - danio, 0f, Atributos.Vida);
        //        //Vida.transform.localScale = new Vector2(Atributos.VidaCombate / Atributos.Vida, 0.5f);
        //        //int.TryParse(gameObject.name.Substring(0, 1), out Atributos.Id);
        //        //conexion.update_functionEnemigo(Atributos.Id, Atributos.VidaCombate);
        //        //player.Nombre = Personaje.gameObject.name;
        //        ObjetoDanio.SetActive(true);
        //        danioRecibido.text = danio.ToString();
        //        Vector3 daniopos = Camera.main.WorldToScreenPoint(PosicionDanio.transform.position);
        //        ObjetoDanio.transform.position = daniopos;
        //        //int.TryParse(player.Nombre.Substring(0, 1), out player.Id);

        //        //#region ConBBDD
        //        //player = conexion.CargarDatos(player.Id);
        //        //#endregion

        //        #region SinBBDD
        //        //player.Fuerza = 50;
        //        #endregion

        //    }

        //}
        //if (col.gameObject.name == "Bola(Clone)")
        //{
        //    if (Vector3.Distance(col.gameObject.transform.position, gameObject.transform.position) < 3.5f)
        //    {
        //        anim.SetBool("Perseguir", false);

        //        anim.SetInteger("Atacar", 0);
        //        anim.SetTrigger("Danio");
        //        Atributos.Magia atributos = new Atributos.Magia();
        //        atributos = conexion.CargarDatosMagias(3);
        //        float danio;
        //        danio = atributos.Fuerza - Atributos.Defensa;

        //        Atributos.VidaCombate = Mathf.Clamp(Atributos.VidaCombate - danio, 0f, Atributos.Vida);
        //        //Vida.transform.localScale = new Vector2(Atributos.VidaCombate / Atributos.Vida, 0.5f);
        //        //int.TryParse(gameObject.name.Substring(0, 1), out Atributos.Id);
        //        conexion.update_functionEnemigo(Atributos.Id, Atributos.VidaCombate);
        //        //player.Nombre = Personaje.gameObject.name;
        //        ObjetoDanio.SetActive(true);
        //        danioRecibido.text = danio.ToString();
        //        Vector3 daniopos = Camera.main.WorldToScreenPoint(PosicionDanio.transform.position);
        //        ObjetoDanio.transform.position = daniopos;
        //        //int.TryParse(player.Nombre.Substring(0, 1), out player.Id);

        //        //#region ConBBDD
        //        //player = conexion.CargarDatos(player.Id);
        //        //#endregion

        //        #region SinBBDD
        //        //player.Fuerza = 50;
        //        #endregion

        //    }

        //}
        //if (col.gameObject.name == "Energia(Clone)")
        //{
        //    if (Vector3.Distance(col.gameObject.transform.position, gameObject.transform.position) < 3.5f)
        //    {
        //        anim.SetBool("Perseguir", false);

        //        anim.SetInteger("Atacar", 0);
        //        anim.SetTrigger("Danio");
        //        Atributos.Magia atributos = new Atributos.Magia();
        //        atributos = conexion.CargarDatosMagias(7);
        //        float danio;
        //        danio = atributos.Fuerza - Atributos.Defensa;

        //        Atributos.VidaCombate = Mathf.Clamp(Atributos.VidaCombate - danio, 0f, Atributos.Vida);
        //        //Vida.transform.localScale = new Vector2(Atributos.VidaCombate / Atributos.Vida, 0.5f);
        //        //int.TryParse(gameObject.name.Substring(0, 1), out Atributos.Id);
        //        conexion.update_functionEnemigo(Atributos.Id, Atributos.VidaCombate);
        //        //player.Nombre = Personaje.gameObject.name;
        //        ObjetoDanio.SetActive(true);
        //        danioRecibido.text = danio.ToString();
        //        Vector3 daniopos = Camera.main.WorldToScreenPoint(PosicionDanio.transform.position);
        //        ObjetoDanio.transform.position = daniopos;
        //        //int.TryParse(player.Nombre.Substring(0, 1), out player.Id);

        //        //#region ConBBDD
        //        //player = conexion.CargarDatos(player.Id);
        //        //#endregion

        //        #region SinBBDD
        //        //player.Fuerza = 50;
        //        #endregion

        //    }

        //}
    }

    void OnTriggerExit(Collider col)
    {
       // Perseguir = false;
       // anim.SetBool("Perseguir", Perseguir);
       // nav.SetDestination(Referencia.position);
    }
    Atributos.NPC ConsultarEstado(Atributos.NPC atributos)
    {
        atributos = Atributos;
        atributos.Vida = Hp;
        return atributos;
    }
}
