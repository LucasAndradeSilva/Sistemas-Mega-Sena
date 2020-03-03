using AnalisadorMegaSena.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace AnalisadorMegaSena.Forms
{
    class ApiMega
    {
        public static string message = "";

        //=============================================================
        // === FUNÇÃO QUE RETORNA AS DEZENAS DOS X JOGOS ANTERIORES ===
        //=============================================================
        public static string[] GetDezenas(int QuantidadeJogos)
        {
            try
            {
                WebClient webClient = new WebClient();
                string strPageCode = webClient.DownloadString("https://www.lotodicas.com.br/api/mega-sena");

                dynamic dobj = JsonConvert.DeserializeObject<dynamic>(strPageCode);
                string[] Dezenas = new string[QuantidadeJogos];

                int NumConcurso = Convert.ToInt32(dobj["numero"]);

                for (int i = 0; i < QuantidadeJogos; i++)
                {
                    string strPageCode1 = webClient.DownloadString("https://www.lotodicas.com.br/api/mega-sena/" + NumConcurso.ToString());

                    dynamic dobj1 = JsonConvert.DeserializeObject<dynamic>(strPageCode1);
                    string JsonDezenas = dobj1["sorteio"].ToString();
                    List<string> Sharp_Dezenas = JsonConvert.DeserializeObject<List<string>>(JsonDezenas);
                    string NoListDezenas = string.Join(", ", Sharp_Dezenas.ToArray());

                    Dezenas[i] = NoListDezenas;
                    NumConcurso--;
                }

                return Dezenas;
            }
            catch (Exception exc)
            {
                //Modo OffiLine
                message = exc.Message;
                Banco_de_Dados db = new Banco_de_Dados();
                Concurso[] concursos = db.Buscar(0, QuantidadeJogos);
                string[] Dezenas = new string[concursos.Length];

                for (int i = 0; i < Dezenas.Length; i++)
                {
                    string Dez = string.Join(",", concursos[i].Dezenas);
                    Dezenas[i] = Dez;
                }

                return Dezenas;
            }
            
        }
        /// <summary>
        /// Retorna todas as Dezes de todos os Concursos da Mega
        /// </summary>
        /// <param name="GetDezenas"></param>
        /// <returns></returns>
        public static string[] GetDezenas()
        {
            try
            {
                WebClient webClient = new WebClient();
                string strPageCode = webClient.DownloadString("https://www.lotodicas.com.br/api/mega-sena");
                
                dynamic dobj = JsonConvert.DeserializeObject<dynamic>(strPageCode);                
                int NumConcurso = Convert.ToInt32(dobj["numero"]);
                string[] Dezenas = new string[NumConcurso];

                for (int i = 0; i < NumConcurso; i++)
                {
                    string strPageCode1 = webClient.DownloadString("https://www.lotodicas.com.br/api/mega-sena/" + NumConcurso.ToString());
                                    
                    dynamic dobj1 = JsonConvert.DeserializeObject<dynamic>(strPageCode1);
                    string JsonDezenas = dobj1["sorteio"].ToString();
                    List<string> Sharp_Dezenas = JsonConvert.DeserializeObject<List<string>>(JsonDezenas);
                    string NoListDezenas = string.Join(", ", Sharp_Dezenas.ToArray());
                                    
                    Dezenas[i] = NoListDezenas;
                                          
                    NumConcurso--;                                    
                }

                return Dezenas;
            }
            catch (Exception exc)
            {
                //Modo OffiLine
                message = exc.Message;
                Banco_de_Dados db = new Banco_de_Dados();
                Concurso[] concursos = db.Buscar(0,true);
                string[] Dezenas = new string[concursos.Length];

                for (int i = 0; i < Dezenas.Length; i++)
                {
                    string Dez = string.Join(",", concursos[i].Dezenas);
                    Dezenas[i] = Dez;
                }

                return Dezenas;
            }

        }

        //===============================================================
        // === FUNÇÃO QUE RETORNA O NÚMERO DOS X CONCURSOS ANTERIORES ===
        //===============================================================
        public static string[] GetConcurso(int QuantidadeJogos)
        {
            try
            {
                WebClient webClient = new WebClient();
                string strPageCode = webClient.DownloadString("https://www.lotodicas.com.br/api/mega-sena");

                dynamic dobj = JsonConvert.DeserializeObject<dynamic>(strPageCode);
                string[] Concursos = new string[QuantidadeJogos];

                int NumConcurso = Convert.ToInt32(dobj["numero"]);

                for (int i = 0; i < QuantidadeJogos; i++)
                {
                    Concursos[i] = NumConcurso.ToString();
                    NumConcurso--;
                }

                return Concursos;
            }
            catch (Exception exc)
            {
                //Modo OffiLine
                message = exc.Message;
                Banco_de_Dados db = new Banco_de_Dados();
                Concurso[] concursos = db.Buscar(0, QuantidadeJogos);
                string[] Concursos = new string[concursos.Length];

                for (int i = 0; i < Concursos.Length; i++)
                {
                    string numConcurso = string.Join(",", concursos[i].NumConcurso);
                    Concursos[i] = numConcurso;
                }

                return Concursos;
            }
        }

        //===========================================================
        // === FUNÇÃO QUE RETORNA UMA LISTA DE TODOS OS CONCURSOS ===
        //===========================================================
        public static List<Concurso> GetTodosConcursos()
    {            
            List<Concurso> ListaConcursos = new List<Concurso>();

            WebClient webClient = new WebClient(); 
            bool Certo = false;
            string strPageCode = "";
            while (!Certo)
            {
                try
                {

                    strPageCode = webClient.DownloadString("https://www.lotodicas.com.br/api/v2/mega_sena/results/last?token=8039cc263cffaeb86a48b98c7301c763399ae0d733c425224a42d43c361b3bb8");
                    Certo = true;
                }
                catch (Exception)
                {
                    Certo = false;
                }

            }

            dynamic dobj = JsonConvert.DeserializeObject<dynamic>(strPageCode);
            int NumConcurso = Convert.ToInt32(dobj["data"]["draw_number"]);

            int Num = NumConcurso;
            for (int i = 0; i < Num; i++)
            {            
                Concurso concurso = new Concurso();
                
                bool Result = false;
                int erro = 0;
                while (Result == false)
                {
                    try
                    {
                        WebClient WebApi = new WebClient();
                        string Token = "?token=8039cc263cffaeb86a48b98c7301c763399ae0d733c425224a42d43c361b3bb8";
                        string Apii = "https://www.lotodicas.com.br/api/v2/mega_sena/results/" + NumConcurso+Token;
                        string strPageCode1 = WebApi.DownloadString(Apii);                        
                        if (strPageCode1 != "")
                        {
                            Result = true;
                            dynamic dobj1 = JsonConvert.DeserializeObject<dynamic>(strPageCode1);

                            string JsonDezenas = dobj1["data"]["drawing"].ToString();
                            if(JsonDezenas.Contains("draw"))
                            {                                
                                int x = JsonDezenas.Length;
                                JsonDezenas = JsonDezenas.Remove(x-3, 3);
                                JsonDezenas = JsonDezenas.Remove(0, 13);                          
                                JsonDezenas = JsonDezenas.Replace("draw", "").Replace("{", "").Replace("}", "").Replace(":", "");
                            }
                  
                            List<string> Sharp_Dezenas = JsonConvert.DeserializeObject<List<string>>(JsonDezenas);
                            string NoListDezenas = string.Join(", ", Sharp_Dezenas.ToArray());

                            concurso.NumConcurso = NumConcurso;
                            concurso.Data = dobj1["data"]["draw_date"].ToString().Replace('-', '/');
                            concurso.Dezenas = NoListDezenas.Split(',');
                            concurso.Acumulado = Convert.ToDouble(dobj1["data"]["next_draw_prize"].ToString());
                            concurso.Acumulou = dobj1["data"]["has_winner"].ToString().ToUpper() == "false" ? "NAO" : "SIM";
                            concurso.ProximaEstimativa = Convert.ToDouble(dobj1["data"]["next_draw_prize"].ToString());

                            NumConcurso--;
                            ListaConcursos.Add(concurso);
                        }
                        else
                        {
                            Result = false;
                        }
                    }
                    catch (Exception)
                    {
                        Result = false;
                        erro++;
                        if (erro >= 5 )
                        {
                            return null;
                        }
                    }
                }                                
            }

            return ListaConcursos;                 
        }


        //==========================================================================
        // === FUNÇÃO QUE RETORNA OS NÚMEROS SORTEADOS DE UM CONCURSO ESPECIFICO ===
        //==========================================================================
        public static string[] GetDezenaConcurso(int Concurso)
        {
            try
            {
                WebClient webClient = new WebClient();
                string strPageCode = webClient.DownloadString("https://www.lotodicas.com.br/api/mega-sena/" + Concurso.ToString());

                dynamic dobj = JsonConvert.DeserializeObject<dynamic>(strPageCode);

                string Dezena2 = dobj["sorteio"].ToString();
                List<string> Sharp_Dezenas = JsonConvert.DeserializeObject<List<string>>(Dezena2);
                string NoListDezenas = string.Join(", ", Sharp_Dezenas.ToArray());

                string[] Dezena = NoListDezenas.Split(',');
                return Dezena;
            }
            catch (Exception exc)
            {
                //Modo Offiline
                message = exc.Message;
                Banco_de_Dados db = new Banco_de_Dados();
                Concurso con = new Concurso();
                con = db.Buscar(Concurso);

                return con.Dezenas;
            }
        }
    }
}
