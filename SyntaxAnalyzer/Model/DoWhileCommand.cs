using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalyzer.Model
{
    public class DoWhileCommand
    {
        public string Code { get; set; }

        public DoWhileCommand(string code)
        {
            Code = code;
        }

        public void Validate()
        {

        }
    }
}
