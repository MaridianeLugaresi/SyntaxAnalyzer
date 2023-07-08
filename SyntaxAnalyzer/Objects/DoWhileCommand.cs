using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyntaxAnalyzer.Objects
{
    public class DoWhileCommand
    {
		public Token Token { get; set; }
		public List<Token> Tokens { get; set; } = new List<Token>();

		public DoWhileCommand(Token tk, List<Token> tokens)
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

		//S -> do { S } while ( C ) ; 
		private bool S()
		{
			if (Tokens[0].Tk == Constants.TKDo)
			{
				getToken();
				getToken();
				if (Token.Tk == Constants.TKAbreChaves)
				{
					getToken();
					if (S())
					{
						if (Token.Tk == Constants.TKFechaChaves)
						{
							getToken();
							if (Token.Tk == Constants.TKWhile)
							{
								getToken();
								if (Token.Tk == Constants.TKAbreParenteses)
								{
									getToken();
									if (C())
									{
										if (Token.Tk == Constants.TKFechaParenteses)
										{
											getToken();
											if (Token.Tk == Constants.TKPontoEVirgula)
											{
												return true;
											}
											else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKPontoEVirgula + "'"); return false; }
										}
										else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKFechaParenteses + "'"); return false; }
									}
									else { Message.ShowErrorMessage("Esperava um comando"); return false; }
								}
								else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKAbreParenteses + "'"); return false; }
							}
							else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKWhile + "'"); return false; }
						}
						else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKFechaChaves + "'"); return false; }
					}
					else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava uma expressão para validar o token"); return false; }
				}
				else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava uma expressão para validar o comando dowhile"); return false; }
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
					else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava uma expressão para validar o token"); return false; }
				}
				else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava um operador lógico(==, !=, <, >, <=, >=)"); return false; }
			}
			else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava um comando expressão"); return false; }
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
					else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava um comando expressão"); return false; }
				}
				else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava um operador lógico(==, !=, <, >, <=, >=)"); return false; }
			}
			else if (Token.Tk == Constants.TKAbreParenteses)
			{
				getToken();
				if (E())
				{
					if (Token.Tk == Constants.TKFechaParenteses)
					{
						getToken();
						return true;
					}
					else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKFechaParenteses); return false; }
				}
				else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava um comando expressão"); return false; }
			}
			else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava o token '" + Constants.TKAbreParenteses + "'"); return false; }
		}

		//R -> == | != | < | > | <= | >= 
		private bool R()
		{
			if (Token.Tk == Constants.TKIgualLogico)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKDiferenteLogico)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKMenorLogico)
			{
				getToken();
				return true;
			}
			else if (Token.Tk == Constants.TKMaiorLogico)
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
			else { Message.ShowErrorMessage(Token.ToString() + " " + "Esperava um operador lógico(==, !=, <, >, <=, >=)"); return false; }
		}

		//OP -> + | - | * | / 
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

		private bool NUM()
		{
			if (Regex.IsMatch(Token.Tk, @"^-?\d+(\.\d+)?$"))
			{
				getToken();
				return true;
			}
			else { return false; }
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

		private void getToken()
        {
            Token = Tokens[0];
            Tokens.RemoveAt(0);
        }
    }
}
