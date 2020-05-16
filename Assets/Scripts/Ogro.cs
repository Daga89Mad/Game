using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Ogro : MonoBehaviour
{
    
    public GameObject target;
    public GameObject target2;
    public GameObject target3;
    int _target=0;
    NavMeshAgent agent;
    public Atributos.NPC AtributosNPC = new Atributos.NPC();
    //public event System.Action<float> onhe
    public Text danioRecibido;
    //public GameObject ObjetoDanio;
    public GameObject BarraVida;
    public GameObject BarraDanio;
    public GameObject BarraFondo;
    public GameObject ObjetoBarrasVida;
    private Animator anim;
    Atributos.Player player;
    private Transform Personaje;
    //Android conexion = new Android();
    public int MoveSpeed;
    public float vida = 4000;
    public float vidaCombate = 4000;
    public int nivel = 15;
    public int fuerza = 200;
    public int defensa = 15;
    public float MaxDist = 10;
    public float MinDist = 1.5f;
    bool Muerto = false;
    Transform Player = null;
    Vector3 EnemyPos;
    float distancia;
    float distanciaCercana = 100;
    public Image VidaImagen;
    List<Transform> PlayerTransform = new List<Transform>();
    bool humano = false;
    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
        #region SinBBDD
        //Asi puedo cambiar los valores en ejecucion al estar public
        AtributosNPC.Vida = vida;
        AtributosNPC.VidaCombate = vidaCombate;
        AtributosNPC.Fuerza = fuerza;
        AtributosNPC.Defensa = defensa;
        AtributosNPC.Nivel = nivel;
        //*****************************************
        #endregion
        anim = GetComponent<Animator>();
        //BarraVida.transform.position = BarraDanio.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Muerto = anim.GetBool("Muerte");
        if (!Muerto)
        {
           
            if (!humano)
            {
                if (_target == 0)
                {
                    anim.SetBool("Perseguir", true);
                    anim.SetInteger("Atacar", 0);
                    if (agent.remainingDistance < 1)
                    {
                        agent.SetDestination(target2.transform.position);
                        anim.SetBool("Perseguir", false);
                        _target = 1;


                    }

                }
                else if (_target == 1)
                {
                    anim.SetBool("Perseguir", true);
                    anim.SetInteger("Atacar", 0);

                    if (agent.remainingDistance < 1)
                    {
                        agent.SetDestination(target3.transform.position);
                        anim.SetBool("Perseguir", false);
                        _target = 2;

                    }
                }
                else if (_target == 2)
                {

                    anim.SetBool("Perseguir", true);
                    anim.SetInteger("Atacar", 0);

                    if (agent.remainingDistance < 1)
                    {
                        agent.SetDestination(target.transform.position);
                        anim.SetBool("Perseguir", false);
                        _target = 0;
                    }
                }
            }
            else
            {
                agent.isStopped=true;
                anim.SetBool("Perseguir", false);//Esto es porque el ogro tiener perseguir como andar y luego otro estado que es correr.
                var Yeah = GameObject.FindGameObjectsWithTag("Player");
                PlayerTransform = new List<Transform>();
                foreach (var child in Yeah)
                {
                    PlayerTransform.Add(child.transform);
                }
                foreach (Transform t in PlayerTransform)
                {
                    EnemyPos = transform.position;
                    distancia = Vector3.Distance(EnemyPos, t.position);
                    if (distancia < distanciaCercana)
                    {
                        distanciaCercana = distancia;
                        Player = t;
                    }
                }
                Vector3 PlayerPos = Player.position;


                if (distanciaCercana >= MinDist && distanciaCercana <= MaxDist)
                {
                    anim.SetBool("Correr", true);
                    anim.SetInteger("Atacar", 0);
                    // this.transform.position.y -= gravity * Time.deltaTime;
                    // targetPos.y -= gravity * Time.deltaTime;
                    gameObject.transform.LookAt(PlayerPos);
                    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                }

                if (distanciaCercana > 0 && distanciaCercana < MinDist)
                {
                    distanciaCercana = 100;
                    // transform.LookAt(targetPos);
                    anim.SetBool("Correr", false);
                    anim.SetInteger("Atacar", 1);
                    //gameObject.transform.LookAt(PlayerPos);
                    //ObjetoDanio.transform.LookAt(PlayerPos);
                    //Vector3 targetPos = new Vector3(Player.position.x,
                    //this.transform.position.y,
                    //Player.position.z);

                }


            }
           
            if (AtributosNPC.VidaCombate <= 0)
            {
                //ControlDePersonaje controlDePersonaje = new ControlDePersonaje();
                //controlDePersonaje.MorirOn();
                anim.SetBool("Muerte", true);
                Muerto = true;
            }
            //BarraVida.transform.LookAt(Camera.main.transform);
            //BarraDanio.transform.LookAt(Camera.main.transform);
            //BarraFondo.transform.LookAt(Camera.main.transform);
            //ObjetoBarrasVida.transform.LookAt(Camera.main.transform);
            // BarraVida.transform.localScale = new Vector2(AtributosNPC.VidaCombate / AtributosNPC.Vida, 2);
            //var RestaVida= AtributosNPC.VidaCombate / AtributosNPC.Vida;
            // VidaImagen.fillAmount= AtributosNPC.VidaCombate / AtributosNPC.Vida;

            //PosicionDanio.transform.Rotate(0, 180, 0);


        }
        else
        {
            //Destroy(this.BarraVida,3);  
            //Destroy(this.BarraDanio,3);
            //Destroy(this.BarraFondo,3);
            Destroy(ObjetoBarrasVida, 3);
            Destroy(this.gameObject, 25);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.name.Substring(0, 2) == "0.")
        {
            humano = true;
           

        }
        if (col.gameObject.name.Substring(0, 2) == "2.")
        {
            if (Vector3.Distance(col.gameObject.transform.position, gameObject.transform.position) < 3.5f)
            {
                anim.SetBool("Perseguir", false);
                GameObject Agresor = col.gameObject;
                GameObject PadreAgresor = col.gameObject;
                //anim.SetInteger("Atacar", 0);
                Agresor = col.gameObject;
                do
                {
                    PadreAgresor = PadreAgresor.transform.parent.gameObject; //Personaje.gameObject.name;
                    player.Nombre = PadreAgresor.gameObject.name;
                } while (player.Nombre.Substring(0, 1) != "0");


                APlayer _aplayer = PadreAgresor.GetComponent<APlayer>();
                //int.TryParse(player.Nombre.Substring(2, 1), out player.Id);

                //#region ConBBDD
                //player = conexion.CargarDatos(player.Id);
                //#endregion

                #region SinBBDD
                player.Fuerza = _aplayer.Atributos.Fuerza;
                //player.Fuerza = 50;
                #endregion

                //GameObject Agresor = GameObject.Find(player.Id + "." + player.Nombre.ToString());
                Animator An = PadreAgresor.GetComponent<Animator>();
                int EstadoActual = An.GetInteger("Accion");
                if ((EstadoActual == 1) || (col.name.Substring(2, 4) == "Bala"))
                {
                    float danio;
                    danio = player.Fuerza - defensa;

                    AtributosNPC.VidaCombate = Mathf.Clamp(AtributosNPC.VidaCombate - danio, 0f, AtributosNPC.Vida);
                    // BarraVida.transform.localScale = new Vector2(AtributosNPC.VidaCombate / AtributosNPC.Vida, 2);
                    VidaImagen.fillAmount = AtributosNPC.VidaCombate / AtributosNPC.Vida;
                    if (vidaCombate<=0)
                    {
                        Muerto = true;
                        anim.SetBool("Muerte", true);
                    }
                    //int.TryParse(gameObject.name.Substring(0, 1), out Atributos.Id);
                    // conexion.update_functionEnemigo(Atributos.Id, Atributos.VidaCombate);
                    // ObjetoDanio.SetActive(true);
                    //danioRecibido.text = vidaCombate.ToString();
                    // Vector3 daniopos = Camera.main.WorldToScreenPoint(PosicionDanio.transform.position);
                    // ObjetoDanio.transform.position = daniopos;
                    // anim.SetTrigger("Danio");
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
}
