using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockiFlowDesktop.Classes
{
    public class Genre
    {
        private int idGenre;
        private string libelle;

        public Genre() { }


        public Genre(int _id , string _libelle)
        {
            this.idGenre = _id; 
            this.libelle = _libelle;
        }


        //getter
        public int GetIdGenre() { return idGenre; }  
        public string GetLibelle() { return libelle; }


        //setter
        public void SetIdGenre(int _id) { this.idGenre = _id; }
        public void SetLibelle(string _libelle) { this.libelle = _libelle; }




        /*     CRUD     */
        
        
        public void CreateGenre()
        {

            // MAX ID 
            string req_MaxId = "select max(idGenre) from Genre;";
            Global.conn.Open();
            MySqlCommand stmt_maxId = new MySqlCommand(req_MaxId, Global.conn);

            // Reader + assignation valeur
            using (MySqlDataReader reader = stmt_maxId.ExecuteReader())
            {
                try
                {
                    reader.Read();
                    this.SetIdGenre(int.Parse(reader["max(idGenre)"].ToString()) + 1);
                }
                catch (Exception) { }
            }
            Global.conn.Close();




            string req_create = "insert into genre values (" + this.GetIdGenre() + ",'" + this.GetLibelle() + "')";
            MySqlCommand stmt_create = new MySqlCommand(req_create, Global.conn);
            Global.conn.Open();
            stmt_create.ExecuteNonQuery();
            Global.conn.Close();

        }






        public void RetrieveGenre(int _id)
        {
            string req_retrieve = "select idGenre,libelle from genre where idGenre = " + _id;
            Global.conn.Open();
            MySqlCommand stmt_retrieve = new MySqlCommand(req_retrieve, Global.conn);

            using (MySqlDataReader reader = stmt_retrieve.ExecuteReader())
            {
                reader.Read();

                try
                {
                    this.SetIdGenre(int.Parse(reader["idGenre"].ToString()));
                    this.SetLibelle(reader["libelle"].ToString());
                }
                catch { }
            }
            Global.conn.Close();
        }





        public void UpdateGenre()
        {
            string req_update = "update Genre set libelle = '" + this.GetLibelle() + "' where idGenre = " + this.GetIdGenre();
            MySqlCommand stmt_update = new MySqlCommand(req_update, Global.conn);
            Global.conn.Open();
            
            stmt_update.ExecuteNonQuery();
            Global.conn.Close();
        }



        public void DeleteGenre()
        {
            string req_delete = "delete from Genre where idGenre = " + this.GetIdGenre() ;
            MySqlCommand stmt_delete = new MySqlCommand(req_delete, Global.conn);
            Global.conn.Open();

            stmt_delete.ExecuteNonQuery();
            Global.conn.Close();
        }




        public List<Genre> FindAllGenre()
        {
            List<Genre> CollectionGenre = new List<Genre>();

            string req_FindAll = "select idGenre,libelle from Genre";
            Global.conn.Open();
            MySqlCommand stmt_FindAll = new MySqlCommand(req_FindAll,Global.conn);
            
            using (MySqlDataReader reader = stmt_FindAll.ExecuteReader())
            {
                while (reader.Read())
                {
                    Genre genre_temp = new Genre(int.Parse(reader["idGenre"].ToString()),reader["libelle"].ToString());

                    CollectionGenre.Add(genre_temp);
                }
            }
            Global.conn.Close();
            return CollectionGenre;
        }






        public List<Genre> FindAllGenreByLivre(List<int> _ListeId)
        {
            List<Genre> collectionGenre = new List<Genre>();

            string req_findAllByLivre = "SELECT * FROM Genre WHERE ";

            //Pour chaque id dans la liste en paramètre on rajoute l'id à la requête
            bool first = true;
            foreach (int i in _ListeId)
            {
                if (!first)
                {
                    req_findAllByLivre += " OR ";
                }
                req_findAllByLivre += $"idGenre = {i}";
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

                    Genre Genre_temp = new Genre(int.Parse(reader["idGenre"].ToString()), reader["libelle"].ToString());

                    //Ajout Genre dans la collection
                    collectionGenre.Add(Genre_temp);
                }
            }

            return collectionGenre;
        }

    }
}
