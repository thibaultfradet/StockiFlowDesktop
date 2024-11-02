using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace StockiFlowDesktop.Classes
{
    public class Auteur
    {
        private int idAuteur;
        private string nomAuteur;
        private string prenomAuteur;

        public Auteur(){}


        public Auteur(int _id, string _nom, string _prenom)
        {
            this.idAuteur = _id;
            this.nomAuteur = _nom;
            this.prenomAuteur= _prenom;
        }



        //getter 
        public int GetIdAuteur() { return this.idAuteur; }
        public string GetNomAuteur() { return this.nomAuteur; }
        public string GetPrenomAuteur() { return this.prenomAuteur;}


        //setter
        public void SetIdAuteur(int _id) { this.idAuteur = _id;}
        public void SetNomAuteur(string _nom) { this.nomAuteur = _nom; }
        public void SetPrenomAuteur(string _prenom) { this.prenomAuteur = _prenom; }



        /*      CRUD     */
        public void CreateAuteur()
        {
            // MAX ID
            string req_MaxId = "select max(idAuteur) from auteur;";
            Global.conn.Open();
            MySqlCommand stmt_maxId = new MySqlCommand(req_MaxId, Global.conn);

            // Reader + assignation valeur
            using (MySqlDataReader reader = stmt_maxId.ExecuteReader())
            {
                try
                {
                    reader.Read();
                    this.SetIdAuteur(int.Parse(reader["MAX(idAuteur)"].ToString()) + 1);
                }
                catch (Exception) {  }
            }
            Global.conn.Close();





            string req_create = "insert into Auteur values('" + this.GetIdAuteur() + "','" + this.GetNomAuteur() + "','" + this.GetPrenomAuteur() + "');";
            Global.conn.Open();
            MySqlCommand stmt_create = new MySqlCommand(req_create, Global.conn);

            stmt_create.ExecuteNonQuery();
            Global.conn.Close();
        }




        public void RetrieveAuteur(int _id)
        {
            string req_retrieve = "select idAuteur,nomAuteur,prenomAuteur from auteur where idAuteur = " + _id;

            MySqlCommand stmt_retrieve = new MySqlCommand(req_retrieve, Global.conn);
            Global.conn.Open();

            using (MySqlDataReader reader = stmt_retrieve.ExecuteReader())
            {
                reader.Read();
                try
                {
                    this.SetIdAuteur(int.Parse(reader["idAuteur"].ToString()));
                    this.SetNomAuteur(reader["nomAuteur"].ToString());
                    this.SetPrenomAuteur(reader["prenomAuteur"].ToString());
                }
                catch (Exception e)
                {

                }
            }
            Global.conn.Close();
        }



        public void UpdateAuteur()
        {
            string req_update = "update auteur set nomAuteur = '" + this.GetNomAuteur() + "' prenomAuteur = '" + this.GetPrenomAuteur() + "' where idAuteur = " + this.GetIdAuteur();
            MySqlCommand stmt_update = new MySqlCommand(req_update, Global.conn);
            Global.conn.Open();

            stmt_update.ExecuteNonQuery();
            Global.conn.Close();
        }




        public void DeleteAuteur()
        {
            string req_delete = "delete from auteur where idAuteur = " + this.GetIdAuteur();
            Global.conn.Open();
            MySqlCommand stmt_delete = new MySqlCommand(req_delete, Global.conn);

            stmt_delete.ExecuteNonQuery();
            Global.conn.Close();
        }



        public List<Auteur> FindAllAuteur()
        {
            List<Auteur> collectionsAuteurs = new List<Auteur>();

            //req
            string req_findAll = "select * from Auteur";

            //Statement + ouverture co +reader
            MySqlCommand stmt_findAll = new MySqlCommand(req_findAll, Global.conn);
            Global.conn.Open();

            //Recuperations des objets + ajout dans la collections de Auteurs
            using (MySqlDataReader readerFindAll = stmt_findAll.ExecuteReader())
            {
                while (readerFindAll.Read())
                {
                    Auteur Auteur_temp = new Auteur(int.Parse(readerFindAll["idAuteur"].ToString()), readerFindAll["nomAuteur"].ToString(), readerFindAll["prenomAuteur"].ToString());

                    collectionsAuteurs.Add(Auteur_temp);
                }
            }
            Global.conn.Close();


            return collectionsAuteurs;
        }




        public List<Auteur> FindAllAuteurByLivre(List<int> _ListeId)
        {
            List<Auteur> collectionAuteur = new List<Auteur>();

            string req_findAllByLivre = "SELECT * FROM auteur WHERE ";

            //Pour chaque id dans la liste en paramètre on rajoute l'id à la requête
            bool first = true;
            foreach (int i in _ListeId)
            {
                if (!first)
                {
                    req_findAllByLivre += " OR ";
                }
                req_findAllByLivre += $"idAuteur = {i}";
                first = false;
            }

            // Objet de commande + ouverture de la connexion
            MySqlCommand stmt_FindAllByLivre = new MySqlCommand(req_findAllByLivre, Global.conn);
            Global.conn.Open();

            //Reader
            using (MySqlDataReader reader = stmt_FindAllByLivre.ExecuteReader())
            {
                while (reader.Read())
                {

                    Auteur Auteur_temp = new Auteur(int.Parse(reader["idAuteur"].ToString()), reader["nomAuteur"].ToString(), reader["prenomAuteur"].ToString());

                    //Ajout Auteur dans la collection
                    collectionAuteur.Add(Auteur_temp);
                }
            }
            Global.conn.Close();
            return collectionAuteur;
        }
    }
}
