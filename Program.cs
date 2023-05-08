using System;
using Analisador_lexico.Objeto;

namespace Analisador_lexico {
    class Program {
        static void Main(string[] args) {
            Analisador palavra = new Analisador();
            Console.Write("Digite o negócio: ");
            palavra.AnalisarPalavra(Console.ReadLine());
            Console.ReadKey();
        }
    }
}
