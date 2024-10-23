using StockiFlowDesktop.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockiFlowDesktop.Pages
{
    public partial class F_ModifStock : Form
    {
        public Livre livreAModifier = new Livre();
        public bool isAugmenter;

        public F_ModifStock(Livre _livreStock, bool _isAugmenter)
        {
            InitializeComponent();


            isAugmenter = _isAugmenter;
            livreAModifier = _livreStock;

            ChargerPage();
        }




        /* Méthode ChargerPage qui va modifier l'apparence de la page en fonction de l'action utilisateur (reduire/augmenter le stock) */
        private void ChargerPage()
        {
            L_AncienStock.Text += livreAModifier.GetStock().ToString();

            DTP_Date.Value = DateTime.Today;
            DTP_Date.MinDate = DateTime.Today.AddDays(-7);


            if (isAugmenter)
            {
                this.Text = "Augmenter le stock";
                L_titre.Text = "Augmenter le stock";
                L_Quantite.Text = "Quantité à rajouter : ";
                L_Raison.Text = "Raison de l'entrée en stock : ";
            }
            else
            {
                this.Text = "Réduire le stock";
                L_titre.Text = "Réduire le stock";
                L_Quantite.Text = "Quantité à réduire :";
                L_Raison.Text = "Raison de la sortie du stock : ";
            }
        }





        /* L'utilisateur valide ses entrées */
        private void B_Valider_Click(object sender, EventArgs e)
        {
            // Récupérations des entrées utilisateurs
            int Quantite = int.Parse(NUD_Quantite.Value.ToString());
            string raison = TB_Raison.Text;
            DateTime dateAction = DTP_Date.Value;



            // Vérifications des entrées utilisateurs
            if (Quantite <= 0)
            {
                MessageBox.Show("La quantité saisie est invalide.");
                return;
            }
            if (string.IsNullOrEmpty(raison))
            {
                MessageBox.Show("La raison saisie est invalide.");
                return;
            }
            if (dateAction <= DateTime.Today.AddDays(-7))
            {
                MessageBox.Show("La date saisie est invalide.");
                return;
            }



            // Touts les tests sont passer => dernière confirmation utilisateur si oui on met à jour en base et on créer l'historisation
            string message = "Voulez-vous vraiment modifier le stock ?" + "\n" + "Quantité ";
            if (isAugmenter) { message += "ajouter : "; }
            else { message += "retirer : "; }
            message += Quantite + "\n Raison de ";
            if (isAugmenter) { message += "la sortie du stock : "; }
            else { message += "l'entrée en stock : "; }
            message += raison + "\n Date : " + dateAction.Date;


            DialogResult result = MessageBox.Show(message, "Confirmation de modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Utilisateur non sûr
            if (result != DialogResult.Yes)
            {
                return;
            }
            else
            {
                int ancienStock = livreAModifier.GetStock();
                int nouveauStock = ancienStock - Quantite;
                livreAModifier.setStock(nouveauStock);
                livreAModifier.UpdateStockLivre();


                Stock stock_create = new Stock(1,Quantite, raison,dateAction,livreAModifier.GetISBN());
                stock_create.CreateStock();
                MessageBox.Show("La modification du stock du livre a bien été effectuée.");
                this.Close();
            }
        }
    }
}
