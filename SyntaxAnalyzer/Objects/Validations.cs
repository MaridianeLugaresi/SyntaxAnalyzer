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
        public Token Token { get; set; }
        public List<Token> Tokens { get; set; } = new List<Token>();

        public void Validate(StreamReader arquivo)
        {
            ProcessaPopulaArrayTokens(arquivo);

            if (ValidateTokens())
            {
                Message.ShowSuccessMessage("Validação dos tokens realizada com sucesso!");
            }
            else
            {
                Message.ShowErrorMessage("Ocorreu algum erro ao validar a expressão!");
            }
        }

        private bool ValidateTokens()
        {
            if (Tokens.Count > 0)
            {
                if (Tokens[0].Tk == Constants.TKInt)
                {
                    MainValidation mainValidation = new MainValidation(null, Tokens);
                    if (mainValidation.Validate())
                    {
                        if (ValidateTokens())
                        {
                            return true;
                        }
                    }
                    else { return false; }
                }
            }

            if (Tokens.Count > 0)
            {
                if (Tokens[0].Tk == Constants.TKIf)
                {
                    IfCommand ifCommand = new IfCommand(null, Tokens);
                    if (ifCommand.Validate())
                    {
                        if (ValidateTokens())
                        {
                            return true;
                        }
                    }
                    else { return false; }
                }
            }

            if (Tokens.Count > 0)
            {
                if (Tokens[0].Tk == Constants.TKFor)
                {
                    ForCommand forCommand = new ForCommand(null, Tokens);
                    if (forCommand.Validate())
                    {
                        if (ValidateTokens())
                        {
                            return true;
                        }
                    }
                    else { return false; }
                }
            }

            if (Tokens.Count > 0)
            {
                if (Tokens[0].Tk == Constants.TKDo)
                {
                    DoWhileCommand doWhileCommand = new DoWhileCommand(null, Tokens);
                    if (doWhileCommand.Validate())
                    {
                        if (ValidateTokens())
                        {
                            return true;
                        }
                    }
                    else { return false; }
                }
            }

            if (Tokens.Count > 0)
            {
                if (Tokens[0].Tk == Constants.TKWhile)
                {
                    WhileCommand whileCommand = new WhileCommand(null, Tokens);
                    if (whileCommand.Validate())
                    {
                        if (ValidateTokens())
                        {
                            return true;
                        }
                    }
                    else { return false; }
                }
            }

            if (Tokens.Count > 0)
            {
                if (Constant())
                {
                    AttributionCommand attributionCommand = new AttributionCommand(null, Tokens);
                    if (attributionCommand.Validate())
                    {
                        if (ValidateTokens())
                        {
                            return true;
                        }
                    }
                    else { return false; }
                }
            }

            if (Tokens.Count > 0)
            {
                if (Tokens[0].Tk == Constants.TKFechaChaves)
                {
                    getToken();
                }
                else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token " + Constants.TKFechaChaves); return false; }
            }
            else { return false; }

            return true;
        }

        private bool Constant()
        {
            if (Tokens[0].Tk != "}")
            {
                if (Regex.IsMatch(Tokens[0].Tk, @"^[a-zA-Z]?[0-9]*\.?[0-9]|([0-9]?[a-zA-Z]+)?$"))
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        private void ProcessaPopulaArrayTokens(StreamReader sr)
        {
            string padrao = @"(\()|(\+\+)|(--)|(\-)|(\+)|(\w+\s+)|(==)|(=)|(;)|(<)|(>)|(>=)|(<=)|(&&)|(!=)|(\w+\s+)|(\))|(\s+\{)|(\})";
            string linha;

            sr.DiscardBufferedData();
            sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

            int countLinha = 0;

            while ((linha = sr.ReadLine()) != null)
            {
                linha = RetornaStringFormatada(linha);

                countLinha++;
                string[] tokens = Regex.Split(linha, padrao);

                foreach (string token in tokens)
                {
                    if (token != "" && token != " " && token != "\t")
                    {
                        Tokens.Add(new Token(token, countLinha));
                    }
                }
            }
        }

        private string RetornaStringFormatada(string sentence)
        {
            sentence = sentence.Replace("\t", "");

            return sentence;
        }

        private void getToken()
        {
            Token = Tokens[0];
            Tokens.RemoveAt(0);
        }
    }
}
