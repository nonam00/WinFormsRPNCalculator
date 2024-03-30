namespace WinFormsRPNCalculator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            expressionInput = new TextBox();
            variables = new ListBox();
            resolveButton = new Button();
            result = new Label();
            variablesGroup = new GroupBox();
            removeVariableButton = new Button();
            addVariableButton = new Button();
            expressionGroup = new GroupBox();
            variablesGroup.SuspendLayout();
            expressionGroup.SuspendLayout();
            SuspendLayout();
            // 
            // expressionInput
            // 
            expressionInput.Font = new Font("Segoe UI", 14F);
            expressionInput.Location = new Point(17, 48);
            expressionInput.Name = "expressionInput";
            expressionInput.PlaceholderText = "Expression";
            expressionInput.Size = new Size(339, 32);
            expressionInput.TabIndex = 0;
            expressionInput.TextAlign = HorizontalAlignment.Center;
            // 
            // variables
            // 
            variables.Font = new Font("Segoe UI", 16F);
            variables.FormattingEnabled = true;
            variables.ItemHeight = 30;
            variables.Location = new Point(18, 39);
            variables.Name = "variables";
            variables.RightToLeft = RightToLeft.No;
            variables.Size = new Size(272, 244);
            variables.TabIndex = 1;
            // 
            // resolveButton
            // 
            resolveButton.Font = new Font("Segoe UI", 15F);
            resolveButton.Location = new Point(78, 101);
            resolveButton.Name = "resolveButton";
            resolveButton.Size = new Size(207, 46);
            resolveButton.TabIndex = 2;
            resolveButton.Text = "Resolve";
            resolveButton.UseVisualStyleBackColor = true;
            resolveButton.Click += Resolve;
            // 
            // result
            // 
            result.Font = new Font("Segoe UI", 20F);
            result.Location = new Point(11, 165);
            result.Name = "result";
            result.Size = new Size(339, 227);
            result.TabIndex = 3;
            result.Text = "Result";
            result.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // variablesGroup
            // 
            variablesGroup.Controls.Add(removeVariableButton);
            variablesGroup.Controls.Add(addVariableButton);
            variablesGroup.Controls.Add(variables);
            variablesGroup.Location = new Point(28, 27);
            variablesGroup.Name = "variablesGroup";
            variablesGroup.Size = new Size(322, 411);
            variablesGroup.TabIndex = 4;
            variablesGroup.TabStop = false;
            variablesGroup.Text = "Variables";
            // 
            // removeVariableButton
            // 
            removeVariableButton.Font = new Font("Segoe UI", 15F);
            removeVariableButton.Location = new Point(63, 349);
            removeVariableButton.Name = "removeVariableButton";
            removeVariableButton.Size = new Size(180, 43);
            removeVariableButton.TabIndex = 6;
            removeVariableButton.Text = "Remove Variable";
            removeVariableButton.UseVisualStyleBackColor = true;
            removeVariableButton.Click += removeVariableButton_Click;
            // 
            // addVariableButton
            // 
            addVariableButton.Font = new Font("Segoe UI", 15F);
            addVariableButton.Location = new Point(63, 300);
            addVariableButton.Name = "addVariableButton";
            addVariableButton.Size = new Size(180, 43);
            addVariableButton.TabIndex = 5;
            addVariableButton.Text = "Add Variable";
            addVariableButton.UseVisualStyleBackColor = true;
            addVariableButton.Click += addVariableButton_Click;
            // 
            // expressionGroup
            // 
            expressionGroup.Controls.Add(expressionInput);
            expressionGroup.Controls.Add(result);
            expressionGroup.Controls.Add(resolveButton);
            expressionGroup.Location = new Point(397, 27);
            expressionGroup.Name = "expressionGroup";
            expressionGroup.Size = new Size(356, 411);
            expressionGroup.TabIndex = 6;
            expressionGroup.TabStop = false;
            expressionGroup.Text = "Expression";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(expressionGroup);
            Controls.Add(variablesGroup);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            variablesGroup.ResumeLayout(false);
            expressionGroup.ResumeLayout(false);
            expressionGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox expressionInput;
        private ListBox variables;
        private Button resolveButton;
        private Label result;
        private GroupBox variablesGroup;
        private Button addVariableButton;
        private GroupBox expressionGroup;
        private Button removeVariableButton;
    }
}
