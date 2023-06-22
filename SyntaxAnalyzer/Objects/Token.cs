using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalyzer.Objects
{
    public class Token
    {
        public string name { get; private set; }
        public string value { get; private set; }

        public Token(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public Token()
        {
            List<Token> tokens = new List<Token>();

            // Comandos Iterativas
            tokens.Add(new Token("tkDo", "do"));
            tokens.Add(new Token("tkWhile", "while"));
            tokens.Add(new Token("tkFor", "for"));
            tokens.Add(new Token("tkIf", "if"));
            tokens.Add(new Token("tkElse", "else"));

            // Operadores Relacionais
            tokens.Add(new Token("tkMaior", ">"));
            tokens.Add(new Token("tkMenor", "<"));
            tokens.Add(new Token("tkIgual", "=="));
            tokens.Add(new Token("tkDiferente", "<>"));
            tokens.Add(new Token("tkDiferente", "!="));
            tokens.Add(new Token("tkMaiorigual", ">="));
            tokens.Add(new Token("tkMenorigual", "<="));

            // Operadores Aritméticos
            tokens.Add(new Token("tkSoma", "+"));
            tokens.Add(new Token("tkSubtracao", "-"));
            tokens.Add(new Token("tkDivisao", "/"));
            tokens.Add(new Token("tkMultiplicacao", "*"));
            tokens.Add(new Token("tkResto", "%"));

            // Operadores Bitwise
            tokens.Add(new Token("tkBitwiseAnd", "&"));
            tokens.Add(new Token("tkBitwiseOr", "|"));
            tokens.Add(new Token("tkBitwiseXor", "^"));
            tokens.Add(new Token("tkBitwiseNot", "~"));
            tokens.Add(new Token("tkBitwiseLeftshift", "<<"));
            tokens.Add(new Token("tkBitwiseRightshift", ">>"));

            // Operadores Lógicos
            tokens.Add(new Token("tkAnd", "&&"));
            tokens.Add(new Token("tkOr", "||"));
            tokens.Add(new Token("tkNegacao", "!"));

            // Operadores Atribuição
            tokens.Add(new Token("tkAtribuicao", "="));
            tokens.Add(new Token("tkAtribuicaoIncremento", "+="));
            tokens.Add(new Token("tkAtribuicaoDecremento", "-="));
            tokens.Add(new Token("tkAtribuicaoMultiplicacao", "*="));
            tokens.Add(new Token("tkAtribuicaoDivisao", "/="));
            tokens.Add(new Token("tkAtribuicaoResto", "%="));
            tokens.Add(new Token("tkAtribuicaoDeslocamentoDireta", ">>="));
            tokens.Add(new Token("tkAtribuicaoDeslocamentoEsquerda", "<<="));
        }
    }
}
