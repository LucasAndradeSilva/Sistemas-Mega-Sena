using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;


namespace AnalisadorMegaSena.Data
{
    public class Banco_de_Dados
    {
        //==================
        // === VARIAVEIS ===
        //==================
        public static string message = "";        
        MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=1234567;database=dbmegasena");

        //===================
        // === CONSTRUTOR ===
        //===================
        public void Open()
        {            
            try
            {                
                connection.Open();                
            }
            catch(Exception exception)
            {
                message = "Não foi possivel se conectar o Banco de Dados: ";
                message += exception.Message;                
            }
        }

        //=================================
        // === FUNÇÃO QUE FECHA O BANCO ===
        //=================================
        public void Close()
        {
            try
            {
                connection.Close();
            }
            catch (Exception exception)
            {
                message = "Não foi possivel se fechar o Banco de Dados: ";
                message += exception.Message;
                return;
            }

        }

        //=========================================
        // === FUNÇÃO QUE INSERE DADOS NO BANCO ===
        //=========================================
        public bool Insert(Concurso concurso)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                MySqlCommand sqlCommand = new MySqlCommand("call sp_Insert (@Concurso, @Data, @Dezenas, @Acumulado, @Acumulou, @Valor_Estimado)", connection);
                sqlCommand.Parameters.AddWithValue("@Concurso", concurso.NumConcurso);
                sqlCommand.Parameters.AddWithValue("@Data", Convert.ToDateTime(concurso.Data));
                sqlCommand.Parameters.AddWithValue("@Dezenas", string.Join("-",concurso.Dezenas));
                sqlCommand.Parameters.AddWithValue("@Acumulado", concurso.Acumulado);
                sqlCommand.Parameters.AddWithValue("@Acumulou", concurso.Acumulou);
                sqlCommand.Parameters.AddWithValue("@Valor_Estimado", concurso.ProximaEstimativa);

                int result = sqlCommand.ExecuteNonQuery();
                
                Close();
                return true;                               
            }
            catch (Exception exception)
            {
                message = "Erro ao inserir: " + exception.Message;
                Close();
                return false;                
            }
        }

        //============================================
        // === FUNÇÃO QUE ALTERA OS DADOS NO BANCO ===
        //============================================
        public bool Alterar(Concurso concurso)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                MySqlCommand command = new MySqlCommand("update tbConcurso set " +
               "DataConcurso = '" + concurso.Data + "'," +
               "Dezenas = '" + string.Join("-", concurso.Dezenas) + "'," +
               "Acumulado = " + concurso.Acumulado + "," +
               "Acumulou = '" + concurso.Acumulou + "'," +
               "ValorEstimativa = " + concurso.ProximaEstimativa + " where Concurso =" + concurso.NumConcurso,connection);

                int resultado = command.ExecuteNonQuery();
                Close();
                return true;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                Close();
                return false;
            }
        }

        //============================================
        // === FUNÇÃO QUE DELETA OS DADOS NO BANCO ===
        //============================================
        public bool Deletar(int Concurso)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                MySqlCommand command = new MySqlCommand("delete from tbConcurso where Concurso = " + Concurso + "",connection);
                int resultado = command.ExecuteNonQuery();
                Close();
                return true;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                Close();
                return false;
            }
        }

        //====================================================
        // === FUNÇÃO QUE DELETA A TABELA INTEIRA DO BANCO ===
        //====================================================
        /// <summary>
        /// Deleta todos os dados da tabela
        /// </summary>
        /// <param name="Deletar"></param>
        /// <returns></returns>
        public bool Deletar()
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                MySqlCommand command = new MySqlCommand("call sp_ClearDb()", connection);
                int resultado = command.ExecuteNonQuery();                                
                Close();
                return true;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                Close();
                return false;
            }
        }

        //===========================================================================
        // === FUNÇÃO QUE BUSCA OS DADOS NO BANCO RETORNA UM CONCURSO PELO NÚMERO ===
        //===========================================================================
        /// <summary>
        /// Retorna os dados de um concurso especifico.
        /// </summary>
        /// <param name="Buscar"></param>
        /// <returns></returns>
        public Concurso Buscar(int IdConsurso)
        {
            Concurso concurso = new Concurso();
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                DataSet ds = new DataSet();
                MySqlCommand command = new MySqlCommand("select * from tbConcurso where Concurso =" + IdConsurso, connection);
                
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {                    
                    concurso.NumConcurso = int.Parse(dr[0].ToString());
                    concurso.Data = dr[1].ToString();
                    concurso.Dezenas = dr[2].ToString().Split('-');
                    concurso.Acumulado = Convert.ToDouble(dr[3].ToString());
                    concurso.Acumulou = dr[4].ToString();
                    concurso.ProximaEstimativa = Convert.ToDouble(dr[5].ToString());
                }
                dr.Close();
                            
                Close();
                return concurso;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                Close();
                return concurso;
            }
        }

        //=======================================================================
        // === FUNÇÃO QUE BUSCA OS DADOS NO BANCO QUE TODOS OS DADOS DO BANCO ===
        //=======================================================================
        /// <summary>
        /// Retorna todos os concursos do Banco de Dados
        /// </summary>
        /// <param name="Buscar"></param>
        /// <returns></returns>
        public DataSet Buscar()
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            List<Concurso> ListaConcurso = new List<Concurso>();            
            try
            {
                DataSet ds = new DataSet();
                MySqlCommand command = new MySqlCommand("select Concurso,DataConcurso,Dezenas,Acumulado, Acumulou, ValorEstimativa from tbConcurso Order by Concurso desc", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(ds, "Consurso");

                Close();
                return ds;
            }
            catch (Exception exception)
            {
                DataSet erro  = new DataSet();
                message = exception.Message;
                Close();
                return erro;
            }
        }

        //===============================================================================
        // === FUNÇÃO QUE BUSCA OS DADOS NO BANCO RETORNA O NÚMERO DO ULTIMO CONCURSO ===
        //===============================================================================
        /// <summary>
        /// Retorna o número do ultimo concurso cadastrado
        /// </summary>
        /// <param name="Buscar"></param>
        /// <returns></returns>
        public int Buscar(string Retorna_Concurso = "")        
        {            
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();
                int Concurso = -1;
                MySqlCommand command = new MySqlCommand("select Max(Concurso) from tbConcurso", connection);               
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    Concurso = Convert.ToInt32(dr[0].ToString());                                        
                }
                dr.Close();
                
                Close();
                return Concurso;
            }
            catch (Exception exception)
            {                
                message = exception.Message;
                Close();
                return -1;
            }
        }

        //========================================================================================
        // === FUNÇÃO QUE BUSCA OS DADOS NO BANCO QUE RETORNA EM LISTA TODOS OS DADOS DO BANCO ===
        //========================================================================================
        /// <summary>
        /// Retorna todos os Dados do Banco em formato de Array
        /// </summary>
        /// <param name="Buscar"></param>
        /// <returns></returns>
        public Concurso[] Buscar(int Null, int QtdElementos)
        {            
            Concurso[] ListaConcurso;
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();
                DataSet ds = new DataSet();
                MySqlCommand command = new MySqlCommand("select *  from tbconcurso  order by(Concurso) desc limit "+ QtdElementos , connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(ds, "Consurso");
                MySqlDataReader dr = command.ExecuteReader();

                int a = 0;
                for (int i = 1; dr.Read(); i++)
                {
                    a = i;
                }
                dr.Close();

                MySqlDataReader dr2 = command.ExecuteReader();
                ListaConcurso = new Concurso[a];
                for (int i = 0; dr2.Read(); i++)
                {
                    Concurso co = new Concurso();
                    co.NumConcurso = Convert.ToInt32(dr2[0].ToString());
                    co.Data = dr2[1].ToString();
                    co.Dezenas = dr2[2].ToString().Split('-');
                    co.Acumulado = Convert.ToDouble(dr2[3].ToString());
                    co.Acumulou = dr2[4].ToString();
                    co.ProximaEstimativa = Convert.ToDouble(dr2[5].ToString());
                    ListaConcurso[i] = co;
                }

                dr2.Close();

                Close();
                return ListaConcurso;
            }
            catch (Exception exception)
            {
                Concurso[] erro = new Concurso[0];
                message = exception.Message;
                Close();
                return erro;
            }
        }

        //========================================================================================
        // === FUNÇÃO QUE BUSCA OS DADOS NO BANCO QUE RETORNA EM LISTA TODOS OS DADOS DO BANCO ===
        //========================================================================================
        /// <summary>
        /// Retorna todos os Dados do Banco em formato de Array
        /// </summary>
        /// <param name="Buscar"></param>
        /// <returns></returns>
        public Concurso[] Buscar(int Null, bool Null2)
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            Concurso[] ListaConcurso;
            try
            {
                DataSet ds = new DataSet();
                MySqlCommand command = new MySqlCommand("select *  from tbconcurso  order by(Concurso)", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(ds, "Consurso");
                MySqlDataReader dr = command.ExecuteReader();

                int a = 0;
                for (int i = 1; dr.Read(); i++)
                {
                    a = i;
                }
                dr.Close();

                MySqlDataReader dr2 = command.ExecuteReader();
                ListaConcurso = new Concurso[a];
                for (int i = 0; dr2.Read(); i++)
                {
                    Concurso co = new Concurso();
                    co.NumConcurso = Convert.ToInt32(dr2[0].ToString());
                    co.Data = dr2[1].ToString();
                    co.Dezenas = dr2[2].ToString().Split('-');
                    co.Acumulado = Convert.ToDouble(dr2[3].ToString());
                    co.Acumulou = dr2[4].ToString();
                    co.ProximaEstimativa = Convert.ToDouble(dr2[5].ToString());
                    ListaConcurso[i] = co;
                }

                dr2.Close();

                Close();
                return ListaConcurso;
            }
            catch (Exception exception)
            {
                Concurso[] erro = new Concurso[0];
                message = exception.Message;
                Close();
                return erro;
            }
        }      
    }

}