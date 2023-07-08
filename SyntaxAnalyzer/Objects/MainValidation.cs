using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyntaxAnalyzer.Objects
{
    public class MainValidation
    {
        public Token Token { get; set; }
        public List<Token> Tokens { get; set; } = new List<Token>();

        public MainValidation(Token tk, List<Token> tokens)
        {
            Token = tk;
            Tokens = tokens;
        }

        public bool Validate()
        {
            getToken();
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
            if (Token.Tk == Constants.TKInt)
            {
                getToken();
                if (Token.Tk == Constants.TKMain)
                {
                    getToken();
                    if (Token.Tk == Constants.TKAbreParenteses)
                    {
                        getToken();
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
                    else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKAbreParenteses + "'"); return false; }
                }
                else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKMain + "'"); return false; }
            }
            else { Message.ShowErrorMessage(Token.ToString() + "Esperava o token '" + Constants.TKInt + "'"); return false; }
        }
        
        private void getToken()
        {
            Token = Tokens[0];
            Tokens.RemoveAt(0);
        }
    }
}
