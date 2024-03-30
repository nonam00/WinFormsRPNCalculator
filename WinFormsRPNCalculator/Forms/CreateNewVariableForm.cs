using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsRPNCalculator.Logic;

namespace WinFormsRPNCalculator.Forms
{
    public partial class CreateNewVariableForm : Form
    {
        public Variable Variable { get; set; } = new Variable();
        public CreateNewVariableForm()
        {
            InitializeComponent();

            MaximizeBox = false;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (variableNameInput.Text.Trim().Length > 0 &&
                variableValueInput.Text.Trim().Length > 0 &&
                double.TryParse(
                    variableValueInput.Text.Trim(),
                    CultureInfo.InvariantCulture,
                    out double value))
            {
                Variable.Name = variableNameInput.Text.Trim();
                Variable.Value = value;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
