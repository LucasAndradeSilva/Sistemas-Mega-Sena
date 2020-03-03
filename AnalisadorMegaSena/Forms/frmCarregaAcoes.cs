using AnalisadorMegaSena.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AnalisadorMegaSena.Forms
{
    public partial class frmCarregaAcoes : Form
    {
        //===================
        // === CONSTRUTOR ===
        //===================

        /// <summary>
        /// Para acessar o Evento opções segua a baixo a lista do eventos ||
        /// 1 - Reseta Banco ||
        /// 2 - Exporta Dados ||
        /// 3 - Restauras Dados com Doc ||
        /// </summary>
        /// <param name="frmCarregaAcoes"></param>        
        public frmCarregaAcoes(Bitmap CaminhaImage, string Text, int WidthForm, int HeightForm, int Opcao)
        {
            InitializeComponent();
            Size = new Size(WidthForm, HeightForm);
            BackgroundImage = CaminhaImage;
            lblAcoesCarrega.Text = Text;
            if (Opcao == 1) ResetaBanco();
            else if (Opcao == 2) ExportaDados();
            else if (Opcao == 3) RestaurasDoc();
        }


        //====================================
        // === FUNÇÃO RESTAURA DADOS BANCO ===
        //====================================
        public static string CaminhoArq = "";
        public void RestaurasDoc()
        {
            bwSecund.RunWorkerAsync(3);
            lblAcoesCarrega.Location = new Point(450, 213);
            pgbCarregaAcoes.Location = new Point(364, 264);
            Refresh();
        }
        public void ThreadRestauraDoc()
        {
            string linha = "";            
            Banco_de_Dados db = new Banco_de_Dados();
            if (db.Deletar())
            {
                StreamReader sr = new StreamReader(CaminhoArq);

                while ((linha = sr.ReadLine()) != null)
                {
                    Concurso concurso = new Concurso();
                    string[] Dados = linha.Split('#');
                    concurso.NumConcurso = Convert.ToInt32(Dados[0]);
                    concurso.Data = Dados[1];
                    concurso.Dezenas = Dados[2].Split('-');
                    concurso.Acumulado = Convert.ToDouble(Dados[3]);
                    concurso.Acumulou = Dados[4];
                    concurso.ProximaEstimativa = Convert.ToDouble(Dados[5].Replace("$", ""));

                    db.Insert(concurso);
                }
                MessageBox.Show("Resturação dos Dados concluida com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Erro na restuaração do Backup.", "Opps!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    
        //============================
        // === FUNÇÃO RESETA BANCO ===
        //============================            
        public void ResetaBanco()
        {
            bwSecund.RunWorkerAsync(1);
            lblAcoesCarrega.Location = new Point(345, 213);
            pgbCarregaAcoes.Location = new Point(364, 264);                
            Refresh();      
        }
        public void FuncThread()
        {
            Banco_de_Dados db = new Banco_de_Dados();
            List<Concurso> TodConcursos = ApiMega.GetTodosConcursos();
            TodConcursos.Reverse();

            if (TodConcursos != null)
            {
                db.Deletar();
                for (int i = 0; i < TodConcursos.Count; i++)
                {
                    db.Insert(TodConcursos[i]);
                }
                MessageBox.Show("Banco Resetado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocorreu um erro do lado da API, restauração cancelada!", "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        //======================================
        // === FUNÇÃO EXPORTA DADOS DO BANCO ===
        //======================================
        public static string gmail = "";
        public void ExportaDados()
        {            
            bwSecund.RunWorkerAsync(2);
            lblAcoesCarrega.Location = new Point(500, 213);
            pgbCarregaAcoes.Location = new Point(364, 264);
            Refresh();
        }
        public void ThreadExporta()
        {
            try
            {               
                StreamWriter sw;
                
                string CaminhoNome = @"C:\Sistema MegaSena\Backup";

                if (Directory.Exists(CaminhoNome) == false) Directory.CreateDirectory(CaminhoNome);
                CaminhoNome += @"\Backup.txt";

                Process process = new Process();
                process.Close();
                sw = File.CreateText(CaminhoNome);

                Banco_de_Dados db = new Banco_de_Dados();
                Concurso[] concursos = db.Buscar(0, false);

                for (int i = 0; i < concursos.Length; i++)
                {
                    sw.WriteLine(concursos[i].NumConcurso + " # " + concursos[i].Data + " # " + string.Join("-", concursos[i].Dezenas) + " # " + concursos[i].Acumulado + " # " + concursos[i].Acumulou + " # " + concursos[i].ProximaEstimativa + " $ ");
                }
                sw.Flush();
                sw.Close();
                sw.Dispose();

                Email email = new Email(gmail, CaminhoNome);
                if (email.Enviar())
                {
                    MessageBox.Show("Backup Concluido e Enviado no Email: " + gmail, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                                                      
                }
                else
                {
                    MessageBox.Show("Erro ao Enviar para o Email: " + gmail + "\nDescrição: " + Email.msg, "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Enviar para o Email: " + gmail + "\nDescrição: " + ex.Message, "Opss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Reseta os Banco de Dados e Insere tudo de novo
            if (Convert.ToInt32(e.Argument) == 1) FuncThread();
            //Exporta Dados Gmail
            else if (Convert.ToInt32(e.Argument) == 2) ThreadExporta();
            //Restaura Banco com Doc]
            else if (Convert.ToInt32(e.Argument) == 3) ThreadRestauraDoc();


        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pgbCarregaAcoes.Style = ProgressBarStyle.Continuous;
            pgbCarregaAcoes.Maximum = 100;
            pgbCarregaAcoes.Value = 100;
            lblAcoesCarrega.Text = "AÇÃO CONCLUIDA!";
            Refresh();
            Thread.Sleep(2000);
            Close();
            bwSecund.CancelAsync();
        }
    }
}
