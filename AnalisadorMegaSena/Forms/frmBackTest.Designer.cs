namespace AnalisadorMegaSena.Forms
{
    partial class frmBackTest
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
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation2 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation3 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation4 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation5 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation6 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackTest));
            this.btnMinimize = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblF = new System.Windows.Forms.Label();
            this.chtResultados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnMinimize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnMinimize.Controls.Add(this.button1);
            this.btnMinimize.Controls.Add(this.btnFechar);
            this.btnMinimize.Controls.Add(this.lblF);
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMinimize.Location = new System.Drawing.Point(0, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(1271, 45);
            this.btnMinimize.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AutoSize = true;
            this.btnFechar.BackColor = System.Drawing.Color.Red;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFechar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(1237, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(34, 31);
            this.btnFechar.TabIndex = 48;
            this.btnFechar.Text = "X";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // lblF
            // 
            this.lblF.AutoSize = true;
            this.lblF.BackColor = System.Drawing.Color.Transparent;
            this.lblF.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF.ForeColor = System.Drawing.Color.White;
            this.lblF.Location = new System.Drawing.Point(588, 9);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(90, 22);
            this.lblF.TabIndex = 1;
            this.lblF.Text = "FILTRAR";
            // 
            // chtResultados
            // 
            textAnnotation1.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textAnnotation1.ForeColor = System.Drawing.Color.White;
            textAnnotation1.Name = "Resultado";
            textAnnotation1.Text = "Resultados";
            textAnnotation1.X = 6D;
            textAnnotation1.Y = 30D;
            textAnnotation2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textAnnotation2.ForeColor = System.Drawing.Color.White;
            textAnnotation2.Name = "Sena";
            textAnnotation2.Text = "Sena acertos:";
            textAnnotation2.X = 6D;
            textAnnotation2.Y = 37D;
            textAnnotation3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            textAnnotation3.ForeColor = System.Drawing.Color.White;
            textAnnotation3.Name = "Quina";
            textAnnotation3.Text = "Quina acertos:";
            textAnnotation3.X = 6D;
            textAnnotation3.Y = 42D;
            textAnnotation4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            textAnnotation4.ForeColor = System.Drawing.Color.White;
            textAnnotation4.Name = "Quadra";
            textAnnotation4.Text = "Quadra acertos:";
            textAnnotation4.X = 6D;
            textAnnotation4.Y = 47D;
            textAnnotation5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            textAnnotation5.ForeColor = System.Drawing.Color.White;
            textAnnotation5.Name = "abordaP";
            textAnnotation5.Text = "Jogos  que a população ";
            textAnnotation5.X = 6D;
            textAnnotation5.Y = 52D;
            textAnnotation6.AllowAnchorMoving = true;
            textAnnotation6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            textAnnotation6.ForeColor = System.Drawing.Color.White;
            textAnnotation6.Name = "p2";
            textAnnotation6.Text = "restante abordou  a Mega:";
            textAnnotation6.X = 6D;
            textAnnotation6.Y = 55D;
            this.chtResultados.Annotations.Add(textAnnotation1);
            this.chtResultados.Annotations.Add(textAnnotation2);
            this.chtResultados.Annotations.Add(textAnnotation3);
            this.chtResultados.Annotations.Add(textAnnotation4);
            this.chtResultados.Annotations.Add(textAnnotation5);
            this.chtResultados.Annotations.Add(textAnnotation6);
            this.chtResultados.BackColor = System.Drawing.Color.Transparent;
            this.chtResultados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chtResultados.BorderlineColor = System.Drawing.Color.Transparent;
            this.chtResultados.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chtResultados.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.BorderColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.White;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "lend";
            legend1.Position.Auto = false;
            legend1.Position.Height = 29.45545F;
            legend1.Position.Width = 13.64205F;
            legend1.Position.X = 78.35795F;
            legend1.Position.Y = 35.27228F;
            legend1.Title = "Anotações";
            legend1.TitleFont = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.TitleForeColor = System.Drawing.Color.White;
            this.chtResultados.Legends.Add(legend1);
            this.chtResultados.Location = new System.Drawing.Point(0, 47);
            this.chtResultados.Name = "chtResultados";
            series1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            series1.BackSecondaryColor = System.Drawing.Color.White;
            series1.BorderColor = System.Drawing.Color.White;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Color = System.Drawing.Color.Transparent;
            series1.Legend = "lend";
            series1.Name = "SQuadra";
            dataPoint1.BackImageTransparentColor = System.Drawing.Color.White;
            dataPoint1.BackSecondaryColor = System.Drawing.Color.White;
            dataPoint1.BorderColor = System.Drawing.Color.Transparent;
            dataPoint1.Color = System.Drawing.Color.Lime;
            dataPoint1.Font = new System.Drawing.Font("Dubai", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataPoint1.Label = "";
            dataPoint1.LegendText = "Sena";
            dataPoint1.MarkerColor = System.Drawing.Color.White;
            dataPoint2.BorderColor = System.Drawing.Color.Transparent;
            dataPoint2.Color = System.Drawing.Color.Yellow;
            dataPoint2.Font = new System.Drawing.Font("Dubai", 15.75F, System.Drawing.FontStyle.Bold);
            dataPoint2.LegendText = "Quina";
            dataPoint3.BorderColor = System.Drawing.Color.Transparent;
            dataPoint3.Color = System.Drawing.Color.Red;
            dataPoint3.Font = new System.Drawing.Font("Dubai", 15.75F, System.Drawing.FontStyle.Bold);
            dataPoint3.LegendText = "Quadra";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            this.chtResultados.Series.Add(series1);
            this.chtResultados.Size = new System.Drawing.Size(1273, 585);
            this.chtResultados.TabIndex = 2;
            // 
            // frmBackTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AnalisadorMegaSena.Properties.Resources.BackGraubd;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1271, 634);
            this.Controls.Add(this.chtResultados);
            this.Controls.Add(this.btnMinimize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBackTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BACK-TEST";
            this.VisibleChanged += new System.EventHandler(this.frmBackTest_VisibleChanged);
            this.btnMinimize.ResumeLayout(false);
            this.btnMinimize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel btnMinimize;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblF;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtResultados;
        private System.Windows.Forms.Button button1;
    }
}