using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuJugar : MonoBehaviour
{
    bool volveramenu = false;
    bool misiones = false;
    bool online = false;
    bool nuevapartida = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Misiones()
    {
        misiones = true;
        volveramenu = false;
    }
    public void VolverAMenu()
    {
        volveramenu = true;
        misiones = false;
    }
    public void Online()
    {
        online = true;
    }
    public void NuevaPartida()
    {
        nuevapartida = true;
    }
}
