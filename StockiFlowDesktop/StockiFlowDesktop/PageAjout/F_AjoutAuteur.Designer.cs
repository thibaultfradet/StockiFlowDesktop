namespace StockiFlowDesktop.PageAjout
{
    partial class F_AjoutAuteur
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
            L_titre = new Label();
            B_valider = new Button();
            TB_NomAuteur = new TextBox();
            TB_PrenomAuteur = new TextBox();
            L_NomAuteur = new Label();
            L_PrenomAuteur = new Label();
            SuspendLayout();
            // 
            // L_titre
            // 
            L_titre.AutoSize = true;
            L_titre.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            L_titre.Location = new Point(79, 9);
            L_titre.Name = "L_titre";
            L_titre.Size = new Size(219, 32);
            L_titre.TabIndex = 0;
            L_titre.Text = "Ajouter un auteur";
            // 
            // B_valider
            // 
            B_valider.Location = new Point(133, 182);
            B_valider.Name = "B_valider";
            B_valider.Size = new Size(116, 30);
            B_valider.TabIndex = 2;
            B_valider.Text = "Valider";
            B_valider.UseVisualStyleBackColor = true;
            B_valider.Click += B_valider_Click;
            // 
            // TB_NomAuteur
            // 
            TB_NomAuteur.Location = new Point(132, 65);
            TB_NomAuteur.Name = "TB_NomAuteur";
            TB_NomAuteur.Size = new Size(219, 23);
            TB_NomAuteur.TabIndex = 3;
            // 
            // TB_PrenomAuteur
            // 
            TB_PrenomAuteur.Location = new Point(132, 112);
            TB_PrenomAuteur.Name = "TB_PrenomAuteur";
            TB_PrenomAuteur.Size = new Size(219, 23);
            TB_PrenomAuteur.TabIndex = 4;
            // 
            // L_NomAuteur
            // 
            L_NomAuteur.AutoSize = true;
            L_NomAuteur.Location = new Point(27, 68);
            L_NomAuteur.Name = "L_NomAuteur";
            L_NomAuteur.Size = new Size(99, 15);
            L_NomAuteur.TabIndex = 5;
            L_NomAuteur.Text = "Nom de l'auteur :";
            // 
            // L_PrenomAuteur
            // 
            L_PrenomAuteur.AutoSize = true;
            L_PrenomAuteur.Location = new Point(12, 115);
            L_PrenomAuteur.Name = "L_PrenomAuteur";
            L_PrenomAuteur.Size = new Size(114, 15);
            L_PrenomAuteur.TabIndex = 6;
            L_PrenomAuteur.Text = "Prenom de l'auteur :";
            // 
            // F_AjoutAuteur
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 224);
            Controls.Add(L_PrenomAuteur);
            Controls.Add(L_NomAuteur);
            Controls.Add(TB_PrenomAuteur);
            Controls.Add(TB_NomAuteur);
            Controls.Add(B_valider);
            Controls.Add(L_titre);
            Name = "F_AjoutAuteur";
            Text = "Ajouter un auteur";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label L_titre;
        private Button B_valider;
        private TextBox TB_NomAuteur;
        private TextBox TB_PrenomAuteur;
        private Label L_NomAuteur;
        private Label L_PrenomAuteur;
    }
}