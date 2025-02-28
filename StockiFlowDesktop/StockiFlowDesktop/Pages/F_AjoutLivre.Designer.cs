﻿namespace StockiFlowDesktop.Pages
{
    partial class F_AjoutLivre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            L_ISBN = new Label();
            TB_ISBN = new TextBox();
            B_Valider = new Button();
            TB_Titre = new TextBox();
            L_Titre = new Label();
            L_NombrePages = new Label();
            NUD_NombrePages = new NumericUpDown();
            NUD_Poid = new NumericUpDown();
            L_Poid = new Label();
            NUD_PrixInitial = new NumericUpDown();
            L_Prix = new Label();
            NUD_Hauteur = new NumericUpDown();
            L_Hauteur = new Label();
            L_Largeur = new Label();
            NUD_Largeur = new NumericUpDown();
            TB_Commentaire = new TextBox();
            L_Commentaire = new Label();
            TB_synopsys = new TextBox();
            L_synopsys = new Label();
            DTP_DateSortie = new DateTimePicker();
            L_DateSortie = new Label();
            L_TypeLivre = new Label();
            L_Genre = new Label();
            B_AjouterTypeLivre = new Button();
            B_AjouterGenre = new Button();
            L_Auteur = new Label();
            B_AjouterAuteur = new Button();
            B_AjouterEditeur = new Button();
            label1 = new Label();
            CLB_Genre = new CheckedListBox();
            CLB_Auteur = new CheckedListBox();
            CLB_Editeur = new CheckedListBox();
            CB_TypeLivre = new ComboBox();
            B_reduire = new Button();
            GB_Stock = new GroupBox();
            B_Ajouter = new Button();
            ((System.ComponentModel.ISupportInitialize)NUD_NombrePages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Poid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_PrixInitial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Hauteur).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Largeur).BeginInit();
            GB_Stock.SuspendLayout();
            SuspendLayout();
            // 
            // L_ISBN
            // 
            L_ISBN.AutoSize = true;
            L_ISBN.Location = new Point(76, 80);
            L_ISBN.Name = "L_ISBN";
            L_ISBN.Size = new Size(38, 15);
            L_ISBN.TabIndex = 0;
            L_ISBN.Text = "ISBN :";
            // 
            // TB_ISBN
            // 
            TB_ISBN.Location = new Point(117, 77);
            TB_ISBN.Name = "TB_ISBN";
            TB_ISBN.Size = new Size(228, 23);
            TB_ISBN.TabIndex = 1;
            // 
            // B_Valider
            // 
            B_Valider.Location = new Point(404, 541);
            B_Valider.Name = "B_Valider";
            B_Valider.Size = new Size(75, 23);
            B_Valider.TabIndex = 2;
            B_Valider.Text = "Valider";
            B_Valider.UseVisualStyleBackColor = true;
            B_Valider.Click += B_Valider_Click;
            // 
            // TB_Titre
            // 
            TB_Titre.Location = new Point(117, 116);
            TB_Titre.Name = "TB_Titre";
            TB_Titre.Size = new Size(228, 23);
            TB_Titre.TabIndex = 5;
            // 
            // L_Titre
            // 
            L_Titre.AutoSize = true;
            L_Titre.Location = new Point(78, 119);
            L_Titre.Name = "L_Titre";
            L_Titre.Size = new Size(37, 15);
            L_Titre.TabIndex = 4;
            L_Titre.Text = "Titre :";
            // 
            // L_NombrePages
            // 
            L_NombrePages.AutoSize = true;
            L_NombrePages.Location = new Point(23, 158);
            L_NombrePages.Name = "L_NombrePages";
            L_NombrePages.Size = new Size(91, 15);
            L_NombrePages.TabIndex = 6;
            L_NombrePages.Text = "Nombre pages :";
            // 
            // NUD_NombrePages
            // 
            NUD_NombrePages.Location = new Point(117, 155);
            NUD_NombrePages.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            NUD_NombrePages.Name = "NUD_NombrePages";
            NUD_NombrePages.Size = new Size(57, 23);
            NUD_NombrePages.TabIndex = 7;
            // 
            // NUD_Poid
            // 
            NUD_Poid.DecimalPlaces = 2;
            NUD_Poid.Location = new Point(288, 157);
            NUD_Poid.Name = "NUD_Poid";
            NUD_Poid.Size = new Size(57, 23);
            NUD_Poid.TabIndex = 9;
            // 
            // L_Poid
            // 
            L_Poid.AutoSize = true;
            L_Poid.Location = new Point(208, 159);
            L_Poid.Name = "L_Poid";
            L_Poid.Size = new Size(77, 15);
            L_Poid.TabIndex = 8;
            L_Poid.Text = "Poid : (en kg)";
            // 
            // NUD_PrixInitial
            // 
            NUD_PrixInitial.DecimalPlaces = 2;
            NUD_PrixInitial.Location = new Point(117, 242);
            NUD_PrixInitial.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            NUD_PrixInitial.Name = "NUD_PrixInitial";
            NUD_PrixInitial.Size = new Size(57, 23);
            NUD_PrixInitial.TabIndex = 11;
            // 
            // L_Prix
            // 
            L_Prix.AutoSize = true;
            L_Prix.Location = new Point(17, 245);
            L_Prix.Name = "L_Prix";
            L_Prix.Size = new Size(97, 15);
            L_Prix.TabIndex = 10;
            L_Prix.Text = "Prix initial : (en €)";
            // 
            // NUD_Hauteur
            // 
            NUD_Hauteur.DecimalPlaces = 2;
            NUD_Hauteur.Location = new Point(117, 202);
            NUD_Hauteur.Name = "NUD_Hauteur";
            NUD_Hauteur.Size = new Size(57, 23);
            NUD_Hauteur.TabIndex = 13;
            // 
            // L_Hauteur
            // 
            L_Hauteur.AutoSize = true;
            L_Hauteur.Location = new Point(14, 205);
            L_Hauteur.Name = "L_Hauteur";
            L_Hauteur.Size = new Size(100, 15);
            L_Hauteur.TabIndex = 12;
            L_Hauteur.Text = "Hauteur : (en cm)";
            // 
            // L_Largeur
            // 
            L_Largeur.AutoSize = true;
            L_Largeur.Location = new Point(188, 205);
            L_Largeur.Name = "L_Largeur";
            L_Largeur.Size = new Size(97, 15);
            L_Largeur.TabIndex = 14;
            L_Largeur.Text = "Largeur : (en cm)";
            // 
            // NUD_Largeur
            // 
            NUD_Largeur.DecimalPlaces = 2;
            NUD_Largeur.Location = new Point(288, 202);
            NUD_Largeur.Name = "NUD_Largeur";
            NUD_Largeur.Size = new Size(57, 23);
            NUD_Largeur.TabIndex = 15;
            // 
            // TB_Commentaire
            // 
            TB_Commentaire.Location = new Point(117, 287);
            TB_Commentaire.MaxLength = 200;
            TB_Commentaire.Multiline = true;
            TB_Commentaire.Name = "TB_Commentaire";
            TB_Commentaire.Size = new Size(228, 53);
            TB_Commentaire.TabIndex = 17;
            // 
            // L_Commentaire
            // 
            L_Commentaire.AutoSize = true;
            L_Commentaire.Location = new Point(28, 304);
            L_Commentaire.Name = "L_Commentaire";
            L_Commentaire.Size = new Size(86, 15);
            L_Commentaire.TabIndex = 16;
            L_Commentaire.Text = "Commentaire :";
            // 
            // TB_synopsys
            // 
            TB_synopsys.Location = new Point(117, 363);
            TB_synopsys.MaxLength = 400;
            TB_synopsys.Multiline = true;
            TB_synopsys.Name = "TB_synopsys";
            TB_synopsys.Size = new Size(228, 81);
            TB_synopsys.TabIndex = 19;
            // 
            // L_synopsys
            // 
            L_synopsys.AutoSize = true;
            L_synopsys.Location = new Point(52, 394);
            L_synopsys.Name = "L_synopsys";
            L_synopsys.Size = new Size(62, 15);
            L_synopsys.TabIndex = 18;
            L_synopsys.Text = "Synopsys :";
            // 
            // DTP_DateSortie
            // 
            DTP_DateSortie.Location = new Point(117, 476);
            DTP_DateSortie.Name = "DTP_DateSortie";
            DTP_DateSortie.Size = new Size(200, 23);
            DTP_DateSortie.TabIndex = 20;
            // 
            // L_DateSortie
            // 
            L_DateSortie.AutoSize = true;
            L_DateSortie.Location = new Point(10, 480);
            L_DateSortie.Name = "L_DateSortie";
            L_DateSortie.Size = new Size(85, 15);
            L_DateSortie.TabIndex = 21;
            L_DateSortie.Text = "Date de sortie :";
            // 
            // L_TypeLivre
            // 
            L_TypeLivre.AutoSize = true;
            L_TypeLivre.Location = new Point(439, 75);
            L_TypeLivre.Name = "L_TypeLivre";
            L_TypeLivre.Size = new Size(76, 15);
            L_TypeLivre.TabIndex = 22;
            L_TypeLivre.Text = "Type de livre:";
            // 
            // L_Genre
            // 
            L_Genre.AutoSize = true;
            L_Genre.Location = new Point(432, 176);
            L_Genre.Name = "L_Genre";
            L_Genre.Size = new Size(95, 15);
            L_Genre.TabIndex = 24;
            L_Genre.Text = "Genre(s) de livre:";
            // 
            // B_AjouterTypeLivre
            // 
            B_AjouterTypeLivre.Location = new Point(737, 71);
            B_AjouterTypeLivre.Name = "B_AjouterTypeLivre";
            B_AjouterTypeLivre.Size = new Size(75, 23);
            B_AjouterTypeLivre.TabIndex = 25;
            B_AjouterTypeLivre.Text = "Ajouter";
            B_AjouterTypeLivre.UseVisualStyleBackColor = true;
            B_AjouterTypeLivre.Click += B_AjouterTypeLivre_Click;
            // 
            // B_AjouterGenre
            // 
            B_AjouterGenre.Location = new Point(736, 176);
            B_AjouterGenre.Name = "B_AjouterGenre";
            B_AjouterGenre.Size = new Size(75, 23);
            B_AjouterGenre.TabIndex = 26;
            B_AjouterGenre.Text = "Ajouter";
            B_AjouterGenre.UseVisualStyleBackColor = true;
            B_AjouterGenre.Click += B_AjouterGenre_Click;
            // 
            // L_Auteur
            // 
            L_Auteur.AutoSize = true;
            L_Auteur.Location = new Point(425, 277);
            L_Auteur.Name = "L_Auteur";
            L_Auteur.Size = new Size(103, 15);
            L_Auteur.TabIndex = 28;
            L_Auteur.Text = "Auteur(s) de livre :";
            // 
            // B_AjouterAuteur
            // 
            B_AjouterAuteur.Location = new Point(737, 277);
            B_AjouterAuteur.Name = "B_AjouterAuteur";
            B_AjouterAuteur.Size = new Size(75, 23);
            B_AjouterAuteur.TabIndex = 29;
            B_AjouterAuteur.Text = "Ajouter";
            B_AjouterAuteur.UseVisualStyleBackColor = true;
            B_AjouterAuteur.Click += B_AjouterAuteur_Click;
            // 
            // B_AjouterEditeur
            // 
            B_AjouterEditeur.Location = new Point(740, 394);
            B_AjouterEditeur.Name = "B_AjouterEditeur";
            B_AjouterEditeur.Size = new Size(75, 23);
            B_AjouterEditeur.TabIndex = 32;
            B_AjouterEditeur.Text = "Ajouter";
            B_AjouterEditeur.UseVisualStyleBackColor = true;
            B_AjouterEditeur.Click += B_AjouterEditeur_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(423, 394);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 31;
            label1.Text = "Editeur(s) du livre :";
            // 
            // CLB_Genre
            // 
            CLB_Genre.FormattingEnabled = true;
            CLB_Genre.Location = new Point(533, 176);
            CLB_Genre.Name = "CLB_Genre";
            CLB_Genre.ScrollAlwaysVisible = true;
            CLB_Genre.Size = new Size(200, 76);
            CLB_Genre.TabIndex = 34;
            // 
            // CLB_Auteur
            // 
            CLB_Auteur.FormattingEnabled = true;
            CLB_Auteur.Location = new Point(534, 277);
            CLB_Auteur.Name = "CLB_Auteur";
            CLB_Auteur.ScrollAlwaysVisible = true;
            CLB_Auteur.Size = new Size(200, 94);
            CLB_Auteur.TabIndex = 35;
            // 
            // CLB_Editeur
            // 
            CLB_Editeur.FormattingEnabled = true;
            CLB_Editeur.Location = new Point(534, 394);
            CLB_Editeur.Name = "CLB_Editeur";
            CLB_Editeur.ScrollAlwaysVisible = true;
            CLB_Editeur.Size = new Size(200, 94);
            CLB_Editeur.TabIndex = 36;
            // 
            // CB_TypeLivre
            // 
            CB_TypeLivre.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_TypeLivre.FormattingEnabled = true;
            CB_TypeLivre.Location = new Point(533, 72);
            CB_TypeLivre.Name = "CB_TypeLivre";
            CB_TypeLivre.Size = new Size(198, 23);
            CB_TypeLivre.TabIndex = 37;
            // 
            // B_reduire
            // 
            B_reduire.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            B_reduire.Location = new Point(180, 22);
            B_reduire.Name = "B_reduire";
            B_reduire.Size = new Size(75, 23);
            B_reduire.TabIndex = 38;
            B_reduire.Text = "REDUIRE";
            B_reduire.UseVisualStyleBackColor = true;
            B_reduire.Click += B_reduire_Click;
            // 
            // GB_Stock
            // 
            GB_Stock.Controls.Add(B_Ajouter);
            GB_Stock.Controls.Add(B_reduire);
            GB_Stock.Location = new Point(288, 12);
            GB_Stock.Name = "GB_Stock";
            GB_Stock.Size = new Size(304, 54);
            GB_Stock.TabIndex = 40;
            GB_Stock.TabStop = false;
            GB_Stock.Text = "Changer le stock du livre";
            // 
            // B_Ajouter
            // 
            B_Ajouter.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            B_Ajouter.Location = new Point(64, 22);
            B_Ajouter.Name = "B_Ajouter";
            B_Ajouter.Size = new Size(75, 23);
            B_Ajouter.TabIndex = 39;
            B_Ajouter.Text = "AJOUTER";
            B_Ajouter.UseVisualStyleBackColor = true;
            B_Ajouter.Click += B_Ajouter_Click;
            // 
            // F_AjoutLivre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 579);
            Controls.Add(GB_Stock);
            Controls.Add(CB_TypeLivre);
            Controls.Add(CLB_Editeur);
            Controls.Add(CLB_Auteur);
            Controls.Add(CLB_Genre);
            Controls.Add(B_AjouterEditeur);
            Controls.Add(label1);
            Controls.Add(B_AjouterAuteur);
            Controls.Add(L_Auteur);
            Controls.Add(B_AjouterGenre);
            Controls.Add(B_AjouterTypeLivre);
            Controls.Add(L_Genre);
            Controls.Add(L_TypeLivre);
            Controls.Add(L_DateSortie);
            Controls.Add(DTP_DateSortie);
            Controls.Add(TB_synopsys);
            Controls.Add(L_synopsys);
            Controls.Add(TB_Commentaire);
            Controls.Add(L_Commentaire);
            Controls.Add(NUD_Largeur);
            Controls.Add(L_Largeur);
            Controls.Add(NUD_Hauteur);
            Controls.Add(L_Hauteur);
            Controls.Add(NUD_PrixInitial);
            Controls.Add(L_Prix);
            Controls.Add(NUD_Poid);
            Controls.Add(L_Poid);
            Controls.Add(NUD_NombrePages);
            Controls.Add(L_NombrePages);
            Controls.Add(TB_Titre);
            Controls.Add(L_Titre);
            Controls.Add(B_Valider);
            Controls.Add(TB_ISBN);
            Controls.Add(L_ISBN);
            Name = "F_AjoutLivre";
            Text = "Ajouter un livre";
            ((System.ComponentModel.ISupportInitialize)NUD_NombrePages).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Poid).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_PrixInitial).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Hauteur).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Largeur).EndInit();
            GB_Stock.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label L_ISBN;
        private Button B_Valider;
        private TextBox TB_ISBN;
        private TextBox TB_Titre;
        private Label L_Titre;
        private Label L_NombrePages;
        private NumericUpDown NUD_NombrePages;
        private NumericUpDown NUD_Poid;
        private Label L_Poid;
        private NumericUpDown NUD_PrixInitial;
        private Label L_Prix;
        private NumericUpDown NUD_Hauteur;
        private Label L_Hauteur;
        private Label L_Largeur;
        private NumericUpDown NUD_Largeur;
        private TextBox TB_Commentaire;
        private Label L_Commentaire;
        private TextBox TB_synopsys;
        private Label L_synopsys;
        private DateTimePicker DTP_DateSortie;
        private Label L_DateSortie;
        private Label L_TypeLivre;
        private Label L_Genre;
        private Button B_AjouterTypeLivre;
        private Button B_AjouterGenre;
        private Label L_Auteur;
        private Button B_AjouterAuteur;
        private Button B_AjouterEditeur;
        private Label label1;
        private CheckedListBox CLB_Genre;
        private CheckedListBox CLB_Auteur;
        private CheckedListBox CLB_Editeur;
        private ComboBox CB_TypeLivre;
        private Button B_reduire;
        private GroupBox GB_Stock;
        private Button B_Ajouter;
    }
}