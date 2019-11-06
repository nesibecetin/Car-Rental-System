namespace Soa_Form_RestApi
{
    partial class Giris
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
            this.btnGiris = new System.Windows.Forms.Button();
            this.lblSifre = new System.Windows.Forms.Label();
            this.lblEMaill = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGiris
            // 
            this.btnGiris.Location = new System.Drawing.Point(214, 255);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(105, 36);
            this.btnGiris.TabIndex = 22;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = true;
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.BackColor = System.Drawing.Color.Transparent;
            this.lblSifre.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifre.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSifre.Location = new System.Drawing.Point(133, 206);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(47, 24);
            this.lblSifre.TabIndex = 21;
            this.lblSifre.Text = "Şifre";
            // 
            // lblEMaill
            // 
            this.lblEMaill.AutoSize = true;
            this.lblEMaill.BackColor = System.Drawing.Color.Transparent;
            this.lblEMaill.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEMaill.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEMaill.Location = new System.Drawing.Point(133, 162);
            this.lblEMaill.Name = "lblEMaill";
            this.lblEMaill.Size = new System.Drawing.Size(62, 24);
            this.lblEMaill.TabIndex = 20;
            this.lblEMaill.Text = "E Mail";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(214, 204);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(142, 22);
            this.txtSifre.TabIndex = 19;
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(214, 162);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(142, 22);
            this.txtEMail.TabIndex = 18;
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Soa_Form_RestApi.Properties.Resources.arka_plan_11;
            this.ClientSize = new System.Drawing.Size(501, 450);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblEMaill);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtEMail);
            this.Name = "Giris";
            this.Text = "Giris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Label lblEMaill;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtEMail;
    }
}