using System;
using tabuleiro;
using xadrez;

namespace jogo_xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez pos = new PosicaoXadrez('a', 1);
            Console.WriteLine(pos);

            Console.WriteLine(pos.toPosicao());

        }
    }
}
