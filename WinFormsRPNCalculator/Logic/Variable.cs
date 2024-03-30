using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsRPNCalculator.Logic
{
    public class Variable
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public override string ToString() =>
            $"{Name} = {Value}";
    }
}
