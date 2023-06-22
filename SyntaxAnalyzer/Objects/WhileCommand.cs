using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalyzer.Objects
{
    public class WhileCommand
    {
        public string Code { get; set; }

        public WhileCommand(string code)
        {
            Code = code;
        }

        public void Validate()
        {

        }
    }
}
