namespace WinFormsRPNCalculator.Logic
{
    public class MathExpression
    {
        public string Expression { set; get; } = "";
        public string ExpressionOpz { set; get; } = "";

        private Dictionary<string, double> variables = new();

        private IReadOnlyDictionary<char, string> trigFunctions = new Dictionary<char, string>()
        {
            { 's', "sin" },
            { 'c', "cos" },
            { 't', "tg" },
            { 'a', "ctg" }
        };

        const string bracketsOpen = "([{";
        const string bracketsClose = ")]}";

        const string operatorsAdditive = "+-";
        const string operatorsMultiplex = "*/";

        public MathExpression() { }
        public MathExpression(string expression) => Expression = expression;

        public double this[string name]
        {
            set
            {
                if (!variables.ContainsKey(name))
                {
                    variables.Add(name, 0.0);
                }
                variables[name] = value;
            }
            get
            {
                if (variables.ContainsKey(name))
                {
                    return variables[name];
                }
                else
                {
                    throw new Exception("Invalid variables name");
                }
            }
        }

        public int CheckBrackets()
        {
            const string brackets = bracketsOpen + bracketsClose;
            Stack<char> bracketsStack = new();

            int position = 0;
            foreach (var symbol in Expression)
            {
                if (!brackets.Contains(symbol))
                {
                    position++;
                    continue;
                }


                if (bracketsOpen.Contains(symbol))
                {
                    position++;
                    bracketsStack.Push(symbol);
                    continue;
                }

                if (bracketsStack.Count == 0)
                    return position;

                int typeClose = bracketsClose.IndexOf(symbol);
                int typeOpen = bracketsOpen.IndexOf(bracketsStack.Peek());

                if (typeClose != typeOpen) return position;

                bracketsStack.Pop();
                position++;
            }

            if (bracketsStack.Count > 0) return position;

            return -1;
        }

        public void OpzCreate()
        {
            Stack<char> operationsStack = new();

            bool isUnar = true;
            bool isLastOperator = false;

            string[] trigOp = trigFunctions.Select(x => x.Value).ToArray();

            for (int position = 0; position < Expression.Length; position++)
            {
                char symbol = Expression[position];

                // white space chars
                if (Char.IsWhiteSpace(symbol)) continue;

                // unar minus
                if (symbol == '-' && (isUnar || isLastOperator))
                {
                    ExpressionOpz += '~';
                    isUnar = false;
                    continue;
                }

                // multiplex operators
                if (operatorsMultiplex.Contains(symbol))
                {
                    while (operationsStack.Count > 0
                            && operatorsMultiplex.Contains(operationsStack.Peek()))
                        ExpressionOpz += operationsStack.Pop();
                    operationsStack.Push(symbol);
                    isLastOperator = true;
                    isUnar = false;
                    continue;
                }

                // additive operators
                if (operatorsAdditive.Contains(symbol))
                {
                    while (operationsStack.Count > 0
                          && (operatorsMultiplex.Contains(operationsStack.Peek())
                          || operatorsAdditive.Contains(operationsStack.Peek())))
                        ExpressionOpz += operationsStack.Pop();
                    operationsStack.Push(symbol);
                    isLastOperator = true;
                    isUnar = false;
                    continue;
                }

                // opening brackets
                if (bracketsOpen.Contains(symbol))
                {
                    operationsStack.Push(symbol);
                    isUnar = true;
                    isLastOperator = false;
                    continue;
                }

                // closing brackets
                if (bracketsClose.Contains(symbol))
                {
                    if(operationsStack.Count == 0)
                    {
                        throw new Exception("Error in the placement of brackets in the expression");
                    }
                    while (!bracketsOpen.Contains(operationsStack.Peek()))
                    {
                        ExpressionOpz += operationsStack.Pop();
                    }
                    operationsStack.Pop();
                    isUnar = false;
                    isLastOperator = false;
                    continue;
                }

                // numbers
                if (Char.IsDigit(symbol) || symbol == '.')
                {
                    string number = "";
                    while ((Char.IsDigit(symbol)
                          || symbol == '.'
                          || Char.ToLower(symbol) == 'e')
                          && position < Expression.Length)
                    {

                        if (Char.ToLower(symbol) == 'e'
                            && Expression[position + 1] == '-')
                        {
                            number += "e-";
                            position += 2;
                            symbol = Expression[position];
                        }
                        else
                        {
                            if (symbol == '.')
                                number += ',';
                            else
                                number += symbol;
                            ++position;
                            if (position < Expression.Length)
                                symbol = Expression[position];
                        }
                    }
                    number += '#';
                    ExpressionOpz += number;
                    position--;
                    isUnar = false;
                    isLastOperator = false;
                    continue;
                }

                // variables
                if (Char.IsLetter(symbol)
                    || symbol == '_')
                {
                    string name = "";
                    while ((Char.IsLetterOrDigit(symbol)
                          || symbol == '_')
                          && position < Expression.Length)
                    {
                        name += symbol;
                        ++position;
                        if (position < Expression.Length)
                            symbol = Expression[position];
                    }

                    // for functions names
                    if (trigOp.Contains(name))
                    {
                        operationsStack.Push(name[0]);
                    }
                    else
                    {
                        if (!variables.ContainsKey(name))
                        {
                            throw new KeyNotFoundException("Variable not found");
                        }
                        ExpressionOpz += variables[name].ToString();
                        ExpressionOpz += "#";
                    }
                    position--;
                    isUnar = false;
                    isLastOperator = false;
                }
            }

            while (operationsStack.Count > 0)
                ExpressionOpz += operationsStack.Pop();
        }

        public double OpzCalculate()
        {

            if (ExpressionOpz.Length == 0)
            {
                throw new Exception("Empty expression");
            }

            Stack<double> operandsStack = new Stack<double>();

            char symbol;
            for (int position = 0; position < ExpressionOpz.Length; position++)
            {
                symbol = ExpressionOpz[position];

                // numbers
                if (Char.IsDigit(symbol)
                    || symbol == '~'
                    || symbol == '.')
                {
                    symbol = (symbol == '~') ? '-' : symbol;
                    string value = "";
                    while (symbol != '#')
                    {
                        value += symbol;
                        symbol = ExpressionOpz[++position];
                        if(symbol != '#' && symbol != ',' && !char.IsNumber(symbol))
                        {
                            throw new Exception("Error in operators placement");
                        }
                    }
                    operandsStack.Push(Double.Parse(value));
                    continue;
                }

                if(operandsStack.Count == 0)
                {
                    throw new Exception("Expression is empty");
                }
                // operators    
                if (operatorsAdditive.Contains(symbol)
                    || operatorsMultiplex.Contains(symbol))
                {
                    if (operandsStack.Count == 1)
                    {
                        throw new Exception("Error in operators or operands placement");
                    }
                    double operand2 = operandsStack.Pop();
                    double operand1 = operandsStack.Pop();

                    if (symbol == '/' && operand2 == 0)
                    {
                        throw new DivideByZeroException("Attempt to divide by 0");
                    }

                    double result = symbol switch
                    {
                        '-' => operand1 - operand2,
                        '+' => operand1 + operand2,
                        '*' => operand1 * operand2,
                        '/' => operand1 / operand2,
                        _ => throw new Exception("Invalid operator or operand")
                    };

                    operandsStack.Push(result);
                    continue;
                }

                if (trigFunctions.ContainsKey(symbol))
                {
                    double operand = operandsStack.Pop();

                    double result = symbol switch
                    {
                        'c' => Math.Cos(operand),
                        's' => Math.Sin(operand),
                        't' => Math.Tan(operand),
                        'a' => Math.Atan(operand),
                        _ => throw new Exception("Invalid operator or operand")
                    };

                    operandsStack.Push(result);
                    continue;
                }
            }
            return operandsStack.Pop();
        }
    }
}
