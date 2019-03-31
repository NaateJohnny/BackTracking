using System;
using System.Collections.Generic;
using System.Linq;

namespace Backtracking
{
    public class Algorithm
    {
        Stack<List<string>> LE, LNE, BSS;
        List<List<string>> Children;
        List<string> EC;
        Int16 CountNodesVisited;
        Boolean Success;

        public Algorithm()
        {
            LE = new Stack<List<string>>();
            LNE = new Stack<List<string>>();
            BSS = new Stack<List<string>>();
            Success = false;
        }

        public void ExecBacktracking(List<string> initialState, List<string> finalState)
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Realizando a busca, vamos encontrar o objetivo....");

            LE.Push(initialState);
            LNE.Push(initialState);
            EC = initialState;

            while (!LNE.Count.Equals(0))
            {
                CountNodesVisited++;

                if (Enumerable.SequenceEqual(EC, finalState))
                {
                    Console.WriteLine();
                    Console.WriteLine("Concluído, o objetivo foi encontrado.");
                    Console.WriteLine("Quantidade final de nós visitados: " + CountNodesVisited);
                    Console.WriteLine("Quantidade final de nós até o objetivo: " + LE.Count);
                    Console.WriteLine("Nós gerados abaixo:");
                    Console.WriteLine();

                    foreach (List<string> actual in LE)
                    {
                        StateShow(actual, initialState, finalState);
                    }

                    Success = true;
                    
                    break;

                }

                else
                {
                    Children = GeneratingChildren(EC);

                    if (Children.Count.Equals(0))
                    {
                        while (!LE.Count.Equals(0) && Enumerable.SequenceEqual(EC, LE.Peek()))
                        {
                            BSS.Push(EC);
                            LE.Pop();
                            LNE.Pop();
                            EC = (!LNE.Count.Equals(0)) ? LNE.Peek() : null;
                        }

                        LE.Push(EC);
                    }
                    else
                    {
                        foreach (List<string> e in Children)
                        {
                            if (!Enumerable.Contains(BSS, e) && (!Enumerable.Contains(LNE, e) || !Enumerable.Contains(LE, e)))
                                LNE.Push(e);
                        }
                        EC = LNE.Peek();
                        LE.Push(EC);
                    }
                }
            }

            if (!Success)
                Console.WriteLine("Algo deu errado e o objetivo não encontrado. Tente novamente.");

        }


        private static void StateShow(List<string> paramState, List<string> paramInitialState, List<string> paramFinalState)
        {
            List<string> ViewState = new List<string>();
            string state = "";

            foreach (string value in paramState)
            {
                state += value;
            }

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();

            if ((Enumerable.SequenceEqual(paramState, paramFinalState)))
                Console.WriteLine("Objetivo:");
            else if ((Enumerable.SequenceEqual(paramState, paramInitialState)))
                Console.WriteLine("Inicial:");
            else
                Console.WriteLine("Demais:");

            ViewState.Add(string.Join("|", Convert.ToString(state[0]), Convert.ToString(state[1]), Convert.ToString(state[2])));
            ViewState.Add(string.Join("|", Convert.ToString(state[3]), Convert.ToString(state[4]), Convert.ToString(state[5])));
            ViewState.Add(string.Join("|", Convert.ToString(state[6]), Convert.ToString(state[7]), Convert.ToString(state[8])));

            Console.WriteLine();

            ViewState.ForEach(vwState => Console.WriteLine(vwState));

            Console.WriteLine();
        }

        private List<List<string>> GeneratingChildren(List<string> currentState)
        {

            int indexPositionEmpty = currentState.IndexOf("O");
            List<List<string>> states = new List<List<string>>();

            List<string> positionsListAtuais = new List<string>(currentState);

            switch (indexPositionEmpty)
            {
                case 0:
                    List<string> positionsListP0P1 = new List<string>(positionsListAtuais);
                    List<string> positionsListP0P3 = new List<string>(positionsListAtuais);
                    StateAdd(states, currentState, positionsListP0P1, 1);
                    StateAdd(states, currentState, positionsListP0P3, 3);

                    break;
                case 1:
                    List<string> positionsListP1P0 = new List<string>(positionsListAtuais);
                    List<string> positionsListP1P2 = new List<string>(positionsListAtuais);
                    List<string> positionsListP1P4 = new List<string>(positionsListAtuais);
                    StateAdd(states, currentState, positionsListP1P0, 0);
                    StateAdd(states, currentState, positionsListP1P2, 2);
                    StateAdd(states, currentState, positionsListP1P4, 4);
                    break;
                case 2:
                    List<string> positionsListP2P1 = new List<string>(positionsListAtuais);
                    List<string> positionsListP2P5 = new List<string>(positionsListAtuais);
                    StateAdd(states, currentState, positionsListP2P1, 1);
                    StateAdd(states, currentState, positionsListP2P5, 5);
                    break;
                case 3:
                    List<string> positionsListP3P0 = new List<string>(positionsListAtuais);
                    List<string> positionsListP3P4 = new List<string>(positionsListAtuais);
                    List<string> positionsListP3P6 = new List<string>(positionsListAtuais);
                    StateAdd(states, currentState, positionsListP3P0, 0);
                    StateAdd(states, currentState, positionsListP3P4, 4);
                    StateAdd(states, currentState, positionsListP3P6, 6);
                    break;
                case 4:
                    List<string> positionsListP4P1 = new List<string>(positionsListAtuais);
                    List<string> positionsListP4P3 = new List<string>(positionsListAtuais);
                    List<string> positionsListP4P5 = new List<string>(positionsListAtuais);
                    List<string> positionsListP4P7 = new List<string>(positionsListAtuais);
                    StateAdd(states, currentState, positionsListP4P1, 1);
                    StateAdd(states, currentState, positionsListP4P3, 3);
                    StateAdd(states, currentState, positionsListP4P5, 5);
                    StateAdd(states, currentState, positionsListP4P7, 7);

                    break;
                case 5:
                    List<string> positionsListP5P2 = new List<string>(positionsListAtuais);
                    List<string> positionsListP5P4 = new List<string>(positionsListAtuais);
                    List<string> positionsListP5P8 = new List<string>(positionsListAtuais);
                    StateAdd(states, currentState, positionsListP5P2, 2);
                    StateAdd(states, currentState, positionsListP5P4, 4);
                    StateAdd(states, currentState, positionsListP5P8, 8);
                    break;
                case 6:
                    List<string> positionsListP6P3 = new List<string>(positionsListAtuais);
                    List<string> positionsListP6P7 = new List<string>(positionsListAtuais);
                    StateAdd(states, currentState, positionsListP6P3, 3);
                    StateAdd(states, currentState, positionsListP6P7, 7);
                    break;
                case 7:
                    List<string> positionsListP7P4 = new List<string>(positionsListAtuais);
                    List<string> positionsListP7P6 = new List<string>(positionsListAtuais);
                    List<string> positionsListP7P8 = new List<string>(positionsListAtuais);
                    StateAdd(states, currentState, positionsListP7P4, 4);
                    StateAdd(states, currentState, positionsListP7P6, 6);
                    StateAdd(states, currentState, positionsListP7P8, 8);

                    break;
                case 8:
                    List<string> positionsListP8P5 = new List<string>(positionsListAtuais);
                    List<string> positionsListP8P7 = new List<string>(positionsListAtuais);
                    StateAdd(states, currentState, positionsListP8P5, 5);
                    StateAdd(states, currentState, positionsListP8P7, 7);
                    break;

                default:
                    Console.WriteLine(string.Empty);
                    break;
            }

            if (states.Count.Equals(0))
                BSS.Push(currentState);

            return states;
        }

        private void StateAdd(List<List<string>> states, List<string> currentState, List<string> positionList, int position)
        {
            Swap(positionList, currentState.IndexOf("O"), position);
            List<string> state = new List<string>(positionList);

            if (!Enumerable.Contains(LNE, state) && !Enumerable.Contains(LE, state) && !Enumerable.Contains(BSS, state))
                states.Add(state);
        }

        private static void Swap(IList<string> list, int indexA, int indexB)
        {
            string tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}
