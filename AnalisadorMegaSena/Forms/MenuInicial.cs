using AnalisadorMegaSena.Data;
using AnalisadorMegaSena.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace AnalisadorMegaSena.Forms
{
    public partial class MenuInicial : Form
    {
        public MenuInicial()
        {
            InitializeComponent();
        }
        //==================
        // === VARIAVEIS ===
        //==================
        public bool Online = true;

        //====================
        // === FUNÇÃO LOAD ===
        //====================        
        //===============================================================
        // === FUNÇÃO QUE RETORNA O ATRIBUTOS PRINCIPAIS DA MEGA SENA ===
        //===============================================================
        private void MenuInicial_Load(object sender, EventArgs e)
        {
            string strPageCode = "";
            string DataMega = "", ValorAcumulado = "0";
            string Co = "";
            string[] Dezenas = new string[5];
            dynamic dobj = "";
            string JsonDezenas = "";
            List<string> Sharp_Dezenas = new List<string>();

            try
            {
                WebClient webClient = new WebClient();
                strPageCode = webClient.DownloadString("https://www.lotodicas.com.br/api/v2/mega_sena/results/last?token=8039cc263cffaeb86a48b98c7301c763399ae0d733c425224a42d43c361b3bb8");
                dobj = JsonConvert.DeserializeObject<dynamic>(strPageCode);

                DataMega = dobj["data"]["draw_date"].ToString();
                DateTime dateTime = Convert.ToDateTime(DataMega);
                DataMega = dateTime.Day.ToString() +@"/"+ (dateTime.Month < 10 ? "0" + dateTime.Month.ToString()+@"/" : dateTime.Month.ToString()+ @"/") + dateTime.Year.ToString();
                ValorAcumulado = dobj["data"]["next_draw_prize"].ToString();
                JsonDezenas = dobj["data"]["drawing"].ToString();
                Co = dobj["data"]["draw_number"].ToString();
                Sharp_Dezenas = JsonConvert.DeserializeObject<List<string>>(JsonDezenas);
                Online = true;

                if (ValorAcumulado == "0")
                {
                    lblAcumulou.Text = "Houve um Ganhador!";
                    lblAcumulou.Location = new Point(449, 208);
                    ValorAcumulado = dobj["data"]["next_draw_prize"].ToString();
                    lblValorEstima.Text = "R$ " + ValorAcumulado;
                    lblValorEstima.Location = new Point(136, 618);
                    lblResultConcurso.Text = Co;
                }
                else
                {
                    lblValorEstima.Text = "R$ " +ValorAcumulado;
                    lblAcumulou.Text = "Acumulou!";
                    lblAcumulou.Location = new Point(469, 208);
                    lblResultConcurso.Text = Co;
                }

                string NoListDezenas = string.Join(", ", Sharp_Dezenas.ToArray());
                Dezenas = NoListDezenas.Split(',');
                lblDataMega.Text = DataMega.Replace('-', '/');
                lblD1.Text = Dezenas[0];
                lblD2.Text = Dezenas[1];
                lblD3.Text = Dezenas[2];
                lblD4.Text = Dezenas[3];
                lblD5.Text = Dezenas[4];
                lblD6.Text = Dezenas[5];
                lblResultConcurso.Text = Co;

                Banco_de_Dados db = new Banco_de_Dados();
                int value = db.Buscar("");
                int con = Convert.ToInt32(Co);
                if (value < con)
                {
                    int QtdJNInsert = con - value;
                    int i = 1;
                    while (QtdJNInsert > 0)
                    {
                        strPageCode = webClient.DownloadString("https://www.lotodicas.com.br/api/v2/mega_sena/results/" + (value + i) + "?token=8039cc263cffaeb86a48b98c7301c763399ae0d733c425224a42d43c361b3bb8".ToString());
                        dobj = JsonConvert.DeserializeObject<dynamic>(strPageCode);

                        DataMega = dobj["data"]["draw_date"].ToString();
                        ValorAcumulado = dobj["data"]["next_draw_prize"].ToString();
                        JsonDezenas = dobj["data"]["drawing"].ToString();
                        Co = dobj["data"]["draw_number"].ToString();
                        Sharp_Dezenas = JsonConvert.DeserializeObject<List<string>>(JsonDezenas);

                        Concurso concurso = new Concurso();
                        concurso.NumConcurso = Convert.ToInt32(Co);
                        concurso.Data = DataMega;
                        concurso.Acumulado = Convert.ToDouble(dobj["data"]["next_draw_prize"].ToString());
                        concurso.Acumulou = dobj["data"]["has_winner"].ToString() == "false" ? "NAO" : "SIM";
                        string NoListDezenas2 = string.Join(", ", Sharp_Dezenas.ToArray());
                        concurso.Dezenas = NoListDezenas2.Split(',');
                        concurso.ProximaEstimativa = Convert.ToDouble(ValorAcumulado.ToString());
                        db.Insert(concurso);

                        i++;
                        QtdJNInsert--;
                    }
                }
            }
            catch (Exception)
            {
                Online = false;
                Banco_de_Dados db = new Banco_de_Dados();
                Concurso concurso = new Concurso();

                int IdCon = db.Buscar("oi");
                concurso = db.Buscar(IdCon);

                Co = concurso.NumConcurso.ToString();
                DataMega = concurso.Data.ToString();
                DateTime dateTime = Convert.ToDateTime(DataMega);
                DataMega = dateTime.Day.ToString() + @"/" + (dateTime.Month < 10 ? "0" + dateTime.Month.ToString() + @"/" : dateTime.Month.ToString() + @"/") + dateTime.Year.ToString();                
                ValorAcumulado = concurso.ProximaEstimativa.ToString();

                for (int i = 0; i < concurso.Dezenas.Length; i++)
                {
                    Sharp_Dezenas.Add(concurso.Dezenas[i]);
                }

                if (concurso.Acumulou == "nao" || concurso.Acumulou == "Não" || concurso.Acumulou == "NAO")
                {
                    lblAcumulou.Text = "Houve um Ganhador!";
                    lblAcumulou.Location = new Point(309, 208);
                    ValorAcumulado = concurso.ProximaEstimativa.ToString();
                    lblValorEstima.Text = "R$ "+ concurso.ProximaEstimativa.ToString();
                    lblResultConcurso.Text = Co;
                }
                else
                {
                    lblValorEstima.Text = "R$ " + ValorAcumulado;
                    lblAcumulou.Text = "Acumulou!";
                    lblAcumulou.Location = new Point(469, 208);
                    lblResultConcurso.Text = Co;
                }

                string NoListDezenas2 = string.Join(", ", Sharp_Dezenas.ToArray());
                Dezenas = NoListDezenas2.Split(',');                
                lblDataMega.Text = DataMega.Replace('-', '/');
                lblD1.Text = Dezenas[0];
                lblD2.Text = Dezenas[1];
                lblD3.Text = Dezenas[2];
                lblD4.Text = Dezenas[3];
                lblD5.Text = Dezenas[4];
                lblD6.Text = Dezenas[5];
            }
        }  
            
        //===================================
        // === FUNÇÃO CLICK NO ICONE HOME ===
        //===================================
        private void ptrHome_Click(object sender, EventArgs e)
        {            
            CtlAnalise.Visible = false;
            CtlInserir.Visible = false;
            CtlBackup1.Visible = false;           
        }    
        private void lblHome_Click(object sender, EventArgs e)
        {
            CtlAnalise.Visible = false;
            CtlBackup1.Visible = false;            
        }
        private void lblHome_MouseMove(object sender, MouseEventArgs e)
        {            
            ptrHome.Image = Resources.Home_Azul;            
            lblHome.ForeColor = Color.FromArgb(0, 204, 205);
        }
        private void lblHome_MouseLeave(object sender, EventArgs e)
        {
            ptrHome.Image = Resources.Home_Branco;
            lblHome.ForeColor = Color.White;
        }

        //======================================
        // === FUNÇÃO CLICK NO ICONE ANALISE ===
        //======================================
        private void ptrAnalise_Click(object sender, EventArgs e)
        {            
            CtlAnalise.Visible = true;
            CtlAnalise.BringToFront();
            CtlInserir.Visible = false;
            CtlBackup1.Visible = false;
            
        }
        private void lblAnalise_Click(object sender, EventArgs e)
        {         
           CtlAnalise.Visible = true;
           CtlInserir.Visible = false;
            CtlBackup1.Visible = false;
        }
        private void ptrAnalise_MouseMove(object sender, MouseEventArgs e)
        {
            ptrAnalise.Image = Resources.Analise_Azul;
            lblAnalise.ForeColor = Color.FromArgb(0, 204, 205);
        }
        private void ptrAnalise_MouseLeave(object sender, EventArgs e)
        {
            ptrAnalise.Image = Resources.Analise_Branco;
            lblAnalise.ForeColor = Color.White;
        }

        //======================================
        // === FUNÇÃO CLICK NO ICONE INSERIR ===
        //======================================
        private void ptrInserir_Click(object sender, EventArgs e)
        {
            CtlInserir.Visible = true;
            CtlInserir.BringToFront();
            CtlAnalise.Visible = false;
            CtlBackup1.Visible = false;
        }
        private void lblInserir_Click(object sender, EventArgs e)
        {
            CtlInserir.Visible = true;
            CtlAnalise.Visible = false;
            CtlBackup1.Visible = false;
        }
        private void ptrInserir_MouseMove(object sender, MouseEventArgs e)
        {
            ptrInserir.Image = Resources.Inserir_Azul;
            lblInserir.ForeColor = Color.FromArgb(0, 204, 205);
        }
        private void ptrInserir_MouseLeave(object sender, EventArgs e)
        {
            ptrInserir.Image = Resources.Inserir_Branco;
            lblInserir.ForeColor = Color.White;
        }

        //=====================================
        // === FUNÇÃO CLICK NO ICONE BACKUP ===
        //=====================================
        private void ptrBackup_Click(object sender, EventArgs e)
        {
            CtlBackup1.Visible = true;
            CtlAnalise.Visible = false;
            CtlInserir.Visible = false;
            CtlBackup1.Show();
            CtlBackup1.BringToFront();
        }
        private void ptrBackup_MouseMove(object sender, MouseEventArgs e)
        {
            ptrBackup.Image = Resources.Backup_Azul;
            lblBackup.ForeColor = Color.FromArgb(0, 204, 205);
        }
        private void ptrBackup_MouseLeave(object sender, EventArgs e)
        {
            ptrBackup.Image = Resources.Backup_Branco;
            lblBackup.ForeColor = Color.White;
        }

        //===================================
        // === FUNÇÃO CLICK NO ICONE SAIR ===
        //===================================
        private void ptrSair_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja fechar o Aplicativo?", "SAIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }            
        }
        private void ptrSair_MouseMove(object sender, MouseEventArgs e)
        {
            ptrSair.Image = Resources.Sair_Azul;
            lblSair.ForeColor = Color.FromArgb(0, 204, 205);
        }
        private void ptrSair_MouseLeave(object sender, EventArgs e)
        {
            ptrSair.Image = Resources.Sair_Branco;
            lblSair.ForeColor = Color.White;
        }
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            ptrSair_Click(sender, e);
        }

        //=================================
        // === FUNÇÃO CLICK NO MIMINIZE ===
        //=================================
        private void btnMiminize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
