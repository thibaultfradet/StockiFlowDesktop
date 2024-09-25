using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace StockiFlowDesktop.Classes
{
    public class Global
    {
        //Pilote + objet de connection pour connection à la base de données
        private static string pilote = "Server=localhost;uid=tibo;pwd=caribou;Database=stockiflow";
        public static MySqlConnection conn = new MySqlConnection(pilote);
    }
}
