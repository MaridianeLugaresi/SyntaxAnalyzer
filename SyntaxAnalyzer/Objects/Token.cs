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
            tokens.Add(new Token("tkDo", Constants.TKDo));
            tokens.Add(new Token("tkWhile", Constants.TKWhile));
            tokens.Add(new Token("tkFor", Constants.TKFor));
            tokens.Add(new Token("tkIf", Constants.TKIf));
            tokens.Add(new Token("tkElse", Constants.TKElse));

            // Operadores Relacionais
            tokens.Add(new Token("tkMaior", Constants.TKMaiorLogico));
            tokens.Add(new Token("tkMenor", Constants.TKMenorLogico));
            tokens.Add(new Token("tkIgual", Constants.TKIgualLogico));
            tokens.Add(new Token("tkDiferente", Constants.TKDiferenteLogico));
            tokens.Add(new Token("tkDiferente", Constants.TKDiferenteCondicao));
            tokens.Add(new Token("tkMaiorigual", Constants.TKMaiorIgualLogico));
            tokens.Add(new Token("tkMenorigual", Constants.TKMenorIgualLogico));

            // Operadores Aritméticos
            tokens.Add(new Token("tkSoma", Constants.TKSoma));
            tokens.Add(new Token("tkSubtracao", Constants.TKSubtracao));
            tokens.Add(new Token("tkDivisao", Constants.TKDivisao));
            tokens.Add(new Token("tkMultiplicacao", Constants.TKMultiplicacao));
            tokens.Add(new Token("tkResto", Constants.TKResto));

            // Operadores Bitwise
            tokens.Add(new Token("tkBitwiseAnd", Constants.TKBitwiseAnd));
            tokens.Add(new Token("tkBitwiseOr", Constants.TKBitwiseOr));
            tokens.Add(new Token("tkBitwiseXor", Constants.TKBitwiseXor));
            tokens.Add(new Token("tkBitwiseNot", Constants.TKBitwiseNot));
            tokens.Add(new Token("tkBitwiseLeftshift", Constants.TKBitwiseLeftshift));
            tokens.Add(new Token("tkBitwiseRightshift", Constants.TKBitwiseRightshift));

            // Operadores Lógicos
            tokens.Add(new Token("tkAnd", Constants.TKAnd));
            tokens.Add(new Token("tkOr", Constants.TKOr));
            tokens.Add(new Token("tkNegacao", Constants.TKNegacao));

            // Operadores Atribuição
            tokens.Add(new Token("tkAtribuicao", Constants.TKAtribuicao));
            tokens.Add(new Token("tkAtribuicaoIncremento", Constants.TKAtribuicaoIncremento));
            tokens.Add(new Token("tkAtribuicaoDecremento", Constants.TKAtribuicaoDecremento));
            tokens.Add(new Token("tkAtribuicaoMultiplicacao", Constants.TKAtribuicaoMultiplicacao));
            tokens.Add(new Token("tkAtribuicaoDivisao", Constants.TKAtribuicaoDivisao));
            tokens.Add(new Token("tkAtribuicaoResto", Constants.TKAtribuicaoResto));
            tokens.Add(new Token("tkAtribuicaoDeslocamentoDireta", Constants.TKAtribuicaoDeslocamentoDireta));
            tokens.Add(new Token("tkAtribuicaoDeslocamentoEsquerda", Constants.TKAtribuicaoDeslocamentoEsquerda));
        }
    }
}
