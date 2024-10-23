using StockiFlowDesktop.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StockiFlowDesktop.Pages
{
    public partial class F_AjoutLivre : Form
    {
        public Livre livreConcerner = new Livre();


        // On récupère les objets
        List<Auteur> collectionAuteurs = new List<Auteur>();
        List<Genre> collectionGenres = new List<Genre>();
        List<Editeur> collectionEditeurs = new List<Editeur>();
        List<TypeLivre> collectionTypeLivre = new List<TypeLivre>();

        public F_AjoutLivre(Livre? _livre)
        {
            livreConcerner = _livre;

            InitializeComponent();

            ChargerListeElement();

            if (_livre != null)
            {
                RemplirInformation();
            }
        }




        /* Méthode RemplirInformation qui est appeler si le livre mis en paramètre est non null, il s'agit donc d'une visualisation de la fiche du livre et non une création */
        private void RemplirInformation()
        {

            //Désactive toutes les entreées utilisateur pour éviter que l'utilisateur modifie des valeurs
            TB_ISBN.Enabled = false;
            TB_Titre.Enabled = false;
            TB_synopsys.Enabled = false;
            TB_Commentaire.Enabled = false;
            NUD_Hauteur.Enabled = false;
            NUD_Largeur.Enabled = false;
            NUD_NombrePages.Enabled = false;
            NUD_Poid.Enabled = false;
            NUD_PrixInitial.Enabled = false;
            CLB_Auteur.Enabled = false;
            CLB_Editeur.Enabled = false;
            CLB_Genre.Enabled = false;
            CB_TypeLivre.Enabled = false;
            DTP_DateSortie.Enabled = false;
            B_Valider.Enabled = false;



            //On ne peux pas changer la clé primaire
            TB_ISBN.Text = livreConcerner.GetISBN();
            TB_Titre.Text = livreConcerner.GetTitre();
            NUD_Hauteur.Value = decimal.Parse(livreConcerner.GetHauteur().ToString());
            NUD_Largeur.Value = decimal.Parse(livreConcerner.GetLargeur().ToString());
            NUD_NombrePages.Value = livreConcerner.GetNombrePages();
            NUD_Poid.Value = decimal.Parse(livreConcerner.GetPoids().ToString());
            NUD_PrixInitial.Value = decimal.Parse(livreConcerner.GetPrixInitial().ToString());
            TB_synopsys.Text = livreConcerner.GetSynopsys();
            TB_Commentaire.Text = livreConcerner.GetCommentaire();
            DTP_DateSortie.Value = livreConcerner.GetDateSortie();
            CB_TypeLivre.SelectedItem = livreConcerner.GetLeType().GetIdTypeLivre();



            // ON AJOUTE LA SELECTION DU TYPE LIVRE
            TypeLivre tlToCheck = collectionTypeLivre.FirstOrDefault(tl => tl.GetIdTypeLivre() == livreConcerner.GetLeType().GetIdTypeLivre());
            if (tlToCheck != null)
            {
                int index = CB_TypeLivre.Items.IndexOf(tlToCheck);

                if (index != -1)
                {
                    CB_TypeLivre.SelectedIndex = index;
                }
            }

            // ON AJOUTE LES ITEMS DE LISTE => on check en fonction de la liste en public
            //Genres

            // Maintenant on coche les genres associés au livre
            foreach (Genre g in livreConcerner.GetLesGenres())
            {

                Genre genreToCheck = collectionGenres.FirstOrDefault(genre => genre.GetIdGenre() == g.GetIdGenre());

                if (genreToCheck != null)
                {
                    // Cocher l'élément correspondant dans la CheckedListBox
                    int index = CLB_Genre.Items.IndexOf(genreToCheck);
                    if (index != -1)
                    {
                        CLB_Genre.SetItemChecked(index, true);
                    }
                }
            }


            //Auteur
            foreach (Auteur a in livreConcerner.GetLesAuteurs())
            {
                Auteur aToCheck = collectionAuteurs.FirstOrDefault(Auteur => Auteur.GetIdAuteur() == a.GetIdAuteur());

                if (aToCheck != null)
                {
                    int index = CLB_Auteur.Items.IndexOf(aToCheck);
                    if (index != -1)
                    {
                        CLB_Auteur.SetItemChecked(index, true);
                    }
                }
            }

            //Editeur
            foreach (Editeur e in livreConcerner.GetLesEditeurs())
            {
                Editeur eToCheck = collectionEditeurs.FirstOrDefault(Editeur => Editeur.GetIdEditeur() == e.GetIdEditeur());

                if (eToCheck != null)
                {
                    int index = CLB_Editeur.Items.IndexOf(eToCheck);
                    if (index != -1)
                    {
                        CLB_Editeur.SetItemChecked(index, true);
                    }
                }
            }
        }





        /* Méthode ChargerListeElement qui récupère les différentes collections d'objets et affiche chaque item dans les CheckedListBox/ComboBox */
        private void ChargerListeElement()
        {

            // on change la date maximum du calendrier a ajd
            DTP_DateSortie.MaxDate = DateTime.Today;


            // on clear les comboBox / checkedListeBox si jamais elles ont deja été charger pour éviter doublon
            CB_TypeLivre.Items.Clear();
            CLB_Auteur.Items.Clear();
            CLB_Editeur.Items.Clear();
            CLB_Genre.Items.Clear();


            // On recupere les objets
            Auteur a_findAll = new Auteur();
            Genre g_findAll = new Genre();
            Editeur e_findAll = new Editeur();
            TypeLivre tl_findAll = new TypeLivre();

            collectionAuteurs = a_findAll.FindAllAuteur();
            collectionGenres = g_findAll.FindAllGenre();
            collectionEditeurs = e_findAll.FindAllEditeur();
            collectionTypeLivre = tl_findAll.FindAllTypeLivre();


            foreach (Auteur a_foreach in collectionAuteurs)
            {
                CLB_Auteur.Items.Add(a_foreach.GetNomAuteur() + " " + a_foreach.GetPrenomAuteur());
            }
            foreach (Genre g_foreach in collectionGenres)
            {
                CLB_Genre.Items.Add(g_foreach.GetLibelle());
            }
            foreach (Editeur e_foreach in collectionEditeurs)
            {
                CLB_Editeur.Items.Add(e_foreach.GetNomEditeur());
            }
            foreach (TypeLivre tl_foreach in collectionTypeLivre)
            {
                CB_TypeLivre.Items.Add(tl_foreach.GetLibelle());
            }
        }
















        /* L'utilisateur valide sa création */
        private void B_Valider_Click(object sender, EventArgs e)
        {
            // Récupération des valeurs sauf les listes que l'on testera avant de recuperer pour provoquer moins de latence
            string ISBN = TB_ISBN.Text;
            string titre = TB_Titre.Text;
            int nombrePages = int.Parse(NUD_NombrePages.Value.ToString());
            float poid = float.Parse(NUD_Poid.Value.ToString());
            float hauteur = float.Parse(NUD_Hauteur.Value.ToString());
            float largeur = float.Parse(NUD_Largeur.Value.ToString());
            float prixInitial = float.Parse(NUD_PrixInitial.Value.ToString());
            string commentaire = TB_Commentaire.Text;
            string synopsys = TB_synopsys.Text;
            DateTime DateSortie = DTP_DateSortie.Value;
            int IndexleType = CB_TypeLivre.SelectedIndex;

            List<Editeur> editeurSelectionner = new List<Editeur>();
            List<Auteur> auteurSelectionner = new List<Auteur>();
            List<Genre> genreSelectionner = new List<Genre>();



            /* Vérifications entrées utilisateurs */
            if (string.IsNullOrEmpty(ISBN))
            {
                MessageBox.Show("L'ISBN renseigné est invalide.");
                return;
            }
            if (string.IsNullOrEmpty(titre))
            {
                MessageBox.Show("Le titre renseigné est invalide.");
                return;
            }
            if (nombrePages <= 0)
            {
                MessageBox.Show("Le nombres de pages renseignées est invalide.");
                return;
            }
            if (poid <= 0)
            {
                MessageBox.Show("Le poid renseigné est invalide.");
                return;
            }
            if (hauteur <= 0)
            {
                MessageBox.Show("La hauteur renseigné est invalide.");
                return;
            }
            if (largeur <= 0)
            {
                MessageBox.Show("La largeur renseigné est invalide.");
                return;
            }
            if (prixInitial <= 0)
            {
                MessageBox.Show("Le prix initial renseigné est invalide.");
                return;
            }
            if (string.IsNullOrEmpty(commentaire) || commentaire.Length > 200)
            {
                MessageBox.Show("Le commentaire renseigné est invalide.");
                return;
            }
            if (string.IsNullOrEmpty(synopsys) || synopsys.Length > 200)
            {
                MessageBox.Show("Le synopsys renseigné est invalide.");
                return;
            }
            if (DateSortie > DateTime.Today)
            {
                MessageBox.Show("La date renseignée est invalide.");
                return;
            }
            if (CB_TypeLivre.SelectedItem == null)
            {
                MessageBox.Show("Merci de selectionner un type de livre.");
                return;
            }



            // On vérifie si l'utilisateur à checker au moins 1 editeur ; auteur ; genre
            if (CLB_Auteur.CheckedItems.Count <= 0)
            {
                MessageBox.Show("Merci de sélectionner au moins 1 auteur.");
                return;
            }
            if (CLB_Editeur.CheckedItems.Count <= 0)
            {
                MessageBox.Show("Merci de sélectionner au moins 1 éditeur.");
                return;
            }
            if (CLB_Genre.CheckedItems.Count <= 0)
            {
                MessageBox.Show("Merci de sélectionner au moins 1 genre.");
                return;
            }




            // Les tests sont passés on récupère les listes et les objets externes
            foreach (int indexEditeurCheck in CLB_Editeur.CheckedIndices)
            {
                Editeur e_temp = new Editeur();
                e_temp.RetrieveEditeur(indexEditeurCheck);
                editeurSelectionner.Add(e_temp);
            }

            foreach (int indexAuteurCheck in CLB_Auteur.CheckedIndices)
            {
                Auteur a_temp = new Auteur();
                a_temp.RetrieveAuteur(indexAuteurCheck);
                auteurSelectionner.Add(a_temp);
            }

            foreach (int indexGenreCheck in CLB_Genre.CheckedIndices)
            {
                Genre g_temp = new Genre();
                g_temp.RetrieveGenre(indexGenreCheck);
                genreSelectionner.Add(g_temp);
            }

            // récupération du typeLivre
            TypeLivre TypeLivreSelectionner = new TypeLivre();
            TypeLivreSelectionner.RetrieveTypeLivre(IndexleType);


            // On créer l'objet livre qui contient toutes les valeurs récuperer et on créer dans la base de données
            Livre l_create = new Livre();
            l_create.SetISBN(ISBN);
            l_create.SetTitre(titre);
            l_create.SetNombrePages(nombrePages);
            l_create.SetPrixInitial(prixInitial);
            l_create.SetHauteur(hauteur);
            l_create.SetLargeur(largeur);
            l_create.SetCommentaire(commentaire);
            l_create.SetSynopsys(synopsys);
            l_create.SetDateSortie(DateSortie);
            l_create.SetLeType(TypeLivreSelectionner);
            l_create.SetLesAuteurs(auteurSelectionner);
            l_create.SetLesGenres(genreSelectionner);
            l_create.SetLesEditeurs(editeurSelectionner);
            //Par défaut le stock est à 0
            l_create.setStock(0);


            // Dernière confirmation utilisateur avant la création

            string auteur_concat = "";
            string editeur_concat = "";
            string genre_concat = "";


            //Ajout dans les variable de concatenation
            foreach (Auteur aCONCAT in auteurSelectionner)
            {
                auteur_concat += aCONCAT.GetPrenomAuteur() + " " + aCONCAT.GetNomAuteur() + " , ";
            }
            foreach (Editeur eCONCAT in editeurSelectionner)
            {
                editeur_concat += eCONCAT.GetNomEditeur() + " , ";
            }
            foreach (Genre gCONCAT in genreSelectionner)
            {
                genre_concat += gCONCAT.GetLibelle() + " , ";
            }

            string message = "Êtes-vous sûr de vouloir créer le livre avec les informations suivantes ?\n\n" +
                             "ISBN : " + TB_ISBN.Text + "\n" +
                             "Titre : " + TB_Titre.Text + "\n" +
                             "Nombre de pages : " + NUD_NombrePages.Value.ToString() + "\n" +
                             "Poids : " + NUD_Poid.Value.ToString() + " kg\n" +
                             "Hauteur : " + NUD_Hauteur.Value.ToString() + " cm\n" +
                             "Largeur : " + NUD_Largeur.Value.ToString() + " cm\n" +
                             "Prix initial : " + NUD_PrixInitial.Value.ToString() + " €\n" +
                             "Commentaire : " + TB_Commentaire.Text + "\n" +
                             "Synopsys : " + TB_synopsys.Text + "\n" +
                             "Date de sortie : " + DTP_DateSortie.Value.ToShortDateString() + "\n" +
                             "Type de livre (index) : " + CB_TypeLivre.SelectedIndex.ToString() + "\n" +
                             "Genres sélectionnés : " + genre_concat + "\n" +
                             "Auteurs sélectionnés : " + auteur_concat + "\n" +
                             "Éditeurs sélectionnés : " + editeur_concat + "\n";


            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result != DialogResult.Yes)
            {
                return;
            }
            //Création du livre dans la base de données => utilisateur sûr
            else
            {
                l_create.CreateLivre();

                MessageBox.Show("Le livre à bien été créer.");
                this.Close();
            }
        }








        /* L'utilisateur viens de la page de modification de stock */
        private void F_StockClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }








        /* Evenement déclencher par l'utilisateur quand il fermera la page d'ajout d'un objet */
        private void F_AjoutClosing(object sender, FormClosingEventArgs e)
        {
            // on réactive la page et on actualise la comboBox selon le contexte
            this.Enabled = true;

            Form ClosedForm = sender as Form;


            //Switch case sur le formulaire fermer en question
            switch (ClosedForm)
            {
                // editeur ; genre ; TypeLivre et en fonction de on refresh la comboBox
                case F_AjoutMulti:
                    string objet = F_AjoutMulti.objet;
                    switch (objet)
                    {
                        case "Editeur":
                            Editeur editeur_temp = new Editeur();
                            List<Editeur> collectionEditeurs = new List<Editeur>();
                            collectionEditeurs = editeur_temp.FindAllEditeur();

                            CLB_Editeur.Items.Clear();
                            foreach (Editeur e_foreach in collectionEditeurs)
                            {
                                CLB_Editeur.Items.Add(e_foreach.GetNomEditeur());
                            }
                            break;


                        case "Genre":
                            Genre genre_temp = new Genre();
                            List<Genre> collecitonGenres = new List<Genre>();
                            collecitonGenres = genre_temp.FindAllGenre();

                            CLB_Genre.Items.Clear();
                            foreach (Genre g_foreach in collecitonGenres)
                            {
                                CLB_Genre.Items.Add(g_foreach.GetLibelle());
                            }
                            break;


                        case "TypeLivre":
                            TypeLivre tl_temp = new TypeLivre();
                            List<TypeLivre> collectionTL = new List<TypeLivre>();
                            collectionTL = tl_temp.FindAllTypeLivre();

                            CB_TypeLivre.Items.Clear();
                            foreach (TypeLivre tl_foreach in collectionTL)
                            {
                                CB_TypeLivre.Items.Add(tl_foreach.GetLibelle());
                            }
                            break;
                    }
                    break;

                // Auteur
                case F_AjoutAuteur:

                    Auteur auteur_temp = new Auteur();
                    List<Auteur> collectionAuteurs = new List<Auteur>();
                    collectionAuteurs = auteur_temp.FindAllAuteur();

                    CLB_Auteur.Items.Clear();
                    foreach (Auteur a_foreach in collectionAuteurs)
                    {
                        CLB_Auteur.Items.Add(a_foreach.GetNomAuteur() + " " + a_foreach.GetPrenomAuteur());
                    }



                    break;
            }
        }








        /* L'utilisateur veut ajouter au stock actuel du livre */
        private void B_Ajouter_Click(object sender, EventArgs e)
        {
            F_ModifStock F_modifierStock = new F_ModifStock(livreConcerner, true);
            F_modifierStock.FormClosing += F_StockClosing;
            this.Enabled = false;
            F_modifierStock.Show();
        }





        /* l'utilisateur veut réduire au stock actuel du livre */
        private void B_reduire_Click(object sender, EventArgs e)
        {
            F_ModifStock F_modifierStock = new F_ModifStock(livreConcerner,false);
            F_modifierStock.FormClosing += F_StockClosing;
            this.Enabled = false;
            F_modifierStock.Show();
        }










        /* Bouton ajout TypeLivre ; Genre ; Auteur ; Editeur si la liste ne satisfait pas la recherche */

        private void B_AjouterTypeLivre_Click(object sender, EventArgs e)
        {
            F_AjoutMulti ActiveForm = new F_AjoutMulti("TypeLivre");
            ActiveForm.FormClosing += F_AjoutClosing;
            this.Enabled = false;
            ActiveForm.Show();
        }

        private void B_AjouterGenre_Click(object sender, EventArgs e)
        {
            F_AjoutMulti ActiveForm = new F_AjoutMulti("Genre");
            ActiveForm.FormClosing += F_AjoutClosing;
            this.Enabled = false;
            ActiveForm.Show();
        }

        private void B_AjouterAuteur_Click(object sender, EventArgs e)
        {
            F_AjoutAuteur ActiveForm = new F_AjoutAuteur();
            ActiveForm.FormClosing += F_AjoutClosing;
            this.Enabled = false;
            ActiveForm.Show();
        }

        private void B_AjouterEditeur_Click(object sender, EventArgs e)
        {
            F_AjoutMulti ActiveForm = new F_AjoutMulti("Editeur");
            ActiveForm.FormClosing += F_AjoutClosing;
            this.Enabled = false;
            ActiveForm.Show();
        }





       
    }
}
