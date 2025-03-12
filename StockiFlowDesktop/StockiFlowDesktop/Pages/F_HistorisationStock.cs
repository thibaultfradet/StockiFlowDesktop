using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockiFlowDesktop.Classes;

namespace StockiFlowDesktop.Pages
{
    public partial class F_HistorisationStock : Form
    {
        public F_HistorisationStock()
        {
            InitializeComponent();
        }


        /* Chargement de la page */
        private void F_HistorisationStock_Load(object sender, EventArgs e)
        {
            List<Stock> collectionStock = new List<Stock>();
            Stock stock_temp = new Stock();
            collectionStock = stock_temp.FindAllStock();

            DGV_Historisation.Columns.Clear();

            // Ajout des colonnes
            DGV_Historisation.Columns.Add("ISBN", "ISBN");
            DGV_Historisation.Columns.Add("Quantite", "Quantité");
            DGV_Historisation.Columns.Add("RaisonStock", "Raison Stock");
            DGV_Historisation.Columns.Add("DateStock", "Date Stock");

            // Parcourir chaque élément de la collection pour l'ajouter au DataGridView
            foreach (Stock stock in collectionStock)
            {
                // Ajouter la ligne avec les valeurs de l'objet stock
                int rowIndex = DGV_Historisation.Rows.Add(
                    stock.getISBN(),
                    stock.getQuantite().ToString(),
                    stock.getRaisonStock(),
                    stock.getDateStock().ToString("dd/MM/yyyy")
                );

                // Récupérer la ligne nouvellement ajoutée
                DataGridViewRow row = DGV_Historisation.Rows[rowIndex];

                // Appliquer la couleur de fond en fonction de la valeur de IsAugmenter
                row.DefaultCellStyle.BackColor = stock.getIsAugmenter() ? Color.Green : Color.Red;
            }
        }

    }
}
