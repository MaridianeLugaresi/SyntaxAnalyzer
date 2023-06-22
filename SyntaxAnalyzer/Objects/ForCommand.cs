using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalyzer.Objects
{
    public class ForCommand
    {
        public string Code { get; set; }

        public ForCommand(string code)
        {
            Code = code;
        }

        public void Validate()
        {

        }
    }
}
