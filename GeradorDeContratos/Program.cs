using System;
using System.Collections.Generic;
using System.Globalization;
using GeradorDeContratos.entities;
using GeradorDeContratos.services;

namespace GeradorDeContratos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contrato> _contratos = new List<Contrato>();
            int option = 10;

            Console.WriteLine("=========================================");
            Console.WriteLine("         GERENCIADOR DE CONTRATOS        ");
            Console.WriteLine("=========================================");

            while (option != 0)
            {
                Console.WriteLine("Informe a opção que deseja fazer:");
                Console.WriteLine("> 1 Gerar um contrato");
                Console.WriteLine("> 2 Visualizar contratos");
                Console.WriteLine("> 0 Sair");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: // Gerar contrato
                        Console.WriteLine("GERAR CONTRATO");
                        Console.WriteLine("Informe:");
                        Console.Write("Numero de contrato: ");
                        int num = int.Parse(Console.ReadLine());
                        Console.Write("Tipo de contrato: ");
                        string type = Console.ReadLine();
                        Console.Write("Data do contrato: ");
                        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Console.Write("Valor total do contrato: ");
                        double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.Write("Numero de parcelas: ");
                        int numParcela = int.Parse(Console.ReadLine());

                        Contrato cont = new Contrato(num, date, price, type);
                        ProcessoContrato processoContrato = new ProcessoContrato(new PaypalService());

                        if (processoContrato.GerarContrato(cont, numParcela))
                        {
                            Console.WriteLine("\nContrato gerado com SUCESSO!\n");
                            _contratos.Add(cont);
                        }
                        else
                            Console.WriteLine("\nFALHA ao gerar o contrato\n");

                        break;
                    case 2: // Visualizar contratos
                        while (option != -1)
                        {
                            Console.WriteLine("\nCONTRATOS EXISTENTES:");
                            Console.WriteLine("=====================");

                            if (_contratos.Count == 0)
                            {
                                Console.WriteLine("Não há nenhum contrato\n");
                                break;
                            }

                            for (int i = 0; i < _contratos.Count; i++)
                            {
                                Console.WriteLine((i + 1) + " -> " + _contratos[i].Type);
                            }
                            Console.WriteLine("=====================");
                            Console.WriteLine("Informe o contrato que deseja visualizar");
                            Console.WriteLine("Informe 0 para sair");
                            option = int.Parse(Console.ReadLine()) - 1;

                            if (option == -1)
                                break;

                            if (option >= _contratos.Count)
                            {
                                Console.WriteLine("\nInforme um contrato existente\n");
                                break;
                            }

                            Console.WriteLine("\n=====================");
                            Console.WriteLine("Contrato: " + _contratos[option].Type);
                            Console.WriteLine("Data de emissão: " + _contratos[option].DateContract.ToString());
                            Console.WriteLine("Numero de parcelas: " + _contratos[option].NumParcela + "\n");
                            foreach (Parcela p in _contratos[option].Parcelas)
                            {
                                Console.WriteLine(p.ToString() + "\n");
                            }
                            Console.WriteLine("=====================\n");
                        }

                        if (option <= 0)
                            option = 10;

                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("\nInforme uma opção válida!\n");
                        if (option <= -1)
                            option = 10;
                        break;
                }
            }
            Console.WriteLine("\nGood Bye");
        }
    }
}
