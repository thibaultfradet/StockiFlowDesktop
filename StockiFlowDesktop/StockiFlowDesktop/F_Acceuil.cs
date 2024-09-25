using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using StockiFlowDesktop.Classes;

namespace StockiFlowDesktop
{
    public partial class F_Acceuil : Form
    {
        

        public int AncienStock = 0;


        public F_Acceuil()
        {
            InitializeComponent();

        }






        /* Au chargement de la page */
        private void F_Acceuil_Load(object sender, EventArgs e)
        {
            
        }







        /* L'utilisateur clique sur rechercher */
        private void B_rechercher_Click(object sender, EventArgs e)
        {
            
        }









        /* L'utilisateur change d'objet s�lectionn� dans la ComboBox */
        private void CB_objet_SelectedIndexChanged(object sender, EventArgs e)
        {

          
        }










        /* Methode refreshGrid qui permet d'actualiser le datagridView */
        private void refreshGrid()
        {
            

        }


        /* L'utilisateur clique sur une cellule de la grid */
        private void DGV_stock_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }








        /* L'utilisateur commence une modification */
        private void DGV_stock_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }








        /* L'utilisateur a finit l'�dition d'une cellule */
        private void DGV_stock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }







        /* Evenement d�clencher par l'utilisateur quand il fermera la page d'ajout d'un objet */
        private void F_AjoutClosing(object sender, FormClosingEventArgs e)
        {
           
        }







        /* L'utilisateur veut ajouter un livre � la base de donn�es */
        private void livreToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}