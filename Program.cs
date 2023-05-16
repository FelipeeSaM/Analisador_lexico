using System;
using Analisador_lexico.Objeto;

namespace Analisador_lexico {
    class Program {
        static void Main(string[] args) {
            Analisador palavra = new Analisador();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Entradas começadas com números serão consideradas palavras reservadas pelo sistema");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Digite o negócio: ");
            palavra.AnalisarPalavra(Console.ReadLine());
            Console.ReadKey();
        }
    }
}
