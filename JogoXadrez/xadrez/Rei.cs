using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }
        public override string ToString()
        {
            return "R";
        }
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }

        private bool testeTorreRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qtdMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            // Acima (N)
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if(tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Diagonal Direita Acima (NE)
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Direita (E)
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Diagonal Direita Abaixo (SE)
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Abaixo (S)
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Diagonal Esquerda Abaixo (SW)
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Esquerda (W)
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // Diagonal Esquerda Acima (NW)
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;
            
            // #Jogada especial Roque
            if(qtdMovimentos == 0 && !partida.xeque)
            {
                // # Roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if(tab.peca(p1) == null && tab.peca(p2) == null)
                        mat[posicao.linha, posicao.coluna + 2] = true;
                }

                // # Roque grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                        mat[posicao.linha, posicao.coluna - 2] = true;
                }
            }


            return mat;
        }
    }
}
