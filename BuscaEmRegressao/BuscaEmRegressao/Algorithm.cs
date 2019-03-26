using System;
using System.Collections;
using System.Collections.Generic;

namespace BuscaEmRegressao
{
    public class Algorithm
    {
        Stack<List<String>> LE, LNE;
        List<List<String>> BSS, Children;
        List<String> EC;
        Int16 CountNodesVisited;
        Boolean Success;

        public Algorithm() {
            LE = new Stack<List<string>>();
            LNE = new Stack<List<string>>();
            BSS = new List<List<string>>();
            Success = false;
        }

        public void BackTracking (List<String> initialState, List<String> finalState)
        {
            LE.Push(initialState);
            LNE.Push(initialState);
            EC = initialState;

            while (!LNE.Count.Equals(0))
            {
                CountNodesVisited++;

                if (EC.Equals(finalState))
                {
                    foreach (List<String>actual in LE)
                    {
                        ExibirEstado(actual);
                    }
                    Success = true;
                    Console.WriteLine("Sucesso.");
                    Console.WriteLine("Total de nós visitados: " + CountNodesVisited);
                    Console.WriteLine("Total de nós que levam ao caminho correto: " + LE.Count);
                    break;

                }

                else
                {
                    Children = GerarFilhos(EC);

                    if (Children.Count.Equals(0))
                    {
                        while (!LE.Count.Equals(0) && EC.Equals(LE.Peek()))
                        {
                            BSS.Add(EC);
                            LE.Pop();
                            LNE.Pop();
                            EC = (!LNE.Count.Equals(0)) ? LNE.Peek() : null;
                        }

                        LE.Push(EC);
                    }
                    else
                    {
                        foreach(List<String> e in Children)
                        {
                            LNE.Push(e);
                        }
                        EC = LNE.Peek();
                        LE.Push(EC);
                    }
                }
            }

            if (!Success)
                Console.WriteLine("Falha. Objetivo não encontrado.");

        }
    

        public static void ExibirEstado(List<String> estados)
        {
            List<String> estadosFormatados = new List<string>();
            String estado = "";

            foreach (String e in estados)
            {
                estado += e;
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            estadosFormatados.Add(String.Join("|", Convert.ToString(estado[0]), Convert.ToString(estado[1]), Convert.ToString(estado[2])));
            estadosFormatados.Add(String.Join("|", Convert.ToString(estado[3]), Convert.ToString(estado[4]), Convert.ToString(estado[5])));
            estadosFormatados.Add(String.Join("|", Convert.ToString(estado[6]), Convert.ToString(estado[7]), Convert.ToString(estado[8])));

            estadosFormatados.ForEach(est => Console.WriteLine(est));
        }

        public List<List<string>> GerarFilhos(List<String> estadoAtual)
        {

            int indicePosicaoVazia = estadoAtual.IndexOf("X");
            List<List<String>> estados = new List<List<String>>();

            List<String> listaPosicoesAtuais = new List<String>(estadoAtual);

            switch (indicePosicaoVazia)
            {
                case 0:
                    List<String> listaPosicoesP0P1 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP0P3 = new List<String>(listaPosicoesAtuais);
                    AddEstado(estados, estadoAtual, listaPosicoesP0P1, 1);
                    AddEstado(estados, estadoAtual, listaPosicoesP0P3, 3);

                    break;
                case 1:
                    List<String> listaPosicoesP1P0 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP1P2 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP1P4 = new List<String>(listaPosicoesAtuais);
                    AddEstado(estados, estadoAtual, listaPosicoesP1P0, 0);
                    AddEstado(estados, estadoAtual, listaPosicoesP1P2, 2);
                    AddEstado(estados, estadoAtual, listaPosicoesP1P4, 4);
                    break;
                case 2:
                    List<String> listaPosicoesP2P1 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP2P5 = new List<String>(listaPosicoesAtuais);
                    AddEstado(estados, estadoAtual, listaPosicoesP2P1, 1);
                    AddEstado(estados, estadoAtual, listaPosicoesP2P5, 5);
                    break;
                case 3:
                    List<String> listaPosicoesP3P0 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP3P4 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP3P6 = new List<String>(listaPosicoesAtuais);
                    AddEstado(estados, estadoAtual, listaPosicoesP3P0, 0);
                    AddEstado(estados, estadoAtual, listaPosicoesP3P4, 4);
                    AddEstado(estados, estadoAtual, listaPosicoesP3P6, 6);
                    break;
                case 4:
                    List<String> listaPosicoesP4P1 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP4P3 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP4P5 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP4P7 = new List<String>(listaPosicoesAtuais);
                    AddEstado(estados, estadoAtual, listaPosicoesP4P1, 1);
                    AddEstado(estados, estadoAtual, listaPosicoesP4P3, 3);
                    AddEstado(estados, estadoAtual, listaPosicoesP4P5, 5);
                    AddEstado(estados, estadoAtual, listaPosicoesP4P7, 7);

                    break;
                case 5:
                    List<String> listaPosicoesP5P2 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP5P4 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP5P8 = new List<String>(listaPosicoesAtuais);
                    AddEstado(estados, estadoAtual, listaPosicoesP5P2, 2);
                    AddEstado(estados, estadoAtual, listaPosicoesP5P4, 4);
                    AddEstado(estados, estadoAtual, listaPosicoesP5P8, 8);
                    break;
                case 6:
                    List<String> listaPosicoesP6P3 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP6P7 = new List<String>(listaPosicoesAtuais);
                    AddEstado(estados, estadoAtual, listaPosicoesP6P3, 3);
                    AddEstado(estados, estadoAtual, listaPosicoesP6P7, 7);
                    break;
                case 7:
                    List<String> listaPosicoesP7P4 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP7P6 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP7P8 = new List<String>(listaPosicoesAtuais);
                    AddEstado(estados, estadoAtual, listaPosicoesP7P4, 4);
                    AddEstado(estados, estadoAtual, listaPosicoesP7P6, 6);
                    AddEstado(estados, estadoAtual, listaPosicoesP7P8, 8);

                    break;
                case 8:
                    List<String> listaPosicoesP8P5 = new List<String>(listaPosicoesAtuais);
                    List<String> listaPosicoesP8P7 = new List<String>(listaPosicoesAtuais);
                    AddEstado(estados, estadoAtual, listaPosicoesP8P5, 5);
                    AddEstado(estados, estadoAtual, listaPosicoesP8P7, 7);
                    break;

                //default:
                //    Console.WriteLine( string.Empty);
            }

            if (estados.Count.Equals(0))
                BSS.Add(estadoAtual);

            return estados;
        }

        public void AddEstado(List<List<String>> estados, List<String> estadoAtual, List<String> listaPosicoes,
                int position)
        {
            Swap(listaPosicoes, estadoAtual.IndexOf("X"), position);
            List<String> estado = new List<String>(listaPosicoes);

            if (!LNE.Contains(estado) && !LE.Contains(estado) && !BSS.Contains(estado))
                estados.Add(estado);
        }

        static void Swap(IList<string> list, int indexA, int indexB)
        {
            string tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}
