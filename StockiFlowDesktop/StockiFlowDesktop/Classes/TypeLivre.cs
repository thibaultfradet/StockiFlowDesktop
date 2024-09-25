using MySql.Data.MySqlClient;
using Mysqlx.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockiFlowDesktop.Classes
{
    public class TypeLivre
    {
        private int idTypeLivre;
        private string libelle;

        public TypeLivre() { }

        public TypeLivre(int _idTypeLivre, string _libelle)
        {
            this.idTypeLivre = _idTypeLivre;
            this.libelle = _libelle;
        }

        //getter
        public int GetIdTypeLivre() { return idTypeLivre; }
        public string GetLibelle() { return libelle; }


        //setter
        public void SetIdTypeLivre(int _id) { this.idTypeLivre = _id; }
        public void SetLibelle(string _libelle) { this.libelle = _libelle; }




        /*     CRUD     */
        public void CreateTypeLivre()
        {
            // MAX ID 
            string req_MaxId = "select max(idTypeLivre) from TypeLivre;";
            Global.conn.Open();
            MySqlCommand stmt_maxId = new MySqlCommand(req_MaxId, Global.conn);

            // Reader + assignation valeur
            using (MySqlDataReader reader = stmt_maxId.ExecuteReader())
            {
                try
                {
                    reader.Read();
                    this.SetIdTypeLivre(int.Parse(reader["max(idTypeLivre)"].ToString()) + 1);
                }
                catch (Exception) { }
            }
            Global.conn.Close();



            string req_create = "insert into TypeLivre values (" + this.GetIdTypeLivre() + ",'" + this.GetLibelle() + "')";
            MySqlCommand stmt_create = new MySqlCommand(req_create, Global.conn);
            Global.conn.Open();
            stmt_create.ExecuteNonQuery();
            Global.conn.Close();
        }




        public void RetrieveTypeLivre(int _id)
        {
            string req_retrieve = "select idTypeLivre,libelle  from TypeLivre where idTypeLivre = " + _id;
            MySqlCommand stmt_retrieve = new MySqlCommand(req_retrieve, Global.conn);
            Global.conn.Close();

            using (MySqlDataReader reader = stmt_retrieve.ExecuteReader())
            {
                reader.Read();
                try
                {
                    this.SetIdTypeLivre(int.Parse(reader["idTypeLivre"].ToString()));
                    this.SetLibelle(reader["libelle"].ToString());
                }
                catch { }
            }
            Global.conn.Close();
        }





        public void UpdateTypeLivre()
        {
            string req_update = "update TypeLivre set libelle = '" + this.GetLibelle() + "' where idTypeLivre = " + this.GetIdTypeLivre();
            MySqlCommand stmt_update = new MySqlCommand(req_update, Global.conn);
            Global.conn.Open();
            using (MySqlDataReader reader = stmt_update.ExecuteReader())
            {
                reader.Read();
                try
                {
                    this.SetIdTypeLivre(int.Parse(reader["idTypeLivre"].ToString()));
                    this.SetLibelle(reader["libelle"].ToString());
                }

                catch { }   
            }
            Global.conn.Close();
        }





        public void DeleteTypeLivre()
        {
            string req_delete = "delete from TypeLivre where idTypeLivre = " + this.GetIdTypeLivre();
            MySqlCommand stmt_delete = new MySqlCommand(req_delete, Global.conn);
            Global.conn.Open();
            stmt_delete.ExecuteNonQuery();  
            Global.conn.Close();    
        }




        public List<TypeLivre> FindAllTypeLivre()
        {
            List<TypeLivre> collectionTypeLivre = new List<TypeLivre>();

            string reqFindAll = "select idTypeLivre,libelle from TypeLivre;";
            MySqlCommand stmt_findAll = new MySqlCommand(reqFindAll, Global.conn);
            Global.conn.Open();

            using (MySqlDataReader reader = stmt_findAll.ExecuteReader())
            {
                while (reader.Read())
                {
                    TypeLivre typeLivre = new TypeLivre(int.Parse(reader["idTypeLivre"].ToString()), reader["libelle"].ToString());

                    collectionTypeLivre.Add(typeLivre);
                }
            }

            Global.conn.Close();

            return collectionTypeLivre;
        }
    }
}
