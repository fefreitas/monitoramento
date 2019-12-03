using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monitoramento.Models
{
    public class Conta
    {
        public List<int> ListaNumPar { get; set; }
        public List<int> ListaNumImpar { get; set; }
        public List<string> Extrato { get; set; }
        public decimal ContaCorrente { get; set; }

        public Conta()
        {
            ListaNumPar = new List<int>();
            ListaNumImpar = new List<int>();
            Extrato = new List<string>();
            ContaCorrente = 200;
        }
    }
}