using System;

namespace GeradorDeContratos.entities
{
    class Parcela
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public Parcela(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }

        public override string ToString()
        {
            return "Date: " + Date.ToString("dd/MM/yyy") +
                "\nPrice: " + Value.ToString("F2");
        }
    }
}
