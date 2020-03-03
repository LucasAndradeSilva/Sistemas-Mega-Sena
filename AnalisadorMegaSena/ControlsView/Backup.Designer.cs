namespace AnalisadorMegaSena.ControlsView
{
    partial class Backup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlEmail = new System.Windows.Forms.Panel();
            this.btnProntoExportar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParaEmail = new System.Windows.Forms.TextBox();
            this.btnClosePnl = new System.Windows.Forms.Button();
            this.btnExpBkp = new System.Windows.Forms.Button();
            this.btnRestaurarBkp = new System.Windows.Forms.Button();
            this.lblLink = new System.Windows.Forms.Label();
            this.pnlEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(68, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Restaurar Backup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(755, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "Exportar Backup";
            // 
            // pnlEmail
            // 
            this.pnlEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlEmail.Controls.Add(this.btnProntoExportar);
            this.pnlEmail.Controls.Add(this.label4);
            this.pnlEmail.Controls.Add(this.label3);
            this.pnlEmail.Controls.Add(this.txtParaEmail);
            this.pnlEmail.Controls.Add(this.btnClosePnl);
            this.pnlEmail.Location = new System.Drawing.Point(321, 139);
            this.pnlEmail.Name = "pnlEmail";
            this.pnlEmail.Size = new System.Drawing.Size(476, 187);
            this.pnlEmail.TabIndex = 4;
            this.pnlEmail.Visible = false;
            // 
            // btnProntoExportar
            // 
            this.btnProntoExportar.AutoSize = true;
            this.btnProntoExportar.BackColor = System.Drawing.Color.Black;
            this.btnProntoExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProntoExportar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProntoExportar.ForeColor = System.Drawing.Color.White;
            this.btnProntoExportar.Location = new System.Drawing.Point(191, 131);
            this.btnProntoExportar.Name = "btnProntoExportar";
            this.btnProntoExportar.Size = new System.Drawing.Size(103, 38);
            this.btnProntoExportar.TabIndex = 27;
            this.btnProntoExportar.Text = "Pronto";
            this.btnProntoExportar.UseVisualStyleBackColor = false;
            this.btnProntoExportar.Click += new System.EventHandler(this.btnProntoExportar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Digite seu email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(109, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Expotar para o Email";
            // 
            // txtParaEmail
            // 
            this.txtParaEmail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParaEmail.Location = new System.Drawing.Point(34, 89);
            this.txtParaEmail.Multiline = true;
            this.txtParaEmail.Name = "txtParaEmail";
            this.txtParaEmail.Size = new System.Drawing.Size(408, 25);
            this.txtParaEmail.TabIndex = 1;
            // 
            // btnClosePnl
            // 
            this.btnClosePnl.BackColor = System.Drawing.Color.Red;
            this.btnClosePnl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClosePnl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosePnl.ForeColor = System.Drawing.Color.White;
            this.btnClosePnl.Location = new System.Drawing.Point(437, 0);
            this.btnClosePnl.Name = "btnClosePnl";
            this.btnClosePnl.Size = new System.Drawing.Size(39, 26);
            this.btnClosePnl.TabIndex = 0;
            this.btnClosePnl.Text = "X";
            this.btnClosePnl.UseVisualStyleBackColor = false;
            this.btnClosePnl.Click += new System.EventHandler(this.btnClosePnl_Click);
            // 
            // btnExpBkp
            // 
            this.btnExpBkp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExpBkp.BackgroundImage = global::AnalisadorMegaSena.Properties.Resources.ico_ExpBkp1;
            this.btnExpBkp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExpBkp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpBkp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpBkp.Location = new System.Drawing.Point(801, 133);
            this.btnExpBkp.Name = "btnExpBkp";
            this.btnExpBkp.Size = new System.Drawing.Size(216, 198);
            this.btnExpBkp.TabIndex = 3;
            this.btnExpBkp.UseVisualStyleBackColor = false;
            this.btnExpBkp.Click += new System.EventHandler(this.btnExpBkp_Click);
            // 
            // btnRestaurarBkp
            // 
            this.btnRestaurarBkp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRestaurarBkp.BackgroundImage = global::AnalisadorMegaSena.Properties.Resources.ico_RestBkp1;
            this.btnRestaurarBkp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRestaurarBkp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurarBkp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestaurarBkp.Location = new System.Drawing.Point(100, 133);
            this.btnRestaurarBkp.Name = "btnRestaurarBkp";
            this.btnRestaurarBkp.Size = new System.Drawing.Size(220, 198);
            this.btnRestaurarBkp.TabIndex = 2;
            this.btnRestaurarBkp.UseVisualStyleBackColor = false;
            this.btnRestaurarBkp.Click += new System.EventHandler(this.btnRestaurarBkp_Click);
            this.btnRestaurarBkp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRestaurarBkp_MouseMove);
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLink.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLink.ForeColor = System.Drawing.Color.White;
            this.lblLink.Location = new System.Drawing.Point(938, 411);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(163, 16);
            this.lblLink.TabIndex = 5;
            this.lblLink.Text = "Resetar Banco de Dados";
            this.lblLink.Click += new System.EventHandler(this.lblLink_Click);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.pnlEmail);
            this.Controls.Add(this.btnExpBkp);
            this.Controls.Add(this.btnRestaurarBkp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Backup";
            this.Size = new System.Drawing.Size(1119, 436);
            this.pnlEmail.ResumeLayout(false);
            this.pnlEmail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRestaurarBkp;
        private System.Windows.Forms.Button btnExpBkp;
        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtParaEmail;
        private System.Windows.Forms.Button btnClosePnl;
        private System.Windows.Forms.Button btnProntoExportar;
        private System.Windows.Forms.Label lblLink;
    }
}
