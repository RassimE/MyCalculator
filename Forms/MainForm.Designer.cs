namespace Calculator
{
    partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.calculateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.InfoButton = new System.Windows.Forms.Button();
			this.FontMinusButton = new System.Windows.Forms.Button();
			this.FontPlusButton = new System.Windows.Forms.Button();
			this.ClearButton = new System.Windows.Forms.Button();
			this.CalcButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
			this.outputText = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.inputText = new System.Windows.Forms.TextBox();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.label1 = new System.Windows.Forms.Label();
			this.lvFunctions = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label2 = new System.Windows.Forms.Label();
			this.lvVariables = new System.Windows.Forms.ListView();
			this.chVarName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chVarValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.contextMenuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.toolStripMenuItem1,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveResultToolStripMenuItem,
            this.toolStripMenuItem2,
            this.aboutToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(140, 170);
			// 
			// calculateToolStripMenuItem
			// 
			this.calculateToolStripMenuItem.Name = "calculateToolStripMenuItem";
			this.calculateToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.calculateToolStripMenuItem.Text = "Calculate";
			this.calculateToolStripMenuItem.Click += new System.EventHandler(this.CalcButton_Click);
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.clearToolStripMenuItem.Text = "Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 6);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.loadToolStripMenuItem.Text = "Load...";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.saveAsToolStripMenuItem.Text = "Save as...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// saveResultToolStripMenuItem
			// 
			this.saveResultToolStripMenuItem.Name = "saveResultToolStripMenuItem";
			this.saveResultToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.saveResultToolStripMenuItem.Text = "Save result...";
			this.saveResultToolStripMenuItem.Click += new System.EventHandler(this.saveResultToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.aboutToolStripMenuItem.Text = "About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.InfoButton);
			this.panel1.Controls.Add(this.FontMinusButton);
			this.panel1.Controls.Add(this.FontPlusButton);
			this.panel1.Controls.Add(this.ClearButton);
			this.panel1.Controls.Add(this.CalcButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 446);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(698, 33);
			this.panel1.TabIndex = 3;
			// 
			// InfoButton
			// 
			this.InfoButton.Font = new System.Drawing.Font("Minion Pro SmBd", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.InfoButton.Location = new System.Drawing.Point(79, 6);
			this.InfoButton.Name = "InfoButton";
			this.InfoButton.Size = new System.Drawing.Size(33, 22);
			this.InfoButton.TabIndex = 4;
			this.InfoButton.Text = "i";
			this.InfoButton.UseVisualStyleBackColor = true;
			this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
			// 
			// FontMinusButton
			// 
			this.FontMinusButton.Location = new System.Drawing.Point(40, 6);
			this.FontMinusButton.Name = "FontMinusButton";
			this.FontMinusButton.Size = new System.Drawing.Size(33, 22);
			this.FontMinusButton.TabIndex = 3;
			this.FontMinusButton.TabStop = false;
			this.FontMinusButton.Text = "A-";
			this.FontMinusButton.UseVisualStyleBackColor = true;
			this.FontMinusButton.Click += new System.EventHandler(this.FontButton_Click);
			// 
			// FontPlusButton
			// 
			this.FontPlusButton.Location = new System.Drawing.Point(4, 6);
			this.FontPlusButton.Name = "FontPlusButton";
			this.FontPlusButton.Size = new System.Drawing.Size(33, 22);
			this.FontPlusButton.TabIndex = 2;
			this.FontPlusButton.TabStop = false;
			this.FontPlusButton.Text = "A+";
			this.FontPlusButton.UseVisualStyleBackColor = true;
			this.FontPlusButton.Click += new System.EventHandler(this.FontButton_Click);
			// 
			// ClearButton
			// 
			this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ClearButton.Location = new System.Drawing.Point(616, 6);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(75, 23);
			this.ClearButton.TabIndex = 1;
			this.ClearButton.Text = "Clear";
			this.ClearButton.UseVisualStyleBackColor = true;
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// CalcButton
			// 
			this.CalcButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CalcButton.Location = new System.Drawing.Point(534, 6);
			this.CalcButton.Name = "CalcButton";
			this.CalcButton.Size = new System.Drawing.Size(75, 23);
			this.CalcButton.TabIndex = 0;
			this.CalcButton.Text = "Calculate";
			this.CalcButton.UseVisualStyleBackColor = true;
			this.CalcButton.Click += new System.EventHandler(this.CalcButton_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			// 
			// saveFileDialog2
			// 
			this.saveFileDialog2.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			// 
			// outputText
			// 
			this.outputText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputText.Location = new System.Drawing.Point(0, 0);
			this.outputText.Multiline = true;
			this.outputText.Name = "outputText";
			this.outputText.ReadOnly = true;
			this.outputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.outputText.Size = new System.Drawing.Size(522, 199);
			this.outputText.TabIndex = 3;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
			this.splitContainer1.Size = new System.Drawing.Size(698, 446);
			this.splitContainer1.SplitterDistance = 522;
			this.splitContainer1.TabIndex = 4;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.inputText);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.outputText);
			this.splitContainer2.Size = new System.Drawing.Size(522, 446);
			this.splitContainer2.SplitterDistance = 243;
			this.splitContainer2.TabIndex = 0;
			// 
			// inputText
			// 
			this.inputText.AcceptsReturn = true;
			this.inputText.AcceptsTab = true;
			this.inputText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inputText.Location = new System.Drawing.Point(0, 0);
			this.inputText.Multiline = true;
			this.inputText.Name = "inputText";
			this.inputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.inputText.Size = new System.Drawing.Size(522, 243);
			this.inputText.TabIndex = 2;
			this.inputText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputText_KeyDown);
			this.inputText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputText_KeyPress);
			this.inputText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inputText_KeyUp);
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.label1);
			this.splitContainer3.Panel1.Controls.Add(this.lvFunctions);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.label2);
			this.splitContainer3.Panel2.Controls.Add(this.lvVariables);
			this.splitContainer3.Size = new System.Drawing.Size(172, 446);
			this.splitContainer3.SplitterDistance = 281;
			this.splitContainer3.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Functions";
			// 
			// lvFunctions
			// 
			this.lvFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvFunctions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.lvFunctions.FullRowSelect = true;
			this.lvFunctions.GridLines = true;
			this.lvFunctions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvFunctions.HideSelection = false;
			this.lvFunctions.LabelWrap = false;
			this.lvFunctions.Location = new System.Drawing.Point(2, 22);
			this.lvFunctions.MultiSelect = false;
			this.lvFunctions.Name = "lvFunctions";
			this.lvFunctions.Size = new System.Drawing.Size(168, 256);
			this.lvFunctions.TabIndex = 9;
			this.lvFunctions.UseCompatibleStateImageBehavior = false;
			this.lvFunctions.View = System.Windows.Forms.View.Details;
			this.lvFunctions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvFunctions_MouseDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 141;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Variables";
			// 
			// lvVariables
			// 
			this.lvVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chVarName,
            this.chVarValue});
			this.lvVariables.FullRowSelect = true;
			this.lvVariables.GridLines = true;
			this.lvVariables.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvVariables.HideSelection = false;
			this.lvVariables.LabelWrap = false;
			this.lvVariables.Location = new System.Drawing.Point(2, 21);
			this.lvVariables.MultiSelect = false;
			this.lvVariables.Name = "lvVariables";
			this.lvVariables.Size = new System.Drawing.Size(168, 140);
			this.lvVariables.TabIndex = 10;
			this.lvVariables.UseCompatibleStateImageBehavior = false;
			this.lvVariables.View = System.Windows.Forms.View.Details;
			this.lvVariables.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvVariables_MouseDoubleClick);
			// 
			// chVarName
			// 
			this.chVarName.Text = "Name";
			this.chVarName.Width = 55;
			// 
			// chVarValue
			// 
			this.chVarValue.Text = "Value";
			this.chVarValue.Width = 108;
			// 
			// MainForm
			// 
			this.AcceptButton = this.CalcButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(698, 479);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.Text = "Calculator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel1.PerformLayout();
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button CalcButton;
		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem calculateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveResultToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog2;
		private System.Windows.Forms.Button FontMinusButton;
		private System.Windows.Forms.Button FontPlusButton;
		private System.Windows.Forms.TextBox outputText;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TextBox inputText;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView lvFunctions;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView lvVariables;
		private System.Windows.Forms.ColumnHeader chVarName;
		private System.Windows.Forms.ColumnHeader chVarValue;
		private System.Windows.Forms.Button InfoButton;
	}
}

