using System;
using System.Diagnostics;
using System.Windows.Forms;
using AnalisadorMegaSena.Data;
using AnalisadorMegaSena.Forms;
using ClosedXML.Excel;

namespace AnalisadorMegaSena.ControlsView
{
    public partial class SubAnalise : UserControl
    {
        public SubAnalise()
        {
            InitializeComponent();
        }

        //==================
        // === VARIAVEIS ===
        //==================
        int[,] Tabela = new int[10, 6]
        {
            { 01, 11, 21, 31, 41, 51}, //Coluna 0
            { 02, 12, 22, 32, 42, 52}, //Coluna 1
            { 03, 13, 23, 33, 43, 53}, //Coluna 2
            { 04, 14, 24, 34, 44, 54}, //Coluna 3
            { 05, 15, 25, 35, 45, 55}, //Coluna 4
            { 06, 16, 26, 36, 46, 56}, //Coluna 5
            { 07, 17, 27, 37, 47, 57}, //Coluna 6
            { 08, 18, 28, 38, 48, 58}, //Coluna 7
            { 09, 19, 29, 39, 49, 59}, //Coluna 8
            { 10, 20, 30, 40, 50, 60}, //Coluna 9
            
        };

        public static int NumJogos;
        public string L0 = "0", L1 = "0", L2 = "0", L3 = "0", L4 = "0", L5 = "0";
        bool[] Linhas = new bool[6];
        int[] CopyDezenasAtrasadas = new int[0];
        int[] CopyNumerosNoOut = new int[0];
        int[] CopyDezenasRepetidas = new int[0];
        int[] CopyDezenasSorteadas = new int[0];
        string[] CopyColunasNoOut = new string[0];
        string[] CopyLinhasNoOut = new string[0];
        string[] CopyDezenasPares = new string[0];
        string[] CopyDezenasImpares = new string[0];

        //Para o Filtro
        public static string LinhasUltimoJogo;
        public static string ColunasUltimoJogo;


        //=============================================
        // === FUNÇÃO QUE ABRE O PAINEL DO EXPORTAR ===
        //=============================================
        private void btnExel_Click(object sender, EventArgs e)
        {
            pnlNomeArq.Visible = true;    
        }

        //=============================
        // === FUNÇÃO CLICK FILTRAR ===
        //=============================
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnFiltrar_Click(sender, e);
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Banco_de_Dados db = new Banco_de_Dados();
            string Concurso = db.Buscar("").ToString();            
            SubAnaliseFiltorcs frmFiltrar = new SubAnaliseFiltorcs(CopyDezenasAtrasadas,CopyNumerosNoOut,CopyDezenasRepetidas,CopyColunasNoOut,CopyLinhasNoOut, Concurso , CopyDezenasSorteadas, CopyDezenasImpares, CopyDezenasPares);            
            frmFiltrar.Show();
        }

        //=======================================
        // === FUNÇÃO QUE EXPORTA PARA O EXEL ===
        //=======================================
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnExel_Click(sender, e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvAtrazados.Rows.Count > 0 && dgvRepetidas.Rows.Count > 0 && dgvPrincipal.Rows.Count > 0 && dgvNotOut.Rows.Count > 0 && dgvColumNaoSaiu.Rows.Count > 0 && txtNomeArquivo.Text != "")
            {                                
                var Exel = new XLWorkbook();
                var Planilha = Exel.Worksheets.Add("Principal");
                                
                //ADICIONA AS COLUNAS NO EXEL
                //dgvPrincipal
                for (int i = 1; i < dgvPrincipal.ColumnCount + 1; i++)
                {                                                       
                    Planilha.Cell(1, i).Value = dgvPrincipal.Columns[i - 1].HeaderText;
                    Planilha.Cell(1, i).Style.Font.SetBold();
                    Planilha.Cell(1, i).Style.Font.SetFontSize(14);
                    Planilha.Cell(1, i).Style.Fill.BackgroundColor = XLColor.GreenRyb;
                    Planilha.Cell(1, i).Style.Font.FontColor = XLColor.White;
                    Planilha.Cell(1, i).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    Planilha.Cell(1, i).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    Planilha.Cell(1, i).Style.Alignment.SetJustifyLastLine();
                }
                
                //dgvRepetidas
                int l = dgvPrincipal.ColumnCount + 2;                
                for (int i = 1; i < dgvRepetidas.ColumnCount + 1; i++)
                {                 
                    Planilha.Cell(1, l).Value = dgvRepetidas.Columns[i - 1].HeaderText;
                    Planilha.Cell(1, l).Style.Font.SetBold();
                    Planilha.Cell(1, l).Style.Font.SetFontSize(14);
                    Planilha.Cell(1, l).Style.Fill.BackgroundColor = XLColor.GreenRyb;
                    Planilha.Cell(1, l).Style.Font.SetFontColor(XLColor.White);
                    Planilha.Cell(1, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    Planilha.Cell(1, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;                    
                    l++;
                }


                //dgvNotOut
                l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + 3;
                for (int i = 1; i < dgvNotOut.ColumnCount + 1; i++)
                {
                    Planilha.Cell(1, l).Value = dgvNotOut.Columns[i - 1].HeaderText;
                    Planilha.Cell(1, l).Style.Font.SetBold();
                    Planilha.Cell(1, l).Style.Font.SetFontSize(14);
                    Planilha.Cell(1, l).Style.Fill.SetBackgroundColor(XLColor.GreenRyb);
                    Planilha.Cell(1, l).Style.Font.SetFontColor(XLColor.White);

                    l++;
                }

                //dgvColumNaoSaiu
                l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + 4;
                for (int i = 1; i < dgvColumNaoSaiu.ColumnCount + 1; i++)
                {
                    Planilha.Cell(1, l).Value = dgvColumNaoSaiu.Columns[i - 1].HeaderText;
                    Planilha.Cell(1, l).Style.Font.SetBold();
                    Planilha.Cell(1, l).Style.Font.SetFontSize(14);
                    Planilha.Cell(1, l).Style.Fill.SetBackgroundColor(XLColor.GreenRyb);
                    Planilha.Cell(1, l).Style.Font.SetFontColor(XLColor.White);

                    l++;
                }

                //dgvAtrazados
                l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + 5;
                for (int i = 1; i < dgvAtrazados.ColumnCount + 1; i++)
                {
                    Planilha.Cell(1, l).Value = dgvAtrazados.Columns[i - 1].HeaderText;
                    Planilha.Cell(1, l).Style.Font.SetBold();
                    Planilha.Cell(1, l).Style.Font.SetFontSize(14);
                    Planilha.Cell(1, l).Style.Fill.SetBackgroundColor(XLColor.GreenRyb);
                    Planilha.Cell(1, l).Style.Font.SetFontColor(XLColor.White);

                    l++;
                }

                //dgvImpares
                l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount  + dgvAtrazados.ColumnCount + 6;
                for (int i = 1; i < dgvImpares.ColumnCount + 1; i++)
                {
                    Planilha.Cell(1, l).Value = dgvImpares.Columns[i - 1].HeaderText;
                    Planilha.Cell(1, l).Style.Font.SetBold();
                    Planilha.Cell(1, l).Style.Font.SetFontSize(14);
                    Planilha.Cell(1, l).Style.Fill.SetBackgroundColor(XLColor.GreenRyb);                    
                    Planilha.Cell(1, l).Style.Font.SetFontColor(XLColor.White);

                    l++;
                }

                //dgvSairam
                l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + dgvAtrazados.ColumnCount + dgvImpares.ColumnCount + 7;
                for (int i = 1; i < dgvSairam.ColumnCount + 1; i++)
                {
                    Planilha.Cell(1, l).Value = dgvSairam.Columns[i - 1].HeaderText;
                    Planilha.Cell(1, l).Style.Font.SetBold();
                    Planilha.Cell(1, l).Style.Font.SetFontSize(14);
                    Planilha.Cell(1, l).Style.Fill.SetBackgroundColor(XLColor.GreenRyb);
                    Planilha.Cell(1, l).Style.Font.SetFontColor(XLColor.White);

                    l++;
                }

                //dgvColunasELinhas
                l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + dgvAtrazados.ColumnCount + dgvImpares.ColumnCount + dgvSairam.ColumnCount + 8;
                for (int i = 1; i < dgvColunasElinhas.ColumnCount + 1; i++)
                {
                    Planilha.Cell(1, l).Value = dgvColunasElinhas.Columns[i - 1].HeaderText;
                    Planilha.Cell(1, l).Style.Font.SetBold();
                    Planilha.Cell(1, l).Style.Font.SetFontSize(14);
                    Planilha.Cell(1, l).Style.Fill.SetBackgroundColor(XLColor.GreenRyb);
                    Planilha.Cell(1, l).Style.Font.SetFontColor(XLColor.White);

                    l++;
                }

                //dgvLinhasEColunas
                l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + dgvAtrazados.ColumnCount + dgvImpares.ColumnCount + dgvSairam.ColumnCount + dgvColunasElinhas.ColumnCount + 9;
                for (int i = 1; i < dgvLinhasEColunas.ColumnCount + 1; i++)
                {
                    Planilha.Cell(1, l).Value = dgvLinhasEColunas.Columns[i - 1].HeaderText;
                    Planilha.Cell(1, l).Style.Font.SetBold();
                    Planilha.Cell(1, l).Style.Font.SetFontSize(14);
                    Planilha.Cell(1, l).Style.Fill.SetBackgroundColor(XLColor.GreenRyb);
                    Planilha.Cell(1, l).Style.Font.SetFontColor(XLColor.White);

                    l++;
                }

                //dgvPrimos
                l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + dgvAtrazados.ColumnCount + dgvImpares.ColumnCount + dgvSairam.ColumnCount + dgvColunasElinhas.ColumnCount +dgvLinhasEColunas.ColumnCount+ 10;
                for (int i = 1; i < dgvNumPrimos.ColumnCount + 1; i++)
                {
                    Planilha.Cell(1, l).Value = dgvNumPrimos.Columns[i - 1].HeaderText;
                    Planilha.Cell(1, l).Style.Font.SetBold();
                    Planilha.Cell(1, l).Style.Font.SetFontSize(14);
                    Planilha.Cell(1, l).Style.Fill.BackgroundColor = XLColor.GreenRyb;
                    Planilha.Cell(1, l).Style.Font.FontColor = XLColor.White;
                    Planilha.Cell(1, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    Planilha.Cell(1, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    Planilha.Cell(1, l).Style.Alignment.SetJustifyLastLine();

                    l++;
                }

                //dgvFibonacci
                l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + dgvAtrazados.ColumnCount + dgvImpares.ColumnCount + dgvSairam.ColumnCount + dgvColunasElinhas.ColumnCount + dgvLinhasEColunas.ColumnCount +dgvNumPrimos.ColumnCount +11;
                for (int i = 1; i < dgvFibonacci.ColumnCount + 1; i++)
                {
                    Planilha.Cell(1, l).Value = dgvFibonacci.Columns[i - 1].HeaderText;
                    Planilha.Cell(1, l).Style.Font.SetBold();
                    Planilha.Cell(1, l).Style.Font.SetFontSize(14);
                    Planilha.Cell(1, l).Style.Fill.BackgroundColor = XLColor.GreenRyb;
                    Planilha.Cell(1, l).Style.Font.FontColor = XLColor.White;
                    Planilha.Cell(1, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    Planilha.Cell(1, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    Planilha.Cell(1, l).Style.Alignment.SetJustifyLastLine();
                
                    l++;
                }

                //PRENCHE AS CELULAR COM OS VALORES//
                bool colore = true;
                for (int i = 0; i < dgvPrincipal.RowCount - 1; i++)//Linha
                {                    
                    for (int j = 0; j < dgvPrincipal.ColumnCount; j++)//Coluna
                    {
                        Planilha.Cell(i + 2, j + 1).Value = dgvPrincipal.Rows[i].Cells[j].Value;
                        Planilha.Cell(i + 2, j + 1).Style.Font.SetFontSize(12);
                        Planilha.Cell(i + 2, j + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Planilha.Cell(i + 2, j + 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        Planilha.Cell(i + 2, j + 1).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, j + 1).Style.Border.InsideBorderColor = XLColor.Black;
                        Planilha.Cell(i + 2, j + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, j + 1).Style.Border.OutsideBorderColor = XLColor.Black;                        
                        if (colore) Planilha.Cell(i + 2, j + 1).Style.Fill.BackgroundColor = XLColor.TeaGreen;
                        else Planilha.Cell(i + 2, j + 1).Style.Fill.BackgroundColor = XLColor.White;
                    }
                    if (colore) colore = false;
                    else colore = true;
                }

                colore = true;
                //dgvRepetidas
                for (int i = 0; i < dgvRepetidas.RowCount - 1; i++)//Linha
                {
                    l = dgvPrincipal.ColumnCount + 2;
                    for (int j = 0; j < dgvRepetidas.ColumnCount; j++)//Coluna
                    {
                        Planilha.Cell(i + 2, l).Value = dgvRepetidas.Rows[i].Cells[j].Value;
                        Planilha.Cell(i + 2, l).Style.Font.SetFontSize(12);
                        Planilha.Cell(i + 2, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorderColor = XLColor.Black;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorderColor = XLColor.Black;
                        if (colore) Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.TeaGreen;
                        else Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.White;
                        l++;
                    }
                    if (colore) colore = false;
                    else colore = true;
                }

                colore = true;
                //dgvNotOut
                for (int i = 0; i < dgvNotOut.RowCount - 1; i++)//Linha
                {
                    l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + 3;
                    for (int j = 0; j < dgvNotOut.ColumnCount; j++)//Coluna
                    {
                        Planilha.Cell(i + 2, l).Value = dgvNotOut.Rows[i].Cells[j].Value;
                        Planilha.Cell(i + 2, l).Style.Font.SetFontSize(12);
                        Planilha.Cell(i + 2, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorderColor = XLColor.Black;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorderColor = XLColor.Black;
                        if (colore) Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.TeaGreen;
                        else Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.White;
                        l++;
                    }
                    if (colore) colore = false;
                    else colore = true;
                }

                colore = true;
                //dgvColumNaoSaiu
                for (int i = 0; i < dgvColumNaoSaiu.RowCount - 1; i++)//Linha
                {
                    l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + 4;
                    for (int j = 0; j < dgvColumNaoSaiu.ColumnCount; j++)//Coluna
                    {
                        Planilha.Cell(i + 2, l).Value = dgvColumNaoSaiu.Rows[i].Cells[j].Value;
                        Planilha.Cell(i + 2, l).Style.Font.SetFontSize(12);
                        Planilha.Cell(i + 2, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorderColor = XLColor.Black;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorderColor = XLColor.Black;
                        if (colore) Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.TeaGreen;
                        else Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.White;
                        l++;
                    }
                    if (colore) colore = false;
                    else colore = true;
                }

                colore = true;
                //dgvAtrazados
                for (int i = 0; i < dgvAtrazados.RowCount - 1; i++)//Linha
                {
                    l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + 5;
                    for (int j = 0; j < dgvAtrazados.ColumnCount; j++)//Coluna
                    {
                        Planilha.Cell(i + 2, l).Value = dgvAtrazados.Rows[i].Cells[j].Value;
                        Planilha.Cell(i + 2, l).Style.Font.SetFontSize(12);
                        Planilha.Cell(i + 2, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorderColor = XLColor.Black;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorderColor = XLColor.Black;
                        if (colore) Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.TeaGreen;
                        else Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.White;
                        l++;
                    }
                    if (colore) colore = false;
                    else colore = true;
                }

                colore = true;
                //dgvImpares
                for (int i = 0; i < dgvImpares.RowCount -1; i++)//Linha
                {
                    l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + dgvAtrazados.ColumnCount + 6;
                    for (int j = 0; j < dgvImpares.ColumnCount; j++)//Coluna
                    {
                        Planilha.Cell(i + 2, l).Value = dgvImpares.Rows[i].Cells[j].Value;
                        Planilha.Cell(i + 2, l).Style.Font.SetFontSize(12);
                        Planilha.Cell(i + 2, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorderColor = XLColor.Black;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorderColor = XLColor.Black;
                        if (colore) Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.TeaGreen;
                        else Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.White;
                        l++;
                    }
                    if (colore) colore = false;
                    else colore = true;
                }

                colore = true;
                //dgvSairam
                for (int i = 0; i < dgvSairam.RowCount - 1; i++)//Linha
                {
                    l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + dgvAtrazados.ColumnCount + dgvImpares.ColumnCount + 7;
                    for (int j = 0; j < dgvSairam.ColumnCount; j++)//Coluna
                    {
                        Planilha.Cell(i + 2, l).Value = dgvSairam.Rows[i].Cells[j].Value;
                        Planilha.Cell(i + 2, l).Style.Font.SetFontSize(12);
                        Planilha.Cell(i + 2, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorderColor = XLColor.Black;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorderColor = XLColor.Black;
                        if (colore) Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.TeaGreen;
                        else Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.White;
                        l++;
                    }
                    if (colore) colore = false;
                    else colore = true;
                }

                colore = true;
                //dgvColunasELinhas
                for (int i = 0; i < dgvColunasElinhas.RowCount - 1; i++)//Linha
                {
                    l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + dgvAtrazados.ColumnCount + dgvImpares.ColumnCount + dgvSairam.ColumnCount + 8;
                    for (int j = 0; j < dgvColunasElinhas.ColumnCount; j++)//Coluna
                    {
                        Planilha.Cell(i + 2, l).Value = dgvColunasElinhas.Rows[i].Cells[j].Value;
                        Planilha.Cell(i + 2, l).Style.Font.SetFontSize(12);
                        Planilha.Cell(i + 2, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorderColor = XLColor.Black;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorderColor = XLColor.Black;
                        if (colore) Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.TeaGreen;
                        else Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.White;
                        l++;
                    }
                    if (colore) colore = false;
                    else colore = true;
                }

                colore = true;
                //dgvLinhasEColunas
                for (int i = 0; i < dgvLinhasEColunas.RowCount - 1; i++)//Linha
                {
                    l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + dgvAtrazados.ColumnCount + dgvImpares.ColumnCount + dgvSairam.ColumnCount + dgvColunasElinhas.ColumnCount + 9;
                    for (int j = 0; j < dgvLinhasEColunas.ColumnCount; j++)//Coluna
                    {
                        Planilha.Cell(i + 2, l).Value = dgvLinhasEColunas.Rows[i].Cells[j].Value;
                        Planilha.Cell(i + 2, l).Style.Font.SetFontSize(12);
                        Planilha.Cell(i + 2, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorderColor = XLColor.Black;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorderColor = XLColor.Black;
                        if (colore) Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.TeaGreen;
                        else Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.White;
                        l++;
                    }
                    if (colore) colore = false;
                    else colore = true;
                }

                colore = true;
                //dgvPrimos
                for (int i = 0; i < dgvNumPrimos.RowCount - 1; i++)//Linha
                {
                    l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + dgvAtrazados.ColumnCount + dgvImpares.ColumnCount + dgvSairam.ColumnCount + dgvColunasElinhas.ColumnCount + dgvLinhasEColunas.ColumnCount+10;
                    for (int j = 0; j < dgvNumPrimos.ColumnCount; j++)//Coluna
                    {
                        Planilha.Cell(i + 2, l).Value = dgvNumPrimos.Rows[i].Cells[j].Value;
                        Planilha.Cell(i + 2, l).Style.Font.SetFontSize(12);
                        Planilha.Cell(i + 2, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorderColor = XLColor.Black;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorderColor = XLColor.Black;
                        if (colore) Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.TeaGreen;
                        else Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.White;
                        l++;
                    }
                    if (colore) colore = false;
                    else colore = true;
                }

                colore = true;
                //dgvFinabocci
                for (int i = 0; i < dgvFibonacci.RowCount - 1; i++)//Linha
                {
                    l = dgvPrincipal.ColumnCount + dgvRepetidas.ColumnCount + dgvNotOut.ColumnCount + dgvColumNaoSaiu.ColumnCount + dgvAtrazados.ColumnCount + dgvImpares.ColumnCount + dgvSairam.ColumnCount + dgvColunasElinhas.ColumnCount + dgvLinhasEColunas.ColumnCount + dgvNumPrimos.ColumnCount+11;
                    for (int j = 0; j < dgvFibonacci.ColumnCount; j++)//Coluna
                    {
                        Planilha.Cell(i + 2, l).Value = dgvFibonacci.Rows[i].Cells[j].Value;
                        Planilha.Cell(i + 2, l).Style.Font.SetFontSize(12);
                        Planilha.Cell(i + 2, l).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.InsideBorderColor = XLColor.Black;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        Planilha.Cell(i + 2, l).Style.Border.OutsideBorderColor = XLColor.Black;
                        if (colore) Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.TeaGreen;
                        else Planilha.Cell(i + 2, l).Style.Fill.BackgroundColor = XLColor.White;
                        l++;
                    }
                    if (colore) colore = false;
                    else colore = true;
                }

                Planilha.Columns().AdjustToContents();

                var range = Planilha.Range("A1:U1").SetAutoFilter();                             
                
                try
                {
                    string LocalSave = @"C:\Sistema MegaSena\Exel\" + txtNomeArquivo.Text + ".xlsx";
                    Exel.SaveAs(LocalSave);
                    MessageBox.Show("Exportado com Sucesso!!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnlNomeArq.Visible = false;
                    Process.Start("Explorer", @"C:\Sistema MegaSena\Exel");                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro interno ou o Arquivo está aberto! \nDescrição: "+ex.Message, "Oppss", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    pnlNomeArq.Visible = false;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Opss, O nome do arquivo não pode estar vazio!!", "Opess!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //================================================
        // === FUNÇÃO CLICK NO BOTÃO X E FECHA O PANEL ===
        //================================================
        private void button2_Click(object sender, EventArgs e)
        {
            pnlNomeArq.Visible = false;
            txtNomeArquivo.Text = "Mega Analise Exel";
        }

        //====================
        // === FUNÇÃO LOAD ===
        //====================
        private void SubAnalise_Load(object sender, EventArgs e)
        {
            LinhasUltimoJogo = "";
            ColunasUltimoJogo = "";          
        }

        //=======================================================
        // === FUNÇÃO QUE REALIZA TODOS AS ANÁLISES DOS DADOS ===
        //=======================================================
        int Col0 = 0, Col1 = 0, Col2 = 0, Col3 = 0, Col4 = 0, Col5 = 0, Col6 = 0, Col7 = 0, Col8 = 0, Col9 = 0;
        public struct CaixaDeVariavies
        {
            public static string TotalDezenas;
        }

        

        public void ContaNumeros()
        {
            try
            {
                if (CopyColunasNoOut.Length > 0) Array.Clear(CopyColunasNoOut, 0, CopyColunasNoOut.Length);
                if (CopyDezenasAtrasadas.Length > 0) Array.Clear(CopyDezenasAtrasadas, 0, CopyDezenasAtrasadas.Length);
                if (CopyDezenasRepetidas.Length > 0) Array.Clear(CopyDezenasRepetidas, 0, CopyDezenasRepetidas.Length);
                if (CopyLinhasNoOut.Length > 0) Array.Clear(CopyLinhasNoOut, 0, CopyLinhasNoOut.Length);
                if (CopyNumerosNoOut.Length > 0) Array.Clear(CopyNumerosNoOut, 0, CopyNumerosNoOut.Length);
                if (CopyDezenasPares.Length > 0) Array.Clear(CopyDezenasPares, 0, CopyDezenasPares.Length);
                if (CopyDezenasImpares.Length > 0) Array.Clear(CopyDezenasImpares, 0, CopyDezenasImpares.Length);
                if (CopyDezenasSorteadas.Length > 0) Array.Clear(CopyDezenasSorteadas, 0, CopyDezenasSorteadas.Length);

                Banco_de_Dados db = new Banco_de_Dados();
                Concurso[] concursos = db.Buscar(0, NumJogos);
                string[] Dezenas = new string[concursos.Length];
                string[] Concursos = new string[concursos.Length];

                for (int i = 0; i < Dezenas.Length; i++)
                {
                    string Dez = string.Join(",", concursos[i].Dezenas);
                    Dezenas[i] = Dez;
                    Concursos[i] = concursos[i].NumConcurso.ToString();
                }

                concursos = db.Buscar(0, false);
                string[] DezenasParaAtrasadas = new string[concursos.Length];
                for (int i = 0; i < concursos.Length; i++)
                {
                    string Dez = string.Join(",", concursos[i].Dezenas);
                    DezenasParaAtrasadas[i] = Dez;
                }

                int[] TotalDezenas = new int[6 * NumJogos];
                string TotalDezenas2 = "";

                int[] DezenasAtrasadas = new int[60];
                int[] TabelaDezenas = new int[60];
                int[] DezenasRepetidas = new int[60];
                int g = 1;
                for (int i = 0; i < 60; i++)
                {
                    TabelaDezenas[i] = g;
                    g++;
                }

                dgvPrincipal.Rows.Clear();
                dgvColumNaoSaiu.Rows.Clear();
                dgvNotOut.Rows.Clear();
                dgvAtrazados.Rows.Clear();
                dgvRepetidas.Rows.Clear();
                dgvImpares.Rows.Clear();
                dgvSairam.Rows.Clear();
                dgvLinhasEColunas.Rows.Clear();
                dgvColunasElinhas.Rows.Clear();

                InserePrincipaisDGV(Dezenas, TotalDezenas2, Concursos, DezenasRepetidas, NumJogos);

                TotalDezenas2 = CaixaDeVariavies.TotalDezenas;

                string[] CloneDezenas = new string[DezenasParaAtrasadas.Length];
                Array.Copy(DezenasParaAtrasadas, CloneDezenas, CloneDezenas.Length);

                //LOOPING QUE ORGANIZA PARA A CONTAGEM DOS NÚMERO MAIS ATRASADOS                                
                for (int p = 0; p < CloneDezenas.Length; p++)
                    {
                        string CopyD1 = CloneDezenas[p];
                        string[] CopySeparaDezenas = CopyD1.Split(',');
                        string IndexAchados = "";
                        for (int S = 0; S < 6; S++)
                        {
                            int index = ArraySeach(TabelaDezenas, Convert.ToInt32(CopySeparaDezenas[S]));
                            DezenasAtrasadas[index] = 0;
                            IndexAchados += IndexAchados == "" ? index.ToString() : " , " + index.ToString();
                        }

                        //LOOPING QUE CALCULA OS AS DEZENAS MAIS ATRASADAS
                        string[] Indexs = IndexAchados.Split(',');
                        for (int i = 0; i < 60; i++)
                        {
                            if (i != Convert.ToInt32(Indexs[0]) && i != Convert.ToInt32(Indexs[1]) && i != Convert.ToInt32(Indexs[2]) && i != Convert.ToInt32(Indexs[3]) && i != Convert.ToInt32(Indexs[4]) && i != Convert.ToInt32(Indexs[5]))
                            {
                                DezenasAtrasadas[i] += 1;
                            }
                        }
                }

                    //LOOPING QUE CONVERT UM ARRAY DE STRING PARA INTEIRO
                    string[] Caracter = new string[TotalDezenas.Length];
                    Caracter = TotalDezenas2.Split(',');
                    for (int i = 0; i < TotalDezenas.Length; i++)
                    {
                        TotalDezenas[i] = Convert.ToInt32(Caracter[i]);
                    }
             

                int[] CopyDezenas = new int[TotalDezenas.Length];                
                Array.Copy(TotalDezenas, CopyDezenas, CopyDezenas.Length);                                

                Array.Sort(CopyDezenas);
                     //LOOPING QUE IDENTIFICA OS NUMEROS IGUAIS
                    int Repetidos = 0;
                    for (int i = 0; i < CopyDezenas.Length; i++)
                    {
                        int X = -1;
                        X = ArraySeach(CopyDezenas, TotalDezenas[i]);

                        for (int y = X + 1; y < TotalDezenas.Length; y++)
                        {
                            if (CopyDezenas[y] == CopyDezenas[X] && i != CopyDezenas.Length - 1) { CopyDezenas[y] = -1; Repetidos++; }
                        }
                    }
                    Array.Sort(CopyDezenas);
                    Array.Reverse(CopyDezenas);


                    //LOOPING QUE RETIRA OS NUMEROS IGUAIS
                    TotalDezenas = new int[CopyDezenas.Length - Repetidos];
                    for (int i = 0; i < TotalDezenas.Length; i++)
                    {
                        if (CopyDezenas[i] != -1) TotalDezenas[i] = CopyDezenas[i];
                    }
                    Array.Reverse(TotalDezenas);

                    //LOOPING QUE CALCULA QUAIS DEZENAS NÃO SAIRAM 
                    int QtdRetirados = 0;
                    int[] TabelaArray = new int[60];
                    int k = 1;
                    for (int i = 0; i < 60; i++)
                    {
                        TabelaArray[i] = k;
                        k++;
                    }
                    for (int i = 0; i < TotalDezenas.Length; i++)
                    {
                        for (int j = 0; j < 60; j++)
                        {
                            if (TotalDezenas[i] == TabelaArray[j]) { TabelaArray[j] = -1; QtdRetirados++; }
                        }
                    }
                    Array.Sort(TabelaArray);

        
                //LOOPING QUE JOGA NA TABELA OS NÚMEROS QUE NÃO SAIRAM
                for (int f = QtdRetirados; f < TabelaArray.Length; f++)
                {
                    if (f >= TabelaArray.Length - 2)
                    {
                        dgvNotOut.Rows.Add(TabelaArray[f]);
                    }
                    else
                    {
                        dgvNotOut.Rows.Add(TabelaArray[f] + " | " + TabelaArray[f + 1] + " | " + TabelaArray[f + 2]);
                        f += 2;
                    }

                }

                //LOOPING QUE JOGA NA TABELA OS NÚMEROS QUE SAIRAM  //LOOPING QUE CALCULA OS NÚMEROS REPETIDOS          
                int[] SorteadasInt = new int[Dezenas.Length * 6];
                int n = 0;
                for (int i = 0; i < SorteadasInt.Length; i++)
                {
                    string Deze = Dezenas[n];
                    string[] Dezen = Deze.Split(',');
                    for (int f = 0; f < 6; f++)
                    {
                        SorteadasInt[i] = Convert.ToInt32(Dezen[f]);
                        i++;
                    }
                    i -= 1;
                    n++;
                }

                int Repeti = 0;
                for (int i = 0; i < SorteadasInt.Length; i++)//identifica os números repetidos
                {
                    int X = -1;
                    X = ArraySeach(SorteadasInt, SorteadasInt[i]);

                    for (int t = X + 1; t < SorteadasInt.Length; t++)
                    {
                        if (SorteadasInt[t] == SorteadasInt[X] && i != SorteadasInt.Length - 1) { SorteadasInt[t] = -1; }
                    }
                }
                for (int i = 0; i < SorteadasInt.Length; i++)//Convert o Array para inteiro
                {
                    if (SorteadasInt[i] == -1) Repeti++;
                }
                Array.Sort(SorteadasInt);
                Array.Reverse(SorteadasInt);

                int[] SorteadosInteirosNoRepeti = new int[SorteadasInt.Length - Repetidos];
                for (int i = 0; i < SorteadasInt.Length; i++)//retira os números repetidos
                {
                    if (SorteadasInt[i] != -1) SorteadosInteirosNoRepeti[i] = SorteadasInt[i];
                }
                Array.Reverse(SorteadosInteirosNoRepeti);
                for (int i = 0; i < SorteadosInteirosNoRepeti.Length; i++)//Adiciona na tabela
                {
                    if (i >= SorteadosInteirosNoRepeti.Length - 2)
                    {
                        dgvSairam.Rows.Add(SorteadosInteirosNoRepeti[i]);
                    }
                    else
                    {
                        dgvSairam.Rows.Add(SorteadosInteirosNoRepeti[i] + " | " + SorteadosInteirosNoRepeti[i + 1] + " | " + SorteadosInteirosNoRepeti[i + 2]);
                        i += 2;
                    }

                }


                //LOOPING QUE ADICIONA OS NÚMEROS PARES E IMPARES
                string[] DezenasPares;
                string[] DezenasImpares;
                int qtdPar = 0;
                int qtdImpar = 0;
                string Pares = "";
                string Impares = "";
                for (int i = 0; i < SorteadosInteirosNoRepeti.Length; i++)
                {
                    if (SorteadosInteirosNoRepeti[i] % 2 == 0)//Par
                    {
                        qtdPar++;
                        Pares += Pares == "" ? SorteadosInteirosNoRepeti[i].ToString() : ", " + SorteadosInteirosNoRepeti[i].ToString();
                    }
                    else //Impar
                    {
                        qtdImpar++;
                        Impares += Impares == "" ? SorteadosInteirosNoRepeti[i].ToString() : ", " + SorteadosInteirosNoRepeti[i].ToString();
                    }
                }
                DezenasPares = Pares.Split(',');
                DezenasImpares = Impares.Split(',');
                int r = 0;
                for (int i = 0; i < DezenasPares.Length; i++)//Add Pares na tabela
                {
                    dgvImpares.Rows.Add();
                    if (i >= DezenasPares.Length - 2)
                    {
                        dgvImpares.Rows[r].Cells[0].Value = DezenasPares[i];
                    }
                    else
                    {
                        dgvImpares.Rows[r].Cells[0].Value = DezenasPares[i] + " | " + DezenasPares[i + 1] + " | " + DezenasPares[i + 2];
                        i += 2;
                    }
                    r++;
                }
                r = 0;
                for (int i = 0; i < DezenasImpares.Length; i++)//Add Pares na tabela
                {
                    dgvImpares.Rows.Add();
                    if (i >= DezenasImpares.Length - 2)
                    {
                        dgvImpares.Rows[r].Cells[1].Value = DezenasImpares[i];
                    }
                    else
                    {
                        dgvImpares.Rows[r].Cells[1].Value = DezenasImpares[i] + " | " + DezenasImpares[i + 1] + " | " + DezenasImpares[i + 2];
                        i += 2;
                    }
                    r++;
                }
                lblTotalImpares.Text = DezenasImpares.Length.ToString();
                lblTotalPares.Text = DezenasPares.Length.ToString();

                //LOOPING QUE ADICIONA OS NÚMEROS MAIS ATRASADOS NA TABELA
                for (int i = 0; i < 60; i++)
                {
                    dgvAtrazados.Rows.Add(TabelaDezenas[i], DezenasAtrasadas[i]);
                }

                //LOOPING QUE ADICIONA OS NÚEMROS REPETIDOS NA TABELA
                for (int i = 0; i < 60; i++)
                {
                    if (DezenasRepetidas[i] >= 2)
                    {
                        dgvRepetidas.Rows.Add(TabelaDezenas[i], DezenasRepetidas[i]);
                    }
                }

                //PASSA TODOS OS DADOS CULCULADOS PARA OS VETORES DE COPIA
                CopyDezenasAtrasadas = DezenasAtrasadas;
                CopyDezenasRepetidas = DezenasRepetidas;
                CopyNumerosNoOut = TabelaArray;
                CopyDezenasImpares = DezenasImpares;
                CopyDezenasPares = DezenasPares;
                CopyDezenasSorteadas = SorteadosInteirosNoRepeti;
              
                //LOOPING QUE CALCULA A CULUNA QUE NÃO SAIU
                string[] ColunasGrid = new string[10] { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10" };
                int[] ColunasCountNotOut = new int[10];
                for (int i = 0; i < dgvColumNaoSaiu.Rows.Count - 1; i++)
                {
                    string[] SplitColumns = dgvColumNaoSaiu.Rows[i].Cells[1].Value.ToString().Split('|');
                    for (int y = 0; y < SplitColumns.Length; y++)
                    {
                        string Col = SplitColumns[y].Replace(" ", "");

                        for (int j = 0; j < 10; j++)
                        {
                            if (Col == ColunasGrid[j])
                            {
                                ColunasCountNotOut[j] += 1;
                            }
                        }
                    }
                }

                //SEPARA AS COLUNAS
                string NotOutC = "";
                for (int i = 0; i < ColunasCountNotOut.Length; i++)
                {
                    if (ColunasCountNotOut[i] == 0)
                    {
                        if (i == 0) NotOutC += NotOutC == "" ? "C1" : "-C1";
                        if (i == 1) NotOutC += NotOutC == "" ? "C2" : "-C2";
                        if (i == 2) NotOutC += NotOutC == "" ? "C3" : "-C3";
                        if (i == 3) NotOutC += NotOutC == "" ? "C4" : "-C4";
                        if (i == 4) NotOutC += NotOutC == "" ? "C5" : "-C5";
                        if (i == 5) NotOutC += NotOutC == "" ? "C6" : "-C6";
                        if (i == 6) NotOutC += NotOutC == "" ? "C7" : "-C7";
                        if (i == 7) NotOutC += NotOutC == "" ? "C8" : "-C8";
                        if (i == 8) NotOutC += NotOutC == "" ? "C9" : "-C9";
                        if (i == 9) NotOutC += NotOutC == "" ? "C10" : "-C10";

                    }
                }

                CopyColunasNoOut = NotOutC.Split('-');

                //LOOPING QUE CALCULA A LINHA QUE NÃO SAIU
                string[] LinhasGrid = new string[6] { "L1", "L2", "L3", "L4", "L5", "L6" };
                int[] LinhasCountNotOut = new int[6];
                for (int i = 0; i < dgvColumNaoSaiu.Rows.Count - 1; i++)
                {
                    string[] SplitLinhas = dgvColumNaoSaiu.Rows[i].Cells[2].Value.ToString().Split('|');
                    for (int y = 0; y < SplitLinhas.Length; y++)
                    {
                        string Line = SplitLinhas[y].Replace(" ", "");

                        for (int j = 0; j < 6; j++)
                        {
                            if (Line == LinhasGrid[j])
                            {
                                LinhasCountNotOut[j] += 1;
                            }
                        }
                    }
                }

                //SEPARA AS LINHAS
                string NotOutL = "";
                for (int i = 0; i < LinhasCountNotOut.Length; i++)
                {
                    if (LinhasCountNotOut[i] == 0)
                    {
                        if (i == 0) NotOutL += NotOutL == "" ? "L1" : "-L1";
                        if (i == 1) NotOutL += NotOutL == "" ? "L2" : "-L2";
                        if (i == 2) NotOutL += NotOutL == "" ? "L3" : "-L3";
                        if (i == 3) NotOutL += NotOutL == "" ? "L4" : "-L4";
                        if (i == 4) NotOutL += NotOutL == "" ? "L5" : "-L5";
                        if (i == 5) NotOutL += NotOutL == "" ? "L6" : "-L6";

                    }
                }

                CopyLinhasNoOut = NotOutL.Split('-');

                //Adiciona na variavel publica as colunas que não sairam no ultimo jogo
                string Value = dgvColumNaoSaiu.Rows[0].Cells[1].Value.ToString();
                Value.Replace("|", " - ");
                ColunasUltimoJogo = Value;

                //Adiciona na variavel publica as linhas que sairam no ultimo jogo
                Value = dgvColumNaoSaiu.Rows[0].Cells[2].Value.ToString();
                Value.Replace("|", " - ");
                LinhasUltimoJogo = Value;

                //==================================================================================================
                //==================================================================================================
                //Gato para conseguir pegar todos os dados kkkk qualquer coisa retirar 
                //{
                concursos = db.Buscar(0, db.Buscar(""));
                Dezenas = new string[concursos.Length];
                Concursos = new string[concursos.Length];

                for (int i = 0; i < Dezenas.Length; i++)
                {
                    string Dez = string.Join(",", concursos[i].Dezenas);
                    Dezenas[i] = Dez;
                    Concursos[i] = concursos[i].NumConcurso.ToString();
                }

                TotalDezenas = new int[6 * db.Buscar("")];
                TotalDezenas2 = "";
                DezenasRepetidas = new int[60];
                dgvColumNaoSaiu.Rows.Clear();
                InserePrincipaisDGV(Dezenas, TotalDezenas2, Concursos, DezenasRepetidas, db.Buscar(""));
                //}
                //Calcula as colunas mais atrazadas

                int[] ColunasAtrazadas = new int[10];
                for (int i = dgvColumNaoSaiu.RowCount - 1; i >= 0; i--)
                {
                    string SairamC = "C1-C2-C3-C4-C5-C6-C7-C8-C9-C10";
                    if (dgvColumNaoSaiu.Rows[i].Cells[1].Value != null)
                    {
                        string[] ColunasNot = dgvColumNaoSaiu.Rows[i].Cells[1].Value.ToString().Split('|');
                        for (int z = 0; z < ColunasNot.Length; z++)
                        {
                            string Valor = ColunasNot[z].Replace(" ", "");
                            if (Valor == "C1") { ColunasAtrazadas[0] += 1; SairamC = SairamC.Replace("C1", ""); }
                            else if (Valor == "C2") { ColunasAtrazadas[1] += 1; SairamC = SairamC.Replace("C2", ""); }
                            else if (Valor == "C3") { ColunasAtrazadas[2] += 1; SairamC = SairamC.Replace("C3", ""); }
                            else if (Valor == "C4") { ColunasAtrazadas[3] += 1; SairamC = SairamC.Replace("C4", ""); }
                            else if (Valor == "C5") { ColunasAtrazadas[4] += 1; SairamC = SairamC.Replace("C5", ""); }
                            else if (Valor == "C6") { ColunasAtrazadas[5] += 1; SairamC = SairamC.Replace("C6", ""); }
                            else if (Valor == "C7") { ColunasAtrazadas[6] += 1; SairamC = SairamC.Replace("C7", ""); }
                            else if (Valor == "C8") { ColunasAtrazadas[7] += 1; SairamC = SairamC.Replace("C8", ""); }
                            else if (Valor == "C9") { ColunasAtrazadas[8] += 1; SairamC = SairamC.Replace("C9", ""); }
                            else if (Valor == "C10") { ColunasAtrazadas[9] += 1; SairamC = SairamC.Replace("C10", ""); }

                        }

                        string[] SairamC2 = SairamC.Split('-');
                        for (int z = 0; z < SairamC2.Length; z++)
                        {
                            string Valor = SairamC2[z].Replace(" ", "");
                            if (Valor == "C1") { ColunasAtrazadas[0] = 0; }
                            else if (Valor == "C2") { ColunasAtrazadas[1] = 0; }
                            else if (Valor == "C3") { ColunasAtrazadas[2] = 0; }
                            else if (Valor == "C4") { ColunasAtrazadas[3] = 0; }
                            else if (Valor == "C5") { ColunasAtrazadas[4] = 0; }
                            else if (Valor == "C6") { ColunasAtrazadas[5] = 0; }
                            else if (Valor == "C7") { ColunasAtrazadas[6] = 0; }
                            else if (Valor == "C8") { ColunasAtrazadas[7] = 0; }
                            else if (Valor == "C9") { ColunasAtrazadas[8] = 0; }
                            else if (Valor == "C10") { ColunasAtrazadas[9] = 0; }
                        }
                    }
                }

                //ColunasAtrazadas[9] -= 2;
                //Calcula as colunas mais atrasadas em pares            
                int[] ColunasAtrasadasPares = new int[10];
                for (int i = dgvPrincipal.Rows.Count - 1; i >= 0; i--)
                {
                    int cont = 0;
                    for (int c = 1; c < 11; c++)
                    {
                        if (dgvPrincipal.Rows[i].Cells[c].Value != null)
                        {
                            string[] ParesSeparados = dgvPrincipal.Rows[i].Cells[c].Value.ToString().Split('|');

                            if (ParesSeparados.Length >= 2) ColunasAtrasadasPares[cont] = 0;
                            else ColunasAtrasadasPares[cont] += 1;
                            cont++;
                        }
                    }
                }

                //Calcula as Linhas mais atrazadas
                int[] LinhasAtrazadas = new int[6];
                for (int i = dgvColumNaoSaiu.RowCount - 1; i >= 0; i--)
                {
                    string SairamL = "L1-L2-L3-L4-L5-L6";
                    if (dgvColumNaoSaiu.Rows[i].Cells[2].Value != null)
                    {
                        string[] LinhasNot = dgvColumNaoSaiu.Rows[i].Cells[2].Value.ToString().Split('|');

                        for (int z = 0; z < LinhasNot.Length; z++)
                        {
                            string Valor = LinhasNot[z].Replace(" ", "");
                            if (Valor == "L1") { LinhasAtrazadas[0] += 1; SairamL = SairamL.Replace("L1", ""); }
                            else if (Valor == "L2") { LinhasAtrazadas[1] += 1; SairamL = SairamL.Replace("L2", ""); }
                            else if (Valor == "L3") { LinhasAtrazadas[2] += 1; SairamL = SairamL.Replace("L3", ""); }
                            else if (Valor == "L4") { LinhasAtrazadas[3] += 1; SairamL = SairamL.Replace("L4", ""); }
                            else if (Valor == "L5") { LinhasAtrazadas[4] += 1; SairamL = SairamL.Replace("L5", ""); }
                            else if (Valor == "L6") { LinhasAtrazadas[5] += 1; SairamL = SairamL.Replace("L6", ""); }

                        }

                        string[] SairamL2 = SairamL.Split('-');
                        for (int z = 0; z < SairamL2.Length; z++)
                        {
                            string Valor = SairamL2[z].Replace(" ", "");
                            if (Valor == "L1") { LinhasAtrazadas[0] = 0; }
                            else if (Valor == "L2") { LinhasAtrazadas[1] = 0; }
                            else if (Valor == "L3") { LinhasAtrazadas[2] = 0; }
                            else if (Valor == "L4") { LinhasAtrazadas[3] = 0; }
                            else if (Valor == "L5") { LinhasAtrazadas[4] = 0; }
                            else if (Valor == "L6") { LinhasAtrazadas[5] = 0; }
                        }
                    }

                }


                //Calcula as Linhas mais atrasadas em pares            
                int[] LinhasAtrasadasPares = new int[10];
                for (int i = dgvPrincipal.Rows.Count - 1; i >= 0; i--)
                {
                    int cont = 0;
                    for (int c = 11; c < 17; c++)
                    {
                        if (dgvPrincipal.Rows[i].Cells[c].Value != null)
                        {
                            string[] ParesSeparados = dgvPrincipal.Rows[i].Cells[c].Value.ToString().Split('|');

                            if (ParesSeparados.Length >= 2) LinhasAtrasadasPares[cont] = 0;
                            else LinhasAtrasadasPares[cont] += 1;
                            cont++;
                        }
                    }
                }

                //Insere as colunas mais atrasadas na tabela
                for (int v = 0; v < 10; v++)
                {
                    dgvColunasElinhas.Rows.Add();
                    dgvColunasElinhas.Rows[v].Cells[0].Value = "C" + (v + 1);
                    dgvColunasElinhas.Rows[v].Cells[1].Value = ColunasAtrazadas[v];
                    dgvColunasElinhas.Rows[v].Cells[2].Value = ColunasAtrasadasPares[v];
                }

                //Insere as Linhas mais atrasadas na tabela
                for (int v = 0; v < 6; v++)
                {
                    dgvLinhasEColunas.Rows.Add();
                    dgvLinhasEColunas.Rows[v].Cells[0].Value = "L" + (v + 1);
                    dgvLinhasEColunas.Rows[v].Cells[1].Value = LinhasAtrazadas[v];
                    dgvLinhasEColunas.Rows[v].Cells[2].Value = LinhasAtrasadasPares[v];
                }

                //==================================================================================================
                //==================================================================================================
                //Gato para conseguir pegar todos os dados kkkk qualquer coisa retirar 
                //{
                concursos = db.Buscar(0, NumJogos);
                Dezenas = new string[concursos.Length];
                Concursos = new string[concursos.Length];

                for (int i = 0; i < Dezenas.Length; i++)
                {
                    string Dez = string.Join(",", concursos[i].Dezenas);
                    Dezenas[i] = Dez;
                    Concursos[i] = concursos[i].NumConcurso.ToString();
                }

                TotalDezenas = new int[6 * NumJogos];
                TotalDezenas2 = "";
                DezenasRepetidas = new int[60];

                dgvPrincipal.Rows.Clear();
                dgvColumNaoSaiu.Rows.Clear();

                InserePrincipaisDGV(Dezenas, TotalDezenas2, Concursos, DezenasRepetidas, NumJogos);

                //}        

                //gdvNúmerosPrimos e Fibonacci
                int[] NumPrimos = new int[17] {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59};
                int[] NumFibo = new int[9] { 1, 2, 3, 5, 8, 13, 21, 34, 55 };
                int TodPrimos = 0;
                int TodFibo = 0;
                for (int i = 0; i < concursos.Length; i++)
                {
                    string Primos = "";
                    string Fibo = "";
                    int QtdPrimos = 0;
                    int QtdFibo = 0;
                    int Concursosss = concursos[i].NumConcurso;
                    string[] DezenasConcurso = concursos[i].Dezenas;

                    for (int w = 0; w < DezenasConcurso.Length; w++)
                    {                            
                        for (int l = 0; l < NumPrimos.Length; l++)
                        {
                            if (Convert.ToInt32(DezenasConcurso[w]) == NumPrimos[l])
                            {
                                QtdPrimos++;
                                Primos += Primos == "" ? DezenasConcurso[w] : "-" + DezenasConcurso[w];
                                TodPrimos++;
                            }
                        }

                        for (int l = 0; l < NumFibo.Length; l++)
                        {
                            if (Convert.ToInt32(DezenasConcurso[w]) == NumFibo[l])
                            {
                                QtdFibo++;
                                TodFibo++;
                                Fibo += Fibo == "" ? DezenasConcurso[w] : "-" + DezenasConcurso[w];
                            }
                        }
                    }
                    if (Primos == "") Primos = "NADA";
                    if (Fibo == "") Fibo = "NADA";

                    lblQtdFibo.Text = TodFibo.ToString();
                    lblQtdPrimos.Text = TodPrimos.ToString();
                    dgvFibonacci.Rows.Add(Concursosss, Fibo, QtdFibo);
                    dgvNumPrimos.Rows.Add(Concursosss, Primos, QtdPrimos);
                }                                    
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Ocorreu um erro: " + ex.Message +" $$ "+ex.HResult+" $$ "+ex.InnerException+ " $$ "+ex.StackTrace+" $$ "+ex.TargetSite+" $$ "+ex.HelpLink+" $$ "+ex.Data+" $$ "+ex.Source, "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //=======================================================
        // === FUNÇÃO QUE INSERE OS DADOS NA TABELA PRINCIPAL ===
        //=======================================================
        public void InserePrincipaisDGV(string[] Dezenas, string TotalDezenas2, string[] Concursos, int[] DezenasRepetidas, int NumJogos)
        {
            for (int y = 0; y < NumJogos; y++)//JOGOS
            {
                bool[] Colunas = new bool[10];
                Linhas = new bool[6];

                string D1 = Dezenas[y];
                TotalDezenas2 += TotalDezenas2 == "" ? D1 : "," + D1;
                string J1 = Concursos[y];
                string C0 = "0", C1 = "0", C2 = "0", C3 = "0", C4 = "0", C5 = "0", C6 = "0", C7 = "0", C8 = "0", C9 = "0";
                string[] SeparaDezenas = D1.Split(',');

                //LOOPING QUE CALCULA AS DEZENAS REPETIDAS
                for (int p = 0; p < 60; p++)
                {
                    if (p == Convert.ToInt32(SeparaDezenas[0]) || p == Convert.ToInt32(SeparaDezenas[1]) || p == Convert.ToInt32(SeparaDezenas[2]) || p == Convert.ToInt32(SeparaDezenas[3]) || p == Convert.ToInt32(SeparaDezenas[4]) || p == Convert.ToInt32(SeparaDezenas[5]))
                    {
                        DezenasRepetidas[p - 1] += 1;
                    }
                }
                L0 = "0"; L1 = "0"; L2 = "0"; L3 = "0"; L4 = "0"; L5 = "0";

                for (int i = 0; i < 10; i++)//COLUNA
                {
                    for (int j = 0; j < 6; j++)//LINHA
                    {
                        for (int w = 0; w < 6; w++)//DEZENA
                        {
                            int numDezena = Convert.ToInt32(SeparaDezenas[w]);
                            int numTabela = Tabela[i, j];

                            if (numDezena == numTabela)
                            {
                                VerificaLinha(j, numDezena);
                                if (i == 0)
                                {
                                    Col0++;
                                    Colunas[0] = true;
                                    w = 6;
                                    C0 = C0 != "0" ? C0 + " | " + numDezena.ToString() : numDezena.ToString();
                                }
                                else if (i == 1)
                                {
                                    Col1++;
                                    Colunas[1] = true;
                                    w = 6;
                                    C1 = C1 != "0" ? C1 + " | " + numDezena.ToString() : numDezena.ToString();
                                }
                                else if (i == 2)
                                {
                                    Col2++;
                                    Colunas[2] = true;
                                    w = 6;
                                    C2 = C2 != "0" ? C2 + " | " + numDezena.ToString() : numDezena.ToString();
                                }
                                else if (i == 3)
                                {
                                    Col3++;
                                    Colunas[3] = true;
                                    w = 6;
                                    C3 = C3 != "0" ? C3 + " | " + numDezena.ToString() : numDezena.ToString();
                                }
                                else if (i == 4)
                                {
                                    Col4++;
                                    w = 6;
                                    Colunas[4] = true;
                                    C4 = C4 != "0" ? C4 + " | " + numDezena.ToString() : numDezena.ToString();
                                }
                                else if (i == 5)
                                {
                                    Col5++;
                                    Colunas[5] = true;
                                    w = 6;
                                    C5 = C5 != "0" ? C5 + " | " + numDezena.ToString() : numDezena.ToString();
                                }
                                else if (i == 6)
                                {
                                    Col6++;
                                    Colunas[6] = true;
                                    w = 6;
                                    C6 = C6 != "0" ? C6 + " | " + numDezena.ToString() : numDezena.ToString();
                                }
                                else if (i == 7)
                                {
                                    Col7++;
                                    w = 6;
                                    Colunas[7] = true;
                                    C7 = C7 != "0" ? C7 + " | " + numDezena.ToString() : numDezena.ToString();
                                }
                                else if (i == 8)
                                {
                                    Col8++;
                                    w = 6;
                                    Colunas[8] = true;
                                    C8 = C8 != "0" ? C8 + " | " + numDezena.ToString() : numDezena.ToString();
                                }
                                else if (i == 9)
                                {
                                    Col9++;
                                    Colunas[9] = true;
                                    w = 6;
                                    C9 = C9 != "0" ? C9 + " | " + numDezena.ToString() : numDezena.ToString();

                                }
                            }
                        }
                    }
                    
                }


                //LOOPING QUE RETORNA QUAIS COLUNAS NÃO SAIRAM
                string ColunasNoOut = "0";
                for (int i = 0; i < 10; i++)
                {
                    if (Colunas[i] == false)
                    {
                        if (i == 0) { ColunasNoOut = ColunasNoOut != "0" ? ColunasNoOut + " | C1" : "C1"; }
                        else if (i == 1) { ColunasNoOut = ColunasNoOut != "0" ? ColunasNoOut + " | C2" : "C2"; }
                        else if (i == 2) { ColunasNoOut = ColunasNoOut != "0" ? ColunasNoOut + " | C3" : "C3"; }
                        else if (i == 3) { ColunasNoOut = ColunasNoOut != "0" ? ColunasNoOut + " | C4" : "C4"; }
                        else if (i == 4) { ColunasNoOut = ColunasNoOut != "0" ? ColunasNoOut + " | C5" : "C5"; }
                        else if (i == 5) { ColunasNoOut = ColunasNoOut != "0" ? ColunasNoOut + " | C6" : "C6"; }
                        else if (i == 6) { ColunasNoOut = ColunasNoOut != "0" ? ColunasNoOut + " | C7" : "C7"; }
                        else if (i == 7) { ColunasNoOut = ColunasNoOut != "0" ? ColunasNoOut + " | C8" : "C8"; }
                        else if (i == 8) { ColunasNoOut = ColunasNoOut != "0" ? ColunasNoOut + " | C9" : "C9"; }
                        else if (i == 9) { ColunasNoOut = ColunasNoOut != "0" ? ColunasNoOut + " | C10" : "C10"; }
                    }
                }


                //LOOPING QUE RETORNA QUAI LINHAS NÃO SAIRAM
                string RowOut = "0";
                for (int i = 0; i < 6; i++)
                {
                    if (Linhas[i] == false)
                    {
                        if (i == 0) { RowOut = RowOut != "0" ? RowOut + " | L1" : "L1"; }
                        else if (i == 1) { RowOut = RowOut != "0" ? RowOut + " | L2" : "L2"; }
                        else if (i == 2) { RowOut = RowOut != "0" ? RowOut + " | L3" : "L3"; }
                        else if (i == 3) { RowOut = RowOut != "0" ? RowOut + " | L4" : "L4"; }
                        else if (i == 4) { RowOut = RowOut != "0" ? RowOut + " | L5" : "L5"; }
                        else if (i == 5) { RowOut = RowOut != "0" ? RowOut + " | L6" : "L6"; }
                    }
                }

                string[] QtdColunasNotOut = ColunasNoOut.Split('|');
                string[] QtdLinhasNotOut = RowOut != "0" ? RowOut.Split('|') : new string[0];
                int LinhasSairam = 6 - QtdLinhasNotOut.Length;
                int ColunasSairam = 10 - QtdColunasNotOut.Length;

                dgvPrincipal.Rows[y].DataGridView.Rows.Add(J1, C0, C1, C2, C3, C4, C5, C6, C7, C8, C9, L0, L1, L2, L3, L4, L5, ColunasSairam, LinhasSairam);
                dgvColumNaoSaiu.Rows[y].DataGridView.Rows.Add(J1, ColunasNoOut, RowOut, QtdColunasNotOut.Length, QtdLinhasNotOut.Length);

                //Verifica quantas Dezenas cairam na mesma coluna                
                string[] Erro = new string[1] { "0" };
                int TodDouplaDezena = 0;
                for (int i = 1; i < 11; i++)
                {
                    string[] DezenaCell = dgvPrincipal.Rows[y].Cells[i].Value == null || dgvPrincipal.Rows[y].Cells[i].Value.ToString() == "0" ? Erro : dgvPrincipal.Rows[y].Cells[i].Value.ToString().Split('|');
                    if (DezenaCell.Length > 1)
                    {
                        TodDouplaDezena++;
                    }
                }
                dgvPrincipal.Rows[y].Cells[19].Value = TodDouplaDezena;

                //Verifica quantas Dezenas cairam na mesma linha                
                int TodDouplaDezenaLinha = 0;
                for (int i = 11; i < 17; i++)
                {
                    string[] DezenaCell = dgvPrincipal.Rows[y].Cells[i].Value == null || dgvPrincipal.Rows[y].Cells[i].Value.ToString() == "0" ? Erro : dgvPrincipal.Rows[y].Cells[i].Value.ToString().Split('|');
                    if (DezenaCell.Length > 1)
                    {
                        TodDouplaDezenaLinha++;
                    }
                }

                dgvPrincipal.Rows[y].Cells[20].Value = TodDouplaDezenaLinha;

                CaixaDeVariavies.TotalDezenas = TotalDezenas2;
            }
        }       

        //===========================================
        // === FUNÇÃO QUE VERIFICA QUAL É A LINHA ===
        //===========================================
        public void VerificaLinha(int Linha, int Dezena)
        {
            if (Linha == 0)
            {
                L0 = L0 != "0" ? L0 + " | " + Dezena.ToString() : Dezena.ToString();
                Linhas[0] = true;
                //L0++;
            }
            if (Linha == 1)
            {
                L1 = L1 != "0" ? L1 + " | " + Dezena.ToString() : Dezena.ToString();
                Linhas[1] = true;
                //L1++;
            }
            if (Linha == 2)
            {
                L2 = L2 != "0" ? L2 + " | " + Dezena.ToString() : Dezena.ToString();
                Linhas[2] = true;
                //L2++;
            }
            if (Linha == 3)
            {
                L3 = L3 != "0" ? L3 + " | " + Dezena.ToString() : Dezena.ToString();
                Linhas[3] = true;
                // L3++;
            }
            if (Linha == 4)
            {
                L4 = L4 != "0" ? L4 + " | " + Dezena.ToString() : Dezena.ToString();
                Linhas[4] = true;
                //L4++;
            }
            if (Linha == 5)
            {
                L5 = L5 != "0" ? L5 + " | " + Dezena.ToString() : Dezena.ToString();
                Linhas[5] = true;
                // L5++;
            }
        }

        


        //=====================================================================
        // === FUNÇÃO QUE LOCALIZA A POSIÇÃO DO ELEMENTO DENTRO DE UM ARRAY ===
        //=====================================================================
        public static int ArraySeach(int[] Array, int Value)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] == Value)
                {
                    return i;
                }
            }
            return -1;
        }        

        //======================================
        // === FUNÇÃO CLIQUE NO BOTÃO VOLTAR ===
        //======================================
        private void btnVoltar_Click(object sender, EventArgs e)
        {                        
            Hide();
            Visible = false;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Hide();
            Visible = false;
        }


        //================================================
        // === FUNÇÃO DUPLA CLIQUE NA GRID E EXPANDIR  ===
        //================================================
        private void dgvColumNaoSaiu_DoubleClick(object sender, EventArgs e)
        {
            if (dgvColumNaoSaiu.Dock == DockStyle.Fill)
            {
                dgvColumNaoSaiu.Dock = DockStyle.None;
                dgvColumNaoSaiu.SendToBack();
            }
            else
            {
                dgvColumNaoSaiu.Dock = DockStyle.Fill;
                dgvColumNaoSaiu.BringToFront();
            }
        }
        private void dgvSairam_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSairam.Dock == DockStyle.Fill)
            {
                dgvSairam.Dock = DockStyle.None;
                dgvSairam.SendToBack();
            }
            else
            {
                dgvSairam.Dock = DockStyle.Fill;
                dgvSairam.BringToFront();
            }
        }
        private void dgvColunasElinhas_DoubleClick(object sender, EventArgs e)
        {
            if (dgvColunasElinhas.Dock == DockStyle.Fill)
            {
                dgvColunasElinhas.Dock = DockStyle.None;
                dgvColunasElinhas.SendToBack();
            }
            else
            {
                dgvColunasElinhas.Dock = DockStyle.Fill;
                dgvColunasElinhas.BringToFront();
            }
        }    
        private void dgvImpares_DoubleClick(object sender, EventArgs e)
        {
            if (dgvImpares.Dock == DockStyle.Fill)
            {
                dgvImpares.Dock = DockStyle.None;
                dgvImpares.SendToBack();
            }
            else
            {
                dgvImpares.Dock = DockStyle.Fill;
                dgvImpares.BringToFront();
            }
        }
        private void dgvAtrazados_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAtrazados.Dock == DockStyle.Fill)
            {
                dgvAtrazados.Dock = DockStyle.None;
                dgvAtrazados.SendToBack();
            }
            else
            {
                dgvAtrazados.Dock = DockStyle.Fill;
                dgvAtrazados.BringToFront();
            }
        }
        private void dgvRepetidas_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRepetidas.Dock == DockStyle.Fill)
            {
                dgvRepetidas.Dock = DockStyle.None;
                dgvRepetidas.SendToBack();
            }
            else
            {
                dgvRepetidas.Dock = DockStyle.Fill;
                dgvRepetidas.BringToFront();
            }
        }
        private void dgvNotOut_DoubleClick(object sender, EventArgs e)
        {
            if (dgvNotOut.Dock == DockStyle.Fill)
            {
                dgvNotOut.Dock = DockStyle.None;
                dgvNotOut.SendToBack();
            }
            else
            {
                dgvNotOut.BringToFront();
                dgvNotOut.Dock = DockStyle.Fill;
            }
        }
        private void dgvPrincipal_DoubleClick(object sender, EventArgs e)
        {
            if (dgvPrincipal.Dock == DockStyle.Fill)
            {
                dgvPrincipal.Dock = DockStyle.None;
                dgvPrincipal.SendToBack();
                dgvPrincipal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            }
            else
            {
                dgvPrincipal.BringToFront();
                dgvPrincipal.Dock = DockStyle.Fill;
                dgvPrincipal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }
        private void dgvNumPrimos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvNumPrimos.Dock == DockStyle.Fill)
            {
                dgvNumPrimos.Dock = DockStyle.None;
                dgvNumPrimos.SendToBack();
                dgvNumPrimos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            }
            else
            {
                dgvNumPrimos.BringToFront();
                dgvNumPrimos.Dock = DockStyle.Fill;
                dgvNumPrimos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }
        private void dgvFibonacci_DoubleClick(object sender, EventArgs e)
        {
            if (dgvFibonacci.Dock == DockStyle.Fill)
            {
                dgvFibonacci.Dock = DockStyle.None;
                dgvFibonacci.SendToBack();
                dgvFibonacci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            }
            else
            {
                dgvFibonacci.BringToFront();
                dgvFibonacci.Dock = DockStyle.Fill;
                dgvFibonacci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }
    }   
}
