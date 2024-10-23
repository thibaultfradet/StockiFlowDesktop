namespace StockiFlowDesktop.Pages
{
    partial class F_AjoutMulti
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
            TB_libelle = new TextBox();
            L_libelle = new Label();
            SuspendLayout();
            // 
            // L_titre
            // 
            L_titre.AutoSize = true;
            L_titre.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            L_titre.Location = new Point(86, 10);
            L_titre.Name = "L_titre";
            L_titre.Size = new Size(137, 32);
            L_titre.TabIndex = 3;
            L_titre.Text = "Ajouter un";
            // 
            // B_valider
            // 
            B_valider.Location = new Point(133, 182);
            B_valider.Name = "B_valider";
            B_valider.Size = new Size(116, 30);
            B_valider.TabIndex = 4;
            B_valider.Text = "Valider";
            B_valider.UseVisualStyleBackColor = true;
            B_valider.Click += B_valider_Click;
            // 
            // TB_libelle
            // 
            TB_libelle.Location = new Point(86, 62);
            TB_libelle.Name = "TB_libelle";
            TB_libelle.Size = new Size(270, 23);
            TB_libelle.TabIndex = 5;
            // 
            // L_libelle
            // 
            L_libelle.AutoSize = true;
            L_libelle.Location = new Point(12, 65);
            L_libelle.Name = "L_libelle";
            L_libelle.Size = new Size(47, 15);
            L_libelle.TabIndex = 7;
            L_libelle.Text = "Libelle :";
            // 
            // F_AjoutMulti
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 224);
            Controls.Add(L_libelle);
            Controls.Add(TB_libelle);
            Controls.Add(B_valider);
            Controls.Add(L_titre);
            Name = "F_AjoutMulti";
            Text = "F_AjoutMulti";
            Load += F_AjoutMulti_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label L_titre;
        private Button B_valider;
        private TextBox TB_libelle;
        private Label L_libelle;
    }
}