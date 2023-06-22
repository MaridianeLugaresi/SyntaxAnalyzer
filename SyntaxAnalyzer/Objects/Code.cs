using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalyzer.Objects
{
    public class Code
    {
        public IfCommand IfCommand { get; set; }
        public ForCommand ForCommand { get; set; }
        public WhileCommand WhileCommand { get; set; }
        public DoWhileCommand DoWhileCommand { get; set; }

        public Code(IfCommand ifCommand, ForCommand forCommand, WhileCommand whileCommand, DoWhileCommand doWhileCommand)
        {
            IfCommand = ifCommand;
            ForCommand = forCommand;
            WhileCommand = whileCommand;
            DoWhileCommand = doWhileCommand;
        }
    }
}
