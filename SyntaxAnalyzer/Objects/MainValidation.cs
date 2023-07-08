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
        public string Tk { get; set; }
        public List<string> Tokens { get; set; } = new List<string>();

        public MainValidation(string tk, List<string> tokens)
        {
            Tk = tk;
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
            if (Tk == Constants.TKInt)
            {
                getToken();
                if (Tk == Constants.TKMain)
                {
                    getToken();
                    if (Tk == Constants.TKAbreParenteses)
                    {
                        getToken();
                        if (Tk == Constants.TKFechaParenteses)
                        {
                            getToken();
                            if (Tk == Constants.TKAbreChaves)
                            {
                                return true;
                            }
                            else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava o token '" + Constants.TKAbreChaves + "'"); return false; }
                        }
                        else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava o token '" + Constants.TKFechaParenteses + "'"); return false; }
                    }
                    else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava o token '" + Constants.TKAbreParenteses + "'"); return false; }
                }
                else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava o token '" + Constants.TKMain + "'"); return false; }
            }
            else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava o token '" + Constants.TKInt + "'"); return false; }
        }
        
        private void getToken()
        {
            Tk = Tokens[0];
            Tokens.RemoveAt(0);
        }
    }
}
