using System;
using tabuleiro;

namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao P;
            Tabuleiro tab = new Tabuleiro(8,8);

            P = new Posicao(3, 4);

            Console.WriteLine(P);
            Console.ReadLine();
        }
    }
}
