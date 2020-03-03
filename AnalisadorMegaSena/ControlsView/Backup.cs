using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using AnalisadorMegaSena.Data;
using System.Threading;
using System.Collections.Generic;
using AnalisadorMegaSena.Forms;
using AnalisadorMegaSena.Properties;

namespace AnalisadorMegaSena.ControlsView
{
    public partial class Backup : UserControl
    {
        public Backup()
        {
            InitializeComponent();
        }

        Banco_de_Dados db = new Banco_de_Dados();
        public static string msg = "Certo";

        //===========================
        // === FUNÇÕES MOUSE MOVE ===
        //===========================
        private void btnRestaurarBkp_MouseMove(object sender, MouseEventArgs e)
        {
            btnRestaurarBkp.Image = Resources.ico_RestBkp;
        }        
        private void btnExpBkp_MouseMove(object sender, MouseEventArgs e)
        {
            btnExpBkp.Image = Resources.ico_ExpBkp;
        }


        //========================================
        // === FUNÇÕES CLICK NO BOTÃO EXPORTAR ===
        //========================================
        private void btnExpBkp_Click(object sender, EventArgs e)
        {
            pnlEmail.Visible = true;
        }

        //=========================================================
        // === FUNÇÕES CLICK NO BOTÃO PRONTO DO PAINEL EXPORTAR ===
        //=========================================================
        private void btnProntoExportar_Click(object sender, EventArgs e)
        {          
            try
            {
                string gmail = txtParaEmail.Text;
                gmail = gmail.Replace(" ", "");
                gmail = gmail.ToLower();
                bool r = gmail.Contains("@");
                r = gmail.Contains(".com");
                if (string.IsNullOrEmpty(gmail) != true && r)
                {
                    frmCarregaAcoes.gmail = gmail;
                    frm = new frmCarregaAcoes(Resources.BackGraubd, "Exportando...", 1206, 482, 2);                                        
                    frm.ShowDialog();                    
                }
                else MessageBox.Show("Email Incorreto, lembre-se deve contar '@', '.com' e ser um email valido. ", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exc)
            {
                msg = exc.Message;
            }
        }

        //=================================================
        // === FUNÇÕES CLICK NO BOTÃO CLOSE DO EXPORTAR ===
        //=================================================
        private void btnClosePnl_Click(object sender, EventArgs e)
        {
            pnlEmail.Visible = false;
        }

        //=========================================
        // === FUNÇÕES CLICK NO BOTÃO RESTAURAR ===
        //=========================================
        private void btnRestaurarBkp_Click(object sender, EventArgs e)
        {
            try
            {                
                OpenFileDialog fileDialog = new OpenFileDialog();
                DialogResult result = fileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    frmCarregaAcoes.CaminhoArq = fileDialog.FileName;
                    frm = new frmCarregaAcoes(Resources.BackGraubd, "Restaurando Dados...", 1206, 482, 3);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na restuaração do Backup.\nDescrição: "+ex.Message, "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
                        
        }

        public static frmCarregaAcoes frm;
        private void lblLink_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certza que deseja continuar, pois está ação ira limpar todos os " +
                                                  "dados do Banco e inserir os novos via Web? ", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                frm = new frmCarregaAcoes(Resources.BackGraubd, "Fazendo Download e Inserindo no Banco...", 1206, 482, 1);
                frm.ShowDialog();         
            }
        }

    }    
}
