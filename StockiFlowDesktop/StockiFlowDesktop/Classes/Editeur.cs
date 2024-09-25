using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockiFlowDesktop.Classes
{
    public class Editeur
    {
        private int idEditeur;
        private string nomEditeur;




#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Editeur() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public Editeur(int _id, string _nomEditeur)
        {
            this.idEditeur = _id;
            this.nomEditeur = _nomEditeur;
        }




        //getter
        public int GetIdEditeur() { return idEditeur; }
        public string GetNomEditeur() { return nomEditeur; }


        //setter
        public void SetIdEditeur(int _id) { this.idEditeur = _id; }
        public void SetNomEditeur(string _nomEditeur) { this.nomEditeur = _nomEditeur; }





        /*     CRUD     */


        public void CreateEditeur()
        {
            // MAX ID 
            string req_MaxId = "select max(idEditeur) from editeur;";
            Global.conn.Open();
            MySqlCommand stmt_maxId = new MySqlCommand(req_MaxId, Global.conn);

            // Reader + assignation valeur
            using (MySqlDataReader reader = stmt_maxId.ExecuteReader())
            {
                try
                {
                    reader.Read();
                    this.SetIdEditeur(int.Parse(reader["MAX(id_editeur)"].ToString()) + 1);
                }
                catch (Exception) {  }
            }
            Global.conn.Close();





            string req_create = "Insert into Editeur values('" + this.GetIdEditeur() + "','" + this.GetNomEditeur() + "')";
            Global.conn.Open();
            MySqlCommand stmt_create = new MySqlCommand(req_create, Global.conn);

            stmt_create.ExecuteNonQuery();
            Global.conn.Close();

            
        }






        public void RetrieveEditeur(int _id)
        {
            string req_retrieve = "select idEditeur,nomEditeur from Editeur where idEditeur = " + _id;
            MySqlCommand stmt_retrieve = new MySqlCommand(req_retrieve, Global.conn);
            Global.conn.Open();

            using (MySqlDataReader reader = stmt_retrieve.ExecuteReader())
            {
                reader.Read();
                try
                {
                    this.SetIdEditeur(int.Parse(reader["idEditeur"].ToString()));
                    this.SetNomEditeur(reader["nomEditeur"].ToString());

                }
                catch(Exception e)
                {
                    
                }
            }

            Global.conn.Close();
        }





        public void UpdateEditeur()
        {

            string req_update = "update editeur set nomEditeur = '" + this.GetNomEditeur() + "' where idEditeur = " + this.GetIdEditeur();
            Global.conn.Open();
            MySqlCommand stmt_update = new MySqlCommand(req_update, Global.conn);

            stmt_update.ExecuteNonQuery();
            Global.conn.Close();

        }






        public void DeleteEditeur()
        {

            string req_delete = "delete from editeur where idEditeur = " + this.GetIdEditeur();
            Global.conn.Open();
            MySqlCommand stmt_delete = new MySqlCommand(req_delete, Global.conn);

            stmt_delete.ExecuteNonQuery();
            Global.conn.Close();

        }



        public List<Editeur> FindAllEditeur()
        {
            List<Editeur> collectionsEditeurs = new List<Editeur>();

            //req
            string req_findAll = "select * from Editeur";

            //Statement + ouverture co +reader
            MySqlCommand stmt_findAll = new MySqlCommand(req_findAll, Global.conn);
            Global.conn.Open();

            //Recuperations des objets + ajout dans la collections de Editeurs
            using (MySqlDataReader readerFindAll = stmt_findAll.ExecuteReader())
            {
                while (readerFindAll.Read())
                {
                    Editeur Editeur_temp = new Editeur(int.Parse(readerFindAll["idEditeur"].ToString()), readerFindAll["nomEditeur"].ToString());

                    collectionsEditeurs.Add(Editeur_temp);
                }
            }
            Global.conn.Close();


            return collectionsEditeurs;
        }





        public List<Editeur> FindAllEditeurByLivre(List<int> _ListeId)
        {
            List<Editeur> collectionEditeur = new List<Editeur>();

            string req_findAllByLivre = "SELECT * FROM editeur WHERE ";

            //Pour chaque id dans la liste en paramètre on rajoute l'id à la requête
            bool first = true;
            foreach (int i in _ListeId)
            {
                if (!first)
                {
                    req_findAllByLivre += " OR ";
                }
                req_findAllByLivre += $"idEditeur = {i}";
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
                    
                    Editeur editeur_temp = new Editeur(int.Parse(reader["idEditeur"].ToString()), reader["nomEditeur"].ToString());

                    //Ajout editeur dans la collection
                    collectionEditeur.Add(editeur_temp);
                }
            }
            Global.conn.Close();
            return collectionEditeur;
        }
    }
}
