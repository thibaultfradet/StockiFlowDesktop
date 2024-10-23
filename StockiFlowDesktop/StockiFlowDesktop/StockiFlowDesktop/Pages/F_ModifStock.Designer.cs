namespace StockiFlowDesktop.Pages
{
    partial class F_ModifStock
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
            B_Valider = new Button();
            L_titre = new Label();
            NUD_Quantite = new NumericUpDown();
            TB_Raison = new TextBox();
            DTP_Date = new DateTimePicker();
            L_Quantite = new Label();
            L_Raison = new Label();
            L_Date = new Label();
            L_AncienStock = new Label();
            ((System.ComponentModel.ISupportInitialize)NUD_Quantite).BeginInit();
            SuspendLayout();
            // 
            // B_Valider
            // 
            B_Valider.Location = new Point(178, 268);
            B_Valider.Name = "B_Valider";
            B_Valider.Size = new Size(75, 23);
            B_Valider.TabIndex = 0;
            B_Valider.Text = "Valider";
            B_Valider.UseVisualStyleBackColor = true;
            B_Valider.Click += B_Valider_Click;
            // 
            // L_titre
            // 
            L_titre.AutoSize = true;
            L_titre.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            L_titre.Location = new Point(112, 9);
            L_titre.Name = "L_titre";
            L_titre.Size = new Size(237, 32);
            L_titre.TabIndex = 1;
            L_titre.Text = "Augmenter le stock";
            // 
            // NUD_Quantite
            // 
            NUD_Quantite.Location = new Point(163, 80);
            NUD_Quantite.Name = "NUD_Quantite";
            NUD_Quantite.Size = new Size(74, 23);
            NUD_Quantite.TabIndex = 2;
            // 
            // TB_Raison
            // 
            TB_Raison.Location = new Point(163, 124);
            TB_Raison.MaxLength = 255;
            TB_Raison.Multiline = true;
            TB_Raison.Name = "TB_Raison";
            TB_Raison.Size = new Size(259, 68);
            TB_Raison.TabIndex = 3;
            // 
            // DTP_Date
            // 
            DTP_Date.Location = new Point(163, 213);
            DTP_Date.Name = "DTP_Date";
            DTP_Date.Size = new Size(200, 23);
            DTP_Date.TabIndex = 4;
            // 
            // L_Quantite
            // 
            L_Quantite.AutoSize = true;
            L_Quantite.Location = new Point(48, 83);
            L_Quantite.Name = "L_Quantite";
            L_Quantite.Size = new Size(112, 15);
            L_Quantite.TabIndex = 5;
            L_Quantite.Text = "Quantité à rajouter :";
            // 
            // L_Raison
            // 
            L_Raison.AutoSize = true;
            L_Raison.Location = new Point(4, 148);
            L_Raison.Name = "L_Raison";
            L_Raison.Size = new Size(153, 15);
            L_Raison.TabIndex = 6;
            L_Raison.Text = "Raison de l'entrée en stock :";
            // 
            // L_Date
            // 
            L_Date.AutoSize = true;
            L_Date.Location = new Point(26, 216);
            L_Date.Name = "L_Date";
            L_Date.Size = new Size(135, 15);
            L_Date.TabIndex = 7;
            L_Date.Text = "Date action sur le stock :";
            // 
            // L_AncienStock
            // 
            L_AncienStock.AutoSize = true;
            L_AncienStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            L_AncienStock.Location = new Point(112, 51);
            L_AncienStock.Name = "L_AncienStock";
            L_AncienStock.Size = new Size(127, 15);
            L_AncienStock.TabIndex = 8;
            L_AncienStock.Text = "Stock actuel du livre :";
            // 
            // F_ModifStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 305);
            Controls.Add(L_AncienStock);
            Controls.Add(L_Date);
            Controls.Add(L_Raison);
            Controls.Add(L_Quantite);
            Controls.Add(DTP_Date);
            Controls.Add(TB_Raison);
            Controls.Add(NUD_Quantite);
            Controls.Add(L_titre);
            Controls.Add(B_Valider);
            Name = "F_ModifStock";
            Text = "F_ModifStock";
            ((System.ComponentModel.ISupportInitialize)NUD_Quantite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button B_Valider;
        private Label L_titre;
        private NumericUpDown NUD_Quantite;
        private TextBox TB_Raison;
        private DateTimePicker DTP_Date;
        private Label L_Quantite;
        private Label L_Raison;
        private Label L_Date;
        private Label L_AncienStock;
    }
}