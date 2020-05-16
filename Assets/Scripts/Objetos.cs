using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Objetos : MonoBehaviour
{
    bool coger = false;
    GameObject Personaje;
   public GameObject BtnRecogerObj;
    public Text Informacion;
    public GameObject CanvasInfo;
    Android conexion = new Android();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.name != "Terrain (2)")
        {
            CanvasInfo.SetActive(true);
            BtnRecogerObj.SetActive(true);
            Informacion.text = gameObject.name;
            Button _recogerObj = BtnRecogerObj.GetComponent<Button>();
            _recogerObj.onClick.AddListener(delegate { RecogerTodo(other.name); });//LLama al evento onclick del boton y lo modifica cada vez q un personaje entra

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.name != "Terrain (2)")
        {
            Informacion.text = "";
            BtnRecogerObj.SetActive(false);
            CanvasInfo.SetActive(false);
           
        }

    }
    public void RecogerTodo( string nombrePersonaje)
    {

        // GameObject Personaje = GameObject.Find(nombrePersonaje);
        // var _bolsa = Personaje.GetComponent<APlayer>();
        //// _bolsa.Atributos.Bolsa=

        Atributos.Bolsa atributos;

        Regex pattern = new Regex(@"(.+?)(\.[^.] *$|$) *");
        Match match = pattern.Match(this.name);
        string _nombre = match.ToString();
        _nombre = _nombre.Split('.')[0];
        int.TryParse(_nombre, out atributos.IdObjeto);

        pattern = new Regex(@"(.+?)(\.[^.] *$|$) *");
        match = pattern.Match(nombrePersonaje);
        _nombre = match.ToString();
        _nombre = _nombre.Split('.')[0];
        int.TryParse(_nombre, out atributos.Id);
        atributos.Cantidad = 2;

        conexion.insertBolsa(atributos.IdObjeto, atributos.Id, atributos.Cantidad);
        //var objBolsa = conexion.CargarDatosBolsa(atributos.Id);


        //conexion.update_RecogerBolsa(bolsa);
        //conexion.insertBolsa(this);
        Destroy(gameObject);
    }  
}
