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

namespace StockiFlowDesktop.PageAjout
{
    public partial class F_AjoutAuteur : Form
    {
        public F_AjoutAuteur()
        {
            InitializeComponent();
        }





        // L'utilisateur valide sa création
        private void B_valider_Click(object sender, EventArgs e)
        {
            string NomAuteur = TB_NomAuteur.Text;
            string PrenomAuteur = TB_PrenomAuteur.Text;

            // Vérfications entrées utilisateurs
            if (string.IsNullOrEmpty(NomAuteur))
            {
                MessageBox.Show("Le nom de l'auteur saisie est invalide.");
                return;
            }
            if (string.IsNullOrEmpty(PrenomAuteur))
            {
                MessageBox.Show("Le prenom de l'auteur saisie est invalide.");
                return;
            }


            // Les entrées utilisateurs sont bonnes on demande une dernière confirmation à l'utilisateur
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir créer l'auteur ? \n Prenom de l'auteur : " + PrenomAuteur + " \n Nom de l'auteur : " + NomAuteur , "Confirmation de création", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Yes)
            {
                return;
            }
            // L'utilisateur accepte => on créer un objet auteur et on ferme la fenêtre
            else
            {
                Auteur auteur_temp = new Auteur(0,NomAuteur,PrenomAuteur);
                auteur_temp.CreateAuteur();

                MessageBox.Show("L'auteur a bien été créer.");
                this.Close();
            }
        }
    }
}
