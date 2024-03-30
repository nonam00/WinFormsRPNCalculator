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

                    variables.Items.Clear();
                    variables.Items.AddRange(expression.Variables);
                }
            }
        }
        private void removeVariableButton_Click(object sender, EventArgs e)
        {
            if(variables.SelectedItem is not null)
            {
                int index = variables.SelectedIndex;
                variables.Items.RemoveAt(index);
                if(index >= variables.Items.Count)
                {
                    variables.SelectedIndex = variables.Items.Count - 1;
                }
                else
                {
                    variables.SelectedIndex = index;
                }
            }
        }

    }
}
