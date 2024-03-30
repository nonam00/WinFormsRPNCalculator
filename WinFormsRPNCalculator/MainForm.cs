using WinFormsRPNCalculator.Forms;
using WinFormsRPNCalculator.Logic;

namespace WinFormsRPNCalculator
{
    public partial class MainForm : Form
    {
        private MathExpression expression = new MathExpression();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Resolve(object sender, EventArgs e)
        {
            if (expressionInput.Text.Trim().Length > 0)
            {
                try
                { 
                    expression.Expression = expressionInput.Text.Trim();
                    expression.OpzCreate();
                    result.Text = expression.OpzCalculate().ToString();
                }
                catch(Exception ex)
                {
                    string msg = ex.Message;
                    //if(msg == "Stack empty.")
                    //{
                    //    result.Text = "Error in the placement of brackets in the expression";
                    //}
                    //else
                    //{
                        result.Text = ex.Message;
                }
                expression.ExpressionOpz = string.Empty;
            }
        }

        private void addVariableButton_Click(object sender, EventArgs e)
        {
            using(CreateNewVariableForm form = new CreateNewVariableForm())
            {
                var result = form.ShowDialog();
                if(result == DialogResult.OK)
                {
                    var variable = form.Variable;
                    expression[variable.Name] = variable.Value;
                    variables.Items.Add(variable);
                }
            }
        }
    }
}
