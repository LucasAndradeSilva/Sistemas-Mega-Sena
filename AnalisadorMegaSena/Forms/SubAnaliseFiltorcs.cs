using AnalisadorMegaSena.ControlsView;
using AnalisadorMegaSena.Data;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AnalisadorMegaSena.Forms
{
    public partial class SubAnaliseFiltorcs : Form
    {
        //===================
        // === CONSTRUTOR ===
        //===================
        public SubAnaliseFiltorcs(int[] Atrasadas, int[] NumNoOut, int[] Repetidas, string[] ColNoOut, string[] LiNoOut, string ConcursoAtual, int[] Sorteados, string[] Impares, string[] Pares)
        {
            InitializeComponent();
            DezenasAtrasadas = Atrasadas;
            NumerosNoOut = NumNoOut;
            DezenasRepetidas = Repetidas;
            ColunasNoOut = ColNoOut;
            LinhasNoOut = LiNoOut;
            UltimoConcurso = ConcursoAtual;
            this.Sorteados = Sorteados;
            this.Pares = Pares;
            this.Impares = Impares;
        }

        //==================
        // === VARIAVEIS ===
        //==================
        int[] DezenasAtrasadas;
        int[] NumerosNoOut;
        int[] DezenasRepetidas;
        int[] Sorteados;
        string[] Impares;
        string[] Pares;
        string[] ColunasNoOut;
        string[] LinhasNoOut;
        string UltimoConcurso;
        List<string> Colunas = new List<string>();
        List<string> Linhas = new List<string>();
        List<string> param = new List<string>();

        string ImpParam = "";
        string DelLinhasParam = "";
        string DelColunsParam = "";
        string ReptParam = "";
        string ColunassParam = "";
        string LinhassParam = "";
        string NumLastGamaParam = "";
        string DezenasAtrasadassParam = "";
        string FixasParam = "";

        public int[] LinhasSelecionadas = new int[6];
        public int[] ColunasSelecionadas = new int[10];
        public object[] PoluacaoRest;

        public int par;
        public int impar;
        public int DezSairam;
        public int DezNotSairam;
        public int Comb;
       
        object[] ResultadoFiltro = new object[60];//Principal

        int[,] Tabela = new int[10, 6]
        {   //L0  L1  L2  L3  L4  L5
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


        public void RepreecheCbm()
        {
            //Adiciona elementos Colunas
            cbmColunas.Items.Clear();
            cbmColunas.Items.Add("C1");
            cbmColunas.Items.Add("C2");
            cbmColunas.Items.Add("C3");
            cbmColunas.Items.Add("C4");
            cbmColunas.Items.Add("C5");
            cbmColunas.Items.Add("C6");
            cbmColunas.Items.Add("C7");
            cbmColunas.Items.Add("C8");
            cbmColunas.Items.Add("C9");
            cbmColunas.Items.Add("C10");

            //Adiciona elementos Linhas
            cbmQuaisLinhas.Items.Clear();
            cbmQuaisLinhas.Items.Add("L1");
            cbmQuaisLinhas.Items.Add("L2");
            cbmQuaisLinhas.Items.Add("L3");
            cbmQuaisLinhas.Items.Add("L4");
            cbmQuaisLinhas.Items.Add("L5");
            cbmQuaisLinhas.Items.Add("L6");

            Colunas.Clear();
            Colunas.Add("C1");
            Colunas.Add("C2");
            Colunas.Add("C3");
            Colunas.Add("C4");
            Colunas.Add("C5");
            Colunas.Add("C6");
            Colunas.Add("C7");
            Colunas.Add("C8");
            Colunas.Add("C9");
            Colunas.Add("C10");

            Linhas.Clear();
            Linhas.Add("L1");
            Linhas.Add("L2");
            Linhas.Add("L3");
            Linhas.Add("L4");
            Linhas.Add("L5");
            Linhas.Add("L6");
        }

        //====================
        // === FUNÇÃO LOAD ===
        //====================
        private void SubAnaliseFiltorcs_Load(object sender, EventArgs e)
        {
            //Adiciona elementos Colunas
            Colunas.Add("C1");
            Colunas.Add("C2");
            Colunas.Add("C3");
            Colunas.Add("C4");
            Colunas.Add("C5");
            Colunas.Add("C6");
            Colunas.Add("C7");
            Colunas.Add("C8");
            Colunas.Add("C9");
            Colunas.Add("C10");

            //Adiciona elementos Linhas
            Linhas.Add("L1");
            Linhas.Add("L2");
            Linhas.Add("L3");
            Linhas.Add("L4");
            Linhas.Add("L5");
            Linhas.Add("L6");

            ReorganizaCombo();
            ReorganizaCombolLinhas();

            //Adiciona todos os números da Mega no vetor
            int Cont = 1;
            for (int i = 0; i < ResultadoFiltro.Length; i++)
            {
                ResultadoFiltro[i] = Cont;
                Cont++;
            }
            txtPopulacao.Text = string.Join(" - ", ResultadoFiltro);

            //Adiciona no txtDezenasDoUltimoJogo
            string[] UltimasDezenas = ApiMega.GetDezenaConcurso(Convert.ToInt32(UltimoConcurso)-1);
            txtDezenasUltimoJogo.Text = string.Join(" - ", UltimasDezenas);
            txtNumConcursoAnterior.Text = (Convert.ToInt32(UltimoConcurso)-1).ToString();

            //Adiciona no txtLinhasDoUltimoJogo
            string[] LinhasUltomo = SubAnalise.LinhasUltimoJogo.Split('-');
            string[] NameLinhas = new string[6] { "L1", "L2", "L3", "L4", "L5", "L6" };
            for (int i = 0; i < LinhasUltomo.Length; i++)
            {
                string value = LinhasUltomo[i];
                value.Replace(" ", "");
                for (int j = 0; j < 6; j++)
                {
                    if (value == NameLinhas[j])
                    {
                        NameLinhas[j] = "0";
                    }
                }

            }
            string Rows = "";
            for (int i = 0; i < NameLinhas.Length; i++)
            {
                if (NameLinhas[i] != "0")
                {
                    Rows += Rows == "" ? NameLinhas[i] : " - " + NameLinhas[i];
                }
            }
            txtLinhasUltimoJogo.Text = Rows;

            //Adiciona no txtColunasDoUltimoJogo
            string Colu = SubAnalise.ColunasUltimoJogo.Replace("|", "-");
            string[] ColunasUltimo = Colu.Split('-');
            string[] NameColum = new string[10] {"C1", "C2", "C3", "C4", "C5", "C6", "C7","C8", "C9", "C10"};
            for (int i = 0; i < ColunasUltimo.Length; i++)
            {
                string value = ColunasUltimo[i].Replace(" ","");
                value.Replace(" ", "");
                value.Replace(" ", "");
                value.Replace(" ", "");                
                for (int j = 0; j < 10; j++)
                {
                    if (value == NameColum[j])
                    {
                        NameColum[j] = "0";
                    }
                }
            }
            string Coluns = "";
            for (int i = 0; i < NameColum.Length; i++)
            {
                if (NameColum[i] != "0")
                {
                    Coluns += Coluns == "" ? NameColum[i] : " - " + NameColum[i];
                }
            }
            txtColunasUltimoJogo.Text = Coluns;
        }


        //===============================
        // === CLICK NO BOTÃO CANCELA ===
        //===============================
        private void btnCanela_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        //===========================================
        // === FUNÇÃO QUANDO SELECIONA UMA COLUNA ===
        //===========================================
        private void cbmColunas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ColunaSelecionada = cbmColunas.Text;
            if (ColunaSelecionada == "C1")
            {
                txtColunasSelecionadas.Text = txtColunasSelecionadas.Text == "" ? " C1" : txtColunasSelecionadas.Text + "-C1";
                Colunas.Remove("C1");
                ReorganizaCombo();
            }
            else if (ColunaSelecionada == "C2")
            {
                txtColunasSelecionadas.Text = txtColunasSelecionadas.Text == "" ? " C2" : txtColunasSelecionadas.Text + "-C2";
                Colunas.Remove("C2");
                ReorganizaCombo();
            }
            else if (ColunaSelecionada == "C3")
            {
                txtColunasSelecionadas.Text = txtColunasSelecionadas.Text == "" ? " C3" : txtColunasSelecionadas.Text + "-C3";
                Colunas.Remove("C3");
                ReorganizaCombo();
            }
            else if(ColunaSelecionada == "C4")
            {
                txtColunasSelecionadas.Text = txtColunasSelecionadas.Text == "" ? " C4" : txtColunasSelecionadas.Text + "-C4";
                Colunas.Remove("C4");
                ReorganizaCombo();
            }
            else if(ColunaSelecionada == "C5")
            {
                txtColunasSelecionadas.Text = txtColunasSelecionadas.Text == "" ? " C5" : txtColunasSelecionadas.Text + "-C5";
                Colunas.Remove("C5");
                ReorganizaCombo();
            }
            else if(ColunaSelecionada == "C6")
            {
                txtColunasSelecionadas.Text = txtColunasSelecionadas.Text == "" ? " C6" : txtColunasSelecionadas.Text + "-C6";
                Colunas.Remove("C6");
                ReorganizaCombo();
            }
            else if(ColunaSelecionada == "C7")
            {
                txtColunasSelecionadas.Text = txtColunasSelecionadas.Text == "" ? " C7" : txtColunasSelecionadas.Text + "-C7";
                Colunas.Remove("C7");
                ReorganizaCombo();
            }
            else if(ColunaSelecionada == "C8")
            {
                txtColunasSelecionadas.Text = txtColunasSelecionadas.Text == "" ? " C8" : txtColunasSelecionadas.Text + "-C8";
                Colunas.Remove("C8");
                ReorganizaCombo();
            }
            else if(ColunaSelecionada == "C9")
            {
                txtColunasSelecionadas.Text = txtColunasSelecionadas.Text == "" ? " C9" : txtColunasSelecionadas.Text + "-C9";
                Colunas.Remove("C9");
                ReorganizaCombo();
            }
            else if(ColunaSelecionada == "C10")
            {
                txtColunasSelecionadas.Text = txtColunasSelecionadas.Text == "" ? " C10" : txtColunasSelecionadas.Text + "-C10";
                Colunas.Remove("C10");
                ReorganizaCombo();
            }            
        }

        //===========================================
        // === FUNÇÃO QUE REORGANIZA A COMBO BOX  ===
        //===========================================
        public void ReorganizaCombo() //COLUNAS
        {
            cbmColunas.Items.Clear();
            for (int i = 0; i < Colunas.Count; i++)
            {
                cbmColunas.Items.Add(Colunas[i]);
            }

            cbmQtdNumMesmaColuna.Items.Clear();            
            for (int i = 0; i < cbmColunas.Items.Count; i++)
            {
                cbmQtdNumMesmaColuna.Items.Add(cbmColunas.Items[i]);
            }                        
        }

        //===========================================
        // === FUNÇÃO QUE REORGANIZA A COMBO BOX  ===
        //===========================================
        public void ReorganizaCombolLinhas() //LINHAS
        {
            cbmQuaisLinhas.Items.Clear();
            for (int i = 0; i < Linhas.Count; i++)
            {
                cbmQuaisLinhas.Items.Add(Linhas[i]);
            }

            cbmQuantosNumNaLinha.Items.Clear();
            for (int i = 0; i < cbmQuaisLinhas.Items.Count; i++)
            {
                cbmQuantosNumNaLinha.Items.Add(cbmQuaisLinhas.Items[i]);
            }
        }

        //===========================================
        // === FUNÇÃO QUANDO SELECIONA UMA LINHAS ===
        //===========================================
        private void cbmQuaisLinhas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string LinhasSelacionadas = cbmQuaisLinhas.Text;
            if (LinhasSelacionadas == "L1")
            {
                txtLinhasSelecionadas.Text = txtLinhasSelecionadas.Text == "" ? "L1" : txtLinhasSelecionadas.Text + "-L1";
                Linhas.Remove("L1");
                ReorganizaCombolLinhas();
            }
            else if (LinhasSelacionadas == "L2")
            {
                txtLinhasSelecionadas.Text = txtLinhasSelecionadas.Text == "" ? "L2" : txtLinhasSelecionadas.Text + "-L2";
                Linhas.Remove("L2");
                ReorganizaCombolLinhas();
            }
            else if (LinhasSelacionadas == "L3")
            {
                txtLinhasSelecionadas.Text = txtLinhasSelecionadas.Text == "" ? "L3" : txtLinhasSelecionadas.Text + "-L3";
                Linhas.Remove("L3");
                ReorganizaCombolLinhas();
            }
            else if (LinhasSelacionadas == "L4")
            {
                txtLinhasSelecionadas.Text = txtLinhasSelecionadas.Text == "" ? "L4" : txtLinhasSelecionadas.Text + "-L4";
                Linhas.Remove("L4");
                ReorganizaCombolLinhas();
            }
            else if (LinhasSelacionadas == "L5")
            {
                txtLinhasSelecionadas.Text = txtLinhasSelecionadas.Text == "" ? "L5" : txtLinhasSelecionadas.Text + "-L5";
                Linhas.Remove("L5");
                ReorganizaCombolLinhas();
            }
            else if (LinhasSelacionadas == "L6")
            {
                txtLinhasSelecionadas.Text = txtLinhasSelecionadas.Text == "" ? "L6" : txtLinhasSelecionadas.Text + "-L6";
                Linhas.Remove("L6");
                ReorganizaCombolLinhas();
            }
        }
        
        //=============================================
        // === FUNÇÃO CLICK NO BOTÃO OK DA GRIDVIEW ===
        //=============================================
        private void btnOK_Click(object sender, EventArgs e)
        {
            int NumerosInserir = Convert.ToInt32(txtQtdNum.Text);
            int CalcNuns = 0;
            int TodDez = Convert.ToInt32(txtTotalJogo.Text);

            for (int i = 0; i < dgvQtdNumeros.ColumnCount; i++)
            {
                CalcNuns += Convert.ToInt32(dgvQtdNumeros.Rows[0].Cells[i].Value);
            }
            if (NumerosInserir + CalcNuns <= TodDez)
            {
                if (txtQtdNum.Text == "" || cbmQtdNumMesmaColuna.Text == "")
                {
                    MessageBox.Show("Opss! O Números não podem ser: 0, Negativos ou maior que "+TodDez.ToString(), "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQtdNum.Text = "1";
                    return;
                }
                for (int i = 0; i < dgvQtdNumeros.ColumnCount; i++)
                {
                    string name = dgvQtdNumeros.Columns[i].HeaderText;
                    if (name == cbmQtdNumMesmaColuna.Text)
                    {
                        MessageBox.Show("Opss! Você já adicionou essa Coluna!", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                dgvQtdNumeros.Columns.Add(cbmQtdNumMesmaColuna.Text, cbmQtdNumMesmaColuna.Text);
                dgvQtdNumeros.Rows[0].Cells[dgvQtdNumeros.ColumnCount - 1].Value = txtQtdNum.Text;
            }
            else
            {
                MessageBox.Show("O Número a inserir é maior que o total de Dezenas, você só pode inserir "+(TodDez - CalcNuns).ToString()+ " número(s).", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnOkLinha_Click(object sender, EventArgs e)
        {
            int NumerosInserir = Convert.ToInt32(txtQtdNumLinha.Text);
            int CalcNuns = 0;
            int TodDez = Convert.ToInt32(txtTotalJogo.Text);

            for (int i = 0; i < dgvQtdNumLinha.ColumnCount; i++)
            {
                CalcNuns += Convert.ToInt32(dgvQtdNumLinha.Rows[0].Cells[i].Value);
            }
            if (NumerosInserir + CalcNuns <= TodDez)
            {
                if (txtQtdNumLinha.Text == "" || cbmQuantosNumNaLinha.Text == "")
                {
                    MessageBox.Show("Opss! O Números não podem ser: 0, Negativos ou maior que " + TodDez.ToString(), "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQtdNumLinha.Text = "1";
                    return;
                }
                for (int i = 0; i < dgvQtdNumLinha.ColumnCount; i++)
                {
                    string name = dgvQtdNumLinha.Columns[i].HeaderText;
                    if (name == cbmQuantosNumNaLinha.Text)
                    {
                        MessageBox.Show("Opss! Você já adicionou essa Linha!", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                dgvQtdNumLinha.Columns.Add(cbmQuantosNumNaLinha.Text, cbmQuantosNumNaLinha.Text);
                dgvQtdNumLinha.Rows[0].Cells[dgvQtdNumLinha.ColumnCount - 1].Value = txtQtdNumLinha.Text;
            }
            else
            {
                MessageBox.Show("O Número a inserir é maior que o total de Dezenas, você só pode inserir " + (TodDez - CalcNuns).ToString() + " número(s).", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //=================================================
        // === FUNÇÃO CHAMADA QUANCO O TEXTO É ALTERADO ===
        //=================================================
        private void txtQtdNum_TextChanged(object sender, EventArgs e)
        {
            if (txtQtdNum.Text != "")
            {
                if (Convert.ToInt32(txtQtdNum.Text) > 6 || Convert.ToInt32(txtQtdNum.Text) < 1)
                {
                    MessageBox.Show("Opss! O Números não podem ser: 0, Negativos ou maior que 6", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQtdNum.Text = "1";
                }
            }
        }

        //=====================================
        // === FUNÇÃO CLICK NO BOTAO LIMPAR ===
        //=====================================        
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            dgvQtdNumeros.Rows.Clear();
            dgvQtdNumeros.Columns.Clear();
            cbmColunas.Items.Clear();
            cbmQuaisLinhas.Items.Clear();
            cbmQtdNumMesmaColuna.Items.Clear();

            foreach (Control TB in Controls)
            {
                if (TB is TextBox)
                {
                    TB.Text = "";                    
                }
                else if (TB is MaskedTextBox)
                {
                    TB.Text = "";
                }
            }

            Colunas.Clear();
            Linhas.Clear(); 

            Colunas.Add("C1");
            Colunas.Add("C2");
            Colunas.Add("C3");
            Colunas.Add("C4");
            Colunas.Add("C5");
            Colunas.Add("C6");
            Colunas.Add("C7");
            Colunas.Add("C9");
            Colunas.Add("C10");

            //Adiciona elementos Linhas
            Linhas.Add("L1");
            Linhas.Add("L2");
            Linhas.Add("L3");
            Linhas.Add("L4");
            Linhas.Add("L5");
            Linhas.Add("L6");

            ReorganizaCombo();
            ReorganizaCombolLinhas();
        }

        //===============================
        // === CLICK NO BOTÃO CANCELA ===
        //===============================
        public void MessageBoxShow()
        {
            MessageBox.Show("Preecha todos os campos para proseguir...", "Opiss", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //============================
        // === CLICK NO BOTÃO SAIR ===
        //============================
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //=================================
        // === CLICK NO BOTÃO MINIMIZAR ===
        //=================================
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //=======================
        // === EVENTOS CHANGE ===
        //=======================        
        private void txtColunasSelecionadas_TextChanged(object sender, EventArgs e)
        {
            string[] ExcluirColunas = txtColunasSelecionadas.Text.Split('-');
            for (int i = 0; i < dgvQtdNumeros.ColumnCount; i++)
            {
                string HeaderText = dgvQtdNumeros.Columns[i].HeaderText;
                for (int j = 0; j < ExcluirColunas.Length; j++)
                {
                    string ColumnExcluir = ExcluirColunas[j].Replace(" ","");
                    if (HeaderText == ColumnExcluir)
                    {
                        dgvQtdNumeros.Columns.Remove(ColumnExcluir);
                    }
                }
            }

        }
        private void txtLinhasSelecionadas_TextChanged(object sender, EventArgs e)
        {
            string[] ExcluirLinhas = txtLinhasSelecionadas.Text.Split('-');
            for (int i = 0; i < dgvQtdNumLinha.ColumnCount; i++)
            {
                string HeaderText = dgvQtdNumLinha.Columns[i].HeaderText;
                for (int j = 0; j < ExcluirLinhas.Length; j++)
                {
                    string LinhasExcluir = ExcluirLinhas[j].Replace(" ","");
                    if (HeaderText == LinhasExcluir)
                    {
                        dgvQtdNumLinha.Columns.Remove(LinhasExcluir);
                    }
                }
            }
        }   
        private void txtQtdDeznasTotais_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQtdDeznasTotais.Text) || txtQtdDeznasTotais.Text == "__")
            {
                MessageBox.Show("O Campo Dezenas Totais não pode estar vazio!", "Opss", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                txtTotalJogo.Text = txtQtdDeznasTotais.Text;
            }
        }
        private void txtRepetNumJogo_TextChanged(object sender, EventArgs e)
        {            
            string[] DezenasUltimoJogo = txtDezenasUltimoJogo.Text.Split('-');
            string Esta = "";
            string NoEsta = "";

            //Verifica se os números já foram excluidos               
            int ConAnt = Convert.ToInt16(txtNumConcursoAnterior.Text)+1;
            bool AchouNum = false;
            for(ConAnt -= 1; AchouNum == false; ConAnt--)
            {
                string[] D = ApiMega.GetDezenaConcurso(ConAnt);
                for (int i = 0; i < D.Length; i++)
                {
                    for (int j = 0; j < PoluacaoRest.Length; j++)
                    {
                        if (Convert.ToInt32(D[i]) == Convert.ToInt32(PoluacaoRest[j].ToString()))
                        {
                            Esta += Esta == "" ? PoluacaoRest[j].ToString() : "-" + PoluacaoRest[j].ToString();
                            j = PoluacaoRest.Length;
                            AchouNum = true;
                        }
                        else if (j == PoluacaoRest.Length - 1)
                        {
                            NoEsta += NoEsta == "" ? D[i].ToString() : "-" + D[i].ToString();
                        }
                    }
                }

                //if (AchouNum == true)
                //{
                //    string[] ReptirD = Esta.Split('-');
                //    //se o número possivel for mais que o necessario pegar os dois primeiros
                //    txtSugestao.Text = Esta;
                //}
            }                       
        }
        private void btnAplicarDefinicoes_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQtdDeznasTotais.Text) && txtQtdDeznasTotais.Text != "0" && txtQtdDeznasTotais.Text != "__" && !string.IsNullOrEmpty(txtUsarQauntosNum.Text) && txtUsarQauntosNum.Text != "__"  && !string.IsNullOrEmpty(txtNaoSairam.Text) && txtNaoSairam.Text != "0" && !string.IsNullOrEmpty(txtQtdPares.Text) && txtQtdPares.Text != "__" && !string.IsNullOrEmpty(txtQtdImpares.Text) && txtQtdImpares.Text != "__")
            {
                int Sairam = cbNumSairam.Checked == true ? Convert.ToInt32(txtUsarQauntosNum.Text) : 0;
                int NSairam = cbNumNotOut.Checked == true ? Convert.ToInt32(txtNaoSairam.Text) : 0;
                int DezenasTotais = Convert.ToInt32(txtQtdDeznasTotais.Text);
                int Impares = Convert.ToInt32(txtQtdImpares.Text);
                int Pares = Convert.ToInt32(txtQtdPares.Text);                
                ImpParam = "Impares: " + Impares.ToString() + ", Pares: " + Pares.ToString() + ", NumSairam: " + Sairam.ToString() + ", Num Não Sairam: " + NSairam.ToString();
                if (cbNumSairam.Checked && cbNumNotOut.Checked && Sairam + NSairam == DezenasTotais)
                {
                    if (Impares + Pares == DezenasTotais)
                    {
                        txtUsarQSairam.Text = Sairam.ToString();
                        txtUsarQNSairam.Text = NSairam.ToString();
                        txtTotalJogo.Text = DezenasTotais.ToString();
                        txtImparesNoUse.Text = Impares.ToString();
                        txtParesNoUse.Text = Pares.ToString();
                        gbExclusao.Enabled = true;
                    }
                    else
                    {
                        txtUsarQSairam.Text = (0).ToString();
                        txtUsarQNSairam.Text = (0).ToString();
                        txtTotalJogo.Text = (0).ToString();
                        txtImparesNoUse.Text = (0).ToString();
                        txtParesNoUse.Text = (0).ToString();
                        MessageBox.Show("Os valores dos campos não estão de acordo com o total de Dezenas!", "Opss", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else if (cbNumSairam.Checked && !cbNumNotOut.Checked)
                {
                    //Fazer ação
                }
                else if (!cbNumSairam.Checked && cbNumNotOut.Checked)
                {
                    //Fazer ação
                }
                else if (!cbNumSairam.Checked && !cbNumNotOut.Checked)
                {
                    if (Impares + Pares == DezenasTotais)
                    {
                        txtUsarQSairam.Text = Sairam.ToString();
                        txtUsarQNSairam.Text = NSairam.ToString();
                        txtTotalJogo.Text = DezenasTotais.ToString();
                        txtImparesNoUse.Text = Impares.ToString();
                        txtParesNoUse.Text = Pares.ToString();
                        gbExclusao.Enabled = true;
                    }
                    else
                    {
                        txtUsarQSairam.Text = (0).ToString();
                        txtUsarQNSairam.Text = (0).ToString();
                        txtTotalJogo.Text = (0).ToString();
                        txtImparesNoUse.Text = (0).ToString();
                        txtParesNoUse.Text = (0).ToString();
                        MessageBox.Show("Os valores dos campos não estão de acordo com o total de Dezenas!", "Opss", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            else
            {
                MessageBox.Show("Todos os campos devem estar preechidos!", "Opss", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }    
        private void cbmExcluirColunas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmExcluirColunas.SelectedIndex == 0)//SIM
            {
                cbmColunas.Visible = true;
                txtColunasSelecionadas.Visible = true;
            }
            else if(cbmExcluirColunas.SelectedIndex == 1)//NÂO
            {
                cbmColunas.Visible = false;
                txtColunasSelecionadas.Visible = false;
                txtColunasSelecionadas.Text = "";
                cbmColunas.Items.Clear();
                Colunas.Clear();
                cbmColunas.Items.Add("C1");
                cbmColunas.Items.Add("C2");
                cbmColunas.Items.Add("C3");
                cbmColunas.Items.Add("C4");
                cbmColunas.Items.Add("C5");
                cbmColunas.Items.Add("C6");
                cbmColunas.Items.Add("C7");
                cbmColunas.Items.Add("C9");
                cbmColunas.Items.Add("C10");
                Colunas.Add("C1");
                Colunas.Add("C2");
                Colunas.Add("C3");
                Colunas.Add("C4");
                Colunas.Add("C5");
                Colunas.Add("C6");
                Colunas.Add("C7");
                Colunas.Add("C9");
                Colunas.Add("C10");
            }
        }
        private void cbmExcluirLinhas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmExcluirLinhas.SelectedIndex == 0)//SIM
            {
                cbmQuaisLinhas.Visible = true;
                txtLinhasSelecionadas.Visible = true;
            }
            else if (cbmExcluirLinhas.SelectedIndex == 1)//NÂO
            {
                cbmQuaisLinhas.Visible = false;
                txtLinhasSelecionadas.Visible = false;
                txtLinhasSelecionadas.Text = "";
                Linhas.Clear();
                cbmQuaisLinhas.Items.Clear();
                cbmQuaisLinhas.Items.Add("L1");
                cbmQuaisLinhas.Items.Add("L2");
                cbmQuaisLinhas.Items.Add("L3");
                cbmQuaisLinhas.Items.Add("L4");
                cbmQuaisLinhas.Items.Add("L5");
                cbmQuaisLinhas.Items.Add("L6");
                Linhas.Add("L1");
                Linhas.Add("L2");
                Linhas.Add("L3");
                Linhas.Add("L4");
                Linhas.Add("L5");
                Linhas.Add("L6");
            }
        }
        private void cbmExcluirRepetidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmExcluirRepetidos.SelectedIndex == 0)//SIM
            {
                cbmCondicoes.Visible = true;
                txtExcluirNumRepet.Visible = true;
            }
            else if (cbmExcluirRepetidos.SelectedIndex == 1)//NÂO
            {
                cbmCondicoes.Visible = false;
                txtExcluirNumRepet.Visible = false;
            }
        }
        private void cbmSelecionarLinhas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmSelecionarLinhas.SelectedIndex == 0 && pnlSelColunas.Visible == false)//SIM
            {
                pnlSelLinhas.BringToFront();
                pnlSelLinhas.Visible = true;
                pnlSelLinhas.Location = new Point(11, 166);                
            }
            else if(cbmSelecionarLinhas.SelectedIndex == 0 && pnlSelColunas.Visible == true)
            {
                pnlSelLinhas.BringToFront();
                pnlSelLinhas.Visible = true;
                pnlSelLinhas.Location = new Point(11, 268);
            }
            else if(cbmSelecionarLinhas.SelectedIndex == 1)//NÂO
            {
                pnlSelLinhas.Visible = false;
            }
        }
        private void cbmSelecionarColunas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmSelecionarColunas.SelectedIndex == 0 && pnlSelLinhas.Visible == false)//SIM
            {
                pnlSelColunas.BringToFront();
                pnlSelColunas.Visible = true;
                pnlSelColunas.Location = new Point(11, 166);
            }
            else if (cbmSelecionarColunas.SelectedIndex == 0 && pnlSelLinhas.Visible == true)
            {
                pnlSelColunas.BringToFront();
                pnlSelColunas.Visible = true;
                pnlSelColunas.Location = new Point(11, 268);
                pnlSelLinhas.Location = new Point(11, 166);
            }
            else if (cbmSelecionarColunas.SelectedIndex == 1)//NÂO
            {
                pnlSelColunas.Visible = false;
            }
        }
        private void cbmEscolherNumEspecifico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmEscolherNumEspecifico.SelectedIndex == 0)//Sim
            {
                lblQualNumEspecifico.Visible = true;
                cbmNumRestantes.Visible = true;

                string[] PRest = txtPopulacao.Text.Split('-');
                for (int i = 0; i < PRest.Length; i++)
                {
                    cbmNumRestantes.Items.Add(PRest[i].Replace(" ", ""));
                }
            }
            else if (cbmEscolherNumEspecifico.SelectedIndex == 1)//Não
            {
                lblQualNumEspecifico.Visible = false;
                cbmNumRestantes.Visible = false;
                cbmNumRestantes.Items.Clear();
            }
        }

        //========================================
        // === CLICK NO BOTÃO APLICAR EXCLUSÃO ===
        //========================================                
        private void btnAplicarExclusao_Click(object sender, EventArgs e)
        {
            string[] NameLinhas = new string[6] { "L1", "L2", "L3", "L4", "L5", "L6" };
            string[] NameColum = new string[10] { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10" };

            int ExcluirRepetidos = 0;
            string CondicaoRepetidos = cbmCondicoes.Text;
            if (txtExcluirNumRepet.Text != "") { ExcluirRepetidos = int.Parse(txtExcluirNumRepet.Text); }
            string NumerosRetirar = "";

            int DezTod = Convert.ToInt32(txtTotalJogo.Text);
            int CalcNuns = 0;

            //Excluir Linhas
            if (cbmExcluirLinhas.SelectedIndex == 0 && string.IsNullOrEmpty(txtLinhasSelecionadas.Text) == false)
            {
                string LE = txtLinhasSelecionadas.Text.Replace(" ", ""); ;
                string[] ExcluirLinhas = LE.Split('-');
                DelLinhasParam = ("Excluir as linha: " + LE);
                //Excluir Linhas                           
                for (int y = 0; y < ExcluirLinhas.Length; y++)
                {
                    for (int j = 0; j < 6; j++)//Linhas
                    {
                        string Value = ExcluirLinhas[y].Replace(" ", "");
                        if (Value == NameLinhas[j])
                        {
                            for (int i = 0; i < 10; i++)//Colunas
                            {
                                NumerosRetirar += NumerosRetirar == "" ? Tabela[i, j].ToString() : "-" + Tabela[i, j].ToString();
                            }
                        }

                    }
                }
            }

            if (cbmExcluirColunas.SelectedIndex == 0 && string.IsNullOrEmpty(txtColunasSelecionadas.Text) == false)
            {
                string LE = txtColunasSelecionadas.Text.Replace(" ", "");
                string[] ExcluirColunas = LE.Split('-');
                DelColunsParam = ("Excluir as colunas: " + LE);
                //Excluir Colunas
                for (int y = 0; y < ExcluirColunas.Length; y++)
                {
                    bool yes = false;
                    for (int i = 0; i < 10 && yes == false; i++)//Colunas
                    {
                        string Value = ExcluirColunas[y].Replace(" ", "");
                        if (Value == NameColum[i])
                        {
                            for (int j = 0; j < 6; j++)//Linhas
                            {
                                NumerosRetirar += NumerosRetirar == "" ? Tabela[i, j].ToString() : "-" + Tabela[i, j].ToString();
                            }
                            yes = true;
                        }
                    }
                }

            }

            //Secionar Linhas
            if (cbmSelecionarLinhas.SelectedIndex == 0)
            {
                //Verificação
                //CalcNuns = 0;
                //for (int i = 0; i < dgvQtdNumLinha.ColumnCount; i++)
                //{
                //    CalcNuns += Convert.ToInt32(dgvQtdNumLinha.Rows[0].Cells[i].Value);
                //}
                //if (CalcNuns < DezTod)
                //{
                //    MessageBox.Show("Os valores das Linhas Selecionadas não coincidem com o total de Dezenas, falta inserir " + (DezTod - CalcNuns).ToString() + " número(s) em alguma coluna.", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //    return;
                //}

                string Colparam = "";
                string LE = "";
                int[] RowsNotSelected = new int[6];
                string[] NLinhas = new string[6] { "L1", "L2", "L3", "L4", "L5", "L6" };
                for (int i = 0; i < dgvQtdNumLinha.ColumnCount; i++)
                {
                    string HeaderText = dgvQtdNumLinha.Columns[i].HeaderText;                    
                    for (int j = 0; j < 6; j++)
                    {
                        string L = NLinhas[j].Replace(" ", "");
                        if (HeaderText == L)
                        {
                            RowsNotSelected[j] = 1;
                        }
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (RowsNotSelected[i] == 0)
                    {
                        LE += "-" + NLinhas[i];
                    }
                }

                string[] ExcluirLinhas = LE.Split('-');
                //Excluir Linhas                           
                for (int y = 0; y < ExcluirLinhas.Length; y++)
                {
                    for (int j = 0; j < 6; j++)//Linhas
                    {
                        string Value = ExcluirLinhas[y].Replace(" ", "");
                        if (Value == NameLinhas[j])
                        {
                            for (int i = 0; i < 10; i++)//Colunas
                            {
                                NumerosRetirar += NumerosRetirar == "" ? Tabela[i, j].ToString() : "-" + Tabela[i, j].ToString();
                            }
                        }
                    }
                }
            }
            //Excluir Colunas
            if (cbmSelecionarColunas.SelectedIndex == 0)
            {
                ////Verificação
                //CalcNuns = 0;
                //for (int i = 0; i < dgvQtdNumeros.ColumnCount; i++)
                //{
                //    CalcNuns += Convert.ToInt32(dgvQtdNumeros.Rows[0].Cells[i].Value);
                //}
                //if (CalcNuns < DezTod)
                //{
                //    MessageBox.Show("Os valores das Colunas Selecionadas não coincidem com o total de Dezenas, falta inserir " + (DezTod - CalcNuns).ToString() + " número(s) em alguma coluna.", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //    return;
                //}

                string LE = "";
                int[] ColumnsNotSelected = new int[10];
                string[] NColum = new string[10] { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10" };
                for (int i = 0; i < dgvQtdNumeros.ColumnCount; i++)
                {
                    string HeaderText = dgvQtdNumeros.Columns[i].HeaderText;
                    for (int j = 0; j < 10; j++)
                    {
                        string L = NColum[j].Replace(" ", "");
                        if (HeaderText == L)
                        {
                            ColumnsNotSelected[j] = 1;
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    if (ColumnsNotSelected[i] == 0)
                    {
                        LE += "-" + NColum[i];
                    }
                }

                string[] ExcluirColunas = LE.Split('-');

                //Excluir Colunas
                for (int y = 0; y < ExcluirColunas.Length; y++)
                {
                    bool yes = false;
                    for (int i = 0; i < 10 && yes == false; i++)//Colunas
                    {
                        string Value = ExcluirColunas[y].Replace(" ", "");
                        if (Value == NameColum[i])
                        {
                            for (int j = 0; j < 6; j++)//Linhas
                            {
                                NumerosRetirar += NumerosRetirar == "" ? Tabela[i, j].ToString() : "-" + Tabela[i, j].ToString();
                            }
                            yes = true;
                        }
                    }
                }

            }

            //Excluir números repeditos
            if (cbmExcluirRepetidos.SelectedIndex == 0)
            {
                //Excluir números repetidos mais que X             
                
                for (int i = 0; i < DezenasRepetidas.Length; i++)
                {
                    if (DezenasRepetidas[i] > ExcluirRepetidos && CondicaoRepetidos == ">") // >
                    {
                        if (i == 0) ReptParam = ("Excluir repetidos > que" + ExcluirRepetidos.ToString());
                        NumerosRetirar += NumerosRetirar == "" ? ResultadoFiltro[i].ToString() : "-" + ResultadoFiltro[i].ToString();
                    }
                    else if (DezenasRepetidas[i] >= ExcluirRepetidos && CondicaoRepetidos == ">=") // >=
                    {
                        if(i == 0) ReptParam = ("Excluir repetidos >= que" + ExcluirRepetidos.ToString());
                        NumerosRetirar += NumerosRetirar == "" ? ResultadoFiltro[i].ToString() : "-" + ResultadoFiltro[i].ToString();
                    }
                    else if (DezenasRepetidas[i] == ExcluirRepetidos && CondicaoRepetidos == "=") // ==
                    {
                        if (i == 0) ReptParam = ("Excluir repetidos = a" + ExcluirRepetidos.ToString());
                        NumerosRetirar += NumerosRetirar == "" ? ResultadoFiltro[i].ToString() : "-" + ResultadoFiltro[i].ToString();
                    }
                }

            }

            //Exclue as linhas, colunas e números repetidos
            if (!string.IsNullOrEmpty(NumerosRetirar))
            {
                //Converte o Array em Inteiro
                string[] CopyNumerosRetirar = NumerosRetirar.Split('-');
                int[] NumerosRetirarInt = new int[CopyNumerosRetirar.Length];
                for (int i = 0; i < CopyNumerosRetirar.Length; i++)
                {
                    NumerosRetirarInt[i] = int.Parse(CopyNumerosRetirar[i]);
                }
                Array.Sort(NumerosRetirarInt);

                //Excluios números repetidos do vetor
                for (int i = 0; i < NumerosRetirarInt.Length; i++)
                {
                    int posicao = SubAnalise.ArraySeach(NumerosRetirarInt, NumerosRetirarInt[i]);

                    for (int j = i + 1; j < NumerosRetirarInt.Length; j++)
                    {
                        if (NumerosRetirarInt[posicao] == NumerosRetirarInt[j]) NumerosRetirarInt[j] = -1;
                    }
                }

                //Conta Quantos Números repetidos
                int repetidos = 0;
                for (int i = 0; i < NumerosRetirarInt.Length; i++)
                {
                    if (NumerosRetirarInt[i] == -1) repetidos++;
                }

            
                //Retira os filtra as dezenas                                        
                for (int i = 0; i < NumerosRetirarInt.Length; i++)
                {
                    for (int j = 0; j < 60; j++)
                    {
                        if (NumerosRetirarInt[i] == int.Parse(ResultadoFiltro[j].ToString()))
                        {
                            ResultadoFiltro[j] = -1;
                        }
                    }
                }

                //Conta quantos -1 tem
                repetidos = 0;
                for (int i = 0; i < ResultadoFiltro.Length; i++)
                {
                    if (int.Parse(ResultadoFiltro[i].ToString()) == -1) repetidos++;
                }
                Array.Sort(ResultadoFiltro);
                Array.Reverse(ResultadoFiltro);

                //Retira -1
                object[] TabelaFiltrada1 = new object[ResultadoFiltro.Length - repetidos];
                for (int i = 0; i < ResultadoFiltro.Length - repetidos; i++)
                {
                    TabelaFiltrada1[i] = ResultadoFiltro[i];
                }

                string txt = string.Join(" - ", TabelaFiltrada1);
                int populacaoRestante = TabelaFiltrada1.Length;

                txtRestante.Text = populacaoRestante.ToString();
                txtPopulacao.Text = txt;

                PoluacaoRest = TabelaFiltrada1;
            }

            string ColunasEParam = "";
            //Selecionar Colunas e ver quias irão ficar com X numeros
            if (cbmSelecionarColunas.SelectedIndex == 0)
            {
                string[] NaColum = new string[10] { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10" };
                for (int i = 0; i < dgvQtdNumeros.ColumnCount; i++)
                {
                    string Linha = dgvQtdNumeros.Columns[i].HeaderText;
                    Linha = Linha.Replace(" ", "");
                    for (int j = 0; j < 10; j++)
                    {
                        string Colu = NaColum[j];
                        if (Linha == Colu)
                        {
                            ColunasSelecionadas[0] = Convert.ToInt32(dgvQtdNumeros.Rows[0].Cells[i].Value);
                            ColunasEParam += ColunasEParam == "" ? Colu + " com " + ColunasSelecionadas[0].ToString() : ", " + Colu + " com " + ColunasSelecionadas[0].ToString();
                        }
                    }
                }
                ColunassParam = (ColunasEParam); 
            }
            
            string LinhaParam = "";
            //Selecionar linhas e ver quias irão ficar com X numeros
            if (cbmSelecionarLinhas.SelectedIndex == 0)
            {
                for (int i = 0; i < dgvQtdNumLinha.ColumnCount; i++)
                {
                    string Linha = dgvQtdNumLinha.Columns[i].HeaderText;
                    Linha = Linha.Replace(" ", "");
                    if (Linha == "L1")
                    {
                        LinhasSelecionadas[0] = Convert.ToInt32(dgvQtdNumLinha.Rows[0].Cells[i].Value);
                        LinhaParam += LinhaParam == "" ? "L1 com " + LinhasSelecionadas[0].ToString() : ", L1 com " + LinhasSelecionadas[0].ToString();
                    }
                    else if (Linha == "L2")
                    {
                        LinhasSelecionadas[1] = Convert.ToInt32(dgvQtdNumLinha.Rows[0].Cells[i].Value);
                        LinhaParam += LinhaParam == "" ? "L2 com " + LinhasSelecionadas[0].ToString() : ", L2 com " + LinhasSelecionadas[0].ToString();
                    }
                    else if (Linha == "L3")
                    {
                        LinhasSelecionadas[2] = Convert.ToInt32(dgvQtdNumLinha.Rows[0].Cells[i].Value);
                        LinhaParam += LinhaParam == "" ? "L3 com " + LinhasSelecionadas[0].ToString() : ", L3 com " + LinhasSelecionadas[0].ToString();
                    }
                    else if (Linha == "L4")
                    {
                        LinhasSelecionadas[3] = Convert.ToInt32(dgvQtdNumLinha.Rows[0].Cells[i].Value);
                        LinhaParam += LinhaParam == "" ? "L4 com " + LinhasSelecionadas[0].ToString() : ", L4 com " + LinhasSelecionadas[0].ToString();
                    }
                    else if (Linha == "L5")
                    {
                        LinhasSelecionadas[4] = Convert.ToInt32(dgvQtdNumLinha.Rows[0].Cells[i].Value);
                        LinhaParam += LinhaParam == "" ? "L5 com " + LinhasSelecionadas[0].ToString() : ", L5 com " + LinhasSelecionadas[0].ToString();
                    }
                    else if (Linha == "L6")
                    {
                        LinhasSelecionadas[5] = Convert.ToInt32(dgvQtdNumLinha.Rows[0].Cells[i].Value);
                        LinhaParam += LinhaParam == "" ? "L6 com " + LinhasSelecionadas[0].ToString() : ", L6 com " + LinhasSelecionadas[0].ToString();
                    }
                }

                LinhassParam = (LinhaParam);
            }
            
            btnAplicarExclusao.Enabled = false;
            gbFixar.Enabled = true;                        
        }

        //=================================
        // === CLICK NOS BOTÃOES LIMPAR ===
        //=================================
        private void btnLimparBgDefinicoes_Click(object sender, EventArgs e)
        {
            txtQtdDeznasTotais.Text = "0";
            txtUsarQauntosNum.Text = "0";
            txtNaoSairam.Text = "0";
            txtQtdPares.Text = "0";
            txtQtdImpares.Text = "0";
            txtUsarQSairam.Text = "0";
            txtUsarQNSairam.Text = "0";
            txtParesNoUse.Text = "0";
            txtImparesNoUse.Text = "0";
            txtTotalJogo.Text = "0";
            gbExclusao.Enabled = false;
            gbFixar.Enabled = false;
        }
        private void btnLimparGbExclusao_Click(object sender, EventArgs e)
        {
            cbmColunas.Visible = false;
            txtColunasSelecionadas.Visible = false;
            txtColunasSelecionadas.Text = "";
            cbmQuaisLinhas.Visible = false;
            txtLinhasSelecionadas.Visible = false;
            txtLinhasSelecionadas.Text = "";
            cbmCondicoes.Visible = false;
            txtExcluirNumRepet.Visible = false;
            txtExcluirNumRepet.Text = "";
            pnlSelColunas.Visible = false;
            pnlSelLinhas.Visible = false;
            dgvQtdNumeros.Rows.Clear();
            dgvQtdNumeros.Columns.Clear();
            dgvQtdNumLinha.Columns.Clear();
            dgvQtdNumLinha.Rows.Clear();
            btnAplicarExclusao.Enabled = true;
            RepreecheCbm();

            Array.Clear(ResultadoFiltro, 0, ResultadoFiltro.Length);
            int Cont = 1;
            for (int i = 0; i < ResultadoFiltro.Length; i++)
            {
                ResultadoFiltro[i] = Cont;
                Cont++;
            }
            txtPopulacao.Text = string.Join(" - ", ResultadoFiltro);
            txtRestante.Text = "60";
        }


        //===========================================
        // === FUNÇÃO CLICK NO BOTÃO MOSTRA JOGOS ===
        //===========================================
        private void ptcBuildGame_Click(object sender, EventArgs e)
        {
            btnFiltrar_Click(sender, e);
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            impar = Convert.ToInt32(txtImparesNoUse.Text);
            par = Convert.ToInt32(txtParesNoUse.Text);
            DezSairam = Convert.ToInt32(txtUsarQSairam.Text);
            DezNotSairam = Convert.ToInt32(txtUsarQNSairam.Text);
            Comb = Convert.ToInt32(txtTotalJogo.Text);
            List<string> pRestSairam = new List<string>();
            List<string> pRestNS = new List<string>();
            string DezenasFixas = "";

            //Seleciona um número do ultimo jogo
            if (cbmRepetirNumerosUltimoJogo.SelectedIndex == 0)//Sim
            {
                NumLastGamaParam = ("Não adicionar número do ultimo jogo");
                Banco_de_Dados db = new Banco_de_Dados();
                int numC = Convert.ToInt32(txtNumConcursoAnterior.Text);
                bool yes = false;                
                for (int i = 0; yes == false && i < Convert.ToInt32(UltimoConcurso); i++)
                {
                    Concurso concurso = db.Buscar(numC - i);
                    string[] UltimoJogo = concurso.Dezenas;
                    for (int t = 0; t < UltimoJogo.Length; t++)
                    {
                        string Dezena = UltimoJogo[t].Replace(" ", "");
                        for (int j = 0; j < PoluacaoRest.Length; j++)
                        {
                            string PR = PoluacaoRest[j].ToString().Replace(" ", "");
                            if (Dezena == PR)
                            {
                                DezenasFixas += DezenasFixas == "" ? Dezena : "-" + Dezena;
                                j = PoluacaoRest.Length;
                                t = UltimoJogo.Length;
                                yes = true;
                            }
                        }
                    }
                }
            }
            else if (cbmRepetirNumerosUltimoJogo.SelectedIndex == 1)//Não
            {
                NumLastGamaParam = ("Não adicionar número do ultimo jogo");
                string[] retDezenas = txtDezenasUltimoJogo.Text.Split('-');
                int[] retIntDezenas = new int[retDezenas.Length];
                object[] CopyPopulacao = PoluacaoRest;

                //Converte para inteiro
                for (int i = 0; i < retDezenas.Length; i++)
                {
                    retIntDezenas[i] = Convert.ToInt32(retDezenas[i]);
                }

                //Retira do restante da população o números do ultimo jogo
                int repet = 0;
                for (int i = 0; i < retIntDezenas.Length; i++)
                {
                    int index = SubAnalise.ArraySeach(retIntDezenas, retIntDezenas[i]);

                    for (int j = index; j < CopyPopulacao.Length; j++)
                    {
                        if (Convert.ToInt32(CopyPopulacao[j]) == retIntDezenas[i])
                        {
                            CopyPopulacao[j] = -1;
                            j = CopyPopulacao.Length;
                            repet++;
                        }
                    }
                }
                Array.Sort(CopyPopulacao);
                Array.Reverse(CopyPopulacao);

                //Retira o -1
                object[] NovaCopyPopulacao = new object[CopyPopulacao.Length - repet];
                for (int i = 0; i < NovaCopyPopulacao.Length; i++)
                {
                    NovaCopyPopulacao[i] = CopyPopulacao[i];
                }

                string p = string.Join(" - ", NovaCopyPopulacao);
                txtPopulacao.Text = p;
                txtRestante.Text = NovaCopyPopulacao.Length.ToString();
                PoluacaoRest = NovaCopyPopulacao;
            }

            //Seleciona a mais atrasada
            if (cbmSelecionarAtrasada.SelectedIndex == 0)//Sim
            {
                DezenasAtrasadassParam = ("Sim colocar uma Dezena mais atrasada");
                int[] AtrasadasDeze = new int[DezenasAtrasadas.Length];
                Array.Copy(DezenasAtrasadas, AtrasadasDeze, AtrasadasDeze.Length);
                List<int> maiorValor = new List<int>();

                for (int q = 0; q < 60; q++)
                {
                    int valorM = -1;
                    int indexM = -1;
                    int value = AtrasadasDeze[0];
                    for (int j = 1; j < AtrasadasDeze.Length; j++)
                    {
                        if (value > AtrasadasDeze[j])
                        {
                            if (value > valorM)
                            {
                                valorM = value;
                                indexM = 0;
                            }
                        }
                        else if (AtrasadasDeze[j] > value)
                        {
                            if (AtrasadasDeze[j] > valorM)
                            {
                                valorM = AtrasadasDeze[j];
                                indexM = j;
                            }
                        }
                    }

                    maiorValor.Add(indexM + 1);
                    AtrasadasDeze[indexM] = -1;
                }

                string Atra = string.Join("-", maiorValor);
                object[] DezAtra = Atra.Split('-');

                for (int i = 0; i < PoluacaoRest.Length; i++)
                {
                    for (int Ji = 0; Ji < DezAtra.Length; Ji++)
                    {
                        if (DezAtra[Ji].ToString() == PoluacaoRest[i].ToString())
                        {
                            DezenasFixas += DezenasFixas == "" ? DezAtra[Ji] : "-" + DezAtra[Ji];
                            Ji = DezAtra.Length;
                            i = PoluacaoRest.Length;
                        }
                    }
                }

            }

            //cbmNumRestantes.Se
            if (cbmEscolherNumEspecifico.SelectedIndex == 0)//Sim 
            {                
                string[] abc = DezenasFixas.Split('-');
                bool yes = false;
                for (int i = 0; i < abc.Length; i++)
                {
                    if (abc[i] == cbmNumRestantes.SelectedItem.ToString())
                    {
                        yes = true;
                    }
                }

                if (!yes)
                {
                    DezenasFixas += DezenasFixas == "" ? cbmNumRestantes.SelectedItem.ToString() : "-" + cbmNumRestantes.SelectedItem.ToString();
                }                
            }

            //Verifica quais o números da População restante que comtemplam as dezenas que sairma
            for (int i = 0; i < PoluacaoRest.Length; i++)
            {
                for (int ji = 0; ji < Sorteados.Length; ji++)
                {
                    if (PoluacaoRest[i].ToString() == Sorteados[ji].ToString())
                    {
                        pRestSairam.Add(PoluacaoRest[i].ToString());
                        ji = Sorteados.Length;
                    }
                }
            }
            //Verifica quais o números da População restante que comtemplam as dezenas que não sairma
            for (int i = 0; i < PoluacaoRest.Length; i++)
            {
                for (int ji = 0; ji < NumerosNoOut.Length; ji++)
                {
                    if (PoluacaoRest[i].ToString() == NumerosNoOut[ji].ToString())
                    {
                        pRestNS.Add(PoluacaoRest[i].ToString());
                        ji = NumerosNoOut.Length;
                    }
                }
            }

            //Realiza as combinasções e os filtros
            List<string> Combinacoes = new List<string>();
            List<string> CombinacoesFiltradas = new List<string>();
            int QtdPoulacaoRest = PoluacaoRest.Length;

            for (int a = 0; a < QtdPoulacaoRest; a++)
            {
                for (int b = a + 1; b < QtdPoulacaoRest; b++)
                {
                    for (int c = b + 1; c < QtdPoulacaoRest; c++)
                    {
                        for (int d = c + 1; d < QtdPoulacaoRest; d++)
                        {
                            for (int g = d + 1; g < QtdPoulacaoRest; g++)
                            {
                                for (int f = g + 1; f < QtdPoulacaoRest; f++)
                                {
                                    string Jogo = PoluacaoRest[a].ToString() + "-" + PoluacaoRest[b].ToString() + "-" + PoluacaoRest[c].ToString() + "-" + PoluacaoRest[d].ToString() + "-" + PoluacaoRest[g].ToString() + "-" + PoluacaoRest[f].ToString();
                                    string[] DezJogo = Jogo.Split('-');

                                    //1º Verificar as Dezenas que tem os números fixos
                                    string[] Fix = DezenasFixas.Replace(" ", "").Split('-');

                                    int Tem = 0;
                                    if (DezenasFixas == "" || Fix.Length == 0)
                                    {
                                        Tem = Fix.Length;
                                    }
                                    else
                                    {
                                        for (int i = 0; i < Fix.Length; i++)
                                        {
                                            for (int ji = 0; ji < DezJogo.Length; ji++)
                                            {
                                                if (Fix[i].ToString() == DezJogo[ji].ToString())
                                                {
                                                    Tem++;
                                                    ji = DezJogo.Length;
                                                }
                                            }
                                        }
                                    }

                                    if (Tem == Fix.Length)//Se sim quer dizer que tem as dezenas fixas
                                    {
                                        //2º Quantidade de pares e impares
                                        int Par = 0;
                                        int Imp = 0;
                                        for (int i = 0; i < DezJogo.Length; i++)
                                        {
                                            int value = Convert.ToInt32(DezJogo[i]);
                                            if (value % 2 == 0)//Par
                                            {
                                                Par++;
                                            }
                                            else//Impar
                                            {
                                                Imp++;
                                            }
                                        }
                                        if (Imp == impar && Par == par)//Se sim quer dizer que contém a quantidade exigida de impares e pares
                                        {
                                            //3º Verificar se tem a quantidade de dezenas das que sairam e não sairam                                            
                                            int QtdS = 0;
                                            if (cbNumSairam.Checked)
                                            {                                                
                                                for (int i = 0; i < DezJogo.Length; i++)
                                                {
                                                    for (int j = 0; j < pRestSairam.Count; j++)
                                                    {
                                                        if (pRestSairam[j] == DezJogo[i])
                                                        {
                                                            QtdS++;
                                                            j = pRestSairam.Count;
                                                        }
                                                    }
                                                } 
                                            }
                                            else
                                            {
                                                QtdS = DezSairam;
                                            }

                                            int QtdNs = 0;
                                            if (cbNumNotOut.Checked)
                                            {
                                                for (int i = 0; i < DezJogo.Length; i++)
                                                {
                                                    for (int j = 0; j < pRestNS.Count; j++)
                                                    {
                                                        if (pRestNS[j].ToString() == DezJogo[i].ToString())
                                                        {
                                                            QtdNs++;
                                                            j = pRestNS.Count;
                                                        }
                                                    }
                                                } 
                                            }
                                            else
                                            {
                                                QtdNs = DezNotSairam;
                                            }

                                            if (QtdS == DezSairam && QtdNs == DezNotSairam)
                                            {
                                                //4º Verificar se as Dezenas estão de acordo com as colunas selecionadas
                                                //Verifica números nas Linhas
                                                int Certos = 0;
                                                int QtdCl = dgvQtdNumLinha.ColumnCount;
                                                if (cbmSelecionarLinhas.SelectedIndex == 0)//Sim Selecionar
                                                {
                                                    string[] L1 = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
                                                    string[] L2 = new string[10] { "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
                                                    string[] L3 = new string[10] { "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
                                                    string[] L4 = new string[10] { "31", "32", "33", "34", "35", "36", "37", "38", "39", "40" };
                                                    string[] L5 = new string[10] { "41", "42", "43", "44", "45", "46", "47", "48", "49", "50" };
                                                    string[] L6 = new string[10] { "51", "52", "53", "54", "55", "56", "57", "58", "59", "60" };

                                                    List<string[]> ListLinha = new List<string[]>();
                                                    ListLinha.Add(L1);
                                                    ListLinha.Add(L2);
                                                    ListLinha.Add(L3);
                                                    ListLinha.Add(L4);
                                                    ListLinha.Add(L5);
                                                    ListLinha.Add(L6);

                                                    string[] LN = new string[6] { "L1", "L2", "L3", "L4", "L5", "L6" };
                                                    Certos = 0;
                                                    QtdCl = dgvQtdNumLinha.ColumnCount;
                                                    for (int i = 0; i < dgvQtdNumLinha.ColumnCount; i++)
                                                    {
                                                        string ColuName = dgvQtdNumLinha.Columns[i].HeaderText.Replace(" ", "");
                                                        int QtdNeedNuns = Convert.ToInt32(dgvQtdNumLinha.Rows[0].Cells[i].Value);
                                                        int QtdHaveNumDez = 0;
                                                        for (int j = 0; j < LN.Length; j++)
                                                        {
                                                            if (ColuName == LN[j])//Verifica qual é a Linha que vai ter x números
                                                            {
                                                                string[] Line = ListLinha[j];

                                                                for (int k = 0; k < DezJogo.Length; k++)
                                                                {
                                                                    for (int l = 0; l < Line.Length; l++)
                                                                    {
                                                                        if (Line[l] == DezJogo[k])
                                                                        {
                                                                            QtdHaveNumDez++;
                                                                            l = Line.Length;
                                                                        }
                                                                    }
                                                                    if (QtdHaveNumDez == QtdNeedNuns)//Quer Dizer que a linha tem a quantidade certa de números
                                                                    {
                                                                        k = DezJogo.Length;
                                                                        j = LN.Length;
                                                                        QtdHaveNumDez = 0;
                                                                        Certos++;
                                                                    }
                                                                }

                                                                if (QtdHaveNumDez == 0 && Certos == 0)//Sai do looping
                                                                {
                                                                    j = LN.Length;
                                                                    i = QtdCl;
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    Certos = QtdCl;
                                                }

                                                int CertosCo = 0;
                                                int QtdCl2 = dgvQtdNumeros.ColumnCount;
                                                if (cbmSelecionarColunas.SelectedIndex == 0)
                                                {
                                                    //Verifica números nas coluans
                                                    string[] C1 = new string[6] { "1", "11", "21", "31", "41", "51" };
                                                    string[] C2 = new string[6] { "2", "12", "22", "32", "42", "52" };
                                                    string[] C3 = new string[6] { "3", "13", "23", "33", "43", "53" };
                                                    string[] C4 = new string[6] { "4", "14", "24", "34", "44", "54" };
                                                    string[] C5 = new string[6] { "5", "15", "25", "35", "45", "55" };
                                                    string[] C6 = new string[6] { "6", "16", "26", "36", "46", "56" };
                                                    string[] C7 = new string[6] { "7", "17", "27", "37", "47", "57" };
                                                    string[] C8 = new string[6] { "8", "18", "28", "38", "48", "58" };
                                                    string[] C9 = new string[6] { "9", "19", "29", "39", "49", "59" };
                                                    string[] C10 = new string[6] { "10", "20", "30", "40", "50", "60" };

                                                    List<string[]> ListColumn = new List<string[]>();
                                                    ListColumn.Add(C1);
                                                    ListColumn.Add(C2);
                                                    ListColumn.Add(C3);
                                                    ListColumn.Add(C4);
                                                    ListColumn.Add(C5);
                                                    ListColumn.Add(C6);
                                                    ListColumn.Add(C7);
                                                    ListColumn.Add(C8);
                                                    ListColumn.Add(C9);
                                                    ListColumn.Add(C10);

                                                    string[] CN = new string[10] { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10" };
                                                    for (int i = 0; i < dgvQtdNumeros.ColumnCount; i++)
                                                    {
                                                        string ColuName = dgvQtdNumeros.Columns[i].HeaderText.Replace(" ", "");
                                                        int QtdNeedNuns = Convert.ToInt32(dgvQtdNumeros.Rows[0].Cells[i].Value);
                                                        int QtdHaveNumDez2 = 0;
                                                        for (int j = 0; j < CN.Length; j++)
                                                        {
                                                            if (ColuName == CN[j])//Verifica qual é a Linha que vai ter x números
                                                            {
                                                                string[] Line = ListColumn[j];

                                                                for (int k = 0; k < DezJogo.Length; k++)
                                                                {
                                                                    for (int l = 0; l < Line.Length; l++)
                                                                    {
                                                                        if (Line[l] == DezJogo[k])
                                                                        {
                                                                            QtdHaveNumDez2++;
                                                                            l = Line.Length;
                                                                        }
                                                                    }
                                                                    if (QtdHaveNumDez2 == QtdNeedNuns)//Quer Dizer que a linha tem a quantidade certa de números
                                                                    {
                                                                        k = DezJogo.Length;
                                                                        j = CN.Length;
                                                                        QtdHaveNumDez2 = 0;
                                                                        CertosCo++;
                                                                    }
                                                                }

                                                                if (QtdHaveNumDez2 == 0 && CertosCo == 0)//Sai do looping
                                                                {
                                                                    j = CN.Length;
                                                                    i = QtdCl2;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    CertosCo = QtdCl2;
                                                }

                                                if (CertosCo == QtdCl2 && Certos == QtdCl)
                                                {
                                                    //5º VERIFICAR SE O JOGO POSSUI A QUANTIDADE X DE NÚMEROS PRIMOS E FIBONACCI
                                                    int[] NumPrimos = new int[17] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59 };
                                                    int[] NumFibo = new int[9] { 1, 2, 3, 5, 8, 13, 21, 34, 55 };
                                                    Combinacoes.Add(Jogo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (Combinacoes.Count != 0)
            {
                string Jogos = "";                
                dgvSugestoes.Rows.Clear();
                txtDezenasFixas.Text = DezenasFixas;
                if(DezenasFixas != "") FixasParam = ("Dezenas Fixas: " + DezenasFixas);
                for (int i = 0; i < Combinacoes.Count; i++)
                {
                    dgvSugestoes.Rows.Add(Combinacoes[i]);
                }
                for (int i = 0; i < Combinacoes.Count; i++)
                {
                    Jogos += Combinacoes[i] + "\r\n"; 
                }                
                DialogResult result = MessageBox.Show("Foram gerados " + Combinacoes.Count + " jogos com sucesso!\rDeseja salvar em Exel?", "Sucesso!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        OpenFileDialog openFile = new OpenFileDialog();
                        openFile.InitialDirectory = @"C:\Sistema MegaSena\Exel";
                        openFile.Multiselect = false;
                        openFile.Title = "Escolha um arquivo!";
                        openFile.ShowDialog();
                        if (openFile.CheckFileExists)
                        {
                            if (openFile.FileName != "")
                            {
                                using (var Exel = new XLWorkbook(openFile.FileName))
                                {
                                    param.Add(ImpParam);
                                    param.Add(DelLinhasParam);
                                    param.Add(DelColunsParam);
                                    param.Add(ReptParam);
                                    param.Add(ColunassParam);
                                    param.Add(LinhassParam);
                                    param.Add(NumLastGamaParam);
                                    param.Add(DezenasAtrasadassParam);
                                    param.Add(FixasParam);

                                    var Planilha = Exel.Worksheet(1);
                                    var LastTable = "";
                                    if (!Exel.Worksheets.TryGetWorksheet("Filtros", out IXLWorksheet xL))
                                    {
                                        Planilha = Exel.AddWorksheet("Filtros");                                       
                                    }
                                    else
                                    {
                                        Planilha = Exel.Worksheet("Filtros");
                                        LastTable = Planilha.Cell("A1").Value.ToString();
                                    }
                                    
                                    int ValueParametros = 3;
                                    int ValuePopulacao = 3;
                                    int ValueJogos = 3;
                                    int ValueFinalTable = 12;
                                    int ValueInicialTable = 2;
                                    if (LastTable != "")
                                    {
                                        int LastNumColunmB = Convert.ToInt32((LastTable[1].ToString() + LastTable[2].ToString()).Replace(":",""));
                                        int LastNumColunmJ = Convert.ToInt32((LastTable[4].ToString() + LastTable[5].ToString()).ToString());
                                      
                                        ValueInicialTable = LastNumColunmJ + 2;
                                        ValueFinalTable = ValueInicialTable + 10;

                                        ValueParametros = ValueInicialTable + 1;
                                        ValuePopulacao = ValueInicialTable + 1;
                                        ValueJogos = ValueInicialTable + 1;
                                    }

                                    Planilha.Cell("B"+ValueInicialTable).Value = "FILTRO";
                                    Planilha.Cell("B"+ValueParametros).Value = "Parametros";
                                    Planilha.Cell("E"+ValuePopulacao).Value = "População restante";
                                    Planilha.Cell("H"+ValueJogos).Value = "Jogos Gerados";

                                    var rangeTable = Planilha.Range("B"+ValueInicialTable+":J"+ValueFinalTable);
                                    rangeTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                    rangeTable.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                    rangeTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                    rangeTable.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                    rangeTable.Cell(1, 1).Style.Font.Bold = true;
                                    rangeTable.Cell(1, 1).Style.Font.FontColor = XLColor.White;
                                    rangeTable.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.Green;
                                    rangeTable.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    rangeTable.Row(1).Merge();

                                    Planilha.Cell("A1").Value = "B" + ValueInicialTable + ":J" + ValueFinalTable;
                                    Planilha.Cell("A1").Style.Font.FontColor = XLColor.White;

                                    var rangeHearder = rangeTable.Range("A2:I2");
                                    rangeHearder.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    rangeHearder.Style.Fill.BackgroundColor = XLColor.LightGray;
                                    int parans = 0;
                                    rangeTable.Range("A2:C2").Merge();//Paramestro - Titulo
                                    for (int i = 3; i < 12; i++)
                                    {
                                        rangeTable.Range("A" + i + ":C" + i).Merge();//Parametros - Corpo                                                                  
                                        if (parans < param.Count - 1 && param[parans] != "") rangeTable.Range("A" + i + ":C" + i).Value = param[parans];
                                        parans++;
                                    }
                                    rangeTable.Range("D2:F2").Merge();//População - Titulo
                                    rangeTable.Range("D3:F11").Merge();//População - Corpo
                                    rangeTable.Range("D3:F11").Value = txtPopulacao.Text;
                                    rangeTable.Range("D3:F11").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    rangeTable.Range("D3:F11").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                                    rangeTable.Range("G2:I2").Merge();//Jogos - Titulo
                                    rangeTable.Range("G3:I11").Merge();//Jogos - Corpo
                                    rangeTable.Range("G3:I11").Value = Jogos;

                                    Planilha.Columns(2, 6).AdjustToContents();

                                    Exel.Save();
                                    MessageBox.Show("Filtro Salvo no Excel com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    Process.Start("Explorer", @"C:\Sistema MegaSena\Exel");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não foi possivel salvar os dados, exporte o arquivo excel primeiro.", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao tentar salvar filtro.\rDescrição: "+ex.Message, "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }                    
                   
                }
            }
            else
            {
                txtDezenasFixas.Text = DezenasFixas;
                MessageBox.Show("Não foi possivel gerar os jogos com esses filtros!", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        frmBackTest frm = null;
        private void btnBackTeste_Click(object sender, EventArgs e)
        {
            if (!Controls.ContainsKey("frm"))
            {
                frm = new frmBackTest();
                frm.TopLevel = false;
                frm.Visible = true;
                Controls.Add(frm);
                frm.BringToFront();
            }
            else
            {
                frm.BringToFront();
            }
            
        }
    
    }
}