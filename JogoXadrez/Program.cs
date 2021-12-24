using System;
using tabuleiro;
using xadrez;
namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                Console.WriteLine("\n\t -------- BEM-VINDO AO JOGO DE XADREZ EM C#! --------\n\t\t  APERTE QUALQUER BOTÃO PARA INICIAR!");
                Console.ReadKey();

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);
                       
                        Console.Write("\nOrigem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);


                        Console.Write("\nDestino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);
                Console.ReadLine();
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
