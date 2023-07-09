using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyntaxAnalyzer.Objects
{
    public class AttributionCommand
    {
		public Token Token { get; set; }
		public List<Token> Tokens { get; set; } = new List<Token>();

		public AttributionCommand(Token tk, List<Token> tokens)
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

		public bool S()
		{
			getToken();
			if (Constant())
			{
				if (Attribution())
				{
					if (Constant())
					{
						if (Token.Tk == Constants.TKPontoEVirgula)
						{
							return true;
						}
						else
						{
							if (Operator())
							{
								if (Constant())
								{
									if (Token.Tk == Constants.TKPontoEVirgula)
									{
										return true;
									}
									else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKPontoEVirgula + "'"); return false; }
								}
								else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava uma constante"); return false; }
							}
							else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava um comando de operador"); return false; }	
						}
					}
					else
					{
						if (Token.Tk == Constants.TKPontoEVirgula)
						{
							return true;
						}
						else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKPontoEVirgula + "'"); return false; }
					}
				}
				else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava um comando de atribuição"); return false; }
			}
			else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava uma constante"); return false; }
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

		private bool Attribution()
		{
			if (Token.Tk == Constants.TKAtribuicao)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKAtribuicaoIncremento)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKAtribuicaoDecremento)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKAtribuicaoMultiplicacao)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKAtribuicaoDivisao)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKAtribuicaoResto)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKDuploMais)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKDuploMenos)
			{
				getToken();
				return true;
			}
			else { return false; }
		}

		private bool Operator()
		{
			if (Token.Tk == Constants.TKSoma)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKSubtracao)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKMultiplicacao)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKDivisao)
			{
				getToken();
				return true;
			}
			else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava um operador(+, -, /, *)"); return false; }
		}

		private void getToken()
		{
			Token = Tokens[0];
			Tokens.RemoveAt(0);
		}
	}
}
