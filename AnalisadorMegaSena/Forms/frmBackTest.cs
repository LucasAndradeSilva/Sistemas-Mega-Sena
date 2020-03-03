using AnalisadorMegaSena.ControlsView;
using AnalisadorMegaSena.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static AnalisadorMegaSena.Forms.frmBackTest.AtrasadosInternal;

namespace AnalisadorMegaSena.Forms
{

    //=========================
    // === CLASSE PRINCIPAL ===
    //=========================
    public partial class frmBackTest : Form
    {
        //============================
        // === CLASSE ESTATISITCAS ===
        //============================
        public class Estatisticas
        {
            public int SenaAcertos = 0;
            public int QuinaAcertos = 0;
            public int QuadraAcertos = 0;
            public int AbordouPopolacao = 0;
            public int JogosGeradosAbordou = 0;
            public string PrevisaoParImpar = "";
            public string PrevisaoRepetirNumJogo = "";
            
        }

        //=================================
        // === CLASSE REPITIR LAST GAME ===
        //=================================
        public class LastGame
        {
            //Repetir Zero
            public int RepeteZero_Ocorrencias = 0;
            public double RepeteZero_Porcentagens = 0;
            public int RepeteZero_Media = 0;
            public int RepeteZero_Atrasos = 0;
            public int RepeteZero_UltimoConcurso = 0;

            //Repetir Uma
            public int RepeteUma_Ocorrencias = 0;
            public double RepeteUma_Porcentagens = 0;
            public int RepeteUma_Media = 0;
            public int RepeteUma_Atrasos = 0;
            public int RepeteUma_UltimoConcurso = 0;

            //Repetir Duas
            public int RepeteDuas_Ocorrencias = 0;
            public double RepeteDuas_Porcentagens = 0;
            public int RepeteDuas_Media = 0;
            public int RepeteDuas_Atrasos = 0;
            public int RepeteDuas_UltimoConcurso = 0;

            //Repetir Três
            public int RepeteTres_Ocorrencias = 0;
            public double RepeteTres_Porcentagens = 0;
            public int RepeteTres_Media = 0;
            public int RepeteTres_Atrasos = 0;
            public int RepeteTres_UltimoConcurso = 0;

            //Repetir Quatro
            public int RepeteQuatro_Ocorrencias = 0;
            public double RepeteQuatro_Porcentagens = 0;
            public int RepeteQuatro_Media = 0;
            public int RepeteQuatro_Atrasos = 0;
            public int RepeteQuatro_UltimoConcurso = 0;

            //Reptir Cinco
            public int RepeteCinco_Ocorrencias = 0;
            public double RepeteCinco_Porcentagens = 0;
            public int RepeteCinco_Media = 0;
            public int RepeteCinco_Atrasos = 0;
            public int RepeteCinco_UltimoConcurso = 0;

            //Reptir Seis
            public int RepeteSeis_Ocorrencias = 0;
            public double RepeteSeis_Porcentagens = 0;
            public int RepeteSeis_Media = 0;
            public int RepeteSeis_Atrasos = 0;
            public int RepeteSeis_UltimoConcurso = 0;
        }

        //===========================
        // === CLASSE OCORRENCIAS ===
        //===========================
        public class Ocorrencia
        {
            //Linhas
            public int L1 = 0;
            public int L2 = 0;
            public int L3 = 0;
            public int L4 = 0;
            public int L5 = 0;
            public int L6 = 0;

            //Colunas 
            public int C1 = 0;
            public int C2 = 0;
            public int C3 = 0;
            public int C4 = 0;
            public int C5 = 0;
            public int C6 = 0;
            public int C7 = 0;
            public int C8 = 0;
            public int C9 = 0;
            public int C10 = 0;
        }


        //=========================
        // === CLASSE ATRASADOS ===
        //=========================
        public class AtrasadosInternal
        {
            //================================
            // === CLASSE LINHAS INTERNAS ===
            //================================
            public class LinhasInternal
            {
                public LinhasInternal(string LinhaName)
                {
                    this.LineName = LinhaName;
                }
                public string LineName;
                public int QtdAtrasados;
            }

            //=====================================
            // === CLASSE LINHAS PARES INTERNAS ===
            //====================================
            public class LinhasParesInternal
            {
                public LinhasParesInternal(string LinhaName)
                {
                    this.LineName = LinhaName;
                }
                public string LineName;
                public int QtdAtrasados;
            }

            //================================
            // === CLASSE COLUNAS INTERNAS ===
            //================================
            public class ColunasInternal
            {
                public ColunasInternal(string ColumnName)
                {
                    this.ColumnName = ColumnName;
                }
                public string ColumnName;
                public int QtdAtrasados;
            }

            //======================================
            // === CLASSE COLUNAS PARES INTERNAS ===
            //======================================
            public class ColunasParesInternal
            {
                public ColunasParesInternal(string ColumnName)
                {
                    this.ColumnName = ColumnName;
                }
                public string ColumnName;
                public int QtdAtrasados;
            }

            //================================
            // === CLASSE DEZENAS INTERNAS ===
            //================================
            public class DezenasInternal
            {          
                public string DezenaName;
                public int QtdAtrasados;
            }

            //==========================================
            // === CLASSE DEZENAS REPETIDAS INTERNAS ===
            //==========================================
            public class RepetidasInternal
            {
                public string DezenaName;
                public int QtdRepetida;
            }

            public IEnumerable<DezenasInternal> All_Atrasadas = null;            
            public DezenasInternal[] TopDezenas_Atrasadas = new DezenasInternal[10];
            public IEnumerable<LinhasInternal> Linhas_Atrasadas = null;
            public IEnumerable<ColunasInternal> Colunas_Atrasadas = null;
            public IEnumerable<ColunasParesInternal> Colunas_Atrasada_Pares = null;
            public IEnumerable<LinhasParesInternal> Linhas_Atrasadas_Pares = null;
            public IEnumerable<RepetidasInternal> DezenasRepetidas = null;
        }

        //===============================
        // === CLASSE PARES E IMPARES ===
        //===============================
        public class ParImparIntenal
        {
            public int QuatroPares_DoisImpares_Ocorrencias = 0;
            public int QuatroImpares_DoisPares_Ocorrencias = 0;
            public int TresPares_TresImpares_Ocorrencias = 0;
            public int CincoPares_UmImpares_Ocorrencias = 0;
            public int UmPares_CincoImpares_Ocorrencias = 0;
            public int SeisPares_ZeroImpares_Ocorrencia = 0;
            public int ZeroPares_SeisImpares_Ocorrencias = 0;

            public double QuatroPares_DoisImpares_Porcentagem = 0;
            public double QuatroImpares_DoisPares_Porcentagem = 0;
            public double TresPares_TresImpares_Porcentagem = 0;
            public double CincoPares_UmImpares_Porcentagem = 0;
            public double UmPares_CincoImpares_Porcentagem = 0;
            public double SeisPares_ZeroImpares_Porcentagem = 0;
            public double ZeroPares_SeisImpares_Porcentagem = 0;

            public int QuatroPares_DoisImpares_Media = 0;
            public int QuatroImpares_DoisPares_Media = 0;
            public int TresPares_TresImpares_Media = 0;
            public int CincoPares_UmImpares_Media = 0;
            public int UmPares_CincoImpares_Media = 0;
            public int SeisPares_ZeroImpares_Media = 0;
            public int ZeroPares_SeisImpares_Media = 0;

            public int QuatroPares_DoisImpares_UltimaOco = 0;
            public int QuatroImpares_DoisPares_UltimaOco = 0;
            public int TresPares_TresImpares_UltimaOco = 0;
            public int CincoPares_UmImpares_UltimaOco = 0;
            public int UmPares_CincoImpares_UltimaOco = 0;
            public int SeisPares_ZeroImpares_UltimaOco = 0;
            public int ZeroPares_SeisImpares_UltimaOco = 0;

            public int QuatroPares_DoisImpares_Atraso = 0;
            public int QuatroImpares_DoisPares_Atraso = 0;
            public int TresPares_TresImpares_Atraso = 0;
            public int CincoPares_UmImpares_Atraso = 0;
            public int UmPares_CincoImpares_Atraso = 0;
            public int SeisPares_ZeroImpares_Atraso = 0;
            public int ZeroPares_SeisImpares_Atraso = 0;
        }

        //===================
        // === CONSTRUTOR ===
        //===================
        public frmBackTest()
        {
            InitializeComponent();
        }

        //==================
        // === VARIAVEIS ===
        //==================
        ParImparIntenal ParImpar = new ParImparIntenal();
        AtrasadosInternal Atrasados = new AtrasadosInternal();
        Estatisticas estatisticas = new Estatisticas();
        Banco_de_Dados db = new Banco_de_Dados();
        LastGame lastGame = new LastGame();
        //População
        object[] Populacao;


        //===================================
        // === QUANDO MUDA A VISIBILIDADE ===
        //===================================
        private void frmBackTest_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == true)
            {
                Show();
                Refresh();
                Thread.Sleep(500);
                //SetValoresGrafico();
            }
        }

        //==========================
        // === TODOS OS CALCULOS ===
        //==========================
        public void Calculos()
        {
            try
            {
                List<Concurso> Concursos = db.Buscar(0, false).ToList();

                for (int i = 0; i < Concursos.Count; i++)
                {
                    Concurso Con = Concursos[i];
                    int QtdPar = 0;
                    int QtdImpar = 0;

                    try
                    {
                        //Quantos Pares e impares
                        for (int j = 0; j < Con.Dezenas.Length; j++)
                        {
                            int Dezena = Convert.ToInt32(Con.Dezenas[j]);
                            if (Dezena % 2 == 0)//Par
                            {
                                QtdPar++;
                            }
                            else //Impar
                            {
                                QtdImpar++;
                            }
                        }
                    }
                    finally
                    {
                        if (QtdPar == 3 && QtdImpar == 3)// 3P e 3I
                        {
                            ParImpar.TresPares_TresImpares_Ocorrencias++;
                            ParImpar.TresPares_TresImpares_UltimaOco = Con.NumConcurso;
                            ParImpar.TresPares_TresImpares_Porcentagem = (ParImpar.TresPares_TresImpares_Ocorrencias * 100) / (i+1);
                            ParImpar.TresPares_TresImpares_Media = (i+1) / ParImpar.TresPares_TresImpares_Ocorrencias;
                            ParImpar.TresPares_TresImpares_Atraso = 0;

                            ParImpar.CincoPares_UmImpares_Atraso++;
                            ParImpar.ZeroPares_SeisImpares_Atraso++;
                            ParImpar.QuatroImpares_DoisPares_Atraso++;
                            ParImpar.QuatroPares_DoisImpares_Atraso++;
                            ParImpar.SeisPares_ZeroImpares_Atraso++;
                            ParImpar.UmPares_CincoImpares_Atraso++;                            
                        }
                        else if(QtdPar == 4 && QtdImpar == 2)// 4P e 2I
                        {
                            ParImpar.QuatroPares_DoisImpares_Ocorrencias++;
                            ParImpar.QuatroPares_DoisImpares_UltimaOco = Con.NumConcurso;
                            ParImpar.QuatroPares_DoisImpares_Porcentagem = (ParImpar.TresPares_TresImpares_Ocorrencias * 100) / (i+1);
                            ParImpar.QuatroPares_DoisImpares_Media = (i + 1) / ParImpar.TresPares_TresImpares_Ocorrencias;
                            ParImpar.QuatroPares_DoisImpares_Atraso = 0;

                            ParImpar.CincoPares_UmImpares_Atraso++;
                            ParImpar.ZeroPares_SeisImpares_Atraso++;
                            ParImpar.QuatroImpares_DoisPares_Atraso++;
                            ParImpar.TresPares_TresImpares_Atraso++;
                            ParImpar.SeisPares_ZeroImpares_Atraso++;
                            ParImpar.UmPares_CincoImpares_Atraso++;                            
                        }
                        else if (QtdPar == 2 && QtdImpar == 4)// 2P e 4I
                        {
                            ParImpar.QuatroImpares_DoisPares_Ocorrencias++;
                            ParImpar.QuatroImpares_DoisPares_UltimaOco = Con.NumConcurso;
                            ParImpar.QuatroImpares_DoisPares_Porcentagem = (ParImpar.TresPares_TresImpares_Ocorrencias * 100) / (i + 1);
                            ParImpar.QuatroImpares_DoisPares_Media = (i + 1) / ParImpar.TresPares_TresImpares_Ocorrencias;
                            ParImpar.QuatroImpares_DoisPares_Atraso = 0;

                            ParImpar.CincoPares_UmImpares_Atraso++;
                            ParImpar.ZeroPares_SeisImpares_Atraso++;
                            ParImpar.QuatroPares_DoisImpares_Atraso++;
                            ParImpar.TresPares_TresImpares_Atraso++;
                            ParImpar.SeisPares_ZeroImpares_Atraso++;
                            ParImpar.UmPares_CincoImpares_Atraso++;
                        }
                        else if (QtdPar == 5 && QtdImpar == 1)// 5P e 1I
                        {
                            ParImpar.CincoPares_UmImpares_Ocorrencias++;
                            ParImpar.CincoPares_UmImpares_UltimaOco = Con.NumConcurso;
                            ParImpar.CincoPares_UmImpares_Porcentagem = (ParImpar.TresPares_TresImpares_Ocorrencias * 100) / (i + 1);
                            ParImpar.CincoPares_UmImpares_Media = (i + 1) / ParImpar.TresPares_TresImpares_Ocorrencias;
                            ParImpar.CincoPares_UmImpares_Atraso = 0;

                            ParImpar.QuatroPares_DoisImpares_Atraso++;
                            ParImpar.ZeroPares_SeisImpares_Atraso++;
                            ParImpar.QuatroPares_DoisImpares_Atraso++;
                            ParImpar.TresPares_TresImpares_Atraso++;
                            ParImpar.SeisPares_ZeroImpares_Atraso++;
                            ParImpar.UmPares_CincoImpares_Atraso++;
                        }
                        else if (QtdPar == 1 && QtdImpar == 5)// 1P e 5I
                        {
                            ParImpar.UmPares_CincoImpares_Ocorrencias++;
                            ParImpar.UmPares_CincoImpares_UltimaOco = Con.NumConcurso;
                            ParImpar.UmPares_CincoImpares_Porcentagem = (ParImpar.TresPares_TresImpares_Ocorrencias * 100) / (i + 1);
                            ParImpar.UmPares_CincoImpares_Media = (i + 1) / ParImpar.TresPares_TresImpares_Ocorrencias;
                            ParImpar.UmPares_CincoImpares_Atraso = 0;

                            ParImpar.QuatroPares_DoisImpares_Atraso++;
                            ParImpar.ZeroPares_SeisImpares_Atraso++;
                            ParImpar.QuatroPares_DoisImpares_Atraso++;
                            ParImpar.TresPares_TresImpares_Atraso++;
                            ParImpar.SeisPares_ZeroImpares_Atraso++;
                            ParImpar.CincoPares_UmImpares_Atraso++;

                        }
                        else if (QtdPar == 6 && QtdImpar == 0)// 6P e 0I
                        {
                            ParImpar.SeisPares_ZeroImpares_Ocorrencia++;
                            ParImpar.SeisPares_ZeroImpares_UltimaOco = Con.NumConcurso;
                            ParImpar.SeisPares_ZeroImpares_Porcentagem = (ParImpar.TresPares_TresImpares_Ocorrencias * 100) / (i + 1);
                            ParImpar.SeisPares_ZeroImpares_Media = (i + 1) / ParImpar.TresPares_TresImpares_Ocorrencias;
                            ParImpar.SeisPares_ZeroImpares_Atraso = 0;

                            ParImpar.QuatroPares_DoisImpares_Atraso++;
                            ParImpar.ZeroPares_SeisImpares_Atraso++;
                            ParImpar.QuatroPares_DoisImpares_Atraso++;
                            ParImpar.TresPares_TresImpares_Atraso++;
                            ParImpar.UmPares_CincoImpares_Atraso++;
                            ParImpar.CincoPares_UmImpares_Atraso++;
                        }
                        else if (QtdPar == 0 && QtdImpar == 6)// 0P e 6I
                        {
                            ParImpar.ZeroPares_SeisImpares_Ocorrencias++;
                            ParImpar.ZeroPares_SeisImpares_UltimaOco = Con.NumConcurso;
                            ParImpar.ZeroPares_SeisImpares_Porcentagem = (ParImpar.TresPares_TresImpares_Ocorrencias * 100) / (i + 1);
                            ParImpar.ZeroPares_SeisImpares_Media = (i + 1) / ParImpar.TresPares_TresImpares_Ocorrencias;
                            ParImpar.ZeroPares_SeisImpares_Atraso = 0;

                            ParImpar.QuatroPares_DoisImpares_Atraso++;
                            ParImpar.SeisPares_ZeroImpares_Atraso++;
                            ParImpar.QuatroPares_DoisImpares_Atraso++;
                            ParImpar.TresPares_TresImpares_Atraso++;
                            ParImpar.UmPares_CincoImpares_Atraso++;
                            ParImpar.CincoPares_UmImpares_Atraso++;
                        }
                    }

                    //Calcula Atrasadas
                    try
                    {
                        //LOOPING QUE ORGANIZA PARA A CONTAGEM DOS NÚMERO MAIS ATRASADOS    
                        int[] TabelaDezenas = new int[60];                        
                        for (int j = 0; j < 60; j++)
                        {
                            TabelaDezenas[j] = j + 1;                            
                        }

                        DezenasInternal[] DezenasAtrasadas = new DezenasInternal[60];//talvez coloco como statico para manter o valores
                        for (int j = 0; j < DezenasAtrasadas.Length; j++)
                        {
                            DezenasInternal dezenasInternal = new DezenasInternal();
                            dezenasInternal.DezenaName = (j + 1).ToString();
                            DezenasAtrasadas[j] = dezenasInternal;
                        }
                        string[] CloneDezenas = new string[Con.NumConcurso];
                        string[] DezenasParaAtrasadas = new string[Con.NumConcurso];
                        for (int j = 0; j < Con.NumConcurso; j++)
                        {
                            string Dez = string.Join(",", Concursos[j].Dezenas);
                            DezenasParaAtrasadas[j] = Dez;
                        }
                        Array.Copy(DezenasParaAtrasadas, CloneDezenas, CloneDezenas.Length);
                                                  
                        for (int p = 0; p < CloneDezenas.Length; p++)
                        {
                            string CopyD1 = CloneDezenas[p];
                            string[] CopySeparaDezenas = CopyD1.Split(',');
                            string IndexAchados = "";
                            for (int S = 0; S < 6; S++)
                            {
                                int index = SubAnalise.ArraySeach(TabelaDezenas, Convert.ToInt32(CopySeparaDezenas[S]));
                                DezenasAtrasadas[index].DezenaName = CopySeparaDezenas[S].Replace(" ","");
                                DezenasAtrasadas[index].QtdAtrasados = 0;
                                IndexAchados += IndexAchados == "" ? index.ToString() : " , " + index.ToString();
                            }

                            //LOOPING QUE CALCULA OS AS DEZENAS MAIS ATRASADAS
                            string[] Indexs = IndexAchados.Split(',');
                            for (int j = 0; j < 60; j++)
                            {
                                if (j != Convert.ToInt32(Indexs[0]) && j != Convert.ToInt32(Indexs[1]) && j != Convert.ToInt32(Indexs[2]) && j != Convert.ToInt32(Indexs[3]) && j != Convert.ToInt32(Indexs[4]) && j != Convert.ToInt32(Indexs[5]))
                                {
                                    DezenasAtrasadas[j].QtdAtrasados += 1;
                                }
                            }
                        }

                        //All Atrasados
                        List<DezenasInternal> ListDezenas = new List<DezenasInternal>();
                        for (int j = 0; j < DezenasAtrasadas.Length; j++)
                        {                            
                            ListDezenas.Add(DezenasAtrasadas[j]);
                        }
                        Atrasados.All_Atrasadas = ListDezenas.OrderByDescending(Dez => Dez.QtdAtrasados);

                        Console.WriteLine("==========ATRASADAS===========");
                        Console.WriteLine(Con.NumConcurso);
                        foreach (DezenasInternal item in Atrasados.All_Atrasadas)
                        {
                            Console.WriteLine(item.DezenaName + ": " + item.QtdAtrasados);
                        }

                        //Dezena Repetida
                        //LOOPING QUE CALCULA AS DEZENAS REPETIDAS
                        List<RepetidasInternal> ListRepetidas = new List<RepetidasInternal>();
                        int[] DezenasRepetidas = new int[60];
                        for (int j = 0; j < Con.NumConcurso; j++)
                        {                            
                            string D1 = string.Join(",", Concursos[j].Dezenas);
                            string[] SeparaDezenas = D1.Split(',');
                            for (int p = 0; p < 60; p++)
                            {
                                if (p == Convert.ToInt32(SeparaDezenas[0]) || p == Convert.ToInt32(SeparaDezenas[1]) || p == Convert.ToInt32(SeparaDezenas[2]) || p == Convert.ToInt32(SeparaDezenas[3]) || p == Convert.ToInt32(SeparaDezenas[4]) || p == Convert.ToInt32(SeparaDezenas[5]))
                                {                                    
                                    DezenasRepetidas[p - 1] += 1;
                                }
                            }
                        }

                        string rest = "";
                        int restCont = 0;
                        for (int j = 0; j < 60; j++)
                        {
                            if (DezenasRepetidas[j] >= 2)
                            {
                                RepetidasInternal repetidasInternal = new RepetidasInternal();
                                repetidasInternal.DezenaName = (j + 1).ToString();
                                repetidasInternal.QtdRepetida = DezenasRepetidas[j];
                                ListRepetidas.Add(repetidasInternal);
                            }
                            else if(DezenasRepetidas[j] < 2)
                            {
                                rest = rest == "" ? (j + 1).ToString() : "-" + (j + 1).ToString();
                                restCont++;
                            }
                        }
                        Populacao = new object[restCont];
                        Populacao = rest.Split('-');
                        Atrasados.DezenasRepetidas = ListRepetidas.OrderByDescending(Repet => Repet.QtdRepetida);

                        Console.WriteLine("=======REPETIDAS==========");
                        Console.WriteLine(Con.NumConcurso);
                        foreach (RepetidasInternal item in Atrasados.DezenasRepetidas)
                        {
                            Console.WriteLine(item.DezenaName + ": " + item.QtdRepetida);
                        }
                  
                        //TOP 10 atrasados
                        int ij = 0;
                        foreach (DezenasInternal D in Atrasados.All_Atrasadas)
                        {
                            if (ij < 10)
                            {
                                Atrasados.TopDezenas_Atrasadas[ij] = D;
                                ij++;
                            }       
                        }

                        Console.WriteLine("=======TOP ATRASADOS==============");
                        Console.WriteLine(Con.NumConcurso);
                        foreach (DezenasInternal item in Atrasados.TopDezenas_Atrasadas)
                        {
                            Console.WriteLine(item.DezenaName + ": " + item.QtdAtrasados);
                        }


                        //Colunas Atrasadas e em Pares
                        List<ColunasInternal> ListColunas = new List<ColunasInternal>();
                        List<ColunasParesInternal> ListPares = new List<ColunasParesInternal>();

                        ColunasParesInternal CP1 = new ColunasParesInternal("C1");
                        ColunasParesInternal CP2 = new ColunasParesInternal("C2");
                        ColunasParesInternal CP3 = new ColunasParesInternal("C3");
                        ColunasParesInternal CP4 = new ColunasParesInternal("C4");
                        ColunasParesInternal CP5 = new ColunasParesInternal("C5");
                        ColunasParesInternal CP6 = new ColunasParesInternal("C6");
                        ColunasParesInternal CP7 = new ColunasParesInternal("C7");
                        ColunasParesInternal CP8 = new ColunasParesInternal("C8");
                        ColunasParesInternal CP9 = new ColunasParesInternal("C9");
                        ColunasParesInternal CP10 = new ColunasParesInternal("C10");

                        ColunasInternal C1 = new ColunasInternal("C1");
                        ColunasInternal C2 = new ColunasInternal("C2");
                        ColunasInternal C3 = new ColunasInternal("C3");
                        ColunasInternal C4 = new ColunasInternal("C4");
                        ColunasInternal C5 = new ColunasInternal("C5");
                        ColunasInternal C6 = new ColunasInternal("C6");
                        ColunasInternal C7 = new ColunasInternal("C7");
                        ColunasInternal C8 = new ColunasInternal("C8");
                        ColunasInternal C9 = new ColunasInternal("C9");
                        ColunasInternal C10 = new ColunasInternal("C10");

                        for (int j = 0; j < Con.NumConcurso; j++)
                        {
                            string[] Dezenas_2 = db.Buscar(j+1).Dezenas;
                            string ColumnsOut = "";                            

                            int QtdC1 = 0;
                            int QtdC2 = 0;
                            int QtdC3 = 0;
                            int QtdC4 = 0;
                            int QtdC5 = 0;
                            int QtdC6 = 0;
                            int QtdC7 = 0;
                            int QtdC8 = 0;
                            int QtdC9 = 0;
                            int QtdC10 = 0;
                            for (int k = 0; k < Dezenas_2.Length; k++)//Verifica qual coluna saiu
                            {
                                string Value = Dezenas_2[k];
                                Value = Value.Remove(1, 1).Replace(" ","");
                                if (Value == "1")
                                {
                                    if(QtdC1 < 1) ColumnsOut += ColumnsOut != "" ? "-C1" : "C1";                                                                        
                                    QtdC1++;

                                }
                                else if (Value == "2")
                                {                                    
                                    if (QtdC2 < 1) ColumnsOut += ColumnsOut != "" ? "-C2" : "C2";
                                    QtdC2++;                               
                                }
                                else if (Value == "3")
                                {
                                    if (QtdC3 < 1) ColumnsOut += ColumnsOut != "" ? "-C3" : "C3";
                                    QtdC3++;
                                }
                                else if (Value == "4")
                                {
                                    if (QtdC4 < 1) ColumnsOut += ColumnsOut != "" ? "-C4" : "C4";
                                    QtdC4++;
                                }
                                else if (Value == "5")
                                {
                                    if (QtdC5 < 1) ColumnsOut += ColumnsOut != "" ? "-C5" : "C5";
                                    QtdC5++;
                                }
                                else if (Value == "6")
                                {
                                    if (QtdC6 < 1) ColumnsOut += ColumnsOut != "" ? "-C6" : "C6";
                                    QtdC6++;
                                }
                                else if (Value == "7")
                                {
                                    if (QtdC7 < 1) ColumnsOut += ColumnsOut != "" ? "-C7" : "C7";
                                    QtdC7++;
                                }
                                else if (Value == "8")
                                {
                                    if (QtdC8 < 1) ColumnsOut += ColumnsOut != "" ? "-C8" : "C8";
                                    QtdC8++;
                                }
                                else if (Value == "9")
                                {
                                    if (QtdC9 < 1) ColumnsOut += ColumnsOut != "" ? "-C9" : "C9";
                                    QtdC9++;
                                }
                                else if (Value == "0")
                                {
                                    if (QtdC10 < 1) ColumnsOut += ColumnsOut != "" ? "-C10" : "C10";
                                    QtdC10++;
                                }                                
                            }

                            string[] C_out = ColumnsOut.Split('-');
                            C1.QtdAtrasados++;
                            C2.QtdAtrasados++;
                            C3.QtdAtrasados++;
                            C4.QtdAtrasados++;
                            C5.QtdAtrasados++;
                            C6.QtdAtrasados++;
                            C7.QtdAtrasados++;
                            C8.QtdAtrasados++;
                            C9.QtdAtrasados++;
                            C10.QtdAtrasados++;

                            CP1.QtdAtrasados++;
                            CP2.QtdAtrasados++;
                            CP3.QtdAtrasados++;
                            CP4.QtdAtrasados++;
                            CP5.QtdAtrasados++;
                            CP6.QtdAtrasados++;
                            CP7.QtdAtrasados++;
                            CP8.QtdAtrasados++;
                            CP9.QtdAtrasados++;
                            CP10.QtdAtrasados++;
                            for (int k = 0; k < C_out.Length; k++)
                            {
                                string value = C_out[k].Replace(" ","");
                                if (value == "C1")
                                {
                                    if (QtdC1 > 1) CP1.QtdAtrasados = 0;
                                    C1.QtdAtrasados = 0;                         
                                }
                                else if (value == "C2")
                                {
                                    if (QtdC2 > 1) CP2.QtdAtrasados = 0;
                                    C2.QtdAtrasados = 0;                                    
                                }
                                else if (value == "C3")
                                {
                                    if (QtdC3 > 1) CP3.QtdAtrasados = 0;
                                    C3.QtdAtrasados = 0;
                                }
                                else if (value == "C4")
                                {
                                    if (QtdC4 > 1) CP4.QtdAtrasados = 0;
                                    C4.QtdAtrasados = 0;
                                }
                                else if (value == "C5")
                                {
                                    if (QtdC5 > 1) CP5.QtdAtrasados = 0;
                                    C5.QtdAtrasados = 0;
                                }
                                else if (value == "C6")
                                {
                                    if (QtdC6 > 1) CP6.QtdAtrasados = 0;
                                    C6.QtdAtrasados = 0;
                                }
                                else if (value == "C7")
                                {
                                    if (QtdC7 > 1) CP7.QtdAtrasados = 0;
                                    C7.QtdAtrasados = 0;
                                }
                                else if (value == "C8")
                                {
                                    if (QtdC8 > 1) CP8.QtdAtrasados = 0;
                                    C8.QtdAtrasados = 0;
                                }
                                else if (value == "C9")
                                {
                                    if (QtdC9 > 1) CP9.QtdAtrasados = 0;
                                    C9.QtdAtrasados = 0;
                                }
                                else if (value == "C10")
                                {
                                    if (QtdC10 > 1) CP10.QtdAtrasados = 0;
                                    C10.QtdAtrasados = 0;
                                }
                            }
                        }

                        ListColunas.Add(C1);
                        ListColunas.Add(C2);
                        ListColunas.Add(C3);
                        ListColunas.Add(C4);
                        ListColunas.Add(C5);
                        ListColunas.Add(C6);
                        ListColunas.Add(C7);
                        ListColunas.Add(C8);
                        ListColunas.Add(C9);
                        ListColunas.Add(C10);

                        ListPares.Add(CP1);
                        ListPares.Add(CP2);
                        ListPares.Add(CP3);
                        ListPares.Add(CP4);
                        ListPares.Add(CP5);
                        ListPares.Add(CP6);
                        ListPares.Add(CP7);
                        ListPares.Add(CP8);
                        ListPares.Add(CP9);
                        ListPares.Add(CP10);

                        Atrasados.Colunas_Atrasada_Pares = ListPares.OrderByDescending(Coluna => Coluna.QtdAtrasados);
                        Atrasados.Colunas_Atrasadas = ListColunas.OrderByDescending(Coluna => Coluna.QtdAtrasados);

                        Console.WriteLine("========COLUNAS=============");
                        Console.WriteLine(Con.NumConcurso);
                        foreach (ColunasInternal item in Atrasados.Colunas_Atrasadas)
                        {
                            Console.WriteLine(item.ColumnName + ": " + item.QtdAtrasados);
                        }

                        Console.WriteLine("========COLUNAS PARES=============");
                        Console.WriteLine(Con.NumConcurso);
                        foreach (ColunasParesInternal item in Atrasados.Colunas_Atrasada_Pares)
                        {
                            Console.WriteLine(item.ColumnName + ": " + item.QtdAtrasados);
                        }

                        //Linhas atrasadas e em Pares
                        List<LinhasInternal> ListLinhas = new List<LinhasInternal>();
                        List<LinhasParesInternal> ListLinePares = new List<LinhasParesInternal>();

                        LinhasParesInternal LP1 = new LinhasParesInternal("L1");
                        LinhasParesInternal LP2 = new LinhasParesInternal("L2");
                        LinhasParesInternal LP3 = new LinhasParesInternal("L3");
                        LinhasParesInternal LP4 = new LinhasParesInternal("L4");
                        LinhasParesInternal LP5 = new LinhasParesInternal("L5");
                        LinhasParesInternal LP6 = new LinhasParesInternal("L6");

                        LinhasInternal L1 = new LinhasInternal("L1");
                        LinhasInternal L2 = new LinhasInternal("L2");
                        LinhasInternal L3 = new LinhasInternal("L3");
                        LinhasInternal L4 = new LinhasInternal("L4");
                        LinhasInternal L5 = new LinhasInternal("L5");
                        LinhasInternal L6 = new LinhasInternal("L6");

                        for (int j = 0; j < Con.NumConcurso; j++)
                        {
                            string[] Dezenas_2 = db.Buscar(j + 1).Dezenas;
                            string LineOut = "";

                            int QtdL1 = 0;
                            int QtdL2 = 0;
                            int QtdL3 = 0;
                            int QtdL4 = 0;
                            int QtdL5 = 0;
                            int QtdL6 = 0;                    
                            for (int k = 0; k < Dezenas_2.Length; k++)//Verifica qual coluna saiu
                            {
                                string Value = Dezenas_2[k];
                                Value = Value.Replace(" ", "");
                                int Valor = Convert.ToInt32(Value);
                                if (Valor >= 1 && Valor <= 10)
                                {
                                    if (QtdL1 < 1) LineOut += LineOut != "" ? "-L1" : "L1";
                                    QtdL1++;

                                }
                                else if (Valor >= 11 && Valor <= 20)
                                {
                                    if (QtdL2 < 1) LineOut += LineOut != "" ? "-L2" : "L2";
                                    QtdL2++;
                                }
                                else if (Valor >= 21 && Valor <= 30)
                                {
                                    if (QtdL3 < 1) LineOut += LineOut != "" ? "-L3" : "L3";
                                    QtdL3++;
                                }
                                else if (Valor >= 31 && Valor <= 40)
                                {
                                    if (QtdL4 < 1) LineOut += LineOut != "" ? "-L4" : "L4";
                                    QtdL4++;
                                }
                                else if (Valor >= 41 && Valor <= 50)
                                {
                                    if (QtdL5 < 1) LineOut += LineOut != "" ? "-L5" : "L5";
                                    QtdL5++;
                                }
                                else if (Valor >= 51 && Valor <= 60)
                                {
                                    if (QtdL6 < 1) LineOut += LineOut != "" ? "-L6" : "L6";
                                    QtdL6++;
                                }                               
                            }

                            string[] L_out = LineOut.Split('-');
                            L1.QtdAtrasados++;
                            L2.QtdAtrasados++;
                            L3.QtdAtrasados++;
                            L4.QtdAtrasados++;
                            L5.QtdAtrasados++;
                            L6.QtdAtrasados++;

                            LP1.QtdAtrasados++;
                            LP2.QtdAtrasados++;
                            LP3.QtdAtrasados++;
                            LP4.QtdAtrasados++;
                            LP5.QtdAtrasados++;
                            LP6.QtdAtrasados++;
                            for (int k = 0; k < L_out.Length; k++)
                            {
                                string value = L_out[k].Replace(" ", "");
                                if (value == "L1")
                                {
                                    if (QtdL1 > 1) LP1.QtdAtrasados = 0;    
                                    L1.QtdAtrasados = 0;
                                }
                                else if (value == "L2")
                                {
                                    if (QtdL2 > 1) LP2.QtdAtrasados = 0;
                                    L2.QtdAtrasados = 0;
                                }
                                else if (value == "L3")
                                {
                                    if (QtdL3 > 1) LP3.QtdAtrasados = 0;
                                    L3.QtdAtrasados = 0;
                                }
                                else if (value == "L4")
                                {
                                    if (QtdL4 > 1) LP4.QtdAtrasados = 0;
                                    L4.QtdAtrasados = 0;
                                }
                                else if (value == "L5")
                                {
                                    if (QtdL5 > 1) LP5.QtdAtrasados = 0;
                                    L5.QtdAtrasados = 0;
                                }
                                else if (value == "L6")
                                {
                                    if (QtdL6 > 1) LP6.QtdAtrasados = 0;
                                    L6.QtdAtrasados = 0;
                                    
                                }                                
                            }
                        }

                        ListLinhas.Add(L1);
                        ListLinhas.Add(L2);
                        ListLinhas.Add(L3);
                        ListLinhas.Add(L4);
                        ListLinhas.Add(L5);
                        ListLinhas.Add(L6);

                        ListLinePares.Add(LP1);
                        ListLinePares.Add(LP2);
                        ListLinePares.Add(LP3);
                        ListLinePares.Add(LP4);
                        ListLinePares.Add(LP5);
                        ListLinePares.Add(LP6);

                        Atrasados.Linhas_Atrasadas = ListLinhas.OrderByDescending(Linha => Linha.QtdAtrasados);
                        Atrasados.Linhas_Atrasadas_Pares = ListLinePares.OrderByDescending(Linha => Linha.QtdAtrasados);

                        Console.WriteLine("========LINHAS=============");
                        Console.WriteLine(Con.NumConcurso);
                        foreach (LinhasInternal item in Atrasados.Linhas_Atrasadas)
                        {
                            Console.WriteLine(item.LineName + ": " + item.QtdAtrasados);
                        }

                        Console.WriteLine("========LINHAS PARES=============");
                        Console.WriteLine(Con.NumConcurso);
                        foreach (LinhasParesInternal item in Atrasados.Linhas_Atrasadas_Pares)
                        {
                            Console.WriteLine(item.LineName + ": " + item.QtdAtrasados);
                        }

                        //Calculos Dezenas Repetidas do ultimo Jogo
                        int Repetiu = 0;
                        for (int k = 0; k < Con.Dezenas.Length; k++)
                        {
                            bool Pula = false;
                            string[] NowGame = Concursos[i].Dezenas;
                            string[] PreviousGame = null;
                            if (Concursos[i - 1].NumConcurso != 0)//Talves possa dar erro
                            {
                                PreviousGame = Concursos[i - 1].Dezenas;
                            }
                            else
                            {
                                Pula = true;
                            }

                            if (Pula == false)
                            {
                                Repetiu = 0;
                                for (int a = 0; a < NowGame.Length; a++)
                                {
                                    int ValueA = Convert.ToInt32(NowGame[a]);
                                    for (int b = 0; b < PreviousGame.Length; b++)
                                    {
                                        int ValueB = Convert.ToInt32(PreviousGame[b]);

                                        if (ValueA == ValueB)
                                        {
                                            Repetiu++;
                                        }
                                    }
                                }                        
                            }
                        }                        
                        if (Repetiu == 0)//Repetiu nenhum
                        {
                            lastGame.RepeteZero_Ocorrencias++;
                            lastGame.RepeteZero_Atrasos = 0;
                            lastGame.RepeteZero_UltimoConcurso = Concursos[i].NumConcurso;
                            lastGame.RepeteZero_Porcentagens = i / lastGame.RepeteZero_Ocorrencias;
                            lastGame.RepeteZero_Media = lastGame.RepeteZero_Ocorrencias / i;
                        }



                    }
                    finally { }

                    //Finalizações
                    List<string> Combinacoes = new List<string>();
                    try
                    {
                        int impar = 0;
                        int par = 0;
                        string DezenasFixas = "";

                        //Define Qual par e impar jogar
                        //{
                        if (ParImpar.TresPares_TresImpares_Atraso >= ParImpar.TresPares_TresImpares_Media)//Par 3 Impar 3
                        {
                            impar = 3;
                            par = 3;
                        }
                        else if (ParImpar.QuatroPares_DoisImpares_Atraso >= ParImpar.QuatroPares_DoisImpares_Media)//Par 4 Impar 2
                        {
                            impar = 2;
                            par = 4;
                        }
                        else if (ParImpar.QuatroImpares_DoisPares_Atraso >= ParImpar.QuatroImpares_DoisPares_Media)//Par 2 Impar 4
                        {
                            impar = 4;
                            par = 2;
                        }
                        else if (ParImpar.UmPares_CincoImpares_Atraso >= ParImpar.UmPares_CincoImpares_Media)//Par 1 Impar 5
                        {
                            impar = 1;
                            par = 5;
                        }
                        else if (ParImpar.CincoPares_UmImpares_Atraso >= ParImpar.CincoPares_UmImpares_Media)//Par 5 Impar 1
                        {
                            impar = 5;
                            par = 1;
                        }
                        else if (ParImpar.SeisPares_ZeroImpares_Atraso >= ParImpar.SeisPares_ZeroImpares_Media)//Par 6 Impar 0
                        {
                            impar = 0;
                            par = 6;
                        }
                        else if (ParImpar.ZeroPares_SeisImpares_Atraso >= ParImpar.ZeroPares_SeisImpares_Media)//Par 0 Impar 6
                        {
                            impar = 6;
                            par = 0;
                        }
                        estatisticas.PrevisaoParImpar = par + " Par " + impar + " Impar";
                        //}


                        //Repetir algum número do ultimo jogo

                        //Seleciona a mais atrasada      
                        //{                        
                        List<DezenasInternal> late = Atrasados.All_Atrasadas.ToList();
                        for (int mi = 0; mi < Populacao.Length; mi++)
                        {
                            for (int Ji = 0; Ji < late.Count; Ji++)
                            {
                                if (late[Ji].DezenaName.ToString() == Populacao[mi].ToString())
                                {
                                    DezenasFixas += DezenasFixas == "" ? late[Ji].DezenaName : "-" + late[Ji].DezenaName;
                                    Ji = late.Count;
                                    mi = Populacao.Length;
                                }
                            }
                        }
                        //}

                        //Realiza as combinasções e os filtros

                        int QtdPoulacaoRest = Populacao.Length;

                        //    for (int a = 0; a < QtdPoulacaoRest; a++)
                        //    {
                        //        for (int b = a + 1; b < QtdPoulacaoRest; b++)
                        //        {
                        //            for (int c = b + 1; c < QtdPoulacaoRest; c++)
                        //            {
                        //                for (int d = c + 1; d < QtdPoulacaoRest; d++)
                        //                {
                        //                    for (int g = d + 1; g < QtdPoulacaoRest; g++)
                        //                    {
                        //                        for (int f = g + 1; f < QtdPoulacaoRest; f++)
                        //                        {
                        //                            string Jogo = Populacao[a].ToString() + "-" + Populacao[b].ToString() + "-" + Populacao[c].ToString() + "-" + Populacao[d].ToString() + "-" + Populacao[g].ToString() + "-" + Populacao[f].ToString();
                        //                            string[] DezJogo = Jogo.Split('-');

                        //                            //1º Verificar as Dezenas que tem os números fixos
                        //                            string[] Fix = DezenasFixas.Replace(" ", "").Split('-');

                        //                            int Tem = 0;
                        //                            if (DezenasFixas == "" || Fix.Length == 0)
                        //                            {
                        //                                Tem = Fix.Length;
                        //                            }
                        //                            else
                        //                            {
                        //                                for (int m = 0; m < Fix.Length; m++)
                        //                                {
                        //                                    for (int ji = 0; ji < DezJogo.Length; ji++)
                        //                                    {
                        //                                        if (Fix[m].ToString() == DezJogo[ji].ToString())
                        //                                        {
                        //                                            Tem++;
                        //                                            ji = DezJogo.Length;
                        //                                        }
                        //                                    }
                        //                                }
                        //                            }

                        //                            if (Tem == Fix.Length)//Se sim quer dizer que tem as dezenas fixas
                        //                            {
                        //                                //2º Quantidade de pares e impares
                        //                                int Par = 0;
                        //                                int Imp = 0;
                        //                                for (int m = 0; m < DezJogo.Length; m++)
                        //                                {
                        //                                    int value = Convert.ToInt32(DezJogo[m]);
                        //                                    if (value % 2 == 0)//Par
                        //                                    {
                        //                                        Par++;
                        //                                    }
                        //                                    else//Impar
                        //                                    {
                        //                                        Imp++;
                        //                                    }
                        //                                }
                        //                                if (Imp == impar && Par == par)//Se sim quer dizer que contém a quantidade exigida de impares e pares
                        //                                {                                                                                                                
                        //                                    //3º Verificar se as Dezenas estão de acordo com as colunas selecionadas
                        //                                    //Verifica números nas Linhas
                        //                                    int Certos = 0;
                        //                                    int QtdCl = dgvQtdNumLinha.ColumnCount;
                        //                                    if (cbmSelecionarLinhas.SelectedIndex == 0)//Sim Selecionar
                        //                                    {
                        //                                        string[] L1 = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
                        //                                        string[] L2 = new string[10] { "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
                        //                                        string[] L3 = new string[10] { "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
                        //                                        string[] L4 = new string[10] { "31", "32", "33", "34", "35", "36", "37", "38", "39", "40" };
                        //                                        string[] L5 = new string[10] { "41", "42", "43", "44", "45", "46", "47", "48", "49", "50" };
                        //                                        string[] L6 = new string[10] { "51", "52", "53", "54", "55", "56", "57", "58", "59", "60" };

                        //                                        List<string[]> ListLinha = new List<string[]>();
                        //                                        ListLinha.Add(L1);
                        //                                        ListLinha.Add(L2);
                        //                                        ListLinha.Add(L3);
                        //                                        ListLinha.Add(L4);
                        //                                        ListLinha.Add(L5);
                        //                                        ListLinha.Add(L6);

                        //                                        string[] LN = new string[6] { "L1", "L2", "L3", "L4", "L5", "L6" };
                        //                                        Certos = 0;
                        //                                        QtdCl = dgvQtdNumLinha.ColumnCount;
                        //                                        for (int i = 0; i < dgvQtdNumLinha.ColumnCount; i++)
                        //                                        {
                        //                                            string ColuName = dgvQtdNumLinha.Columns[i].HeaderText.Replace(" ", "");
                        //                                            int QtdNeedNuns = Convert.ToInt32(dgvQtdNumLinha.Rows[0].Cells[i].Value);
                        //                                            int QtdHaveNumDez = 0;
                        //                                            for (int j = 0; j < LN.Length; j++)
                        //                                            {
                        //                                                if (ColuName == LN[j])//Verifica qual é a Linha que vai ter x números
                        //                                                {
                        //                                                    string[] Line = ListLinha[j];

                        //                                                    for (int k = 0; k < DezJogo.Length; k++)
                        //                                                    {
                        //                                                        for (int l = 0; l < Line.Length; l++)
                        //                                                        {
                        //                                                            if (Line[l] == DezJogo[k])
                        //                                                            {
                        //                                                                QtdHaveNumDez++;
                        //                                                                l = Line.Length;
                        //                                                            }
                        //                                                        }
                        //                                                        if (QtdHaveNumDez == QtdNeedNuns)//Quer Dizer que a linha tem a quantidade certa de números
                        //                                                        {
                        //                                                            k = DezJogo.Length;
                        //                                                            j = LN.Length;
                        //                                                            QtdHaveNumDez = 0;
                        //                                                            Certos++;
                        //                                                        }
                        //                                                    }

                        //                                                    if (QtdHaveNumDez == 0 && Certos == 0)//Sai do looping
                        //                                                    {
                        //                                                        j = LN.Length;
                        //                                                        i = QtdCl;
                        //                                                    }
                        //                                                }
                        //                                            }
                        //                                        }

                        //                                    }
                        //                                    else
                        //                                    {
                        //                                        Certos = QtdCl;
                        //                                    }

                        //                                    int CertosCo = 0;
                        //                                    int QtdCl2 = dgvQtdNumeros.ColumnCount;
                        //                                    if (cbmSelecionarColunas.SelectedIndex == 0)
                        //                                    {
                        //                                        //Verifica números nas coluans
                        //                                        string[] C1 = new string[6] { "1", "11", "21", "31", "41", "51" };
                        //                                        string[] C2 = new string[6] { "2", "12", "22", "32", "42", "52" };
                        //                                        string[] C3 = new string[6] { "3", "13", "23", "33", "43", "53" };
                        //                                        string[] C4 = new string[6] { "4", "14", "24", "34", "44", "54" };
                        //                                        string[] C5 = new string[6] { "5", "15", "25", "35", "45", "55" };
                        //                                        string[] C6 = new string[6] { "6", "16", "26", "36", "46", "56" };
                        //                                        string[] C7 = new string[6] { "7", "17", "27", "37", "47", "57" };
                        //                                        string[] C8 = new string[6] { "8", "18", "28", "38", "48", "58" };
                        //                                        string[] C9 = new string[6] { "9", "19", "29", "39", "49", "59" };
                        //                                        string[] C10 = new string[6] { "10", "20", "30", "40", "50", "60" };

                        //                                        List<string[]> ListColumn = new List<string[]>();
                        //                                        ListColumn.Add(C1);
                        //                                        ListColumn.Add(C2);
                        //                                        ListColumn.Add(C3);
                        //                                        ListColumn.Add(C4);
                        //                                        ListColumn.Add(C5);
                        //                                        ListColumn.Add(C6);
                        //                                        ListColumn.Add(C7);
                        //                                        ListColumn.Add(C8);
                        //                                        ListColumn.Add(C9);
                        //                                        ListColumn.Add(C10);

                        //                                        string[] CN = new string[10] { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10" };
                        //                                        for (int i = 0; i < dgvQtdNumeros.ColumnCount; i++)
                        //                                        {
                        //                                            string ColuName = dgvQtdNumeros.Columns[i].HeaderText.Replace(" ", "");
                        //                                            int QtdNeedNuns = Convert.ToInt32(dgvQtdNumeros.Rows[0].Cells[i].Value);
                        //                                            int QtdHaveNumDez2 = 0;
                        //                                            for (int j = 0; j < CN.Length; j++)
                        //                                            {
                        //                                                if (ColuName == CN[j])//Verifica qual é a Linha que vai ter x números
                        //                                                {
                        //                                                    string[] Line = ListColumn[j];

                        //                                                    for (int k = 0; k < DezJogo.Length; k++)
                        //                                                    {
                        //                                                        for (int l = 0; l < Line.Length; l++)
                        //                                                        {
                        //                                                            if (Line[l] == DezJogo[k])
                        //                                                            {
                        //                                                                QtdHaveNumDez2++;
                        //                                                                l = Line.Length;
                        //                                                            }
                        //                                                        }
                        //                                                        if (QtdHaveNumDez2 == QtdNeedNuns)//Quer Dizer que a linha tem a quantidade certa de números
                        //                                                        {
                        //                                                            k = DezJogo.Length;
                        //                                                            j = CN.Length;
                        //                                                            QtdHaveNumDez2 = 0;
                        //                                                            CertosCo++;
                        //                                                        }
                        //                                                    }

                        //                                                    if (QtdHaveNumDez2 == 0 && CertosCo == 0)//Sai do looping
                        //                                                    {
                        //                                                        j = CN.Length;
                        //                                                        i = QtdCl2;
                        //                                                    }
                        //                                                }
                        //                                            }
                        //                                        }
                        //                                    }
                        //                                    else
                        //                                    {
                        //                                        CertosCo = QtdCl2;
                        //                                    }

                        //                                    if (CertosCo == QtdCl2 && Certos == QtdCl)
                        //                                    {
                        //                                        Combinacoes.Add(Jogo);
                        //                                    }

                        //                                }
                        //                            }
                        //                        }
                        //                    }
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                        //finally
                        //{
                        //    Concurso ConSorteado = db.Buscar(Con.NumConcurso);
                        //    int Comtemplados = 0;
                        //    for (int j = 0; j < Populacao.Length; j++)
                        //    {
                        //        for (int m = 0; m < ConSorteado.Dezenas.Length; m++)
                        //        {
                        //            if (Convert.ToInt32(ConSorteado.Dezenas[m]) == Convert.ToInt32(Populacao[j]))
                        //            {
                        //                Comtemplados++;
                        //            }
                        //        }
                        //    }

                        //    if (Comtemplados >= 4)
                        //    {
                        //        estatisticas.AbordouPopolacao++;
                        //    }

                        //    for (int j = 0; j < Combinacoes.Count; j++)
                        //    {
                        //        string[] Game = Combinacoes[j].Split('-');
                        //        int Contem = 0;
                        //        for (int m = 0; m < ConSorteado.Dezenas.Length; m++)
                        //        {
                        //            for (int n = 0; n < Game.Length; n++)
                        //            {
                        //                if (Game[n] == ConSorteado.Dezenas[m])
                        //                {
                        //                    Contem++;
                        //                }
                        //            }
                        //        }
                        //        if (Contem == 4)
                        //        {
                        //            estatisticas.QuadraAcertos++;
                        //        }
                        //        else if (Contem == 5)
                        //        {
                        //            estatisticas.QuinaAcertos++;
                        //        }
                        //        else if (Contem == 6)
                        //        {
                        //            estatisticas.SenaAcertos++;
                        //        }
                        //    }

                    }
                    finally { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Opss!", "Ocorreu um erro: " + ex.Message);
            }
        }

    
        public void SetValoresGrafico()        
        {
            int k = 0, k1 = 80;
            int j = 0, j1 = 50;
            for (int i = 0; i < 201; i++)
            {
                chtResultados.Series[0].Points[0].SetValueY(i);
                chtResultados.Series[0].Points[0].Label = i.ToString();
                if (j <= j1)
                {
                    chtResultados.Series[0].Points[1].SetValueY(j);
                    chtResultados.Series[0].Points[1].Label = j.ToString();
                }
                if (k <= k1)
                {
                    chtResultados.Series[0].Points[2].SetValueY(k);
                    chtResultados.Series[0].Points[2].Label = k.ToString();

                }
                Thread.Sleep(1);
                
                k++;
                j++;
                Refresh();
            }
        }

        //=======================
        // === EVENTOS CLICK ====
        //=======================          
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Calculos();
            //ocorrencia();
        }


        public void ocorrencia()
        {
            List<Concurso> Concursos = db.Buscar(0, false).ToList();
            Ocorrencia ocorrencia = new Ocorrencia();
            
            for (int i = 0; i < Concursos.Count; i++)
            {
                bool TrueL1 = false;
                bool TrueL2 = false;
                bool TrueL3 = false;
                bool TrueL4 = false;
                bool TrueL5 = false;
                bool TrueL6 = false;

                string[] Dezenas = Concursos[i].Dezenas;

                for (int j = 0; j < Concursos[i].Dezenas.Length; j++)
                {
                    int Value = Convert.ToInt32(Dezenas[j]);

                    if (Value >= 1 && Value <= 10)//L1
                    {
                        if (TrueL1 == false)
                        {
                            ocorrencia.L1++;
                            TrueL1 = true;
                        }
                    }
                    else if (Value >= 11 && Value <= 20)//L2
                    {
                        if (TrueL2 == false)
                        {
                            ocorrencia.L2++;
                            TrueL2 = true;
                        }
                    }
                    else if (Value >= 21 && Value <= 30)//L3
                    {
                        if (TrueL3 == false)
                        {
                            ocorrencia.L3++;
                            TrueL3 = true;
                        }
                    }
                    else if (Value >= 31 && Value <= 40)//L4
                    {
                        if (TrueL4 == false)
                        {
                            ocorrencia.L4++;
                            TrueL4 = true;
                        }
                    }
                    else if (Value >= 41 && Value <= 50)//L5
                    {
                        if (TrueL5 == false)
                        {
                            ocorrencia.L5++;
                            TrueL5 = true;
                        }
                    }
                    else if (Value >= 51 && Value <= 60)//L6
                    {
                        if (TrueL6 == false)
                        {
                            ocorrencia.L6++;
                            TrueL6 = true;
                        }
                    }
                }
            }

            Console.WriteLine("======== OCORRENCIAS LINHAS =============");
            Console.WriteLine("L1: " + ocorrencia.L1);
            Console.WriteLine("L2: " + ocorrencia.L2);
            Console.WriteLine("L3: " + ocorrencia.L3);
            Console.WriteLine("L4: " + ocorrencia.L4);
            Console.WriteLine("L5: " + ocorrencia.L5);
            Console.WriteLine("L6: " + ocorrencia.L6);
        }
    }
}
