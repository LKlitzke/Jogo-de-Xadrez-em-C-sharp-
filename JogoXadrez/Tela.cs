using System;
using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace JogoXadrez
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            Tela.imprimirTabuleiro(partida.tab);
            Console.WriteLine("");
            imprimirPecasCapturadas(partida);
            Console.WriteLine("");
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque)
                    Console.WriteLine("XEQUE!");
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("\nPretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine("");
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        // Print inicial do tabuleiro
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            Console.WriteLine("");
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write("\t" + (8 - i) + "| ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\t  ----------------");
            Console.WriteLine("\t   a b c d e f g h");
        }

        // Print do tabuleiro com posições possíveis
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            Console.WriteLine("");
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write("\t" + (8 - i) + "| ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if(posicoesPossiveis[i,j] == true)
                        Console.BackgroundColor = fundoAlterado;
                    else
                        Console.BackgroundColor = fundoOriginal;
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\t  ----------------");
            Console.WriteLine("\t   a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            try
            {
                string s = Console.ReadLine();
                char coluna = s[0];
                int linha = int.Parse(s[1] + "");
                return new PosicaoXadrez(coluna, linha);
            }
            catch(Exception)
            {
                throw new TabuleiroException("Entrada inválida ou formato incorreto!"
                   + "\nTente novamente com uma letra de A até H seguido de um número de 1 a 8. "
                   + "Ex.: a1, c4, h8.");
            }
        }
        public static void imprimirPeca(Peca peca) {

            if(peca == null)
                Console.Write("- ");
            else
            {
                if (peca.cor == Cor.Branca)
                    Console.Write(peca);
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
