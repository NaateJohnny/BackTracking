using Backtracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExecBacktracking.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá, aqui veremos a execução do Algoritmo de Busca em Regressão.");
            Console.WriteLine("Escreva suas listas 'Inicial' e 'Objetivo'.");
            Console.WriteLine();
            Console.WriteLine("Regras:");
            Console.WriteLine(" > Utilize a letra 'O' para representar o campo vazio.");
            Console.WriteLine(" > Utilize o carácter ',' para separar cada item da lista.");
            Console.WriteLine(" > A lista deverá ter 9 posições, uma posição sendo a vazia.");
            Console.WriteLine(" > Os números deverão ser insiridos em ordem.");
            Console.WriteLine(" > Siga o exemplo a seguir, ex.: 1,2,3,4,5,6,7,8,O");
            Console.WriteLine();

            Console.WriteLine("----------------------- Estado Inicial -----------------------");
            Console.WriteLine("Insira os números:");
            string initialState = Console.ReadLine();
            Console.WriteLine();
            List<string> initialList = initialState.ToUpper().Split(",").ToList();

            ListTreatment(initialList);

            StateShow(initialList);
            Console.WriteLine();

            Console.WriteLine("----------------------- Estado Objetivo -----------------------");
            Console.WriteLine("Insira os números:");
            string finalState = Console.ReadLine();
            Console.WriteLine();
            List<string> finalList = finalState.ToUpper().Split(",").ToList();

            ListTreatment(finalList);

            StateShow(finalList);
            Console.WriteLine();


            void ListTreatment(List<string> paramList)
            {
                while (paramList.Count > 9)
                {
                    paramList.FindLastIndex(ind => paramList.Remove(ind));
                }
            }

            void StateShow(List<string> paramState)
            {
                List<string> ViewState = new List<string>();
                string state = "";

                foreach (string value in paramState)
                {
                    state += value;
                }

                ViewState.Add(string.Join("|", Convert.ToString(state[0]), Convert.ToString(state[1]), Convert.ToString(state[2])));
                ViewState.Add(string.Join("|", Convert.ToString(state[3]), Convert.ToString(state[4]), Convert.ToString(state[5])));
                ViewState.Add(string.Join("|", Convert.ToString(state[6]), Convert.ToString(state[7]), Convert.ToString(state[8])));

                ViewState.ForEach(vwState => Console.WriteLine(vwState));
            }

            //Debug
            //List<String> initialList = new List<String>(new[] { "1", "2", "3", "4", "5", "6", "7", "8", "O" });
            //List<String> finalList = new List<String>(new[] { "1", "2", "3", "4", "5", "6", "7", "O", "8" });
            //List<String> finalList = new List<String>(new[] { "1", "2", "3", "4", "O", "5", "6", "7", "8" });

            Algorithm algorithm = new Algorithm();

            algorithm.ExecBacktracking(initialList, finalList);

            Console.ReadKey();
        }
    }
}
