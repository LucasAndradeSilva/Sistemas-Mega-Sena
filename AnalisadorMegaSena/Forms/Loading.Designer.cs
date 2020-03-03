namespace AnalisadorMegaSena
{
    partial class Loading
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.loadingBar = new System.Windows.Forms.ProgressBar();
            this.lblCarregando = new System.Windows.Forms.Label();
            this.lblPorcento = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // loadingBar
            // 
            this.loadingBar.BackColor = System.Drawing.SystemColors.Control;
            this.loadingBar.Location = new System.Drawing.Point(90, 245);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(772, 31);
            this.loadingBar.TabIndex = 2;
            // 
            // lblCarregando
            // 
            this.lblCarregando.AutoSize = true;
            this.lblCarregando.BackColor = System.Drawing.Color.Transparent;
            this.lblCarregando.Font = new System.Drawing.Font("Arial Rounded MT Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarregando.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCarregando.Location = new System.Drawing.Point(158, 131);
            this.lblCarregando.Name = "lblCarregando";
            this.lblCarregando.Size = new System.Drawing.Size(407, 75);
            this.lblCarregando.TabIndex = 3;
            this.lblCarregando.Text = "Carregando";
            // 
            // lblPorcento
            // 
            this.lblPorcento.AutoSize = true;
            this.lblPorcento.BackColor = System.Drawing.Color.Transparent;
            this.lblPorcento.Font = new System.Drawing.Font("Arial Rounded MT Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcento.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPorcento.Location = new System.Drawing.Point(599, 134);
            this.lblPorcento.Name = "lblPorcento";
            this.lblPorcento.Size = new System.Drawing.Size(125, 75);
            this.lblPorcento.TabIndex = 4;
            this.lblPorcento.Text = "0%";
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::AnalisadorMegaSena.Properties.Resources.load1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(916, 399);
            this.ControlBox = false;
            this.Controls.Add(this.lblPorcento);
            this.Controls.Add(this.lblCarregando);
            this.Controls.Add(this.loadingBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.Load += new System.EventHandler(this.Loading_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar loadingBar;
        private System.Windows.Forms.Label lblCarregando;
        private System.Windows.Forms.Label lblPorcento;
    }
}

