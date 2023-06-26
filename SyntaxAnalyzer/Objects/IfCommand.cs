using System;
using System.Collections.Generic;
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

        public IfCommand(string code)
        {
			Code = code;
        }

        public void Validate()
        {
			string tk;

			//S(tk);
		}

		private bool S(string tk)
		{
			if (tk == Constants.TKIf)
			{
				//getToken();
				if (tk == Constants.TKAbreParenteses)
				{
					//getToken();
					if (C(tk))
					{
						if (tk == Constants.TKFechaParenteses)
						{
							//getToken();
							if (tk == Constants.TKAbreChaves)
							{
								//getToken();
								if (S(tk))
								{
									if (tk == Constants.TKFechaChaves)
									{
									 //getToken();
										return true;
									} else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava o token '}'"); return false; }
								} else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava uma expressão para validar o comando IF"); return false; }
							} else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava o token '{'"); return false; }
						} else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava o token ')'"); return false; }
					} else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava uma expressão para validar o comando IF"); return false; }
				} else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava o token '('"); return false; }
			} else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava o token 'if'"); return false; }
		}

		//C -> E R E 
		private bool C(string tk)
		{
			if (E(tk))
			{
				if (R(tk))
				{
					if (E(tk))
					{
						return true;
					}
					else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava um comando expressão"); return false; }
				}
				else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava um operador lógico(==, !=, <, >, <=, >=)"); return false; }
			}
			else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava um comando expressão"); return false; }
		}

		//E -> ID | NUM | E OP E | ( E ) 
		private bool E(string tk)
		{
			if (ID(tk))
			{
				return true;
			}
			else if (NUM(tk))
			{
				return true;
			}
			else if (E(tk))
			{
				if (Operator(tk))
				{
					if (E(tk))
					{
						return true;
					}
					else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava um comando expressão"); return false; }
				}
				else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava um operador lógico(==, !=, <, >, <=, >=)"); return false; }
			}
			else if (tk == Constants.TKAbreParenteses)
			{
				//getToken();
				if (E(tk))
				{
					if (tk == Constants.TKFechaParenteses)
					{
						//getToken();
						return true;
					}
					else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava o token ')'"); return false; }
				}
				else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava um comando expressão"); return false; }
			}
			else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava o token '('"); return false; }
		}

		private bool NUM(string tk)
        {
            if (Regex.IsMatch(tk, @"^-?[0-9][0-9,\.]+$"))
			{
				return true;
			}
			else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava encontrar um valor numerico"); return false; }
		}

		private bool ID(string tk)
		{
			if (Regex.IsMatch(tk, @"^.*?const\s+(\w+\s+)?(\w)\s+=.*$"))
			{
				return true;
			}
			else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava encontrar uma constante"); return false; }
		}

		//R -> == | != | < | > | <= | >= 
		private bool R(string tk)
		{
			if (tk == Constants.TKIgualLogico)
			{
				//getToken();
				return true;
			}
			else if (tk == Constants.TKDiferenteLogico)
			{
				//getToken();
				return true;
			}
			else if (tk == Constants.TKMenorLogico)
			{
				//getToken();
				return true;
			}
			else if (tk == Constants.TKMaiorLogico)
			{
				//getToken();
				return true;
			}
			else if (tk == Constants.TKMenorIgualLogico)
			{
				//getToken();
				return true;
			}
			else if (tk == Constants.TKMaiorIgualLogico)
			{
				//getToken();
				return true;
			}
			else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava um operador lógico(==, !=, <, >, <=, >=)"); return false; }
		}

		//Operator -> + | - | * | / 
		private bool Operator(string tk)
		{
			if (tk == Constants.TKSoma)
			{
				//getToken();
				return true;
			}
			else if (tk == Constants.TKSubtracao)
			{
				//getToken();
				return true;
			}
			else if (tk == Constants.TKMultiplicacao)
			{
				//getToken();
				return true;
			}
			else if (tk == Constants.TKDivisao)
			{
				//getToken();
				return true;
			}
			else { Message.ShowErrorMessage("Token:" + tk + " " + "Esperava um operador(+, -, /, *)"); return false; }
		}
    }
}
