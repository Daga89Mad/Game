using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InstanciarInicio : MonoBehaviour
{
    public GameObject Personaje;
    public GameObject Personaje2;
    public GameObject Spawner;
    public GameObject Spawner2;
    string Jugador1;
    int Jugador2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Jugador1 = Photon.Pun.PhotonNetwork.PlayerListOthers.ToString();

       
        //Jugador2= PhotonNetwork.CurrentRoom.;

        //if (Jugador1<Jugador2)
        //{
        //if (Photon.Pun.PhotonNetwork.LocalPlayer.ActorNumber == 1)
        //{
            Photon.Pun.PhotonNetwork.Instantiate(Personaje.name, Spawner.transform.position, Quaternion.identity);

        //}
        //else
        //{
        //    Photon.Pun.PhotonNetwork.Instantiate(Personaje2.name, Spawner2.transform.position, Quaternion.identity);
        //}
        
            //Photon.Pun.PhotonNetwork.Instantiate(Personaje.name, Spawner2.transform.position, Quaternion.identity);
            //Instantiate(Personaje,Spawner.transform); 
        //}
        //else if (Jugador2 == 2)
        //{
        //    Photon.Pun.PhotonNetwork.Instantiate(Personaje.name, Spawner2.transform.position, Quaternion.identity);
        //}
        
    }

}
