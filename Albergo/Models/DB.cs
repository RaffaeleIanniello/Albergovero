using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;

namespace Albergo.Models
{
    public static class DB
    {

        public static void AddCliente(string nomeCliente, string cognomeCliente, string cittaCliente, string provinciaCliente, string mailCliente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [clienti] (nomeCliente, cognomeCliente, cittaCliente, provinciaCliente, mailCliente) VALUES(@nomeCliente, @cognomeCliente, @cittaCliente, @provinciaCliente, @mailCliente)";
                cmd.Parameters.AddWithValue("nomeCliente", nomeCliente);
                cmd.Parameters.AddWithValue("cognomeCliente", cognomeCliente);
                cmd.Parameters.AddWithValue("cittaCliente", cittaCliente);
                cmd.Parameters.AddWithValue("provinciaCliente", provinciaCliente);
                cmd.Parameters.AddWithValue("mailCliente", mailCliente);
                int IsOk = cmd.ExecuteNonQuery();
            }
            catch { }
            finally { conn.Close(); }
        }
        public static void AddCamera(int numeroCamera, bool cameraSingola, bool cameraDoppia, string descrizioneCamera, int idCliente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [camera] (numeroCamera, cameraSingola, cameraDoppia, descrizioneCamera, idCliente) VALUES(@numeroCamera, @cameraSingola, @cameraDoppia, @descrizioneCamera, @idCliente)";
                cmd.Parameters.AddWithValue("numeroCamera", numeroCamera);
                cmd.Parameters.AddWithValue("cameraSingola", cameraSingola);
                cmd.Parameters.AddWithValue("cameraDoppia", cameraDoppia);
                cmd.Parameters.AddWithValue("descrizioneCamera", descrizioneCamera);
                cmd.Parameters.AddWithValue("idCliente", idCliente);
                int IsOk = cmd.ExecuteNonQuery();
            }
            catch { }
            finally { conn.Close(); }
        }
        public static void AddPrenotazione(DateTime dataPrenotazione, DateTime checkIn, DateTime checkOut, int caparraConfirmatoria, int tariffaApplicata, int idCliente, int idCamera)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO prenotazione VALUES(@dataPrenotazione, @checkIn, @checkOut, @caparraConfirmatoria, @tariffaApplicata, @idCliente, @idCamera)";
                cmd.Parameters.AddWithValue("dataPrenotazione", dataPrenotazione);
                cmd.Parameters.AddWithValue("checkIn", checkIn);
                cmd.Parameters.AddWithValue("checkOut", checkOut);
                cmd.Parameters.AddWithValue("caparraConfirmatoria", caparraConfirmatoria);
                cmd.Parameters.AddWithValue("tariffaApplicata", tariffaApplicata);
                cmd.Parameters.AddWithValue("idCliente", idCliente);
                cmd.Parameters.AddWithValue("idCamera", idCamera);
                int IsOk = cmd.ExecuteNonQuery();
            }
            catch { }
            finally { conn.Close(); }
        }
        public static void AddDettagli(bool mezzaPensione, bool pensioneCompleta, bool primaColazione, int idPrenotazione)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [dettagli] (mezzaPensione, pensioneCompleta, primaColazione, idPrenotazione) VALUES(@mezzaPensione, @pensioneCompleta, @primaColazione, @idPrenotazione)";
                cmd.Parameters.AddWithValue("mezzaPensione", mezzaPensione);
                cmd.Parameters.AddWithValue("pensioneCompleta", pensioneCompleta);
                cmd.Parameters.AddWithValue("primaColazione", primaColazione);
                cmd.Parameters.AddWithValue("idPrenotazione", idPrenotazione);

                int IsOk = cmd.ExecuteNonQuery();
            }
            catch { }
            finally { conn.Close(); }
        }
        public static void AddServizi(bool colazioneInCamera, bool foodBar, bool internetCamera, bool lettoAggiuntivo, bool cullaCamera, int idPrenotazione, int quantita, int prezzo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [servizi] (colazioneCamera, foodBar, internetCamera, lettoAggiuntivo, cullaCamera, idPrenotazione, quantita, prezzo) VALUES(@colazioneCamera, @foodBar, @internetCamera, @lettoAggiuntivo, @cullaCamera, @idPrenotazione, @quantita, @prezzo)";
                cmd.Parameters.AddWithValue("colazioneCamera", colazioneInCamera);
                cmd.Parameters.AddWithValue("foodBar", foodBar);
                cmd.Parameters.AddWithValue("internetCamera", internetCamera);
                cmd.Parameters.AddWithValue("lettoAggiuntivo", lettoAggiuntivo);
                cmd.Parameters.AddWithValue("cullaCamera", cullaCamera);
                cmd.Parameters.AddWithValue("idPrenotazione", idPrenotazione);
                cmd.Parameters.AddWithValue("quantita", quantita);
                cmd.Parameters.AddWithValue("prezzo", prezzo);

                int IsOk = cmd.ExecuteNonQuery();
            }
            catch { }
            finally { conn.Close(); }

        }
        public static List<Cliente> AllClienti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("Select * FROM clienti", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Cliente> clienti = new List<Cliente>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Cliente c = new Cliente();

                c.NomeCliente = sqlDataReader["NomeCliente"].ToString();
                c.CognomeCliente = sqlDataReader["CognomeCliente"].ToString();
                c.CittaCliente = sqlDataReader["CittaCliente"].ToString();
                c.ProvinciaCliente = sqlDataReader["ProvinciaCliente"].ToString();
                c.MailCliente = sqlDataReader["MailCliente"].ToString();
                clienti.Add(c);
            }

            conn.Close();
            return clienti;


        }

        public static List<Prenotazione> AllPrenotazioni()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("Select * FROM prenotazione", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Prenotazione> prenotazioni = new List<Prenotazione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Prenotazione p = new Prenotazione();

                p.CheckIn = Convert.ToDateTime(sqlDataReader["checkIn"]);
                p.CheckOut = Convert.ToDateTime(sqlDataReader["checkOut"]);
                p.CaparraConfirmatoria = Convert.ToInt32(sqlDataReader["caparraConfirmatoria"]);
                p.TariffaApplicata = Convert.ToInt32(sqlDataReader["tariffaApplicata"]);
                p.IdCliente = Convert.ToInt32(sqlDataReader["idCliente"]);
                p.IdCamera = Convert.ToInt32(sqlDataReader["idCamera"]);
                prenotazioni.Add(p);
            }

            conn.Close();
            return prenotazioni;


        }

        public static List<Servizi> AllServizi(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("Select * FROM servizi WHERE idPrenotazione=@id", conn);
            cmd.Parameters.AddWithValue("idPrenotazione", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Servizi> servizi = new List<Servizi>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Servizi s = new Servizi();

                s.ColazioneInCamera = Convert.ToBoolean(sqlDataReader["colazioneInCamera"]);
                s.FoodBar = Convert.ToBoolean(sqlDataReader["foodBar"]);
                s.InternetCamera = Convert.ToBoolean(sqlDataReader["internetCamera"]);
                s.LettoAggiuntivo = Convert.ToBoolean(sqlDataReader["lettoAggiuntivo"]);
                s.CullaCamera = Convert.ToBoolean(sqlDataReader["cullaCamera"]);
                s.IdPrenotazione = Convert.ToInt32(sqlDataReader["idPrenotazione"]);
                s.Quantita = Convert.ToInt32(sqlDataReader["quantita"]);
                s.Prezzo = Convert.ToInt32(sqlDataReader["prezzo"]);

            }

            conn.Close();
            return servizi;


        }
        public static List<Camera> AllCamera()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("Select * FROM camera", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Camera> camere = new List<Camera>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Camera r = new Camera();

                r.NumeroCamera = Convert.ToInt32(sqlDataReader["numeroCamera"]);
                r.CameraSingola = Convert.ToBoolean(sqlDataReader["cameraSingola"]);
                r.CameraDoppia = Convert.ToBoolean(sqlDataReader["cameraDoppia"]);
                r.DescrizioneCamera = sqlDataReader["descrizioneCamera"].ToString();
                r.IdCliente = Convert.ToInt32(sqlDataReader["idCliente"]);
                camere.Add(r);
            }

            conn.Close();
            return camere;


        }
        public static List<Dettagli> AllDettagli()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("Select * FROM dettagli", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Dettagli> dettagli = new List<Dettagli>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Dettagli d = new Dettagli();

                d.MezzaPensione = Convert.ToBoolean(sqlDataReader["mezzaPensione"]);
                d.PensioneCompleta = Convert.ToBoolean(sqlDataReader["pensioneCompleta"]);
                d.PrimaColazione = Convert.ToBoolean(sqlDataReader["primaColazione"]);
                d.IdPrenotazione = Convert.ToInt32(sqlDataReader["idPrenotazione"]);


            }

            conn.Close();
            return dettagli;


        }
        public static Cliente GetClientiById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("Select * from clienti WHERE idClienti = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Cliente c = new Cliente();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                c.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
                c.NomeCliente = sqlDataReader["NomeCliente"].ToString();
                c.CognomeCliente = sqlDataReader["CognomeClient"].ToString();
                c.CittaCliente = sqlDataReader["CittaCliente"].ToString();
                c.ProvinciaCliente = sqlDataReader["ProvinciaCliente"].ToString();
                c.MailCliente = sqlDataReader["MailCliente"].ToString();

            }

            conn.Close();
            return c;
        }
        public static Prenotazione GetPrenotazioniById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("Select * from prenotazione WHERE idPrenotazione = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Prenotazione p = new Prenotazione();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                p.IdPrenotazione = Convert.ToInt32(sqlDataReader["idPrenotazione"]);
                p.CheckIn = Convert.ToDateTime(sqlDataReader["checkIn"]);
                p.CheckOut = Convert.ToDateTime(sqlDataReader["checkOut"]);
                p.CaparraConfirmatoria = Convert.ToInt32(sqlDataReader["caparraConfirmatoria"]);
                p.TariffaApplicata = Convert.ToInt32(sqlDataReader["tariffaApplicata"]);
                p.IdCliente = Convert.ToInt32(sqlDataReader["idCliente"]);
                p.IdCamera = Convert.ToInt32(sqlDataReader["idCamera"]);

            }

            conn.Close();
            return p;

        }

        public static string connectionString = ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString.ToString();
        public static SqlConnection conn = new SqlConnection(connectionString);
        public static Admin GetAdmin(Admin a)
        {
            SqlCommand sqlCommand = new SqlCommand("Select * FROM admin WHERE username=@username And password=@password", conn);
            sqlCommand.Parameters.AddWithValue("Username", a.Username);
            sqlCommand.Parameters.AddWithValue("Password", a.Password);
            conn.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                FormsAuthentication.SetAuthCookie(a.Username, false);
                conn.Close();
                return a;
            }
            conn.Close();
            return null;

        }
    }
}

    