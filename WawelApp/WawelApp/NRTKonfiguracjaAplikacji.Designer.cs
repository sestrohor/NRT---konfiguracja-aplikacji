namespace WawelApp
{
    partial class NRTKonfiguracjaAplikacji
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.Ltitle = new System.Windows.Forms.Label();
            this.Ldes1 = new System.Windows.Forms.Label();
            this.TpathInput = new System.Windows.Forms.TextBox();
            this.Bsave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Ltitle
            // 
            this.Ltitle.AutoSize = true;
            this.Ltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ltitle.Location = new System.Drawing.Point(160, 10);
            this.Ltitle.Name = "Ltitle";
            this.Ltitle.Size = new System.Drawing.Size(229, 24);
            this.Ltitle.TabIndex = 0;
            this.Ltitle.Text = "Konfiguracja aplikacji NRT";
            this.Ltitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // Ldes1
            // 
            this.Ldes1.AutoSize = true;
            this.Ldes1.Location = new System.Drawing.Point(184, 81);
            this.Ldes1.Name = "Ldes1";
            this.Ldes1.Size = new System.Drawing.Size(172, 13);
            this.Ldes1.TabIndex = 1;
            this.Ldes1.Text = "Ścieżka do pliku konfiguracyjnego:";
            // 
            // TpathInput
            // 
            this.TpathInput.Location = new System.Drawing.Point(187, 97);
            this.TpathInput.Name = "TpathInput";
            this.TpathInput.Size = new System.Drawing.Size(166, 20);
            this.TpathInput.TabIndex = 2;
            // 
            // Bsave
            // 
            this.Bsave.Location = new System.Drawing.Point(228, 123);
            this.Bsave.Name = "Bsave";
            this.Bsave.Size = new System.Drawing.Size(75, 23);
            this.Bsave.TabIndex = 3;
            this.Bsave.Text = "Konfiguruj";
            this.Bsave.UseVisualStyleBackColor = true;
            this.Bsave.Click += new System.EventHandler(this.Bsave_Click);
            // 
            // NRTKonfiguracjaAplikacji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 255);
            this.Controls.Add(this.Bsave);
            this.Controls.Add(this.TpathInput);
            this.Controls.Add(this.Ldes1);
            this.Controls.Add(this.Ltitle);
            this.Name = "NRTKonfiguracjaAplikacji";
            this.Text = "NRT - konfiguracja aplikacji";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Ltitle;
        private System.Windows.Forms.Label Ldes1;
        private System.Windows.Forms.TextBox TpathInput;
        private System.Windows.Forms.Button Bsave;
    }
}

