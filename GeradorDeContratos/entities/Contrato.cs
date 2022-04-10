using System;
using System.Collections.Generic;

namespace GeradorDeContratos.entities
{
    class Contrato
    {
        public int Number { get; set; }
        public DateTime DateContract { get; set; }
        public double TotalValue { get; set; }
        public string Type { get; set; }
        public int NumParcela { get; set; }
        public List<Parcela> Parcelas { get; set; }

        public Contrato(int number, DateTime dateContract, double value, string type)
        {
            Number = number;
            DateContract = dateContract;
            TotalValue = value;
            Type = type;
            Parcelas = new List<Parcela>();
        }

        public void AddParcelas(Parcela par)
        {
            Parcelas.Add(par);
        }
    }
}
