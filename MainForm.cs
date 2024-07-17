using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace odlocitvenoDrevo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            logListBox.HorizontalScrollbar = true;
            logListBox.DrawMode = DrawMode.OwnerDrawFixed;
            logListBox.DrawItem += new DrawItemEventHandler(logListBox_DrawItem);
        }

        private void logListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            string itemText = logListBox.Items[e.Index].ToString();
            Color itemColor = GetItemColor(itemText);

            e.DrawBackground();
            using (SolidBrush brush = new SolidBrush(itemColor))
            {
                e.Graphics.DrawString(itemText, e.Font, brush, e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        private Color GetItemColor(string itemText)
        {
            if (itemText.Contains("%"))
            {
                return Color.Orange; // Event node
            }
            else if (itemText.Contains("EUR"))
            {
                return Color.Green; // Leaf node
            }
            else
            {
                return Color.Red; // Decision node
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize TreeView
            treeViewDecisionTree.Nodes.Add("Brunova_kariera");
        }

        private void btnRemoveNode_Click(object sender, EventArgs e)
        {
            if (treeViewDecisionTree.SelectedNode != null)
            {
                treeViewDecisionTree.SelectedNode.Remove();
            }
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            using (AddNodeForm addNodeForm = new AddNodeForm())
            {
                if (addNodeForm.ShowDialog() == DialogResult.OK)
                {
                    TreeNode selectedNode = treeViewDecisionTree.SelectedNode ?? treeViewDecisionTree.Nodes[0];
                    TreeNode newNode = addNodeForm.CreatedNode;
                    if (newNode != null)
                    {
                        selectedNode.Nodes.Add(newNode);
                        selectedNode.Expand();
                    }
                }
            }
        }

        private void btnCalculateBestOutcome_Click(object sender, EventArgs e)
        {
            if (treeViewDecisionTree.Nodes.Count > 0)
            {
                ResetNodeStyles(treeViewDecisionTree.Nodes[0]);
                logListBox.Items.Clear();
                TreeNode rootNode = (TreeNode)treeViewDecisionTree.Nodes[0].Clone();
                double bestOutcome = CalculateBestOutcome(treeViewDecisionTree.Nodes[0], out TreeNode bestNode);

                treeViewCalculated.Nodes.Clear();
                treeViewCalculated.Nodes.Add(rootNode);
                UpdateCalculatedTreeView(treeViewDecisionTree.Nodes[0], rootNode);

                if (bestNode != null)
                {
                    MessageBox.Show($"The best outcome is: {bestOutcome} EUR\nPath: {GetNodePath(bestNode)}");
                    HighlightBestPath(rootNode, GetNodePath(bestNode));
                }
                else
                {
                    MessageBox.Show("No valid outcome found.");
                }

                UpdateLogListBoxHorizontalExtent();
            }
        }

        private double CalculateBestOutcome(TreeNode node, out TreeNode bestNode)
        {
            logListBox.Items.Add($"Calculating outcome for node: {node.Text}");

            if (node.Nodes.Count == 0)
            {
                // This is a leaf node, parse its value
                string[] parts = node.Text.Split(' ');
                if (parts.Length > 1 && double.TryParse(parts[0], out double value))
                {
                    logListBox.Items.Add($"Leaf node found. Value: {value} EUR");
                    bestNode = node;
                    return value;
                }
                bestNode = null;
                logListBox.Items.Add($"Invalid leaf node. Skipping.");
                return 0;
            }

            double totalOutcome = 0;
            bestNode = null;
            bool isDecisionNode = true;

            foreach (TreeNode child in node.Nodes)
            {
                string[] parts = child.Text.Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 1 && parts[1].EndsWith("%"))
                {
                    if (double.TryParse(parts[1].Trim('%'), out double percentage))
                    {
                        percentage /= 100;
                        double childOutcome = CalculateBestOutcome(child, out TreeNode childBestNode);
                        logListBox.Items.Add($"Calculating: {child.Text} with outcome {childOutcome} EUR and percentage {percentage * 100}%");
                        totalOutcome += percentage * childOutcome;
                        isDecisionNode = false;
                    }
                }
                else
                {
                    double childOutcome = CalculateBestOutcome(child, out TreeNode childBestNode);
                    if (bestNode == null || childOutcome > CalculateBestOutcome(bestNode, out _))
                    {
                        bestNode = childBestNode;
                        totalOutcome = childOutcome;
                    }
                }
            }

            if (!isDecisionNode)
            {
                bestNode = node;
            }

            node.Tag = totalOutcome; // Store the outcome in the Tag property
            logListBox.Items.Add($"Node: {node.Text} Total Outcome: {totalOutcome} EUR");
            return totalOutcome;
        }

        private void UpdateCalculatedTreeView(TreeNode originalNode, TreeNode calculatedNode)
        {
            foreach (TreeNode originalChild in originalNode.Nodes)
            {
                TreeNode calculatedChild = (TreeNode)originalChild.Clone();
                UpdateCalculatedTreeView(originalChild, calculatedChild);
                double outcome = originalChild.Tag != null ? (double)originalChild.Tag : 0;
                calculatedChild.Text += $" ({outcome} EUR)";
                calculatedNode.Nodes.Add(calculatedChild);
            }
        }

        private void HighlightBestPath(TreeNode rootNode, string bestPath)
        {
            TreeNode currentNode = rootNode;
            string[] pathParts = bestPath.Split(new string[] { " -> " }, StringSplitOptions.None);

            foreach (string part in pathParts)
            {
                foreach (TreeNode child in currentNode.Nodes)
                {
                    if (child.Text.StartsWith(part))
                    {
                        child.NodeFont = new Font(treeViewCalculated.Font, FontStyle.Bold);
                        currentNode = child;
                        break;
                    }
                }
            }
        }

        private void ResetNodeStyles(TreeNode node)
        {
            node.NodeFont = new Font(treeViewDecisionTree.Font, FontStyle.Regular);
            foreach (TreeNode child in node.Nodes)
            {
                ResetNodeStyles(child);
            }
        }

        private string GetNodePath(TreeNode node)
        {
            if (node == null)
                return string.Empty;

            if (node.Parent != null)
            {
                return $"{GetNodePath(node.Parent)} -> {node.Text}";
            }
            return node.Text;
        }

        private void saveToCSVButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Tree View to CSV";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveTreeToCSV(treeViewDecisionTree, saveFileDialog.FileName);
                }
            }
        }

        private void importCSVButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.Title = "Import Tree View from CSV";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImportTreeFromCSV(openFileDialog.FileName);
                }
            }
        }

        private void SaveTreeToCSV(TreeView treeView, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            foreach (TreeNode node in treeView.Nodes)
            {
                SaveNodeToCSV(node, sb, "");
            }
            File.WriteAllText(filePath, sb.ToString());
        }

        private void SaveNodeToCSV(TreeNode node, StringBuilder sb, string indent)
        {
            sb.AppendLine($"{indent}{node.Text}");
            foreach (TreeNode child in node.Nodes)
            {
                SaveNodeToCSV(child, sb, indent + ",");
            }
        }

        private void ImportTreeFromCSV(string filePath)
        {
            treeViewDecisionTree.Nodes.Clear();
            string[] lines = File.ReadAllLines(filePath);
            TreeNode lastNode = null;
            int lastIndent = -1;
            foreach (string line in lines)
            {
                int indent = line.TakeWhile(c => c == ',').Count();
                string nodeText = line.TrimStart(',');
                TreeNode newNode = new TreeNode(nodeText);
                if (indent == 0)
                {
                    treeViewDecisionTree.Nodes.Add(newNode);
                }
                else if (indent > lastIndent)
                {
                    lastNode.Nodes.Add(newNode);
                }
                else
                {
                    TreeNode parent = lastNode;
                    for (int i = 0; i < lastIndent - indent + 1; i++)
                    {
                        parent = parent.Parent;
                    }
                    parent.Nodes.Add(newNode);
                }
                lastNode = newNode;
                lastIndent = indent;
            }
        }

        private void UpdateLogListBoxHorizontalExtent()
        {
            using (Graphics g = logListBox.CreateGraphics())
            {
                int hzSize = (int)g.MeasureString(logListBox.Items.Cast<string>().OrderByDescending(s => s.Length).FirstOrDefault(), logListBox.Font).Width;
                logListBox.HorizontalExtent = hzSize;
            }
        }

        private void exportToWebButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
                saveFileDialog.Title = "Export Tree View to HTML";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportTreeToHTML(treeViewCalculated, saveFileDialog.FileName);
                }
            }
        }

        private void ExportTreeToHTML(TreeView treeView, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang='en'>");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset='UTF-8'>");
            sb.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
            sb.AppendLine("<title>Decision Tree</title>");
            sb.AppendLine("<link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css'>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<div class='container mt-5'>");
            sb.AppendLine("<h1>Decision Tree</h1>");
            sb.AppendLine("<ul class='list-group'>");

            foreach (TreeNode node in treeView.Nodes)
            {
                ExportNodeToHTML(node, sb, 0);
            }

            sb.AppendLine("</ul>");
            sb.AppendLine("</div>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            File.WriteAllText(filePath, sb.ToString());
        }

        private void ExportNodeToHTML(TreeNode node, StringBuilder sb, int level)
        {
            string indent = new string(' ', level * 4);
            sb.AppendLine($"{indent}<li class='list-group-item'>");
            sb.AppendLine($"{indent}    {node.Text}");
            if (node.Nodes.Count > 0)
            {
                sb.AppendLine($"{indent}    <ul class='list-group mt-2'>");
                foreach (TreeNode child in node.Nodes)
                {
                    ExportNodeToHTML(child, sb, level + 1);
                }
                sb.AppendLine($"{indent}    </ul>");
            }
            sb.AppendLine($"{indent}</li>");
        }

        private void treeViewDecisionTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
