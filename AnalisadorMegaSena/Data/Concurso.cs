using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorMegaSena.Data
{
    public class Concurso
    {
        public int Id { get; set; }
        public int NumConcurso { get; set; }
        public string[] Dezenas { get; set; }
        public string Data { get; set; }
        public string Acumulou { get; set; }
        public double Acumulado { get; set; }
        public double ProximaEstimativa { get; set; }

    }
}
