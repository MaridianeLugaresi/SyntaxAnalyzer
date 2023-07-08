using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SyntaxAnalyzer.Objects
{
    public class WhileCommand
    {
        public Token Token { get; set; }
        public List<Token> Tokens { get; set; } = new List<Token>();

        public WhileCommand(Token tk, List<Token> tokens)
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

        //S -> while ( C ) { S } 
        private bool S()
        {
            if (Tokens[0].Tk == Constants.TKWhile)
            {
                getToken();
                getToken();
                if (Token.Tk == Constants.TKAbreParenteses)
                {
                    getToken();
                    if (C())
                    {
                        if (Token.Tk == Constants.TKFechaParenteses)
                        {
                            getToken();
                            if (Token.Tk == Constants.TKAbreChaves)
                            {
                                return true;
                            }
                            else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKAbreChaves + "'"); return false; }
                        }
                        else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKFechaParenteses + "'"); return false; }
                    }
                    else { return false; }
                }
                else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKAbreParenteses + "'"); return false; }
            }
            else { return true; }
        }

        //C -> E R E 
        private bool C()
        {
            if (E())
            {
                if (R())
                {
                    if (E())
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }

        //R -> < | > | == | <= | >= | != 
        private bool R()
        {
            if (Token.Tk == Constants.TKMenorLogico)
            {
                getToken();
                return true;
            }
            else if (Token.Tk == Constants.TKMaiorLogico)
            {
                getToken();
                return true;
            }
            else if (Token.Tk == Constants.TKIgualLogico)
            {
                getToken();
                return true;
            }
            else if (Token.Tk == Constants.TKMenorIgualLogico)
            {
                getToken();
                return true;
            }
            else if (Token.Tk == Constants.TKMaiorIgualLogico)
            {
                getToken();
                return true;
            }
            else if (Token.Tk == Constants.TKDiferenteCondicao)
            {
                getToken();
                return true;
            }
            else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava token de operações lógicas e matemáticas"); return false; }
        }

        //E -> V | N 
        private bool E()
        {
            if (ID())
            {
                return true;
            }
            else if (NUM())
            {
                return true;
            }
            else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava token numérico ou id"); return false; }
        }

        private bool ID()
        {
            if (Regex.IsMatch(Token.Tk, @"^[a-zA-Z]+$"))
            {
                getToken();
                return true;
            }
            else { return false; }
        }

        private bool NUM()
        {
            if (Regex.IsMatch(Token.Tk, @"^-?\d+(\.\d+)?$"))
            {
                getToken();
                return true;
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
