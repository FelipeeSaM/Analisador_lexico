﻿using System;
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

        private char[] caracteresNaoPermitidos = { 'j', 'w', 'k', 'y', 'ç', 'h', 'q', 'J', 'W', 'K', 'Y', 'Ç', 'H', 'Q' };
        private char[] caracteresEspeciaisNaoPermitidos = { '/', '(', ')', '&', '%', '$', '#', '@', '!' };
        private bool valido = true;

        public void AnalisarPalavra(string token) {
            token = token.Substring(0, Math.Min(10, token.Length));
            PalavraDoSistema(token);
            valido = AnalisarCaracteresPermitidos(token) && ComecaComLetraValida(token) && AlternaVogalEconsoante(token) && NaoTemDigrafoConsoante(token) && NaoContemNumeroNoMeio(token);
            EhValidoOuNao(valido);
        }
        private void PalavraDoSistema(string tokenReservado) {
            if(tokenReservado.Substring(0, 1).Contains("z") || tokenReservado.Substring(0, 1).Contains("x")) {
                MudarCorConsole(ConsoleColor.Magenta);
                Console.WriteLine("Palavra reservada do sistema. O sistema é foda, parsero.");
            }
        }

        private bool AnalisarCaracteresPermitidos(string tokenReservado) {
            if (tokenReservado.Any(c => caracteresNaoPermitidos.Contains(c) || caracteresEspeciaisNaoPermitidos.Contains(c))) {
                valido = false;
            }
            return valido;
        }

        private bool ComecaComLetraValida(string tokenReservado) {
            if(tokenReservado.Substring(0, 1).Any(c => caracteresNaoPermitidos.Contains(c))) {
                valido = false;
            }
            return valido;
        }

        private bool AlternaVogalEconsoante(string tokenReservado) {
            bool alternanciaCorreta = Regex.IsMatch(tokenReservado, @"(?:(?:[aeiouAEIOU][^aeiouAEIOU])+[aeiouAEIOU])");
            return alternanciaCorreta;
        }

        private bool NaoTemDigrafoConsoante(string tokenReservado) {
            bool alternanciaCorreta = !Regex.IsMatch(tokenReservado, @"[^aeiouAEIOU]{2}");
            return alternanciaCorreta;
        }

        private bool NaoContemNumeroNoMeio(string tokenReservado) {
            if (tokenReservado.Substring(0, tokenReservado.Length-1).Any(c => Char.IsDigit(c))) {
                valido = false;
            }
            return valido;
        }


        private void EhValidoOuNao(bool permitido) {
            if(permitido) {
                MudarCorConsole(ConsoleColor.Green);
                Console.WriteLine("Entrada válida");
            } else {
                MudarCorConsole(ConsoleColor.Red);
                Console.WriteLine("Entrada inválida");
            }
        }

        private void MudarCorConsole(ConsoleColor cor) {
            Console.ForegroundColor = cor;
        }

    }
}
