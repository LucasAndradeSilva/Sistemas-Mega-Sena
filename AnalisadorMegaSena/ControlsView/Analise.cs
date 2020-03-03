using System;
using System.Windows.Forms;
using AnalisadorMegaSena.ControlsView;
using AnalisadorMegaSena.Data;

namespace AnalisadorMegaSena.Forms
{
    public partial class Analise : UserControl
    {
        public Analise()
        {
            InitializeComponent();
        }
        
        //===================================
        // === FUNÇÃO CLICK NO BTN LISTAR ===
        //===================================
        private void btnListar_Click(object sender, EventArgs e)
        {
            FuncListaGrid();
        }

        //===============================================
        // === FUNÇÃO QUE LISTA OS DADOS NA GRID VIEW ===
        //===============================================
        public void FuncListaGrid()
        {
            if (int.TryParse(txtQtdJogos.Text, out int QtdJogos) == true)
            {
                Banco_de_Dados db = new Banco_de_Dados();
                dgvJogos.AllowUserToAddRows = true;
                dgvJogos.Rows.Clear();

                Concurso[] concursos = db.Buscar(0, QtdJogos);           
                for (int i = 0; i < concursos.Length; i++)
                {
                    dgvJogos.Rows[i].DataGridView.Rows.Add(concursos[i].NumConcurso, string.Join("-", concursos[i].Dezenas));
                }
                dgvJogos.AllowUserToAddRows = false; 
            }
            else
            {
                MessageBox.Show("Digite somente números para realizar a ação", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        //=====================================
        // === FUNÇÃO CLICK NO BTN ANÁLISAR ===
        //=====================================        
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtQtdJogos.Text, out int QtdJogos) == true)
            {
                SubAnalise.NumJogos = Convert.ToInt32(txtQtdJogos.Text);
                pnlContemSubAna.Visible = true;
                CtlSubAnalise.Visible = true;
                CtlSubAnalise.BringToFront();
                CtlSubAnalise.Show();
                CtlSubAnalise.ContaNumeros();             
            }
            else
            {
                MessageBox.Show("Digite somente números para realizar a ação", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //====================
        // === FUNÇÃO LOAD ===
        //====================
        private void Analise_VisibleChanged(object sender, EventArgs e)
        {
            FuncListaGrid();            
        }
        private void CtlSubAnalise_VisibleChanged(object sender, EventArgs e)
        {
            if (CtlSubAnalise.Visible == false)
            {
                pnlContemSubAna.Visible = false;                
            }
        }

        //=====================================
        // === CLIQUE NO BOTÃO ESTASTISTICA ===
        //=====================================
        private void btnEstatistica_Click(object sender, EventArgs e)
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Show();
        }

    }
}
