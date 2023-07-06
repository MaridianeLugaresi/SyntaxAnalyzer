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
        public string Tk { get; set; }
        public List<string> Tokens { get; set; } = new List<string>();

        public WhileCommand()
        {
        }

        public void Validate(StreamReader arquivo)
        {
            ProcessaPopulaArrayTokens(arquivo);
            getToken();
            if (S())
            {
                Message.ShowSuccessMessage("Tokens do comando WHILE validados com sucesso");
            }
        }

        //S -> while ( C ) { S } 
        private bool S()
        {
            if (Tk == Constants.TKWhile)
            {
                getToken();
                if (Tk == Constants.TKAbreParenteses)
                {
                    getToken();
                    if (C())
                    {
                        if (Tk == Constants.TKFechaParenteses)
                        {
                            getToken();
                            if (Tk == Constants.TKAbreChaves)
                            {
                                getToken();
                                if (S())
                                {
                                    if (Tk == Constants.TKFechaChaves)
                                    {
                                        getToken();
                                        return true;
                                    }
                                    else { Message.ShowErrorMessage("Token: " + Tk + "Esperava o token " + Constants.TKFechaChaves); return false; }
                                }
                                else { return false; }
                            }
                            else { Message.ShowErrorMessage("Token: " + Tk + "Esperava o token " + Constants.TKAbreChaves); return false; }
                        }
                        else { Message.ShowErrorMessage("Token: " + Tk + "Esperava o token " + Constants.TKFechaParenteses); return false; }
                    }
                    else { return false; }
                }
                else { Message.ShowErrorMessage("Token: " + Tk + "Esperava o token " + Constants.TKAbreParenteses); return false; }
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
            if (Tk == Constants.TKMenorLogico)
            {
                getToken();
                return true;
            }
            else if (Tk == Constants.TKMaiorLogico)
            {
                getToken();
                return true;
            }
            else if (Tk == Constants.TKIgualLogico)
            {
                getToken();
                return true;
            }
            else if (Tk == Constants.TKMenorIgualLogico)
            {
                getToken();
                return true;
            }
            else if (Tk == Constants.TKMaiorIgualLogico)
            {
                getToken();
                return true;
            }
            else if (Tk == Constants.TKDiferenteCondicao)
            {
                getToken();
                return true;
            }
            else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava token de operações lógicas e matemáticas"); return false; }
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
            else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava token numérico ou id"); return false; }
        }

        private bool ID()
        {
            if (Regex.IsMatch(Tk, @"^[a-zA-Z]+$"))
            {
                getToken();
                return true;
            }
            else { return false; }
        }

        private bool NUM()
        {
            if (Regex.IsMatch(Tk, @"^-?\d+(\.\d+)?$"))
            {
                getToken();
                return true;
            }
            else { return false; }
        }


        private void ProcessaPopulaArrayTokens(StreamReader sr)
        {

            string padrao = @"(\()|(\w+\s+)|(==)|(\w+\s+)|(\))|(\s+\{)|(\})";
            string linha;

            while ((linha = sr.ReadLine()) != null)
            {
                string[] tokens = Regex.Split(linha, padrao);

                foreach (string token in tokens)
                {
                    Tokens.Add(token);
                }
            }

        }

        private void getToken()
        {
            Tk = Tokens[0];
            Tokens.RemoveAt(0);
        }
    }
}
