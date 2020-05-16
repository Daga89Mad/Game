using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//References
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;
public class Android : MonoBehaviour
{
    private string conn, sqlQuery, sqlQuery2, sqlQuery3;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    private IDataReader reader;
    public InputField t_name, t_Address, t_id;
    public Text data_staff;
    public GameObject Text;
    string Info;

    string DatabaseName = "VANIR.db";
    // Start is called before the first frame update
    public void OpenDb()
    {
        //Application database Path android
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database

            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/VANIR");



            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/VANIR.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);




        }

        conn = "URI=file:" + filepath;
        //Application.persistentDataPath + "/" + DatabaseName;
        //conn = "URI=file:" + Application.dataPath + "/Plugins/VANIR.db"; //Path to database.
        Debug.Log("Stablishing connection to: " + conn);
        dbconn = new SqliteConnection(conn);
        // dbconn.Open();
        string Namereaders, Addressreaders;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT ID,NOMBRE,VIDA,VIDACOMBATE " + "FROM Personajes where id=1";// table name
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string Nombre = reader.GetString(1);
                    float Vida = reader.GetFloat(2);
                    float VidaCombate = reader.GetFloat(3);

                    // Debug.Log("ID= " + Id + "  name =" + Nombre + "  VIDA =" + Vida + "VIDA COMBATE =" + VidaCombate);
                    Info = Id.ToString() + " " + Nombre.ToString() + " " + Vida.ToString() + " " + VidaCombate.ToString();

                    //data_staff.text += Namereaders + " - " + Addressreaders + "\n";
                    //Debug.Log(" name =" + Namereaders + "Address=" + Addressreaders);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                Text.GetComponent<Text>().text = Info;
            }
            catch (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }
            //       dbconn = null;

        }
        string query;
        //query = "CREATE TABLE Staff (ID INTEGER PRIMARY KEY   AUTOINCREMENT, Name varchar(100), Address varchar(200))";
        //try
        //{
        //    dbcmd = dbconn.CreateCommand(); // create empty command
        //    dbcmd.CommandText = query; // fill the command
        //    reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        //}
        //catch (Exception e)
        //{

        //    Debug.Log(e);

        //}
        //  reader_function();
    }
    //Insert
    public void insert_button()
    {
        insert_function(t_name.text, t_Address.text);

    }
    //Search 
    public void Search_button()
    {
        data_staff.text = "";
        Search_function(t_id.text);

    }

    //Found to Update 
    public void F_to_update_button()
    {
        data_staff.text = "";
        F_to_update_function(t_id.text);

    }
    //Update
    public void Update_button()
    {
        // update_function(t_id.text, t_name.text, t_Address.text);

    }

    //Delete
    public void Delete_button()
    {
        data_staff.text = "";
        Delete_function(t_id.text);

    }

    //Insert To Database
    private void insert_function(string name, string Address)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into Staff (name, Address) values (\"{0}\",\"{1}\")", name, Address);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
        data_staff.text = "";
        Debug.Log("Insert Done  ");

        reader_function();
    }
    public void insertMision(int Id)
    {
        int REALIZADA = 0;
        int PENDIENTE = 1;
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        conn = "URI=file:" + filepath;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format($@"insert into MisionesAceptadas (IDMISION, REALIZADA, PENDIENTE) values ({Id},{REALIZADA}, {PENDIENTE})");
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }

    }
    //Insert To Database
    public void insertBolsa(int IdObjeto, int IdPersonaje, int Cantidad)
    {
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        conn = "URI=file:" + filepath;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format($@"insert into Bolsa (IDOBJETO, IDPERSONAJE, CANTIDAD) 
                values ({IdObjeto},{IdPersonaje}, {Cantidad})");
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }

    }
    //Read All Data For To Database
    private void reader_function()
    {
        // int idreaders ;
        string Namereaders, Addressreaders;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT  Name, Address " + "FROM Staff";// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                // idreaders = reader.GetString(1);
                Namereaders = reader.GetString(0);
                Addressreaders = reader.GetString(1);

                data_staff.text += Namereaders + " - " + Addressreaders + "\n";
                Debug.Log(" name =" + Namereaders + "Address=" + Addressreaders);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            //       dbconn = null;

        }
    }
    //Search on Database by ID
    private void Search_function(string Search_by_id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            string Name_readers_Search, Address_readers_Search;
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT name,address " + "FROM Staff where id =" + Search_by_id;// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                //  string id = reader.GetString(0);
                Name_readers_Search = reader.GetString(0);
                Address_readers_Search = reader.GetString(1);
                data_staff.text += Name_readers_Search + " - " + Address_readers_Search + "\n";

                Debug.Log(" name =" + Name_readers_Search + "Address=" + Address_readers_Search);

            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();


        }

    }


    //Search on Database by ID
    private void F_to_update_function(string Search_by_id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            string Name_readers_Search, Address_readers_Search;
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT name,address " + "FROM Staff where id =" + Search_by_id;// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {

                Name_readers_Search = reader.GetString(0);
                Address_readers_Search = reader.GetString(1);
                t_name.text = Name_readers_Search;
                t_Address.text = Address_readers_Search;

            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();


        }

    }

    public void update_RecogerBolsa(Atributos.NPC NPC)
    {
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database

            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/VANIR");



            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/VANIR.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);




        }
        conn = "URI=file:" + filepath;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Personajes set IDOBJETO = @IdObjeto where ID = @id ");
            SqliteParameter P_IdAsesino = new SqliteParameter("@IdObjeto", NPC.IdObjeto);
            //SqliteParameter P_update_address = new SqliteParameter("@address", update_address);
            SqliteParameter P_update_id = new SqliteParameter("@id", NPC.IdAsesino);

            dbcmd.Parameters.Add(P_IdAsesino);
            //  dbcmd.Parameters.Add(P_update_address);
            dbcmd.Parameters.Add(P_update_id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            //Search_function(t_id.text);
        }

        // SceneManager.LoadScene("home");
    }

    public void update_RecogerBolsa(Atributos.Bolsa bolsa)
    {
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database

            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/VANIR");



            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/VANIR.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);




        }
        conn = "URI=file:" + filepath;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Bolsa set IDOBJETO = @IdObjeto where IDOBJETO = @id ");
            SqliteParameter P_IdObjeto = new SqliteParameter("@IdObjeto", bolsa.IdObjeto);
            //SqliteParameter P_update_address = new SqliteParameter("@address", update_address);

            dbcmd.Parameters.Add(P_IdObjeto);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            //Search_function(t_id.text);
        }

    }
    public void update_Asesino(Atributos.NPC NPC, Atributos.Player Player)
    {
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database

            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/VANIR");



            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/VANIR.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);




        }
        conn = "URI=file:" + filepath;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Enemigos set IDASESINO = @Playerid where ID = @id ");
            SqliteParameter P_IdAsesino = new SqliteParameter("@Playerid", Player.Id);
            //SqliteParameter P_update_address = new SqliteParameter("@address", update_address);
            SqliteParameter P_update_id = new SqliteParameter("@id", NPC.Id);

            dbcmd.Parameters.Add(P_IdAsesino);
            //  dbcmd.Parameters.Add(P_update_address);
            dbcmd.Parameters.Add(P_update_id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            //Search_function(t_id.text);
        }

        // SceneManager.LoadScene("home");
    }
    //Update on  Database 
    public void update_function(int update_id, float vidaCombate)
    {
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database

            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/VANIR");



            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/VANIR.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);




        }
        conn = "URI=file:" + filepath;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Personajes set VIDACOMBATE = @vidaCombate ,IDOBJETO=" + 1 + " where ID = @id ");
            SqliteParameter P_vidaCombate = new SqliteParameter("@vidaCombate", vidaCombate);
            //SqliteParameter P_update_address = new SqliteParameter("@address", update_address);
            SqliteParameter P_update_id = new SqliteParameter("@id", update_id);

            dbcmd.Parameters.Add(P_vidaCombate);
            //  dbcmd.Parameters.Add(P_update_address);
            dbcmd.Parameters.Add(P_update_id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            //Search_function(t_id.text);
        }

        // SceneManager.LoadScene("home");
    }
    public void update_AceptarMision(int update_id)
    {
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/VANIR");
            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/VANIR.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);

        }
        conn = "URI=file:" + filepath;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE MisionesAceptadas set ID = update_id,PENDIENTE="+ 1 +",REALIZADA=" + 0);           
            //SqliteParameter P_update_address = new SqliteParameter("@address", update_address);
            SqliteParameter P_update_id = new SqliteParameter("@id", update_id);
            dbcmd.Parameters.Add(P_update_id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    public void update_functionEnemigo(int update_id, float vidaCombate)
    {
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database

            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/VANIR");



            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/VANIR.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);




        }
        conn = "URI=file:" + filepath;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Enemigos set VIDACOMBATE = @vidaCombate ,IDASESINO=" + 0 + " where ID = @id ");
            SqliteParameter P_vidaCombate = new SqliteParameter("@vidaCombate", vidaCombate);
            //SqliteParameter P_update_address = new SqliteParameter("@address", update_address);
            SqliteParameter P_update_id = new SqliteParameter("@id", update_id);

            dbcmd.Parameters.Add(P_vidaCombate);
            //  dbcmd.Parameters.Add(P_update_address);
            dbcmd.Parameters.Add(P_update_id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            //Search_function(t_id.text);
        }

        // SceneManager.LoadScene("home");
    }
    public void update_Personaje(int update_id, float idCasco, float idArma, float idTraje, float idCompa, float idCapucha)
    {
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database

            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/VANIR");



            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/VANIR.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);




        }
        conn = "URI=file:" + filepath;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Personajes set CABEZA = @idCasco ,TRAJE=@idTraje, ARMA=@idArma, COMPA=@idCompa , CAPUCHA=@idCapucha where ID = @id ");
            SqliteParameter P_idCasco = new SqliteParameter("@idCasco", idCasco);
            SqliteParameter P_idCapucha = new SqliteParameter("@idCapucha", idCapucha);
            SqliteParameter P_idTraje = new SqliteParameter("@idTraje", idTraje);
            SqliteParameter P_idArma = new SqliteParameter("@idArma", idArma);
            SqliteParameter P_idCompa = new SqliteParameter("@idCompa", idCompa);
            SqliteParameter P_update_id = new SqliteParameter("@id", update_id);

            dbcmd.Parameters.Add(P_idCasco);
            dbcmd.Parameters.Add(P_idCapucha);
            dbcmd.Parameters.Add(P_idTraje);
            dbcmd.Parameters.Add(P_idArma);
            dbcmd.Parameters.Add(P_idCompa);
            //  dbcmd.Parameters.Add(P_update_address);
            dbcmd.Parameters.Add(P_update_id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            //Search_function(t_id.text);
        }

        // SceneManager.LoadScene("home");
    }
    public void update_Habilidad(int update_id, int idHabilidad, int ventana)//Ventana es para saber si grabarlo en el campo magia 1,2,3 ....
    {
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database

            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/VANIR");



            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/VANIR.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);

        }
        conn = "URI=file:" + filepath;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();

            switch (ventana)
            {
                case 1:
                    sqlQuery3 = string.Format("UPDATE MagiasDisponibles SET SELECCIONADO=0 WHERE IDMAGIAS=(SELECT MAGIA1 FROM PERSONAJES WHERE ID=@id) ");
                    sqlQuery = string.Format("UPDATE Personajes set MAGIA1 = @idHabilidad where ID = @id ");
                    sqlQuery2 =string.Format("UPDATE MagiasDisponibles set SELECCIONADO=1 where IDMAGIAS = @idHabilidad ");

                    break;
                case 2:
                    sqlQuery3 = string.Format("UPDATE MagiasDisponibles SET SELECCIONADO=0 WHERE IDMAGIAS=(SELECT MAGIA2 FROM PERSONAJES WHERE ID=@id) ");
                    sqlQuery = string.Format("UPDATE Personajes set MAGIA2 = @idHabilidad where ID = @id ");
                    sqlQuery2 = string.Format("UPDATE MagiasDisponibles set SELECCIONADO=1 where IDMAGIAS = @idHabilidad ");
                    break;
                case 3:
                    sqlQuery3 = string.Format("UPDATE MagiasDisponibles SET SELECCIONADO=0 WHERE IDMAGIAS=(SELECT MAGIA3 FROM PERSONAJES WHERE ID=@id) ");
                    sqlQuery = string.Format("UPDATE Personajes set MAGIA3 = @idHabilidad where ID = @id ");
                    sqlQuery2 = string.Format("UPDATE MagiasDisponibles set SELECCIONADO=1 where IDMAGIAS = @idHabilidad ");
                    break;
                case 4:
                    sqlQuery3 = string.Format("UPDATE MagiasDisponibles SET SELECCIONADO=0 WHERE IDMAGIAS=(SELECT ATACAR FROM PERSONAJES WHERE ID=@id) ");
                    sqlQuery = string.Format("UPDATE Personajes set ATACAR = @idHabilidad where ID = @id ");
                    sqlQuery2 = string.Format("UPDATE MagiasDisponibles set SELECCIONADO=1 where IDMAGIAS = @idHabilidad ");
                    break;
                case 5:
                    sqlQuery3 = string.Format("UPDATE MagiasDisponibles SET SELECCIONADO=0 WHERE IDMAGIAS=(SELECT ESQUIVAR FROM PERSONAJES WHERE ID=@id) ");
                    sqlQuery = string.Format("UPDATE Personajes set ESQUIVAR = @idHabilidad where ID = @id ");
                    sqlQuery2 = string.Format("UPDATE MagiasDisponibles set SELECCIONADO=1 where IDMAGIAS = @idHabilidad ");
                    break;
            }
            SqliteParameter P_idHabilidad = new SqliteParameter("@idHabilidad", idHabilidad);
            SqliteParameter P_update_id = new SqliteParameter("@id", update_id);

            dbcmd.Parameters.Add(P_idHabilidad);
            dbcmd.Parameters.Add(P_update_id);

            dbcmd.CommandText = sqlQuery3;
            dbcmd.ExecuteScalar();
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbcmd.CommandText = sqlQuery2;
            dbcmd.ExecuteScalar();

            dbconn.Close();
            //Search_function(t_id.text);
        }

        // SceneManager.LoadScene("home");
    }

    //Delete
    private void Delete_function(string Delete_by_id)
    {
        using (dbconn = new SqliteConnection(conn))
        {

            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "DELETE FROM Staff where id =" + Delete_by_id;// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();


            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            data_staff.text = Delete_by_id + " Delete  Done ";

        }

    }
    public List<Atributos.Equipo> CargarEquipo(int Id,string tabla)
    {
        List<Atributos.Equipo> Equipo=new List<Atributos.Equipo>();
        Atributos.Equipo _equipo=new Atributos.Equipo();
        //Atributos.Player _atributos = new Atributos.Player();
        //string query = "SELECT * FROM PERSONAJES where ID=" + Id;
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        string conn = "URI=file:" + filepath;
        IDbConnection dbconn;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn = new SqliteConnection(conn);
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT ID,NOMBRE,DESCRIPCION,RANGO " + "from " + tabla; //+ " ID=" + Id;
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    _equipo.Id = reader.GetInt32(0);
                    _equipo.Nombre = reader.GetString(1);
                    _equipo.Descripcion = reader.GetString(2);
                    // _equipo.IdObjeto = reader.GetInt32(3);
                    //_equipo.Tipo = reader.GetInt32(4);
                    _equipo.Rango = reader.GetInt32(3);

                    Equipo.Add(_equipo);
                 
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
            catch
            (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }
        }
        return Equipo;
    }
    public Atributos.Player CargarDatos(int Id)
    {
        Atributos.Player _atributos = new Atributos.Player();
        //string query = "SELECT * FROM PERSONAJES where ID=" + Id;
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        string conn = "URI=file:" + filepath;
        IDbConnection dbconn;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn = new SqliteConnection(conn);
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT P.ID,P.NOMBRE,P.NIVEL,FUERZA,DEFENSA,VELOCIDAD,VIDA,ESTAMINA,VIDACOMBATE,CANTIDAD,O.NOMBRE,O.DESCRIPCION,P.IDOBJETO " + "from Personajes P INNER JOIN Objetos O on P.IDOBJETO = O.ID where P.ID=" + Id;
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    _atributos.Id = reader.GetInt32(0);
                    _atributos.Nombre = reader.GetString(1);
                    _atributos.Nivel = reader.GetInt32(2);
                    _atributos.Fuerza = reader.GetInt16(3);
                    _atributos.Defensa = reader.GetInt32(4);
                    _atributos.Velocidad = reader.GetInt32(5);
                    _atributos.Vida = reader.GetFloat(6);
                    _atributos.Estamina = reader.GetFloat(7);
                    _atributos.VidaCombate = reader.GetFloat(8);
                    _atributos.Cantidad = reader.GetInt32(9);
                    _atributos.NombreObjeto = reader.GetString(10);
                    _atributos.DescripcionObjeto = reader.GetString(11);
                    _atributos.IdObjeto = reader.GetInt32(12);


                    //_atributos.VidaCombate = reader.GetFloat(11);
                    //atributos.EstaminaCombate = reader.GetFloat(6);

                    //Debug.Log("ID= " + Id + "  name =" + Nombre + "  VIDA =" + Vida + "ESTAMINA =" + Estamina);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
            catch
            (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }


        }
        return _atributos;

    }
    public Atributos.Player CargarDatosHabilidad(int Id)
    {
        Atributos.Player _atributos = new Atributos.Player();
        //string query = "SELECT * FROM PERSONAJES where ID=" + Id;
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        string conn = "URI=file:" + filepath;
        IDbConnection dbconn;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn = new SqliteConnection(conn);
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT P.MAGIA1,(select NOMBRE from MagiasDisponibles where IDMAGIAS = (select MAGIA1 from Personajes where id = " + Id + ")) as NombreMAGIA1,(select DESCRIPCION from MagiasDisponibles where IDMAGIAS = (select MAGIA1 from Personajes where id = " + Id + ")) as DESCRIPCIONMAGIA1," +
                    "P.MAGIA2,(select NOMBRE from MagiasDisponibles where IDMAGIAS = (select MAGIA2 from Personajes where id = " + Id + "))as NombreMAGIA2,(select DESCRIPCION from MagiasDisponibles where IDMAGIAS = (select MAGIA2 from Personajes where id = " + Id + ")) as DESCRIPCIONMAGIA2," +
                    "P.MAGIA3,(select NOMBRE from MagiasDisponibles where IDMAGIAS = (select MAGIA3 from Personajes where id = " + Id + "))as NombreMAGIA3,(select DESCRIPCION from MagiasDisponibles where IDMAGIAS = (select MAGIA3 from Personajes where id = " + Id + ")) as DESCRIPCIONMAGIA3," +
                    "P.ATACAR,(select NOMBRE from MagiasDisponibles where IDMAGIAS = (select ATACAR from Personajes where id = " + Id + ")) as NombreAtaque,(select DESCRIPCION from MagiasDisponibles where IDMAGIAS = (select ATACAR from Personajes where id = " + Id + ")) as DESCRIPCIOAtaque," +
                    "P.ESQUIVAR,(select NOMBRE from MagiasDisponibles where IDMAGIAS = (select ESQUIVAR from Personajes where id = " + Id + ")) as NombreEsquivar,(select DESCRIPCION from MagiasDisponibles where IDMAGIAS = (select ESQUIVAR from Personajes where id = " + Id + ")) as DESCRIPCIOESQUIVAR " +
                    "from Personajes P INNER JOIN MagiasDisponibles O on P.ID = O.IDMAGIAS where P.ID = " + Id;
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    _atributos.Habilidad1 = reader.GetInt32(0);
                    _atributos.NombreHabilidad1 = reader.GetString(1);
                    _atributos.DescripcionHabilidad1 = reader.GetString(2);
                    _atributos.Habilidad2 = reader.GetInt32(3);
                    _atributos.NombreHabilidad2 = reader.GetString(4);
                    _atributos.DescripcionHabilidad2 = reader.GetString(5);
                    _atributos.Habilidad3 = reader.GetInt32(6);
                    _atributos.NombreHabilidad3 = reader.GetString(7);
                    _atributos.DescripcionHabilidad3 = reader.GetString(8);
                    _atributos.Atacar = reader.GetInt32(9);
                    _atributos.NombreAtacar = reader.GetString(10);
                    _atributos.DescripcionAtacar = reader.GetString(11);
                    _atributos.Esquivar = reader.GetInt32(12);
                    _atributos.NombreEsquivar = reader.GetString(13);
                    _atributos.DescripcionEsquivar = reader.GetString(14);
                   

                    //_atributos.VidaCombate = reader.GetFloat(11);
                    //atributos.EstaminaCombate = reader.GetFloat(6);

                    //Debug.Log("ID= " + Id + "  name =" + Nombre + "  VIDA =" + Vida + "ESTAMINA =" + Estamina);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
            catch
            (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }


        }
        return _atributos;

    }
    public List<Atributos.Player> CargarDatosHabilidadDisponible(int tipo)
    {
        Atributos.Player _atributos = new Atributos.Player();
        List<Atributos.Player> listaHabilidades=new List<Atributos.Player>();
        
        //string query = "SELECT * FROM PERSONAJES where ID=" + Id;
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        string conn = "URI=file:" + filepath;
        IDbConnection dbconn;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn = new SqliteConnection(conn);
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "select IDMAGIAS,NOMBRE, DESCRIPCION from MagiasDisponibles WHERE SELECCIONADO=0 AND TIPO =" + tipo;
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    _atributos.Habilidad1 = reader.GetInt32(0);
                    _atributos.NombreHabilidad1 = reader.GetString(1);
                    _atributos.DescripcionHabilidad1 = reader.GetString(2);
                    listaHabilidades.Add(_atributos);
                    //_atributos.VidaCombate = reader.GetFloat(11);
                    //atributos.EstaminaCombate = reader.GetFloat(6);

                    //Debug.Log("ID= " + Id + "  name =" + Nombre + "  VIDA =" + Vida + "ESTAMINA =" + Estamina);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
            catch
            (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }


        }
        return listaHabilidades;

    }
    public Atributos.NPC CargarDatosEnemigos(int Id)
    {
        Atributos.NPC _atributos = new Atributos.NPC();
        // query = "SELECT * FROM PERSONAJES where ID=" + Id;
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        string conn = "URI=file:" + filepath;
        IDbConnection dbconn;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn = new SqliteConnection(conn);
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT P.ID,P.NOMBRE,P.NIVEL,FUERZA,DEFENSA,VELOCIDAD,VIDA,ESTAMINA,VIDACOMBATE,CANTIDAD,O.NOMBRE,O.DESCRIPCION,P.IDASESINO,P.IDOBJETO " + "from Enemigos P INNER JOIN Objetos O on P.IDOBJETO = O.ID where P.ID=" + Id;
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    _atributos.Id = reader.GetInt32(0);
                    _atributos.Nombre = reader.GetString(1);
                    _atributos.Nivel = reader.GetInt32(2);
                    _atributos.Fuerza = reader.GetInt16(3);
                    _atributos.Defensa = reader.GetInt32(4);
                    _atributos.Velocidad = reader.GetInt32(5);
                    _atributos.Vida = reader.GetFloat(6);
                    _atributos.Estamina = reader.GetFloat(7);
                    _atributos.VidaCombate = reader.GetFloat(8);
                    _atributos.Cantidad = reader.GetInt32(9);
                    _atributos.NombreObjeto = reader.GetString(10);
                    _atributos.DescripcionObjeto = reader.GetString(11);
                    _atributos.IdAsesino = reader.GetInt32(12);
                    _atributos.IdObjeto = reader.GetInt32(13);

                    //_atributos.VidaCombate = reader.GetFloat(11);
                    //atributos.EstaminaCombate = reader.GetFloat(6);

                    //Debug.Log("ID= " + Id + "  name =" + Nombre + "  VIDA =" + Vida + "ESTAMINA =" + Estamina);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
            catch
            (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }


        }
        return _atributos;

    }
    public Atributos.NPC CargarDatosEnemigos(string Arma)
    {
        Atributos.NPC _atributos = new Atributos.NPC();
        // query = "SELECT * FROM PERSONAJES where ID=" + Id;
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        string conn = "URI=file:" + filepath;
        IDbConnection dbconn;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn = new SqliteConnection(conn);
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT ID,NOMBRE,NIVEL,FUERZA,DEFENSA,VELOCIDAD,VIDA,ESTAMINA,VIDACOMBATE " + "FROM Enemigos where ID=" + Arma;
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    _atributos.Id = reader.GetInt32(0);
                    _atributos.Nombre = reader.GetString(1);
                    _atributos.Nivel = reader.GetInt32(2);
                    _atributos.Fuerza = reader.GetInt16(3);
                    _atributos.Defensa = reader.GetInt32(4);
                    _atributos.Velocidad = reader.GetInt32(5);
                    _atributos.Vida = reader.GetFloat(6);
                    _atributos.Estamina = reader.GetFloat(7);
                    _atributos.VidaCombate = reader.GetFloat(8);

                    //_atributos.VidaCombate = reader.GetFloat(11);
                    //atributos.EstaminaCombate = reader.GetFloat(6);

                    //Debug.Log("ID= " + Id + "  name =" + Nombre + "  VIDA =" + Vida + "ESTAMINA =" + Estamina);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
            catch
            (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }


        }
        return _atributos;

    }
    public Atributos.NPC CargarDatosNPC(int Id)
    {
        Atributos.NPC _atributos = new Atributos.NPC();
        // query = "SELECT * FROM PERSONAJES where ID=" + Id;
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        string conn = "URI=file:" + filepath;
        IDbConnection dbconn;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn = new SqliteConnection(conn);
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT N.ID,N.NOMBRE,N.DIALOGO,M.ID,M.NOMBRE,M.DESCRIPCION " + "FROM NPC N INNER JOIN Misiones M ON N.MISION1 = M.ID WHERE M.REALIZADA = 0 AND N.ID =" + Id;

                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                if (reader == null)//Si mision 1 ya esta realizada entonces cogemos mision 2
                {
                     sqlQuery = "SELECT N.ID,N.NOMBRE,N.DIALOGO,M.ID,M.NOMBRE,M.DESCRIPCION " + "FROM NPC N INNER JOIN Misiones M ON N.MISION2 = M.ID WHERE M.REALIZADA = 0 AND N.ID =" + Id;

                    dbcmd.CommandText = sqlQuery;
                    reader = dbcmd.ExecuteReader();
                }
                while (reader.Read())
                {
                    _atributos.Id = reader.GetInt32(0);
                    _atributos.Nombre = reader.GetString(1);
                    _atributos.descripcionMision = reader.GetString(2)+" "+ reader.GetString(5);
                    _atributos.idMision= reader.GetInt32(3);
                    _atributos.nombreMision = reader.GetString(4);
                    

                    //_atributos.VidaCombate = reader.GetFloat(11);
                    //atributos.EstaminaCombate = reader.GetFloat(6);

                    //Debug.Log("ID= " + Id + "  name =" + Nombre + "  VIDA =" + Vida + "ESTAMINA =" + Estamina);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
            catch
            (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }


        }
        return _atributos;

    }
    public Atributos.Bolsa CargarDatosObjetos(int Id)
    {
        Atributos.Bolsa _atributos = new Atributos.Bolsa();
        // query = "SELECT * FROM PERSONAJES where ID=" + Id;
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        string conn = "URI=file:" + filepath;
        IDbConnection dbconn;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn = new SqliteConnection(conn);
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT ID,NOMBRE,DESCRIPCION,TIPO " + "from Objetos  where ID=" + Id;
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    _atributos.Id = reader.GetInt32(0);
                    _atributos.Nombre = reader.GetString(1);
                    _atributos.Descripcion = reader.GetString(2);
                    _atributos.Tipo = reader.GetInt32(3);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
            catch
            (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }


        }
        return _atributos;

    }
    public Atributos.Magia CargarDatosMagias(int Id)
    {
        Atributos.Magia _atributos = new Atributos.Magia();
        // query = "SELECT * FROM PERSONAJES where ID=" + Id;
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        string conn = "URI=file:" + filepath;
        IDbConnection dbconn;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn = new SqliteConnection(conn);
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "select NOMBRE,FUERZA,ESTAMINA,VELOCIDAD,TIEMPORECUPERACION,DESCRIPCION from magias where ID=" + Id;
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    //_atributos.Id = reader.GetInt32(0);
                    _atributos.Nombre = reader.GetString(0);
                    _atributos.Fuerza = reader.GetInt32(1);
                    _atributos.Estamina = reader.GetInt16(2);
                    _atributos.Velocidad = reader.GetInt32(3);
                    _atributos.TiempoRecuperacion = reader.GetInt32(4);
                    _atributos.Descripcion = reader.GetString(5);
                    //_atributos.Estamina = reader.GetFloat(7);
                    //_atributos.VidaCombate = reader.GetFloat(8);
                    //_atributos.DescripcionObjeto = reader.GetString(9);

                    //_atributos.VidaCombate = reader.GetFloat(11);
                    //atributos.EstaminaCombate = reader.GetFloat(6);

                    //Debug.Log("ID= " + Id + "  name =" + Nombre + "  VIDA =" + Vida + "ESTAMINA =" + Estamina);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
            catch
            (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }


        }
        return _atributos;

    }
    public List<Atributos.Bolsa> CargarDatosBolsa(int IdPersonaje)
    {
        List<Atributos.Bolsa> bolsa = new List<Atributos.Bolsa>();
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        string conn = "URI=file:" + filepath;
        IDbConnection dbconn;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn = new SqliteConnection(conn);
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = $"select IDOBJETO, NOMBRE,DESCRIPCION,CANTIDAD,TIPO from bolsa b left join Objetos o on b.IDOBJETO=O.ID where IDPERSONAJE = {IdPersonaje}";
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    bolsa.Add(new Atributos.Bolsa()
                    {
                        IdObjeto = reader.GetInt32(0),
                        Nombre= reader.GetString(1),
                        Descripcion = reader.GetString(2),
                        Cantidad = reader.GetInt32(3),
                        Tipo = reader.GetInt32(4),
                    });
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
            catch
            (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }


        }
        return bolsa;

    }
    public Atributos.Bolsa ElementoBolsa(int idObjeto)
    {
        Atributos.Bolsa bolsa = new Atributos.Bolsa();
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        string conn = "URI=file:" + filepath;
        IDbConnection dbconn;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn = new SqliteConnection(conn);
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = $"select ID, NOMBRE,DESCRIPCION,TIPO from Objetos  where ID = {idObjeto}";
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {

                    bolsa.IdObjeto = reader.GetInt32(0);
                    bolsa.Nombre = reader.GetString(1);
                    bolsa.Descripcion = reader.GetString(2);
                    bolsa.Tipo = reader.GetInt32(3);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
            catch
            (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }


        }
        return bolsa;

    }
    public Atributos.Personalizacion CargarDatosPersonalizacion(int Id)
    {
        Atributos.Personalizacion _atributos = new Atributos.Personalizacion();
        //string query = "SELECT * FROM PERSONAJES where ID=" + Id;
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        string conn = "URI=file:" + filepath;
        IDbConnection dbconn;
        using (dbconn = new SqliteConnection(conn))
        {
            try
            {
                dbconn = new SqliteConnection(conn);
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT P.ID,P.CABEZA,P.ARMA,P.TRAJE,P.COMPA,O.NOMBRE AS CASCO,O.DESCRIPCION AS DESCRIPCIONCASCO, A.NOMBRE AS ARMA, A.DESCRIPCION AS DESCRIPCIONARMA, T.NOMBRE AS TRAJE, T.DESCRIPCION AS DESCRIPCIONTRAJE, C.NOMBRE AS COMPA, C.DESCRIPCION AS DESCRIPCIONCOMPA,P.CAPUCHA " + "from Personajes P INNER JOIN Casco O on P.CABEZA = O.ID LEFT JOIN Armas A on P.ARMA = A.ID LEFT JOIN Trajes T on P.TRAJE = T.ID LEFT JOIN COMPA C on P.COMPA = C.ID where P.ID=" + Id;
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    _atributos.IdPersonaje = reader.GetInt32(0);
                    _atributos.IdCasco = reader.GetInt32(1);
                    _atributos.IdArma = reader.GetInt32(2);
                    _atributos.IdTraje = reader.GetInt32(3);
                    _atributos.IdCompa = reader.GetInt32(4);

                    _atributos.NombreCasco = reader.GetString(5);
                    _atributos.DescripcionCasco = reader.GetString(6);
                    _atributos.NombreArma = reader.GetString(7);
                    _atributos.DescripcionArma = reader.GetString(8);
                    _atributos.NombreTraje = reader.GetString(9);
                    _atributos.DescripcionTraje = reader.GetString(10);
                    _atributos.NombreCompa = reader.GetString(11);
                    _atributos.DescripcionCompa = reader.GetString(12);

                    _atributos.IdCapucha = reader.GetInt32(13);


                    //_atributos.VidaCombate = reader.GetFloat(11);
                    //atributos.EstaminaCombate = reader.GetFloat(6);

                    //Debug.Log("ID= " + Id + "  name =" + Nombre + "  VIDA =" + Vida + "ESTAMINA =" + Estamina);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
            catch
            (Exception e)
            {
                Debug.Log("Oh No Conectado");
                Text.GetComponent<Text>().text = e.ToString();

            }


        }
        return _atributos;

    }
}