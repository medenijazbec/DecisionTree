
namespace odlocitvenoDrevo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TreeView treeViewDecisionTree;
        private Button btnAddNode;
        private Button btnRemoveNode;
        private Button btnCalculateBestOutcome;
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
            treeViewDecisionTree = new TreeView();
            btnAddNode = new Button();
            btnRemoveNode = new Button();
            btnCalculateBestOutcome = new Button();
            treeViewCalculated = new TreeView();
            logListBox = new ListBox();
            saveToCSVButton = new Button();
            importCSVButton = new Button();
            exportToWebButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // treeViewDecisionTree
            // 
            treeViewDecisionTree.Location = new Point(12, 12);
            treeViewDecisionTree.Name = "treeViewDecisionTree";
            treeViewDecisionTree.Size = new Size(482, 324);
            treeViewDecisionTree.TabIndex = 0;
            
            // 
            // btnAddNode
            // 
            btnAddNode.Location = new Point(500, 12);
            btnAddNode.Name = "btnAddNode";
            btnAddNode.Size = new Size(75, 23);
            btnAddNode.TabIndex = 1;
            btnAddNode.Text = "Add Node";
            btnAddNode.UseVisualStyleBackColor = true;
            btnAddNode.Click += btnAddNode_Click;
            // 
            // btnRemoveNode
            // 
            btnRemoveNode.Location = new Point(500, 41);
            btnRemoveNode.Name = "btnRemoveNode";
            btnRemoveNode.Size = new Size(75, 23);
            btnRemoveNode.TabIndex = 2;
            btnRemoveNode.Text = "Remove Node";
            btnRemoveNode.UseVisualStyleBackColor = true;
            btnRemoveNode.Click += btnRemoveNode_Click;
            // 
            // btnCalculateBestOutcome
            // 
            btnCalculateBestOutcome.Location = new Point(581, 12);
            btnCalculateBestOutcome.Name = "btnCalculateBestOutcome";
            btnCalculateBestOutcome.Size = new Size(95, 52);
            btnCalculateBestOutcome.TabIndex = 3;
            btnCalculateBestOutcome.Text = "Calculate Best Outcome";
            btnCalculateBestOutcome.UseVisualStyleBackColor = true;
            btnCalculateBestOutcome.Click += btnCalculateBestOutcome_Click;
            // 
            // treeViewCalculated
            // 
            treeViewCalculated.Location = new Point(12, 363);
            treeViewCalculated.Name = "treeViewCalculated";
            treeViewCalculated.Size = new Size(482, 311);
            treeViewCalculated.TabIndex = 4;
            // 
            // logListBox
            // 
            logListBox.FormattingEnabled = true;
            logListBox.ItemHeight = 15;
            logListBox.Location = new Point(500, 70);
            logListBox.Name = "logListBox";
            logListBox.Size = new Size(463, 604);
            logListBox.TabIndex = 5;
            // 
            // saveToCSVButton
            // 
            saveToCSVButton.Location = new Point(682, 41);
            saveToCSVButton.Name = "saveToCSVButton";
            saveToCSVButton.Size = new Size(106, 23);
            saveToCSVButton.TabIndex = 6;
            saveToCSVButton.Text = "Export to CVS File";
            saveToCSVButton.UseVisualStyleBackColor = true;
            saveToCSVButton.Click += saveToCSVButton_Click;
            // 
            // importCSVButton
            // 
            importCSVButton.Location = new Point(682, 12);
            importCSVButton.Name = "importCSVButton";
            importCSVButton.Size = new Size(106, 23);
            importCSVButton.TabIndex = 7;
            importCSVButton.Text = "Import CVS";
            importCSVButton.UseVisualStyleBackColor = true;
            importCSVButton.Click += importCSVButton_Click;
            // 
            // exportToWebButton
            // 
            exportToWebButton.Location = new Point(794, 12);
            exportToWebButton.Name = "exportToWebButton";
            exportToWebButton.Size = new Size(106, 23);
            exportToWebButton.TabIndex = 8;
            exportToWebButton.Text = "Export to WEB";
            exportToWebButton.UseVisualStyleBackColor = true;
            exportToWebButton.Click += exportToWebButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 345);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 9;
            label1.Text = "Results:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 688);
            Controls.Add(label1);
            Controls.Add(exportToWebButton);
            Controls.Add(importCSVButton);
            Controls.Add(saveToCSVButton);
            Controls.Add(logListBox);
            Controls.Add(treeViewCalculated);
            Controls.Add(btnCalculateBestOutcome);
            Controls.Add(btnRemoveNode);
            Controls.Add(btnAddNode);
            Controls.Add(treeViewDecisionTree);
            Name = "MainForm";
            Text = "Decision Tree";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private TreeView treeViewCalculated;
        private ListBox logListBox;
        private Button saveToCSVButton;
        private Button importCSVButton;
        private Button exportToWebButton;
        private Label label1;
    }
}
