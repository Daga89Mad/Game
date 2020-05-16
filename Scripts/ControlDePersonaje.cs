using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Photon.Pun;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]

public class ControlDePersonaje : Photon.Pun.MonoBehaviourPun/*MonoBehaviour*/ {

    [SerializeField]  private Camera m_Camera;
    public bool Personaje;
    public float speed = 1.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    Atributos.Player AtributosPersonaje;
   // Enemigo AEnemigo;//Struct creado en Atributos.cs
    public bool rodar = false;                 //Animacion rodar
    public bool atacar = false;                //Animacion atacar
    public bool especial = false;              //Animacion especial
    public GameObject Seleccion;
    public GameObject BarraVida;
    //Barras Barras;
   // Cat Enemigo;
    //Barras de vida
    [System.NonSerialized]
    public float lookWeight;                    // the amount to transition when using head look

    [System.NonSerialized]
    public Transform enemy;                     // a transform to Lerp the camera to during head look
    float currenTime = 0;
    float maxTime = 1.2f;
    public float animSpeed = 1.5f;              // a public setting for overall animator animation speed
    public float lookSmoother = 3f;             // a smoothing setting for camera motion
    public bool useCurves;                      // a setting for teaching purposes to show use of curves

    private Animator anim;                          // a reference to the animator on the character
    private AnimatorStateInfo currentBaseState;         // a reference to the current state of the animator, used for base layer
    private AnimatorStateInfo layer2CurrentState;   // a reference to the current state of the animator, used for layer 2
    private CapsuleCollider col;                    // a reference to the capsule collider of the character

    CharacterController controller;
    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int locoState = Animator.StringToHash("Base Layer.Locomotion");          // these integers are references to our animator's states
    static int jumpState = Animator.StringToHash("Base Layer.Jump");                // and are used to check state for various actions to occur
    static int jumpDownState = Animator.StringToHash("Base Layer.JumpDown");        // within our FixedUpdate() function below
    static int fallState = Animator.StringToHash("Base Layer.Fall");
    static int rollState = Animator.StringToHash("Base Layer.Roll");

   // static int waveState = Animator.StringToHash("Layer2.Wave");
    // Use this for initialization

    void Start()
    {
        //Player= photonView.IsMine;
        controller = GetComponent<CharacterController>();
        ////controller.enabled = false;
        //Vector3 PosInicial = GameObject.Find("Cube").transform.position;
        //GameObject Personaje = GameObject.Find("Cube");
        //GameObject Personaje2 = GameObject.Find("1.Daga");
        //Personaje2.transform.position = Personaje.transform.position;
        //controller.enabled = true;
        // initialising reference variables
        anim = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();
        //enemy = GameObject.Find("Enemy").transform;
        BarraVida = GameObject.Find("BarraVida");//No detecta este objeto lo pongo publico
        if (!photonView.IsMine)
        {
            m_Camera.enabled = false;
        }

        if (anim.layerCount == 2)
            anim.SetLayerWeight(1, 1);
        
    }

    void FixedUpdate()
    {

        //if (Personaje)
        //{
            //bool Personaje = photonView.IsMine;
            //CharacterController n = controller;
            // is the controller on the ground?
            if (controller.isGrounded)
            {
                //Feed moveDirection with input.
                moveDirection = new Vector3(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0, CrossPlatformInputManager.GetAxisRaw("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                //Multiply it by speed.
                moveDirection.x *= speed;
                moveDirection.z *= speed;

            }

            transform.Rotate(0, CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0);
            //Applying gravity to the controller
            moveDirection.y -= gravity * Time.deltaTime;
            //Making the character move
            controller.Move(moveDirection * Time.deltaTime);//Lo dejo activado por el Online.


            float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");               // setup h variable as our horizontal input axis
            float v = CrossPlatformInputManager.GetAxisRaw("Vertical");             // setup v variables as our vertical input axis
            anim.SetFloat("Speed", v);                          // set our animator's float parameter 'Speed' equal to the vertical input axis				
            anim.SetFloat("Direction", h);                      // set our animator's float parameter 'Direction' equal to the horizontal input axis		
            anim.speed = animSpeed;                             // set the speed of our animator to the public variable 'animSpeed'
                                                                //anim.SetLookAtWeight(lookWeight);                   // set the Look At Weight - amount to use look at IK vs using the head's animation
            currentBaseState = anim.GetCurrentAnimatorStateInfo(0); // set our currentState variable to the current state of the Base Layer (0) of animation

            if (anim.layerCount == 2)
                layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);   // set our layer2CurrentState variable to the current state of the second Layer (1) of animation
                                                                            // lookWeight = Mathf.Lerp(lookWeight, 0f, Time.deltaTime * lookSmoother);
            #region Animaciones
            if (rodar == true)
            {
                anim.SetBool("Roll", true);

            }
            else
            {
                anim.SetBool("Roll", false);
            }
            if (atacar == true)
            {
                anim.SetBool("Atacar", true);
            }
            else
            {
                currenTime += Time.deltaTime;
                if (currenTime >= maxTime)
                {
                    currenTime = 0;
                    anim.SetBool("Atacar", false);
                }

            }
            if (especial == true)
            {
                anim.SetBool("Especial", true);

            }
            else
            {
                anim.SetBool("Especial", false);
            }
            #endregion

        //}
        //else
        //{
        //    Personaje = photonView.IsMine;
        //}
    }
    #region Activar/Desactivar Animaciones
    private void OnTriggerEnter(Collider col)
    {

    }
        public void Rodar()
        {
            rodar = true;
        }
        public void NoRodar()
        {
            rodar = false;
        }
        public void Atacar()
        {
            atacar = true;

        }
        public void NoAtacar()
        {
            atacar = false;

        }
        public void Especial()
        {
            especial = true;
        }
        public void NoEspecial()
        {
            especial = false;
        }
    #endregion

}
