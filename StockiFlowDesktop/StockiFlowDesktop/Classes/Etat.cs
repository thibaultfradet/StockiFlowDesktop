using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockiFlowDesktop.Classes
{
    public class Etat
    {
        private int idEtat;
        private string libelle;

        public Etat() { }

        public Etat(int _idEtat, string _libelle)
        {
            this.idEtat = _idEtat;
            this.libelle = _libelle;
        }

        //getter
        public int GetIdEtat() { return idEtat; }
        public string GetLibelle() { return libelle; }


        //setter
        public void SetIdEtat(int _id) { this.idEtat = _id; }
        public void SetLibelle(string _libelle) { this.libelle = _libelle; }




        /*     CRUD     */
        
        
        public void CreateEtat()
        {
            // MAX ID 
            string req_MaxId = "select max(idEtat) from Etat;";
            Global.conn.Open();
            MySqlCommand stmt_maxId = new MySqlCommand(req_MaxId, Global.conn);

            // Reader + assignation valeur
            using (MySqlDataReader reader = stmt_maxId.ExecuteReader())
            {
                try
                {
                    reader.Read();
                    this.SetIdEtat(int.Parse(reader["MAX(id_editeur)"].ToString()) + 1);
                }
                catch (Exception) { }
            }
            Global.conn.Close();




            string req_create = "insert into etat values(" + this.GetIdEtat() + "','" + this.GetLibelle() + "');";
            Global.conn.Open();
            MySqlCommand stmt_create = new MySqlCommand(req_create,Global.conn);

            stmt_create.ExecuteNonQuery();
            Global.conn.Close();
        }




        public void RetrieveEtat(int _id)
        {
            string req_retrieve = "select idEtat,libelle from Etat where idEtat = " + _id;
            Global.conn.Open();

            MySqlCommand stmt_retrieve = new MySqlCommand(req_retrieve,Global.conn);

            using (MySqlDataReader reader = stmt_retrieve.ExecuteReader())
            {
                reader.Read();

                try
                {
                    this.SetIdEtat(int.Parse(reader["idEtat"].ToString()));
                    this.SetLibelle(reader["libelle"].ToString());
                }
                catch (Exception) { }

            }
            Global.conn.Close();
        }



        public void UpdateEtat()
        {
            string req_update = "update Etat set libelle = '" + this.GetLibelle() + "' where idEtat = " + this.GetIdEtat();
            MySqlCommand stmt_update = new MySqlCommand(req_update,Global.conn);
            Global.conn.Open();

            stmt_update.ExecuteNonQuery();

            Global.conn.Close();
        }




        public void DeleteEtat()
        {
            string req_delete = "delete from etat where idEtat = " + this.GetIdEtat();
            MySqlCommand stmt_delete = new MySqlCommand(req_delete,Global.conn);
            Global.conn.Open();

            stmt_delete.ExecuteNonQuery();
            Global.conn.Close();
        }


        
        public List<Etat> FindAllEtat()
        {
            List<Etat> collectionEtat = new List<Etat>();

            string reqFindAll = "select idEtat,libelle from Etat";
            Global.conn.Open();
            MySqlCommand stmt_findAll = new MySqlCommand(reqFindAll,Global.conn);

            using (MySqlDataReader reader = stmt_findAll.ExecuteReader())
            {
                Etat etat_temp = new Etat(int.Parse(reader["idEtat"].ToString()),reader["libelle"].ToString());

                collectionEtat.Add(etat_temp);
            }
            
            Global.conn.Close();
            return collectionEtat;
        }
    }
}
