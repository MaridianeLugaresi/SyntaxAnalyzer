using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyntaxAnalyzer.Objects
{
    public class DeclarationCommand
    {
        public Token Token { get; set; }
        public List<Token> Tokens { get; set; } = new List<Token>();

        public DeclarationCommand(Token tk, List<Token> tokens)
        {
            Token = tk;
            Tokens = tokens;
        }

        public bool Validate()
        {
            if (S())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool S()
        {
            getToken();
            if (Token.Tk == Constants.TKInt || Token.Tk == Constants.TKFloat || Token.Tk == Constants.TKChar)
            {
                getToken();
                if (Constant())
                {
                    if(Token.Tk == Constants.TKPontoEVirgula)
                    {
                        return true;
                    } else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKPontoEVirgula + "'"); return false;}
                } else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava token para nomeação da variável"); return false; }
            }
            else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava token definição do tipo da variável"); return false; }

        }

        private bool Constant()
        {
            if (Token.Tk != ";")
            {
                if (Regex.IsMatch(Token.Tk, @"^[a-zA-Z]?[0-9]*\.?[0-9]|([0-9]?[a-zA-Z]+)?$"))
                {
                    getToken();
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        private void getToken()
        {
            Token = Tokens[0];
            Tokens.RemoveAt(0);
        }
    }
}
