using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Analisador_lexico.Objeto {
    class Analisador {
        #region kkkkkkk
        public string cadeia { get; set; }

        public Analisador() {

        }

        public Analisador(string cadeia) {
            this.cadeia = cadeia;
        }
        #endregion

        #region parte_1_exercicio
        private Regex caracteresPermitidos = new Regex("[a-su-vA-SU-V0-9â-ýÂ-Ý]");
        #endregion

        #region parte_2_exercicio
        private List<string> tokensAtomicosLetras = new List<string>(new string[] {"x", "y", "z", "w", "t" });
        private List<string> tokensAtomicosCaracteresEspeciais = new List<string>(new string[] {"+", "-", "*", "/", ",", "@", "#", "!", "(", ")", "[", "]", "{", "}" });
        private int contador = 0;
        #endregion

        private string tokensAchados = "";


        public string AnalisarPalavra(string token) {
            ComecaComNumeros(token);
            MisturarCaracteresEanalisa(token);
            return "";

        }

        private void ComecaComNumeros(string tokenReservado) {
            if(char.IsDigit(tokenReservado.Substring(0, 1), 0)) {
                Console.WriteLine("Palavra reservada pelo sistema!");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        private void MisturarCaracteresEanalisa(string tokenReservado) {
            int validaExpressaoMatematica = AnalisarTokensEspeciais(tokenReservado);

            if (validaExpressaoMatematica >= 1) {
                Console.WriteLine("Expressão matemática!");
                Console.ReadKey();
            } else if (validaExpressaoMatematica > 10) {
                Console.WriteLine("Permitido no máximo 10 tokens atômicos.");
                Console.ReadKey();
            } else {
                AnalisarCaracteresMinusculos(tokenReservado);
            }
        }
         
        private int AnalisarTokensEspeciais(string tokenReservado) {
            for (int i = 0; i < tokensAtomicosLetras.Count; i++) {
                for (int j = 0; j < tokensAtomicosCaracteresEspeciais.Count; j++) {
                    if (tokenReservado.Contains((tokensAtomicosLetras[i] + tokensAtomicosCaracteresEspeciais[j]))) {
                        contador++;
                    }
                }
            }
            return contador;
        }

        private void AnalisarCaracteresMinusculos(string tokenReservado) {
            MatchCollection encontro = caracteresPermitidos.Matches(tokenReservado);
            foreach(Match match in encontro) {
                tokensAchados += $"{match.Value}";
            }

            if(tokenReservado.Length != tokensAchados.Length) {
                Console.WriteLine("Entrada inválida");
                Console.ReadKey();
            } else {
                Console.WriteLine("Entrada válida");
                Console.ReadKey();
            }
        }

    }
}
