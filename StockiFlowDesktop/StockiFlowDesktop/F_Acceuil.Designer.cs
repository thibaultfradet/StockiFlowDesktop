using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StockiFlowDesktop
{
    partial class F_Acceuil
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TB_rechercher = new TextBox();
            B_rechercher = new Button();
            MenuStrip = new MenuStrip();
            ajouterToolStripMenuItem = new ToolStripMenuItem();
            livreToolStripMenuItem = new ToolStripMenuItem();
            typeLivreToolStripMenuItem = new ToolStripMenuItem();
            genreToolStripMenuItem = new ToolStripMenuItem();
            auteurToolStripMenuItem = new ToolStripMenuItem();
            editeurToolStripMenuItem = new ToolStripMenuItem();
            GB_Filtre = new GroupBox();
            DGV_stock = new DataGridView();
            MenuStrip.SuspendLayout();
            GB_Filtre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_stock).BeginInit();
            SuspendLayout();
            // 
            // TB_rechercher
            // 
            TB_rechercher.Location = new Point(6, 23);
            TB_rechercher.Name = "TB_rechercher";
            TB_rechercher.Size = new Size(194, 23);
            TB_rechercher.TabIndex = 0;
            // 
            // B_rechercher
            // 
            B_rechercher.Location = new Point(206, 20);
            B_rechercher.Name = "B_rechercher";
            B_rechercher.Size = new Size(130, 30);
            B_rechercher.TabIndex = 1;
            B_rechercher.Text = "Rechercher par titre";
            B_rechercher.UseVisualStyleBackColor = true;
            B_rechercher.Click += B_rechercher_Click;
            // 
            // MenuStrip
            // 
            MenuStrip.ImageScalingSize = new Size(20, 20);
            MenuStrip.Items.AddRange(new ToolStripItem[] { ajouterToolStripMenuItem });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(1924, 24);
            MenuStrip.TabIndex = 2;
            // 
            // ajouterToolStripMenuItem
            // 
            ajouterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { livreToolStripMenuItem, typeLivreToolStripMenuItem, genreToolStripMenuItem, auteurToolStripMenuItem, editeurToolStripMenuItem });
            ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            ajouterToolStripMenuItem.Size = new Size(58, 20);
            ajouterToolStripMenuItem.Text = "Ajouter";
            // 
            // livreToolStripMenuItem
            // 
            livreToolStripMenuItem.Name = "livreToolStripMenuItem";
            livreToolStripMenuItem.Size = new Size(180, 22);
            livreToolStripMenuItem.Text = "Livre";
            livreToolStripMenuItem.Click += livreToolStripMenuItem_Click;
            // 
            // typeLivreToolStripMenuItem
            // 
            typeLivreToolStripMenuItem.Name = "typeLivreToolStripMenuItem";
            typeLivreToolStripMenuItem.Size = new Size(180, 22);
            typeLivreToolStripMenuItem.Text = "TypeLivre";
            typeLivreToolStripMenuItem.Click += typeLivreToolStripMenuItem_Click;
            // 
            // genreToolStripMenuItem
            // 
            genreToolStripMenuItem.Name = "genreToolStripMenuItem";
            genreToolStripMenuItem.Size = new Size(180, 22);
            genreToolStripMenuItem.Text = "Genre";
            genreToolStripMenuItem.Click += genreToolStripMenuItem_Click;
            // 
            // auteurToolStripMenuItem
            // 
            auteurToolStripMenuItem.Name = "auteurToolStripMenuItem";
            auteurToolStripMenuItem.Size = new Size(180, 22);
            auteurToolStripMenuItem.Text = "Auteur";
            auteurToolStripMenuItem.Click += auteurToolStripMenuItem_Click;
            // 
            // editeurToolStripMenuItem
            // 
            editeurToolStripMenuItem.Name = "editeurToolStripMenuItem";
            editeurToolStripMenuItem.Size = new Size(180, 22);
            editeurToolStripMenuItem.Text = "Editeur";
            editeurToolStripMenuItem.Click += editeurToolStripMenuItem_Click;
            // 
            // GB_Filtre
            // 
            GB_Filtre.Controls.Add(TB_rechercher);
            GB_Filtre.Controls.Add(B_rechercher);
            GB_Filtre.Location = new Point(12, 48);
            GB_Filtre.Name = "GB_Filtre";
            GB_Filtre.Size = new Size(571, 64);
            GB_Filtre.TabIndex = 3;
            GB_Filtre.TabStop = false;
            GB_Filtre.Text = "Filtrer";
            // 
            // DGV_stock
            // 
            DGV_stock.AllowUserToAddRows = false;
            DGV_stock.AllowUserToDeleteRows = false;
            DGV_stock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_stock.Location = new Point(12, 134);
            DGV_stock.Name = "DGV_stock";
            DGV_stock.RowHeadersWidth = 51;
            DGV_stock.Size = new Size(1798, 785);
            DGV_stock.TabIndex = 3;
            DGV_stock.CellDoubleClick += DGV_stock_CellDoubleClick;
            // 
            // F_Acceuil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 824);
            Controls.Add(GB_Filtre);
            Controls.Add(DGV_stock);
            Controls.Add(MenuStrip);
            MainMenuStrip = MenuStrip;
            Name = "F_Acceuil";
            Text = "Gestion de stock";
            Load += F_Acceuil_Load;
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            GB_Filtre.ResumeLayout(false);
            GB_Filtre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_stock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_rechercher;
        private Button B_rechercher;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem ajouterToolStripMenuItem;
        private GroupBox GB_Filtre;
        private DataGridView DGV_stock;
        private ToolStripMenuItem livreToolStripMenuItem;
        private ToolStripMenuItem typeLivreToolStripMenuItem;
        private ToolStripMenuItem genreToolStripMenuItem;
        private ToolStripMenuItem auteurToolStripMenuItem;
        private ToolStripMenuItem editeurToolStripMenuItem;
    }
}