using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Atributos : MonoBehaviour
{
    List<NPC> Listadoenemigos;
    List<Player> ListadoJugadores;
    public struct Equipo
    {       
        public int Id;
        public int IdObjeto;
        public int Cantidad;
        public string Nombre;
        public string Descripcion;
        public int Tipo;
        public int Rango;

    }
    public struct Bolsa
    {
        public int Huecos;
        public int Id;
        public int IdObjeto;
        public int Cantidad;
        public string Nombre;
        public string Descripcion;
        public int Tipo;
        //public gameObject Barras;//Creo q esto seria mejor en otro struct
    }
    public struct Player
    {
        public int Id;
        public int Nivel;
        public int Fuerza;
        public int Defensa;
        public int Velocidad;
        public string Nombre;
        public float Vida;
        public float Estamina;
        public float VidaCombate;
        public float EstaminaCombate;
        public int IdObjeto;
        public int Cantidad;
        public string NombreObjeto;
        public string DescripcionObjeto;
        public int Cantidad2;
        public string NombreObjeto2;
        public string DescripcionObjeto2;
        public int Habilidad1;
        public string NombreHabilidad1;
        public string DescripcionHabilidad1;
        public int Habilidad2;
        public string NombreHabilidad2;
        public string DescripcionHabilidad2;
        public int Habilidad3;
        public string NombreHabilidad3;
        public string DescripcionHabilidad3;
        public int Atacar;
        public string NombreAtacar;
        public string DescripcionAtacar;
        public int Esquivar;
        public string NombreEsquivar;
        public string DescripcionEsquivar;
        public List<Bolsa> Bolsa;
        //public gameObject Barras;//Creo q esto seria mejor en otro struct
    }

    public struct NPC
    {
        public int Id;
        public int Nivel;
        public int Fuerza;
        public int Defensa;
        public int Velocidad;
        public string Nombre;
        public float Vida;
        public float Estamina;
        public float VidaCombate;
        public float EstaminaCombate;
        public int IdObjeto;
        public int Cantidad;
        public string NombreObjeto;
        public string DescripcionObjeto;
        public int IdAsesino;
        public int idMision;
        public string nombreMision;
        public string descripcionMision;
        //public gameObject Barras;//Creo q esto seria mejor en otro struct
    }
   
    public struct Personalizacion
    {
        public int IdPersonaje;
        public int IdCasco;
        public int IdCapucha;
        public string NombreCasco;
        public string DescripcionCasco;
        public int IdArma;
        public string NombreArma;
        public string DescripcionArma;
        public int IdTraje;
        public string NombreTraje;
        public string DescripcionTraje;
        public int IdCompa;
        public string NombreCompa;
        public string DescripcionCompa;
    }
    public struct Magia
    {
        public int Id;
        public string Nombre;
        public int Fuerza;
        public float Estamina;
        public int Velocidad;
        public int TiempoRecuperacion;
        public string Descripcion;

        //public gameObject Barras;//Creo q esto seria mejor en otro struct
    }
    //public struct BolsaEnemigo
    //{
    //    public int Id;
    //    public int IdObjeto;
    //    public int Cantidad;
    //    public string Nombre;
    //    public string Descripcion;
    //    //public gameObject Barras;//Creo q esto seria mejor en otro struct
    //}
    //void Start()
    //{
    //    //ListadoJugadores = CargarJugadores(ListadoJugadores);
    //    //Listadoenemigos = CargarEnemigos(Listadoenemigos);
    //}
    public Player ConsultarAtributos(Player atributos)
    {

        foreach (Player Busqueda in ListadoJugadores)
        {
            if (Busqueda.Nombre==atributos.Nombre)
            {
                atributos = Busqueda;
            }

        }
        return atributos;
    }
    public List<Player> CargarJugadores(List<Player> atributos)
    {
        Player player=new Player();

        #region SinBBDD
        player.Fuerza = 50;
        player.Estamina = 500;
        player.Vida = 500;
        player.Defensa = 20;
        player.Nivel = 15;
        player.Velocidad = 2;
        player.Nombre ="Personaje";
        #endregion


        atributos.Add(player);

        return atributos;
    }
    public List<NPC> CargarEnemigos(List<NPC> atributos)
    {
        NPC npc = new NPC();

        #region SinBBDD
        npc.Fuerza = 50;
        npc.Estamina = 500;
        npc.Vida = 500;
        npc.Defensa = 20;
        npc.Nivel = 15;
        npc.Velocidad = 2;
        npc.Nombre = "Personaje";
        #endregion


        atributos.Add(npc);

        return atributos;
    }
}
