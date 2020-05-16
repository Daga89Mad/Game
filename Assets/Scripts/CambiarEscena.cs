using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public Atributos.Player Atributos = new Atributos.Player();
    Android conexion = new Android();
    Atributos bbdd = new Atributos();

    public void Escena(string Escena)
    {

        switch (Escena)
        {
            case "Mina":
                SceneManager.LoadScene("Mina");
                break;

            case "Mision1":
                SceneManager.LoadScene("Mision1");

                break;
            case "MenuPrincipal":
                SceneManager.LoadScene("MenuPrincipal");

                break;
            case "OnlineSalaEspera":
                SceneManager.LoadScene("OnlineSalaEspera");

                break;

        }

    }
    void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.name == "0.1.Daga")
        {

            Atributos.Nombre = o.name;
            int.TryParse(Atributos.Nombre.Substring(2, 1), out Atributos.Id);
            Atributos = conexion.CargarDatos(Atributos.Id);
            if (Atributos.IdObjeto == 1)
            {
                Escena("Mina");
            }

        }

    }
}
