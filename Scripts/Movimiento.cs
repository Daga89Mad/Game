using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]

public class Movimiento : MonoBehaviour
{
    public GameObject Disparos;
    private Animator anim;                          // a reference to the animator on the character
    private AnimatorStateInfo currentBaseState;         // a reference to the current state of the animator, used for base layer
    private AnimatorStateInfo layer2CurrentState;   // a reference to the current state of the animator, used for layer 2
    private CapsuleCollider col;
    public float speed = 0.6F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float animSpeed = 1.5f;              // a public setting for overall animator animation speed
    public float lookSmoother = 3f;             // a smoothing setting for camera motion
    public bool useCurves;
    public int Prueba = 0;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //aquí asignamos el animator a la variable
        controller = GetComponent<CharacterController>();
        controller.isTrigger = true;
        col = GetComponent<CapsuleCollider>();
        if (anim.layerCount == 2)
            anim.SetLayerWeight(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if ( Prueba == 1)
        {
            Vector3 Posicion = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(Disparos, Posicion, Quaternion.identity);
        }
    }
    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0, CrossPlatformInputManager.GetAxisRaw("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection.x *= speed;
            moveDirection.z *= speed;
            //Jumping
        }
        transform.Rotate(0, CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0);
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        //controller.Move(moveDirection * Time.deltaTime);


        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal"); // setup h variable as our horizontal input axis
        float v = CrossPlatformInputManager.GetAxisRaw("Vertical");  // setup v variables as our vertical input axis
        anim.SetFloat("Speed", v);                                  // set our animator's float parameter 'Speed' equal to the vertical input axis				
        anim.SetFloat("Direccion", h);                             // set our animator's float parameter 'Direction' equal to the horizontal input axis		                      // set our animator's float parameter 'Direction' equal to the horizontal input axis		
        anim.speed = animSpeed;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "R_elbow")
        {
            anim.SetTrigger("Danio");
        }

    }
}
