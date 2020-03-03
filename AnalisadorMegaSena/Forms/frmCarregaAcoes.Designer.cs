namespace AnalisadorMegaSena.Forms
{
    partial class frmCarregaAcoes
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
            this.lblAcoesCarrega = new System.Windows.Forms.Label();
            this.pgbCarregaAcoes = new System.Windows.Forms.ProgressBar();
            this.bwSecund = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblAcoesCarrega
            // 
            this.lblAcoesCarrega.AutoSize = true;
            this.lblAcoesCarrega.BackColor = System.Drawing.Color.Transparent;
            this.lblAcoesCarrega.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblAcoesCarrega.ForeColor = System.Drawing.Color.White;
            this.lblAcoesCarrega.Location = new System.Drawing.Point(120, 119);
            this.lblAcoesCarrega.Name = "lblAcoesCarrega";
            this.lblAcoesCarrega.Size = new System.Drawing.Size(332, 29);
            this.lblAcoesCarrega.TabIndex = 1;
            this.lblAcoesCarrega.Text = "CARREGANDO AGUARDE...";
            // 
            // pgbCarregaAcoes
            // 
            this.pgbCarregaAcoes.BackColor = System.Drawing.Color.White;
            this.pgbCarregaAcoes.Location = new System.Drawing.Point(74, 168);
            this.pgbCarregaAcoes.MarqueeAnimationSpeed = 20;
            this.pgbCarregaAcoes.Name = "pgbCarregaAcoes";
            this.pgbCarregaAcoes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pgbCarregaAcoes.Size = new System.Drawing.Size(430, 27);
            this.pgbCarregaAcoes.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbCarregaAcoes.TabIndex = 0;
            // 
            // bwSecund
            // 
            this.bwSecund.WorkerReportsProgress = true;
            this.bwSecund.WorkerSupportsCancellation = true;
            this.bwSecund.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bwSecund.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmCarregaAcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::AnalisadorMegaSena.Properties.Resources.BackGraubd;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(605, 347);
            this.ControlBox = false;
            this.Controls.Add(this.lblAcoesCarrega);
            this.Controls.Add(this.pgbCarregaAcoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCarregaAcoes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCarregaAcoes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAcoesCarrega;
        private System.Windows.Forms.ProgressBar pgbCarregaAcoes;
        private System.ComponentModel.BackgroundWorker bwSecund;
    }
}