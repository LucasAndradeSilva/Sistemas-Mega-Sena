using AnalisadorMegaSena.Forms;
using AnalisadorMegaSena.Properties;
using System;
using System.Windows.Forms;

namespace AnalisadorMegaSena
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        //==================
        // === VARIAVEIS ===
        //==================        
        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();            
        }

        //==============
        // === TIMER ===
        //==============
        private void timer1_Tick(object sender, EventArgs e)
        {        
            if (loadingBar.Value < 100)
            {
                loadingBar.Value += 2;
                lblPorcento.Text = loadingBar.Value.ToString() + "%";
                if (loadingBar.Value == 30)
                {
                    BackgroundImage = Resources.load2;
                }
                else if (loadingBar.Value == 60)
                {
                    BackgroundImage = Resources.load3;
                }
            }
            else
            {
                timer1.Enabled = false;
                Hide();
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
            }                
        }               
    }
}
