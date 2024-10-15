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
    public partial class F_AjoutMulti : Form
    {
        // Objet initialiser dans le constructeur du form
        // Objet concerner :  Editeur  ; Genre ; TypeLivre
        public static string objet = "";

        public F_AjoutMulti(string _objet)
        {
            objet = _objet;

            InitializeComponent();
        }



        // Chargement de la page

        private void F_AjoutMulti_Load(object sender, EventArgs e)
        {
            // En fonction de l'objet on change le Nom de la page/titre/Nom du libelle
            switch (objet)
            {
                case "Editeur":
                    L_libelle.Text = "Nom de l'editeur :";
                    this.Text = "Ajouter un editeur";
                    L_titre.Text = "Ajouter un editeur";
                break;






                case "Genre":
                    L_libelle.Text = "Nom du genre :";
                    this.Text = "Ajouter un genre";
                    L_titre.Text = "Ajouter un genre";
                break;



                case "TypeLivre":
                    L_libelle.Text = "Type de livre :";
                    this.Text = "Ajouter un type de livre";
                    L_titre.Text = "Ajouter un type de livre";
                break;
            }
        }




        // L'utilisateur valide sa création
        private void B_valider_Click(object sender, EventArgs e)
        {
            // On récupère le libelle
            string libelle = TB_libelle.Text;

            // Vérifications entrée utilisateur
            if (string.IsNullOrEmpty(libelle))
            {
                if (objet == "Editeur")
                {
                    MessageBox.Show("Le nom de l'editeur saisie est invalide.");
                    return;
                }
                else
                {
                    MessageBox.Show("Le libelle saisie est invalide.");
                    return;
                }
            }

            // Entrée utilisateur correct, on demande une dernière confirmation à l'utilisateurs avant de créer.
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir créer" + objet + " ? \n Libelle : " + libelle, "Confirmation de création", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Yes)
            {
                return;
            }
        
            else
            {
                switch(objet) 
                {
                    case "Editeur":
                        Editeur editeur_temp = new Editeur(0, libelle);
                        editeur_temp.CreateEditeur();
                        MessageBox.Show("L'editeur a bien été créer.");
                        this.Close();
                    break;



                    case "Genre":
                        Genre genre_temp = new Genre(0, libelle);
                        genre_temp.CreateGenre();
                        MessageBox.Show("Le genre a bien été créer.");
                        this.Close();
                    break;



                    case "TypeLivre":
                        TypeLivre typelivre_temp = new TypeLivre(0, libelle);
                        typelivre_temp.CreateTypeLivre();
                        MessageBox.Show("Le type de livre à bien été créer.");
                        this.Close();
                    break;
                }
            }
        }        
    }
}
