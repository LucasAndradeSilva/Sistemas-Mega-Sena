namespace AnalisadorMegaSena.Forms
{
    partial class Analise
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvJogos = new System.Windows.Forms.DataGridView();
            this.Colu1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colu2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtQtdJogos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnEstatistica = new System.Windows.Forms.Button();
            this.pnlContemSubAna = new System.Windows.Forms.Panel();
            this.CtlSubAnalise = new AnalisadorMegaSena.ControlsView.SubAnalise();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogos)).BeginInit();
            this.pnlContemSubAna.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvJogos
            // 
            this.dgvJogos.AllowUserToDeleteRows = false;
            this.dgvJogos.AllowUserToResizeColumns = false;
            this.dgvJogos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvJogos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvJogos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJogos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.dgvJogos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvJogos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJogos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvJogos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Colu1,
            this.Colu2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJogos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvJogos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvJogos.Location = new System.Drawing.Point(237, 185);
            this.dgvJogos.MultiSelect = false;
            this.dgvJogos.Name = "dgvJogos";
            this.dgvJogos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJogos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvJogos.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvJogos.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvJogos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJogos.Size = new System.Drawing.Size(334, 293);
            this.dgvJogos.StandardTab = true;
            this.dgvJogos.TabIndex = 2;
            // 
            // Colu1
            // 
            this.Colu1.HeaderText = "Número Cuncurso";
            this.Colu1.Name = "Colu1";
            // 
            // Colu2
            // 
            this.Colu2.HeaderText = "Dezenas";
            this.Colu2.Name = "Colu2";
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIniciar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.Color.Transparent;
            this.btnIniciar.Image = global::AnalisadorMegaSena.Properties.Resources.ico_Ana;
            this.btnIniciar.Location = new System.Drawing.Point(697, 263);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(115, 122);
            this.btnIniciar.TabIndex = 3;
            this.btnIniciar.Text = "Analisar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtQtdJogos
            // 
            this.txtQtdJogos.BackColor = System.Drawing.Color.White;
            this.txtQtdJogos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtdJogos.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQtdJogos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtdJogos.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.txtQtdJogos.Location = new System.Drawing.Point(957, 200);
            this.txtQtdJogos.Multiline = true;
            this.txtQtdJogos.Name = "txtQtdJogos";
            this.txtQtdJogos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtQtdJogos.Size = new System.Drawing.Size(77, 27);
            this.txtQtdJogos.TabIndex = 4;
            this.txtQtdJogos.Text = "12";
            this.txtQtdJogos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 48F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(516, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 75);
            this.label1.TabIndex = 5;
            this.label1.Text = "Análise";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(750, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Listar Quantos Jogos?";
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.ForeColor = System.Drawing.Color.Transparent;
            this.btnListar.Image = global::AnalisadorMegaSena.Properties.Resources.ico_List;
            this.btnListar.Location = new System.Drawing.Point(969, 263);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(119, 122);
            this.btnListar.TabIndex = 7;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnEstatistica
            // 
            this.btnEstatistica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEstatistica.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEstatistica.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstatistica.ForeColor = System.Drawing.Color.Transparent;
            this.btnEstatistica.Image = global::AnalisadorMegaSena.Properties.Resources.ico_Est;
            this.btnEstatistica.Location = new System.Drawing.Point(834, 263);
            this.btnEstatistica.Name = "btnEstatistica";
            this.btnEstatistica.Size = new System.Drawing.Size(115, 122);
            this.btnEstatistica.TabIndex = 9;
            this.btnEstatistica.Text = "Estatistica";
            this.btnEstatistica.UseVisualStyleBackColor = false;
            this.btnEstatistica.Click += new System.EventHandler(this.btnEstatistica_Click);
            // 
            // pnlContemSubAna
            // 
            this.pnlContemSubAna.AutoScroll = true;
            this.pnlContemSubAna.Controls.Add(this.CtlSubAnalise);
            this.pnlContemSubAna.Location = new System.Drawing.Point(3, 3);
            this.pnlContemSubAna.Name = "pnlContemSubAna";
            this.pnlContemSubAna.Size = new System.Drawing.Size(1203, 576);
            this.pnlContemSubAna.TabIndex = 10;
            this.pnlContemSubAna.Visible = false;
            // 
            // CtlSubAnalise
            // 
            this.CtlSubAnalise.AutoScroll = true;
            this.CtlSubAnalise.AutoSize = true;
            this.CtlSubAnalise.BackColor = System.Drawing.Color.Transparent;
            this.CtlSubAnalise.Location = new System.Drawing.Point(3, 12);
            this.CtlSubAnalise.Name = "CtlSubAnalise";
            this.CtlSubAnalise.Size = new System.Drawing.Size(1173, 905);
            this.CtlSubAnalise.TabIndex = 8;
            this.CtlSubAnalise.Visible = false;
            this.CtlSubAnalise.VisibleChanged += new System.EventHandler(this.CtlSubAnalise_VisibleChanged);
            // 
            // Analise
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.pnlContemSubAna);
            this.Controls.Add(this.btnEstatistica);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQtdJogos);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.dgvJogos);
            this.Name = "Analise";
            this.Size = new System.Drawing.Size(1223, 582);
            this.VisibleChanged += new System.EventHandler(this.Analise_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogos)).EndInit();
            this.pnlContemSubAna.ResumeLayout(false);
            this.pnlContemSubAna.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJogos;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox txtQtdJogos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colu1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colu2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnListar;
        private ControlsView.SubAnalise CtlSubAnalise;
        private System.Windows.Forms.Button btnEstatistica;
        public System.Windows.Forms.Panel pnlContemSubAna;
    }
}