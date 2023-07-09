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
				getToken();
				if (Attribution())
				{
					getToken();
					if (Constant())
					{
						getToken();
						if (Token.Tk == Constants.TKPontoEVirgula)
						{
							return true;
						}
						else
						{
							if (Constant())
							{
								getToken();
								if (Operator())
								{
									getToken();
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
							else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava uma constante"); return false; }
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
			if (Regex.IsMatch(Token.Tk, @"^[a-zA-Z]?[0-9]*\.?[0-9]|([0-9]?[a-zA-Z]+)?$"))
			{
				return true;
			}
			else { return false; }
		}

		private bool Attribution()
		{
			if (Token.Tk == Constants.TKAtribuicao)
			{
				return true;
			}
			else if (Token.Tk == Constants.TKAtribuicaoIncremento)
			{
				return true;
			}
			else if (Token.Tk == Constants.TKAtribuicaoDecremento)
			{
				return true;
			}
			else if (Token.Tk == Constants.TKAtribuicaoMultiplicacao)
			{
				return true;
			}
			else if (Token.Tk == Constants.TKAtribuicaoDivisao)
			{
				return true;
			}
			else if (Token.Tk == Constants.TKAtribuicaoResto)
			{
				return true;
			}
			else if (Token.Tk == Constants.TKDuploMais)
			{
				return true;
			}
			else if (Token.Tk == Constants.TKDuploMenos)
			{
				return true;
			}
			else { return false; }
		}

		private bool Operator()
		{
			if (Token.Tk == Constants.TKSoma)
			{
				return true;
			}
			else if (Token.Tk == Constants.TKSubtracao)
			{
				return true;
			}
			else if (Token.Tk == Constants.TKMultiplicacao)
			{
				return true;
			}
			else if (Token.Tk == Constants.TKDivisao)
			{
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
