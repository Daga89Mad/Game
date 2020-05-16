using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CambioEscenaOnline : MonoBehaviourPunCallbacks
{
    public Button Conectar;
    public Button Join;
    public Text Log;
    public byte NPersonas = 3;
    public byte MinNPersonas = 1;
    public Text Personcount;
    public int personcount;
    bool isloading = false;


    private void LoadMapMinas()
    {
        isloading = true;
        PhotonNetwork.LoadLevel("Minas");
    }
    void OnTriggerEnter(Collider col)
    {
        if (PhotonNetwork.CurrentRoom != null)
        {
            personcount = PhotonNetwork.CurrentRoom.PlayerCount;
          
        }
        if (!isloading && personcount >= MinNPersonas)
        {
            LoadMapMinas();
        }
    }
}
