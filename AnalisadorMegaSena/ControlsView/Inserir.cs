using System;
using System.Windows.Forms;
using AnalisadorMegaSena.Data;

namespace AnalisadorMegaSena.ControlsView
{
    public partial class Inserir : UserControl
    {
        public Inserir()
        {
            InitializeComponent();            
        }

        //===================
        // === VARIAVEIS  ===
        //===================        
        Concurso CO = new Concurso();

        //=====================================
        // === FUNÇÃO LOAD DA CONTROL VIEW  ===
        //=====================================      
        private void Inserir_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == true)
            {
                AtualizaGrid();
            }
        }

        //===========================
        // === ATUALIZA GRID VIEW ===
        //===========================
        public void AtualizaGrid()
        {
            try
            {
                Banco_de_Dados db = new Banco_de_Dados();
                dgvConcurso.DataSource = db.Buscar();
                dgvConcurso.DataMember = "Consurso";
            }
            catch (Exception ex)
            {
                throw;
            }            
        }                          

        //=======================================
        // === CLIQUE NO BOTÃO SALVAR INSERIR ===
        //=======================================
        private void btnSalvarInserir_Click(object sender, EventArgs e)
        {
            Banco_de_Dados db = new Banco_de_Dados();
            if (txtInserirAcumulou.Text != "" || mktData.MaskCompleted && mktDezenas.MaskCompleted && txtInserirEstimativa.Text != "" && txtInserirNumConcurso.Text != "")
            {
                if (int.TryParse(txtInserirNumConcurso.Text, out int NumCon) == true && NumCon > 0)
                {

                    bool erro = false;
                    string[] D = mktDezenas.Text.Split('-');
                    int[] VerifcaDezenas = new int[D.Length];
                    for (int i = 0; i < D.Length; i++)
                    {
                        VerifcaDezenas[i] = int.Parse(D[i]);
                        if (VerifcaDezenas[i] > 60  || VerifcaDezenas[i] == 0)
                        {
                            i = D.Length;
                            erro = true;
                        }                        
                    }
                    for (int i = 0; i < D.Length; i++)
                    {
                        int index = SubAnalise.ArraySeach(VerifcaDezenas, VerifcaDezenas[i]);

                        for (int j = index + 1; j < D.Length; j++)
                        {
                            if (VerifcaDezenas[j] == VerifcaDezenas[index]) erro = true;                            
                        }
                    }
                    if (erro == true)
                    {
                        MessageBox.Show("Os números das Dezenas devem estar entre 1 e 60 e não podem ser repetidos", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    CO.NumConcurso = NumCon;
                    int value = db.Buscar("oi") + 1;
                    if (value == NumCon)
                    {
                        string data = mktData.Text;
                        DateTime dateTime = Convert.ToDateTime(data);
                        CO.Data = dateTime.Year.ToString() + @"/" + (dateTime.Month < 10 ? "0" + dateTime.Month.ToString() + @"/" : dateTime.Month.ToString() + @"/") + dateTime.Day.ToString();
                        CO.Data = mktData.Text;
                        CO.Acumulou = cbmInserirAcumulou.Text;
                        CO.Acumulado = Convert.ToDouble(txtInserirAcumulou.Text);
                        CO.ProximaEstimativa = Convert.ToDouble(txtInserirEstimativa.Text);
                        CO.Dezenas = mktDezenas.Text.Split('-');

                        if (db.Insert(CO))
                        {
                            MessageBox.Show("Os dados foram guardados com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            AtualizaGrid();
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro para guardar os dados! " + Banco_de_Dados.message, "Óh não!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O Concurso deve ser exatamente 1 núemro maior que o ultimo concurso!!", "Opsss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("O Concurso deve conter somente números e ser maior que 0!!", "Opsss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Nenhum campo pode estar vazio!!", "Opsss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //================================
        // === CLIQUE NO BOTÃO INSERIR ===
        //================================
        private void btnInserir_Click(object sender, EventArgs e)
        {
            pnlDeletar.Visible = false;
            pnlInserir.Visible = true;
            pAlterar.Visible = false;
        }

        //================================
        // === CLIQUE NO BOTÃO DELETAR ===
        //================================
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            pnlDeletar.Visible = true;
            pnlInserir.Visible = false;
            pAlterar.Visible = false;
        }

        //================================
        // === CLIQUE NO BOTÃO ALTERAR ===
        //================================
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            pAlterar.Visible = true;
            pnlDeletar.Visible = false;
            pnlInserir.Visible = false;           
        }

        //==================================================
        // === CLIQUE NO BOTÃO DELETAR DO PAINEL DELETAR ===
        //==================================================
        private void btnDeletarConcurso_Click(object sender, EventArgs e)
        {        
            Banco_de_Dados db = new Banco_de_Dados();
                
            if (int.TryParse(txtConcursoDeletar.Text, out int Num))
            {
                if (db.Deletar(Num))
                {
                    MessageBox.Show("Os dados foram deletados com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    AtualizaGrid();
                }
                else
                {
                    MessageBox.Show("Erro ao deletar: "+Banco_de_Dados.message, "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("A somente números podem ser inseridos", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }            
        }

        //=================================================
        // === CLIQUE NO BOTÃO BUSCAR DO PAINEL ALTERAR ===
        //=================================================
        private void btnBuscarAlterar_Click(object sender, EventArgs e)
        {
            Banco_de_Dados db = new Banco_de_Dados();
            if (txtNumBuscar.Text != "" && int.TryParse(txtNumBuscar.Text, out int NC) == true && NC > 0 )
            {
                Concurso con = db.Buscar(NC);
                if (con.NumConcurso != 0)
                {
                    txtNumConcursoAlterar.Text = con.NumConcurso.ToString();
                    mktDezenasAlterar.Text = string.Join("-", con.Dezenas);
                    cbmAcumulouAlterar.SelectedIndex = con.Acumulou == "SIM" ? 0 : 1;
                    txtValorAcumuladoAlterar.Text = con.Acumulado.ToString();
                    txtEstimativaAlterar.Text = con.ProximaEstimativa.ToString();
                    DateTime dateTime = Convert.ToDateTime(con.Data);
                    mktDataAlterar.Text = dateTime.Day.ToString() + @"/" + (dateTime.Month < 10 ? "0" + dateTime.Month.ToString() + @"/" : dateTime.Month.ToString() + @"/") + dateTime.Year.ToString(); ;
                }
                else
                {
                    MessageBox.Show("Número do concurso inválido!", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Para realizar a busca o concurso tem que ser somente números e maior que 0!", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //=================================================
        // === CLIQUE NO BOTÃO SALVAR DO PAINEL ALTERAR ===
        //=================================================
        private void btnSalvarAlteracoes_Click(object sender, EventArgs e)
        {
            Banco_de_Dados db = new Banco_de_Dados();
            if (txtEstimativaAlterar.Text != "" && double.TryParse(txtEstimativaAlterar.Text, out double Estimativa) == true && txtValorAcumuladoAlterar.Text != "" && double.TryParse(txtValorAcumuladoAlterar.Text, out double Acumulado) == true && mktDezenasAlterar.MaskCompleted == true && mktDataAlterar.MaskCompleted == true)
            {
                bool erro = false;
                string[] D = mktDezenasAlterar.Text.Split('-');
                int[] VerifcaDezenas = new int[D.Length];
                for (int i = 0; i < D.Length; i++)
                {
                    VerifcaDezenas[i] = int.Parse(D[i]);
                    if (VerifcaDezenas[i] > 60 || VerifcaDezenas[i] == 0)
                    {
                        i = D.Length;
                        erro = true;
                    }
                }
                for (int i = 0; i < D.Length; i++)
                {
                    int index = SubAnalise.ArraySeach(VerifcaDezenas, VerifcaDezenas[i]);

                    for (int j = index + 1; j < D.Length; j++)
                    {
                        if (VerifcaDezenas[j] == VerifcaDezenas[index]) erro = true;
                    }
                }
                if (erro == true)
                {
                    MessageBox.Show("Os números das Dezenas devem estar entre 1 e 60 e não podem ser repetidos", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                Concurso concurso = new Concurso();
                concurso.NumConcurso = int.Parse(txtNumConcursoAlterar.Text);
                concurso.ProximaEstimativa = Estimativa;
                concurso.Dezenas = mktDezenasAlterar.Text.Split('-');
                DateTime dateTime = Convert.ToDateTime(mktDataAlterar.Text);                
                concurso.Data = dateTime.Year.ToString() + @"/" + (dateTime.Month < 10 ? "0" + dateTime.Month.ToString() + @"/" : dateTime.Month.ToString() + @"/") + dateTime.Day.ToString(); ;
                concurso.Acumulado = Acumulado;
                concurso.Acumulou = cbmAcumulouAlterar.Text;


                if (db.Alterar(concurso))
                {
                    MessageBox.Show("Dados alterados com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    AtualizaGrid();
                }
                else
                {
                    MessageBox.Show("Erro na alteração do dados: "+Banco_de_Dados.message, "Ohh não!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Para realizar a alteração nenhum campo pode estar vazio e os que exigem números devem ser somente números", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //============================
        // === EXPANDE A GRID VIEW ===
        //============================
        private void dgvConcurso_DoubleClick(object sender, EventArgs e)
        {
            if (dgvConcurso.Dock == DockStyle.Fill)
            {
                dgvConcurso.SendToBack();
                dgvConcurso.Dock = DockStyle.None;
                dgvConcurso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgvConcurso.BringToFront();                
                dgvConcurso.Dock = DockStyle.Fill;
                dgvConcurso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            
        }
    }
}
