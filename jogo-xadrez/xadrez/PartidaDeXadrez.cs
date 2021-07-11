using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branco;
            terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
                throw new TabuleiroException("Não existe peça nessa posição");
            if (jogadorAtual != tab.peca(pos).cor)
                throw new TabuleiroException("A peça escolhida não é sua");
            if (!tab.peca(pos).existeMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para esta peça");
            
        }

        public void validarPosicaoDeDestino (Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
                throw new TabuleiroException("Posição de destino inválida");
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branco)
                jogadorAtual = Cor.Preto;
            else
                jogadorAtual = Cor.Branco;
            
        }
        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(Cor.Branco, tab), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branco, tab), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branco, tab), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branco, tab), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branco, tab), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(Cor.Branco, tab), new PosicaoXadrez('d', 1).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preto, tab), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preto, tab), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preto, tab), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preto, tab), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preto, tab), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(Cor.Preto, tab), new PosicaoXadrez('d', 8).toPosicao());

        }
    }
}
