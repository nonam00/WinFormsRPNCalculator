namespace WinFormsRPNCalculator.Forms
{
    partial class CreateNewVariableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            createButton = new Button();
            variableNameInput = new TextBox();
            variableValueInput = new TextBox();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // createButton
            // 
            createButton.Location = new Point(42, 113);
            createButton.Name = "createButton";
            createButton.Size = new Size(75, 23);
            createButton.TabIndex = 0;
            createButton.Text = "Create Variable";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // variableNameInput
            // 
            variableNameInput.Location = new Point(12, 29);
            variableNameInput.Name = "variableNameInput";
            variableNameInput.PlaceholderText = "Variable Name";
            variableNameInput.Size = new Size(260, 23);
            variableNameInput.TabIndex = 1;
            // 
            // variableValueInput
            // 
            variableValueInput.Location = new Point(12, 72);
            variableValueInput.Name = "variableValueInput";
            variableValueInput.PlaceholderText = "Variable Value";
            variableValueInput.Size = new Size(260, 23);
            variableValueInput.TabIndex = 2;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(146, 113);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // CreateNewVariableForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 161);
            Controls.Add(cancelButton);
            Controls.Add(variableValueInput);
            Controls.Add(variableNameInput);
            Controls.Add(createButton);
            Name = "CreateNewVariableForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CreateNewVariableForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button createButton;
        private TextBox variableNameInput;
        private TextBox variableValueInput;
        private Button cancelButton;
    }
}