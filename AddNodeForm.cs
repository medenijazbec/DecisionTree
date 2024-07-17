using System;
using System.Windows.Forms;

namespace odlocitvenoDrevo
{
    public partial class AddNodeForm : Form
    {
        public TreeNode CreatedNode { get; private set; }

        public AddNodeForm()
        {
            InitializeComponent();
            cmbCurrency.SelectedIndex = 0;
        }

        private void radioDecisionNode_CheckedChanged(object sender, EventArgs e)
        {
            ToggleVisibility(radioDecisionNode.Checked, txtDecisionNodeName, lblDecisionNodeName);
            ToggleVisibility(!radioDecisionNode.Checked, txtEventNodeName, lblEventNodeName, txtEventNodePercentage, lblEventNodePercentage, procentageLAbel);
            ToggleVisibility(!radioDecisionNode.Checked, txtLeafNodeValue, lblLeafNodeValue, cmbCurrency, lblCurrency);
        }

        private void radioEventNode_CheckedChanged(object sender, EventArgs e)
        {
            ToggleVisibility(!radioEventNode.Checked, txtDecisionNodeName, lblDecisionNodeName);
            ToggleVisibility(radioEventNode.Checked, txtEventNodeName, lblEventNodeName, txtEventNodePercentage, lblEventNodePercentage, procentageLAbel);
            ToggleVisibility(!radioEventNode.Checked, txtLeafNodeValue, lblLeafNodeValue, cmbCurrency, lblCurrency);
        }

        private void radioLeafNode_CheckedChanged(object sender, EventArgs e)
        {
            ToggleVisibility(!radioLeafNode.Checked, txtDecisionNodeName, lblDecisionNodeName);
            ToggleVisibility(!radioLeafNode.Checked, txtEventNodeName, lblEventNodeName, txtEventNodePercentage, lblEventNodePercentage, procentageLAbel);
            ToggleVisibility(radioLeafNode.Checked, txtLeafNodeValue, lblLeafNodeValue, cmbCurrency, lblCurrency);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (radioDecisionNode.Checked)
            {
                string nodeName = ReplaceSpaces(txtDecisionNodeName.Text);
                CreatedNode = new TreeNode(nodeName);
            }
            else if (radioEventNode.Checked)
            {
                if (!ValidatePercentage())
                {
                    MessageBox.Show("Percentage must be a valid number and sum up to 100% with its siblings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nodeName = ReplaceSpaces(txtEventNodeName.Text);
                CreatedNode = new TreeNode($"{nodeName} ({txtEventNodePercentage.Text}%)");
            }
            else if (radioLeafNode.Checked)
            {
                string nodeName = ReplaceSpaces(txtLeafNodeValue.Text);
                CreatedNode = new TreeNode($"{nodeName} {cmbCurrency.SelectedItem}");
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ToggleVisibility(bool visible, params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.Visible = visible;
            }
        }

        private bool ValidatePercentage()
        {
            if (double.TryParse(txtEventNodePercentage.Text, out double percentage))
            {
                return percentage > 0 && percentage <= 100;
            }
            return false;
        }

        private string ReplaceSpaces(string input)
        {
            return input.Replace(" ", "_");
        }
    }
}