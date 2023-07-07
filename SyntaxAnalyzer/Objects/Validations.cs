using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyntaxAnalyzer.Objects
{
    public class Validations
    {
        public string Tk { get; set; }
        public List<string> Tokens { get; set; } = new List<string>();

        public void Validate(StreamReader arquivo)
        {
            ProcessaPopulaArrayTokens(arquivo);

            if (ValidateTokens())
            {
                Message.ShowSuccessMessage("Validação dos tokens realizada com sucesso!");
            }
            else
            {
                Message.ShowErrorMessage("Houveram ocorrências de erro na validação!");
            }
        }

        private bool ValidateTokens()
        {
            if (Tokens.Count > 0)
            {
                if (Tokens[0] == Constants.TKInt)
                {
                    MainValidation mainValidation = new MainValidation(null, Tokens);
                    if (mainValidation.Validate())
                    {
                        ValidateTokens();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (Tokens.Count > 0)
            {
                if (Tokens[0] == Constants.TKIf)
                {
                    IfCommand ifCommand = new IfCommand(null, Tokens);
                    if (ifCommand.Validate())
                    {
                        ValidateTokens();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (Tokens.Count > 0)
            {
                if (Tokens[0] == Constants.TKFor)
                {
                    ForCommand forCommand = new ForCommand(null, Tokens);
                    if (forCommand.Validate())
                    {
                        ValidateTokens();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (Tokens.Count > 0)
            {
                if (Tokens[0] == Constants.TKDo)
                {
                    DoWhileCommand doWhileCommand = new DoWhileCommand(null, Tokens);
                    if (doWhileCommand.Validate())
                    {
                        ValidateTokens();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (Tokens.Count > 0)
            {
                if (Tokens[0] == Constants.TKWhile)
                {
                    WhileCommand whileCommand = new WhileCommand(null, Tokens);
                    if (whileCommand.Validate())
                    {
                        ValidateTokens();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (Tokens.Count > 0)
            {
                if (Tokens[0] == Constants.TKFechaChaves)
                {
                    getToken();
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void ProcessaPopulaArrayTokens(StreamReader sr)
        {
            string padrao = @"(\()|(\+\+)|(--)|(\-)|(\+)|(\w+\s+)|(==)|(=)|(;)|(<)|(>)|(>=)|(<=)|(\w+\s+)|(\))|(\s+\{)|(\})";
            string linha;

            sr.DiscardBufferedData();
            sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

            while ((linha = sr.ReadLine()) != null)
            {
                string[] tokens = Regex.Split(linha, padrao);

                foreach (string token in tokens)
                {
                    if (token != "")
                    {
                        Tokens.Add(token);
                    }
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
