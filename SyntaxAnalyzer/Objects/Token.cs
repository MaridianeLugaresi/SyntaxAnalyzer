using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalyzer.Objects
{
    public class Token
    {
        public string Tk { get; private set; }
        public int Linha { get; private set; }

        public Token(string tk, int linha)
        {
            Tk = tk;
            Linha = linha;
        }

        public override string ToString()
        {
            return "Token:" + Tk + " " + "Linha:" + Linha;
        }
    }
}
