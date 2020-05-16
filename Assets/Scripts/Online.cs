using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Online : MonoBehaviourPunCallbacks
{
    public Button Conectar;
    public Button Join;
    public Text Log;
    public byte NPersonas = 3;
    public byte MinNPersonas = 1;
    public Text Personcount;
    public int personcount;
    bool isloading = false;

    public void conect()
    {
        if (!PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.ConnectUsingSettings())
            {
                Log.text += "\nConectado al servidor";
            }
            else
            {
                Log.text += "\nFallo al conectar con servidor";
            }

        }

    }
    public override void OnConnectedToMaster()
    {
        Conectar.interactable = false;
        Join.interactable = true;
    }
    public void JoinRandom()
    {
        if (PhotonNetwork.JoinRandomRoom())
        {
            Log.text += "\nEntrando a sala";
        }
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Log.text += "\nCreando sala";
        if (PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions() { MaxPlayers = NPersonas }))
        {
            Log.text += "\nSala Creada";
        }
        else
        {
            Log.text += "\nFallo al crear sala";
        }
    }

    public override void OnJoinedRoom()
    {
        Log.text += "\nEstas dentro";
        Join.interactable = false;
    }
    private void FixedUpdate()
    {
        if (PhotonNetwork.CurrentRoom!=null)
        {
            personcount = PhotonNetwork.CurrentRoom.PlayerCount;
            Personcount.text = personcount + "/" + NPersonas;
        }
        if (!isloading && personcount >= MinNPersonas)
        {
            LoadMap();
        }
    }
    private void LoadMap()
    {
        isloading = true;
        PhotonNetwork.LoadLevel("OnlineJuego");
    }
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
            Personcount.text = personcount + "/" + NPersonas;
        }
        if (!isloading && personcount >= MinNPersonas)
        {
            LoadMapMinas();
        }
    }
}
