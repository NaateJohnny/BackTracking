using System;
using System.Collections.Generic;
using BuscaEmRegressao;

namespace ExecBackTracking.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> posInicial = new List<String>(new []{"1", "2", "3", "4", "5", "6", "7", "8", "X"});
            List<String> posFinal = new List<String>(new []{"1", "2", "3", "4", "X", "5", "6", "7", "8" });

            Algorithm algorithm = new Algorithm();

            algorithm.BackTracking(posInicial, posFinal);

            Console.ReadKey();
        }
    }
}
