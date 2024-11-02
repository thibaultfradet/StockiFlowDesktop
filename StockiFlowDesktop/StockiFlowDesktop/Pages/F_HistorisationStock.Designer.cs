namespace StockiFlowDesktop.Pages
{
    partial class F_HistorisationStock
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
            DGV_Historisation = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DGV_Historisation).BeginInit();
            SuspendLayout();
            // 
            // DGV_Historisation
            // 
            DGV_Historisation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Historisation.Location = new Point(0, 0);
            DGV_Historisation.Name = "DGV_Historisation";
            DGV_Historisation.Size = new Size(800, 450);
            DGV_Historisation.TabIndex = 0;
            // 
            // F_HistorisationStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DGV_Historisation);
            Name = "F_HistorisationStock";
            Text = "Historisation du stock";
            Load += F_HistorisationStock_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_Historisation).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGV_Historisation;
    }
}