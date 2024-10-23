using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StockiFlowDesktop.Classes
{
    public class Stock
    {
        private int idStock;
        private int Quantite;
        private string RaisonStock;
        private DateTime DateStock;
        private string ISBN;

        public Stock() { }


        public Stock(int _id, int _quantite, string _raison, DateTime _DateStock, string _ISBN)
        {
            this.idStock = _id;
            this.Quantite = _quantite;
            this.RaisonStock = _raison;
            this.DateStock = _DateStock;
            this.ISBN = _ISBN;
        }



        public int getIdStock() { return idStock; }
        public int getQuantite() { return Quantite; }
        public string getRaisonStock() { return RaisonStock; }
        public DateTime getDateStock() { return DateStock; }
        public string getISBN() { return ISBN; }


        public void setIdStock(int _id) { this.idStock = _id; }
        public void setQuantite(int _quantite) { this.Quantite = _quantite; }
        public void setRaisonStock(string _raison) { this.RaisonStock = _raison; }
        public void setDateStock(DateTime _dateStock) { this.DateStock = _dateStock; }
        public void setISBN(string _ISBN) { this.ISBN = _ISBN; }


        public void CreateStock()
        {
            string req_create = "insert into stock values(" + this.getIdStock() + "," + this.getQuantite() + ",'" + this.getRaisonStock() + "','" + this.getDateStock().ToString("yyyy-MM-dd") + "','" +this.getISBN() +  "');";

            MySqlCommand stmt_create = new MySqlCommand(req_create, Global.conn);
            Global.conn.Open();

            stmt_create.ExecuteNonQuery();
            Global.conn.Close();
        }


        public void RetrieveStock(int _id)
        {
            string req_retrieve = "select idStock,Quantite,RaisonStock,DateStock,ISBN from stock where idStock = " + _id;
            MySqlCommand stmt_retrieve = new MySqlCommand(req_retrieve, Global.conn);
            Global.conn.Open();

            using (MySqlDataReader reader = stmt_retrieve.ExecuteReader())
            {
                try
                {
                    reader.Read();

                    this.setIdStock(int.Parse(reader["idStock"].ToString()));
                    this.setQuantite(int.Parse(reader["Quantite"].ToString()));
                    this.setRaisonStock(reader["RaisonStock"].ToString());
                    this.setDateStock(DateTime.Parse(reader["DateStock"].ToString()));
                    this.setISBN(reader["ISBN"].ToString());
                }
                catch (Exception e) { }
                Global.conn.Close();
            }
        }

        public void UpdateStock()
        {
            string req_update = "update from stock set Quantite = " + this.getQuantite() + ",RaisonStock='" + this.getRaisonStock() + "',DateStock = '" + this.getDateStock().ToString("yyyy-MM-dd") + "',ISBN = '" + this.getISBN() + "'" + " where idStock = " + this.getIdStock();
            MySqlCommand stmt_update = new MySqlCommand(req_update, Global.conn);
            Global.conn.Open();

            stmt_update.ExecuteNonQuery();
            Global.conn.Close();
        }


        public void DeleteStock()
        {
            string req_delete = "delete from stock where idStock = " + this.getIdStock();
            MySqlCommand stmt_delete = new MySqlCommand(@req_delete, Global.conn);
            Global.conn.Open();
            stmt_delete.ExecuteNonQuery();
            Global.conn.Close();
        }


        public List<Stock> FindAllStock()
        {
            List<Stock> collectionStock = new List<Stock>();

            string req_select = "select idStock,Quantite,RaisonStock,DateStock,ISBN from stock";
            MySqlCommand stmt_select = new MySqlCommand(req_select, Global.conn);
            Global.conn.Open();

            using (MySqlDataReader reader = stmt_select.ExecuteReader())
            {

                while (reader.Read())
                {
                    Stock stock_temp = new Stock(int.Parse(reader["idStock"].ToString()), int.Parse(reader["Quantite"].ToString()), reader["RaisonStock"].ToString(), DateTime.Parse(reader["DateStock"].ToString()), reader["ISBN"].ToString());
                    collectionStock.Add(stock_temp);
                }
            }
            Global.conn.Close();
            return collectionStock;
        } 
    }
}
