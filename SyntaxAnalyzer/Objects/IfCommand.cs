using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace SyntaxAnalyzer.Objects
{
    public class IfCommand
    {
        public string Code { get; set; }
		public string Tk { get; set; }
		public List<string> Tokens { get; set; } = new List<string>();

        public IfCommand(string code, string tk)
        {
			Code = code;
			Tk = tk;
        }

        public void Validate(StreamReader arquivo)
        {
			ProcessaPopulaArrayTokens(arquivo);
			getToken();
			if (S())
			{
				Message.ShowSuccessMessage("Tokens validados com sucesso");
			}
		}

		private bool S()
		{
			if (Tk == Constants.TKIf)
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
									} else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava o token '}'"); return false; }
								} else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava uma expressão para validar o comando IF"); return false; }
							} else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava o token '{'"); return false; }
						} else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava o token ')'"); return false; }
					} else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava uma expressão para validar o comando IF"); return false; }
				} else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava o token '('"); return false; }
			} else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava o token 'if'"); return false; }
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
					else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava um comando expressão"); return false; }
				}
				else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava um operador lógico(==, !=, <, >, <=, >=)"); return false; }
			}
			else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava um comando expressão"); return false; }
		}

		//E -> ID | NUM | E OP E | ( E ) 
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
			else if (E())
			{
				if (Operator())
				{
					if (E())
					{
						return true;
					}
					else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava um comando expressão"); return false; }
				}
				else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava um operador lógico(==, !=, <, >, <=, >=)"); return false; }
			}
			else if (Tk == Constants.TKAbreParenteses)
			{
				getToken();
				if (E())
				{
					if (Tk == Constants.TKFechaParenteses)
					{
						getToken();
						return true;
					}
					else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava o token ')'"); return false; }
				}
				else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava um comando expressão"); return false; }
			}
			else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava o token '('"); return false; }
		}

		private bool NUM()
        {
            if (Regex.IsMatch(Tk, @"^-?[0-9][0-9,\.]+$"))
			{
                getToken();
                return true;
			}
			else { return false; }
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

		//R -> == | != | < | > | <= | >= 
		private bool R()
		{
			if (Tk == Constants.TKIgualLogico)
			{
				getToken();
				return true;
			}
			else if (Tk == Constants.TKDiferenteLogico)
			{
				getToken();
				return true;
			}
			else if (Tk == Constants.TKMenorLogico)
			{
				getToken();
				return true;
			}
			else if (Tk == Constants.TKMaiorLogico)
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
			else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava um operador lógico(==, !=, <, >, <=, >=)"); return false; }
		}

		//Operator -> + | - | * | / 
		private bool Operator()
		{
			if (Tk == Constants.TKSoma)
			{
				getToken();
				return true;
			}
			else if (Tk == Constants.TKSubtracao)
			{
				getToken();
				return true;
			}
			else if (Tk == Constants.TKMultiplicacao)
			{
				getToken();
				return true;
			}
			else if (Tk == Constants.TKDivisao)
			{
				getToken();
				return true;
			}
			else { Message.ShowErrorMessage("Token:" + Tk + " " + "Esperava um operador(+, -, /, *)"); return false; }
		}

		private void getToken()
		{
			Tk = Tokens[0];
			Tokens.RemoveAt(0);
		}

		private void ProcessaPopulaArrayTokens(StreamReader sr)
		{
			string padrao = @"(\()|(\w+\s+)|(==)|(\w+\s+)|(\))|(\s+\{)|(\})";
			string linha;

			while ((linha = sr.ReadLine()) != null)
			{
				string[] tokens = Regex.Split(linha, padrao);

				// Print the tokens
				foreach (string token in tokens)
				{
					Tokens.Add(token);
				}
			}
			
		}
	}
}
