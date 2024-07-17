namespace odlocitvenoDrevo
{
    partial class AddNodeForm
    {
        private System.ComponentModel.IContainer components = null;
        private RadioButton radioDecisionNode;
        private RadioButton radioEventNode;
        private RadioButton radioLeafNode;
        private TextBox txtDecisionNodeName;
        private TextBox txtEventNodeName;
        private TextBox txtLeafNodeValue;
        private ComboBox cmbCurrency;
        private TextBox txtEventNodePercentage;
        private Button btnAdd;
        private Label lblDecisionNodeName;
        private Label lblEventNodeName;
        private Label lblLeafNodeValue;
        private Label lblCurrency;
        private Label lblEventNodePercentage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            radioDecisionNode = new RadioButton();
            radioEventNode = new RadioButton();
            radioLeafNode = new RadioButton();
            txtDecisionNodeName = new TextBox();
            txtEventNodeName = new TextBox();
            txtLeafNodeValue = new TextBox();
            cmbCurrency = new ComboBox();
            txtEventNodePercentage = new TextBox();
            btnAdd = new Button();
            lblDecisionNodeName = new Label();
            lblEventNodeName = new Label();
            lblLeafNodeValue = new Label();
            lblCurrency = new Label();
            lblEventNodePercentage = new Label();
            procentageLAbel = new Label();
            SuspendLayout();
            // 
            // radioDecisionNode
            // 
            radioDecisionNode.AutoSize = true;
            radioDecisionNode.Location = new Point(12, 12);
            radioDecisionNode.Name = "radioDecisionNode";
            radioDecisionNode.Size = new Size(102, 19);
            radioDecisionNode.TabIndex = 0;
            radioDecisionNode.TabStop = true;
            radioDecisionNode.Text = "Decision Node";
            radioDecisionNode.UseVisualStyleBackColor = true;
            radioDecisionNode.CheckedChanged += radioDecisionNode_CheckedChanged;
            // 
            // radioEventNode
            // 
            radioEventNode.AutoSize = true;
            radioEventNode.Location = new Point(12, 37);
            radioEventNode.Name = "radioEventNode";
            radioEventNode.Size = new Size(86, 19);
            radioEventNode.TabIndex = 1;
            radioEventNode.TabStop = true;
            radioEventNode.Text = "Event Node";
            radioEventNode.UseVisualStyleBackColor = true;
            radioEventNode.CheckedChanged += radioEventNode_CheckedChanged;
            // 
            // radioLeafNode
            // 
            radioLeafNode.AutoSize = true;
            radioLeafNode.Location = new Point(12, 62);
            radioLeafNode.Name = "radioLeafNode";
            radioLeafNode.Size = new Size(79, 19);
            radioLeafNode.TabIndex = 2;
            radioLeafNode.TabStop = true;
            radioLeafNode.Text = "Leaf Node";
            radioLeafNode.UseVisualStyleBackColor = true;
            radioLeafNode.CheckedChanged += radioLeafNode_CheckedChanged;
            // 
            // txtDecisionNodeName
            // 
            txtDecisionNodeName.Location = new Point(153, 84);
            txtDecisionNodeName.Name = "txtDecisionNodeName";
            txtDecisionNodeName.Size = new Size(200, 23);
            txtDecisionNodeName.TabIndex = 3;
            // 
            // txtEventNodeName
            // 
            txtEventNodeName.Location = new Point(153, 84);
            txtEventNodeName.Name = "txtEventNodeName";
            txtEventNodeName.Size = new Size(200, 23);
            txtEventNodeName.TabIndex = 4;
            // 
            // txtLeafNodeValue
            // 
            txtLeafNodeValue.Location = new Point(153, 84);
            txtLeafNodeValue.Name = "txtLeafNodeValue";
            txtLeafNodeValue.Size = new Size(200, 23);
            txtLeafNodeValue.TabIndex = 5;
            // 
            // cmbCurrency
            // 
            cmbCurrency.FormattingEnabled = true;
            cmbCurrency.Items.AddRange(new object[] { "EUR", "USD", "GBP" });
            cmbCurrency.Location = new Point(153, 113);
            cmbCurrency.Name = "cmbCurrency";
            cmbCurrency.Size = new Size(121, 23);
            cmbCurrency.TabIndex = 6;
            // 
            // txtEventNodePercentage
            // 
            txtEventNodePercentage.Location = new Point(153, 113);
            txtEventNodePercentage.Name = "txtEventNodePercentage";
            txtEventNodePercentage.Size = new Size(50, 23);
            txtEventNodePercentage.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(151, 142);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblDecisionNodeName
            // 
            lblDecisionNodeName.AutoSize = true;
            lblDecisionNodeName.Location = new Point(12, 87);
            lblDecisionNodeName.Name = "lblDecisionNodeName";
            lblDecisionNodeName.Size = new Size(122, 15);
            lblDecisionNodeName.TabIndex = 9;
            lblDecisionNodeName.Text = "Decision Node Name:";
            // 
            // lblEventNodeName
            // 
            lblEventNodeName.AutoSize = true;
            lblEventNodeName.Location = new Point(12, 87);
            lblEventNodeName.Name = "lblEventNodeName";
            lblEventNodeName.Size = new Size(106, 15);
            lblEventNodeName.TabIndex = 10;
            lblEventNodeName.Text = "Event Node Name:";
            // 
            // lblLeafNodeValue
            // 
            lblLeafNodeValue.AutoSize = true;
            lblLeafNodeValue.Location = new Point(12, 87);
            lblLeafNodeValue.Name = "lblLeafNodeValue";
            lblLeafNodeValue.Size = new Size(95, 15);
            lblLeafNodeValue.TabIndex = 11;
            lblLeafNodeValue.Text = "Leaf Node Value:";
            // 
            // lblCurrency
            // 
            lblCurrency.AutoSize = true;
            lblCurrency.Location = new Point(12, 113);
            lblCurrency.Name = "lblCurrency";
            lblCurrency.Size = new Size(58, 15);
            lblCurrency.TabIndex = 12;
            lblCurrency.Text = "Currency:";
            // 
            // lblEventNodePercentage
            // 
            lblEventNodePercentage.AutoSize = true;
            lblEventNodePercentage.Location = new Point(12, 116);
            lblEventNodePercentage.Name = "lblEventNodePercentage";
            lblEventNodePercentage.Size = new Size(133, 15);
            lblEventNodePercentage.TabIndex = 13;
            lblEventNodePercentage.Text = "Event Node Percentage:";
            // 
            // procentageLAbel
            // 
            procentageLAbel.AutoSize = true;
            procentageLAbel.Location = new Point(209, 116);
            procentageLAbel.Name = "procentageLAbel";
            procentageLAbel.Size = new Size(17, 15);
            procentageLAbel.TabIndex = 14;
            procentageLAbel.Text = "%";
            // 
            // AddNodeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 356);
            Controls.Add(procentageLAbel);
            Controls.Add(lblEventNodePercentage);
            Controls.Add(txtEventNodePercentage);
            Controls.Add(lblCurrency);
            Controls.Add(lblLeafNodeValue);
            Controls.Add(lblEventNodeName);
            Controls.Add(lblDecisionNodeName);
            Controls.Add(btnAdd);
            Controls.Add(cmbCurrency);
            Controls.Add(txtLeafNodeValue);
            Controls.Add(txtEventNodeName);
            Controls.Add(txtDecisionNodeName);
            Controls.Add(radioLeafNode);
            Controls.Add(radioEventNode);
            Controls.Add(radioDecisionNode);
            Name = "AddNodeForm";
            Text = "Add Node";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label procentageLAbel;
    }
}
