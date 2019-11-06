namespace Soa_Form
{
    partial class Giriş
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
            this.btnGiris.Location = new System.Drawing.Point(184, 220);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(105, 36);
            this.btnGiris.TabIndex = 17;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.BackColor = System.Drawing.Color.Transparent;
            this.lblSifre.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifre.Location = new System.Drawing.Point(103, 171);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(47, 24);
            this.lblSifre.TabIndex = 16;
            this.lblSifre.Text = "Şifre";
            // 
            // lblEMaill
            // 
            this.lblEMaill.AutoSize = true;
            this.lblEMaill.BackColor = System.Drawing.Color.Transparent;
            this.lblEMaill.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEMaill.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEMaill.Location = new System.Drawing.Point(103, 127);
            this.lblEMaill.Name = "lblEMaill";
            this.lblEMaill.Size = new System.Drawing.Size(62, 24);
            this.lblEMaill.TabIndex = 15;
            this.lblEMaill.Text = "E Mail";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(184, 169);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(142, 22);
            this.txtSifre.TabIndex = 14;
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(184, 127);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(142, 22);
            this.txtEMail.TabIndex = 13;
            // 
            // Giriş
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Soa_Form.Properties.Resources.arka_plan_11;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(455, 428);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblEMaill);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtEMail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Giriş";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.Load += new System.EventHandler(this.Giriş_Load);
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