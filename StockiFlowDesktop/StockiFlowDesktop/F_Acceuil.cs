using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using StockiFlowDesktop.Classes;
using StockiFlowDesktop.Pages;

namespace StockiFlowDesktop
{
    public partial class F_Acceuil : Form
    {


        public int AncienStock = 0;

        public List<Livre> collectionLivres = new List<Livre>();


        public F_Acceuil()
        {
            InitializeComponent();
        }






        /* Au chargement de la page */
        private void F_Acceuil_Load(object sender, EventArgs e)
        {
            // on ajoute les colonnes au data grid view
            DGV_stock.Columns.Add("ISBN", "ISBN");
            DGV_stock.Columns.Add("Stock", "Quantité stock");
            DGV_stock.Columns.Add("titre", "Titre");
            DGV_stock.Columns.Add("nombre_pages", "Nombres de pages");
            DGV_stock.Columns.Add("poid", "Poid");
            DGV_stock.Columns.Add("PrixInitial", "Prix initial");
            DGV_stock.Columns.Add("Hauteur", "Hauteur");
            DGV_stock.Columns.Add("Largeur", "Largeur");
            DGV_stock.Columns.Add("Commentaire", "Commentaire");
            DGV_stock.Columns.Add("Synopsys", "Synopsys");
            DGV_stock.Columns.Add("DateSortie", "Date de sortie");
            DGV_stock.Columns.Add("Type", "Type");
            DGV_stock.Columns.Add("Auteurs", "Auteurs");
            DGV_stock.Columns.Add("Editeurs", "Editeurs");
            DGV_stock.Columns.Add("Genres", "Genres");

           
            //Appel de la méthode refreshGrid qui va créer les colonnes et charger les obj
            refreshGrid(null);
        }







        /* L'utilisateur clique sur rechercher */
        private void B_rechercher_Click(object sender, EventArgs e)
        {
            // On appelle refreshGrid avec les paramètres pour faire une recherche
            refreshGrid(TB_rechercher.Text);

        }







        /* Methode refreshGrid qui permet d'actualiser le datagridView 
         Paramètre : pattern : Si l'utilisateur est bien dans le cas d'une recherche alors il s'agit du pattern de recherche*/
        private void refreshGrid(string? pattern)
        {
            DGV_stock.Rows.Clear();

            // On initialise la grid et on y rajoute les obj avec findAll
            Livre livre_findAll = new Livre();



            // Si l'utilisateur recherche on appelle FindAllLivres avec des paramètres différents
            if (pattern != null)
            {
                collectionLivres = livre_findAll.FindAllLivre(true, pattern);
            }
            else
            {
                collectionLivres = livre_findAll.FindAllLivre(false, null);
            }


            foreach (Livre livre_dgv in collectionLivres)
            {
                // Variable concatenation des libelle/nom
                string AuteurConcat = "";
                string EditeurConcat = "";
                string GenreConcat = "";


                foreach (Auteur a in livre_dgv.GetLesAuteurs()) { AuteurConcat += a.GetNomAuteur() + " " + a.GetPrenomAuteur() + " , "; }
                foreach (Editeur e in livre_dgv.GetLesEditeurs()) { EditeurConcat += e.GetNomEditeur() + " , "; }
                foreach (Genre g in livre_dgv.GetLesGenres()) { GenreConcat += g.GetLibelle() + " , "; }



                DGV_stock.Rows.Add(
                livre_dgv.GetISBN(),
                livre_dgv.GetStock(),
                livre_dgv.GetTitre(),
                livre_dgv.GetNombrePages(),
                livre_dgv.GetPoids(),
                livre_dgv.GetPrixInitial(),
                livre_dgv.GetHauteur(),
                livre_dgv.GetLargeur(),
                livre_dgv.GetCommentaire(),
                livre_dgv.GetSynopsys(),
                livre_dgv.GetDateSortie().ToString("dd/MM/yyyy"),
                livre_dgv.GetLeType().GetLibelle(),
                AuteurConcat,
                EditeurConcat,
                GenreConcat);

            }
        }






        /* L'utilisatuer double clique sur une des ligne du DGV on affiche les informations du livre ou de l'objet externe selon l'endroit cliquer */
        private void DGV_stock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            Livre LivreCliquer = new Livre();
            LivreCliquer.RetrieveLivre(collectionLivres.ElementAt(e.RowIndex).GetISBN());


            //On envoie l'utilisateur vers la page de modification de livre => livre dans le constructeur de la page d'ajout

            F_AjoutLivre F_ModifLivre = new F_AjoutLivre(LivreCliquer);
            F_ModifLivre.FormClosing += F_AjoutClosing;
            this.Enabled = false;
            F_ModifLivre.Show();

        }








        /* Evenement déclencher par l'utilisateur quand il fermera la page d'ajout d'un objet */
        private void F_AjoutClosing(object sender, FormClosingEventArgs e)
        {
            this.Enabled = true;
        }





        
        
        /* L'utilisateur veux voir l'historique des actions sur le stock */
        private void historiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_HistorisationStock F_Historisation = new F_HistorisationStock();
            F_Historisation.FormClosing += F_AjoutClosing;
            this.Enabled = false;
            F_Historisation.Show();
        }








        /* L'utilisateur veux ajouter un item et clique sur un des items */
        /* APPEL de la page d'ajout approprier avec le nom de l'objet en paramètre selon l'objet sélectionner */
        private void livreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_AjoutLivre F_Livre = new F_AjoutLivre(null);
            F_Livre.FormClosing += F_AjoutClosing;
            this.Enabled = false;
            F_Livre.Show();
        }


        private void typeLivreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_AjoutMulti F_TypeLivre = new F_AjoutMulti("TypeLivre");
            F_TypeLivre.FormClosing += F_AjoutClosing;
            this.Enabled = false;
            F_TypeLivre.Show();
        }

        private void genreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_AjoutMulti F_Genre = new F_AjoutMulti("Genre");
            F_Genre.FormClosing += F_AjoutClosing;
            this.Enabled = false;
            F_Genre.Show();
        }



        private void auteurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_AjoutAuteur F_Auteur = new F_AjoutAuteur();
            F_Auteur.FormClosing += F_AjoutClosing;
            this.Enabled = false;
            F_Auteur.Show();
        }

        private void editeurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_AjoutMulti F_Editeur = new F_AjoutMulti("Editeur");
            F_Editeur.FormClosing += F_AjoutClosing;
            this.Enabled = false;
            F_Editeur.Show();
        }




       
    }
}