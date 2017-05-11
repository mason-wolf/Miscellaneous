namespace VIPER
{
    partial class Viper
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Detected");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Storage");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Vulnerabilities", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("MSI Installers");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Custom Installers");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Remnant Cleanup");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Patches", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Scan History");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Parameters");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Scans", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viper));
            this.ProductList = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Directory = new System.Windows.Forms.TreeView();
            this.ScanButton = new System.Windows.Forms.Button();
            this.StorageMenuOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsoleContainer = new System.Windows.Forms.GroupBox();
            this.Console = new System.Windows.Forms.RichTextBox();
            this.AbortButton = new System.Windows.Forms.Button();
            this.StorageBox = new System.Windows.Forms.GroupBox();
            this.AddVulnerabilityButton = new System.Windows.Forms.Button();
            this.VulnerabilityTextBox = new System.Windows.Forms.TextBox();
            this.VulnerabilityList = new System.Windows.Forms.ListBox();
            this.DetectedVulnerabilities = new System.Windows.Forms.GroupBox();
            this.VulnerabilityTabs = new System.Windows.Forms.TabControl();
            this.ThreatTab = new System.Windows.Forms.TabPage();
            this.PatchButton = new System.Windows.Forms.Button();
            this.DetectedVulnerabilitiesList = new System.Windows.Forms.ListBox();
            this.RemovalKeyTab = new System.Windows.Forms.TabPage();
            this.RemovalKey = new System.Windows.Forms.ListBox();
            this.MSIInstallers = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.ProductList)).BeginInit();
            this.StorageMenuOptions.SuspendLayout();
            this.ConsoleContainer.SuspendLayout();
            this.StorageBox.SuspendLayout();
            this.DetectedVulnerabilities.SuspendLayout();
            this.VulnerabilityTabs.SuspendLayout();
            this.ThreatTab.SuspendLayout();
            this.RemovalKeyTab.SuspendLayout();
            this.MSIInstallers.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductList
            // 
            this.ProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.Version,
            this.Vendor,
            this.Identifier});
            this.ProductList.Location = new System.Drawing.Point(16, 15);
            this.ProductList.Margin = new System.Windows.Forms.Padding(4);
            this.ProductList.Name = "ProductList";
            this.ProductList.ReadOnly = true;
            this.ProductList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProductList.Size = new System.Drawing.Size(1239, 396);
            this.ProductList.TabIndex = 1;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Product.Width = 200;
            // 
            // Version
            // 
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            // 
            // Vendor
            // 
            this.Vendor.HeaderText = "Vendor";
            this.Vendor.Name = "Vendor";
            this.Vendor.ReadOnly = true;
            // 
            // Identifier
            // 
            this.Identifier.HeaderText = "Identifier";
            this.Identifier.Name = "Identifier";
            this.Identifier.ReadOnly = true;
            this.Identifier.Width = 500;
            // 
            // Directory
            // 
            this.Directory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Directory.Location = new System.Drawing.Point(17, 420);
            this.Directory.Margin = new System.Windows.Forms.Padding(4);
            this.Directory.Name = "Directory";
            treeNode1.Name = "Detected";
            treeNode1.Text = "Detected";
            treeNode2.Name = "Storage";
            treeNode2.Text = "Storage";
            treeNode3.ImageIndex = -2;
            treeNode3.Name = "Vulnerabilities";
            treeNode3.SelectedImageKey = "(default)";
            treeNode3.Text = "Vulnerabilities";
            treeNode4.Name = "MSIInstallers";
            treeNode4.Text = "MSI Installers";
            treeNode5.Name = "CustomInstallers";
            treeNode5.Text = "Custom Installers";
            treeNode6.Name = "RemnantCleanup";
            treeNode6.Text = "Remnant Cleanup";
            treeNode7.Name = "Patches";
            treeNode7.Text = "Patches";
            treeNode8.Name = "Scan History";
            treeNode8.Text = "Scan History";
            treeNode9.Name = "Parameters";
            treeNode9.Text = "Parameters";
            treeNode10.Name = "Scans";
            treeNode10.Text = "Scans";
            this.Directory.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode7,
            treeNode10});
            this.Directory.Size = new System.Drawing.Size(323, 355);
            this.Directory.TabIndex = 2;
            this.Directory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Directory_AfterSelect);
            // 
            // ScanButton
            // 
            this.ScanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ScanButton.Location = new System.Drawing.Point(1112, 725);
            this.ScanButton.Margin = new System.Windows.Forms.Padding(4);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(143, 43);
            this.ScanButton.TabIndex = 6;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // StorageMenuOptions
            // 
            this.StorageMenuOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.copyToolStripMenuItem});
            this.StorageMenuOptions.Name = "StorageMenuOptions";
            this.StorageMenuOptions.Size = new System.Drawing.Size(118, 48);
            this.StorageMenuOptions.Opening += new System.ComponentModel.CancelEventHandler(this.StorageMenuOptions_Opening);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // ConsoleContainer
            // 
            this.ConsoleContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleContainer.Controls.Add(this.Console);
            this.ConsoleContainer.Location = new System.Drawing.Point(759, 420);
            this.ConsoleContainer.Margin = new System.Windows.Forms.Padding(4);
            this.ConsoleContainer.Name = "ConsoleContainer";
            this.ConsoleContainer.Padding = new System.Windows.Forms.Padding(4);
            this.ConsoleContainer.Size = new System.Drawing.Size(496, 297);
            this.ConsoleContainer.TabIndex = 9;
            this.ConsoleContainer.TabStop = false;
            this.ConsoleContainer.Text = "Console";
            // 
            // Console
            // 
            this.Console.BackColor = System.Drawing.SystemColors.Desktop;
            this.Console.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Console.ForeColor = System.Drawing.Color.Lime;
            this.Console.Location = new System.Drawing.Point(9, 25);
            this.Console.Margin = new System.Windows.Forms.Padding(4);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(479, 264);
            this.Console.TabIndex = 0;
            this.Console.Text = "";
            // 
            // AbortButton
            // 
            this.AbortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AbortButton.Location = new System.Drawing.Point(947, 725);
            this.AbortButton.Margin = new System.Windows.Forms.Padding(4);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(143, 43);
            this.AbortButton.TabIndex = 10;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Visible = false;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // StorageBox
            // 
            this.StorageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StorageBox.Controls.Add(this.AddVulnerabilityButton);
            this.StorageBox.Controls.Add(this.VulnerabilityTextBox);
            this.StorageBox.Controls.Add(this.VulnerabilityList);
            this.StorageBox.Location = new System.Drawing.Point(349, 418);
            this.StorageBox.Margin = new System.Windows.Forms.Padding(4);
            this.StorageBox.Name = "StorageBox";
            this.StorageBox.Padding = new System.Windows.Forms.Padding(4);
            this.StorageBox.Size = new System.Drawing.Size(400, 357);
            this.StorageBox.TabIndex = 9;
            this.StorageBox.TabStop = false;
            this.StorageBox.Text = "Vulnerability Storage";
            // 
            // AddVulnerabilityButton
            // 
            this.AddVulnerabilityButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddVulnerabilityButton.Location = new System.Drawing.Point(316, 322);
            this.AddVulnerabilityButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddVulnerabilityButton.Name = "AddVulnerabilityButton";
            this.AddVulnerabilityButton.Size = new System.Drawing.Size(76, 27);
            this.AddVulnerabilityButton.TabIndex = 9;
            this.AddVulnerabilityButton.Text = "Add";
            this.AddVulnerabilityButton.UseVisualStyleBackColor = true;
            this.AddVulnerabilityButton.Click += new System.EventHandler(this.AddVulnerabilityButton_Click);
            // 
            // VulnerabilityTextBox
            // 
            this.VulnerabilityTextBox.Location = new System.Drawing.Point(9, 324);
            this.VulnerabilityTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.VulnerabilityTextBox.Name = "VulnerabilityTextBox";
            this.VulnerabilityTextBox.Size = new System.Drawing.Size(297, 22);
            this.VulnerabilityTextBox.TabIndex = 1;
            // 
            // VulnerabilityList
            // 
            this.VulnerabilityList.ContextMenuStrip = this.StorageMenuOptions;
            this.VulnerabilityList.FormattingEnabled = true;
            this.VulnerabilityList.ItemHeight = 16;
            this.VulnerabilityList.Location = new System.Drawing.Point(9, 25);
            this.VulnerabilityList.Margin = new System.Windows.Forms.Padding(4);
            this.VulnerabilityList.Name = "VulnerabilityList";
            this.VulnerabilityList.Size = new System.Drawing.Size(381, 292);
            this.VulnerabilityList.TabIndex = 0;
            // 
            // DetectedVulnerabilities
            // 
            this.DetectedVulnerabilities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DetectedVulnerabilities.Controls.Add(this.VulnerabilityTabs);
            this.DetectedVulnerabilities.Location = new System.Drawing.Point(349, 418);
            this.DetectedVulnerabilities.Margin = new System.Windows.Forms.Padding(4);
            this.DetectedVulnerabilities.Name = "DetectedVulnerabilities";
            this.DetectedVulnerabilities.Padding = new System.Windows.Forms.Padding(4);
            this.DetectedVulnerabilities.Size = new System.Drawing.Size(400, 357);
            this.DetectedVulnerabilities.TabIndex = 10;
            this.DetectedVulnerabilities.TabStop = false;
            this.DetectedVulnerabilities.Text = "Detected Vulnerabilities";
            // 
            // VulnerabilityTabs
            // 
            this.VulnerabilityTabs.Controls.Add(this.ThreatTab);
            this.VulnerabilityTabs.Controls.Add(this.RemovalKeyTab);
            this.VulnerabilityTabs.Location = new System.Drawing.Point(9, 26);
            this.VulnerabilityTabs.Margin = new System.Windows.Forms.Padding(4);
            this.VulnerabilityTabs.Name = "VulnerabilityTabs";
            this.VulnerabilityTabs.SelectedIndex = 0;
            this.VulnerabilityTabs.Size = new System.Drawing.Size(373, 331);
            this.VulnerabilityTabs.TabIndex = 2;
            // 
            // ThreatTab
            // 
            this.ThreatTab.Controls.Add(this.PatchButton);
            this.ThreatTab.Controls.Add(this.DetectedVulnerabilitiesList);
            this.ThreatTab.Location = new System.Drawing.Point(4, 25);
            this.ThreatTab.Margin = new System.Windows.Forms.Padding(4);
            this.ThreatTab.Name = "ThreatTab";
            this.ThreatTab.Padding = new System.Windows.Forms.Padding(4);
            this.ThreatTab.Size = new System.Drawing.Size(365, 302);
            this.ThreatTab.TabIndex = 0;
            this.ThreatTab.Text = "Threat";
            this.ThreatTab.UseVisualStyleBackColor = true;
            // 
            // PatchButton
            // 
            this.PatchButton.Enabled = false;
            this.PatchButton.Location = new System.Drawing.Point(276, 268);
            this.PatchButton.Margin = new System.Windows.Forms.Padding(4);
            this.PatchButton.Name = "PatchButton";
            this.PatchButton.Size = new System.Drawing.Size(79, 27);
            this.PatchButton.TabIndex = 1;
            this.PatchButton.Text = "Patch";
            this.PatchButton.UseVisualStyleBackColor = true;
            this.PatchButton.Click += new System.EventHandler(this.PatchButton_Click);
            // 
            // DetectedVulnerabilitiesList
            // 
            this.DetectedVulnerabilitiesList.ContextMenuStrip = this.StorageMenuOptions;
            this.DetectedVulnerabilitiesList.FormattingEnabled = true;
            this.DetectedVulnerabilitiesList.ItemHeight = 16;
            this.DetectedVulnerabilitiesList.Location = new System.Drawing.Point(4, 2);
            this.DetectedVulnerabilitiesList.Margin = new System.Windows.Forms.Padding(4);
            this.DetectedVulnerabilitiesList.Name = "DetectedVulnerabilitiesList";
            this.DetectedVulnerabilitiesList.Size = new System.Drawing.Size(349, 260);
            this.DetectedVulnerabilitiesList.TabIndex = 0;
            // 
            // RemovalKeyTab
            // 
            this.RemovalKeyTab.Controls.Add(this.RemovalKey);
            this.RemovalKeyTab.Location = new System.Drawing.Point(4, 25);
            this.RemovalKeyTab.Margin = new System.Windows.Forms.Padding(4);
            this.RemovalKeyTab.Name = "RemovalKeyTab";
            this.RemovalKeyTab.Padding = new System.Windows.Forms.Padding(4);
            this.RemovalKeyTab.Size = new System.Drawing.Size(365, 302);
            this.RemovalKeyTab.TabIndex = 1;
            this.RemovalKeyTab.Text = "Removal Key";
            this.RemovalKeyTab.UseVisualStyleBackColor = true;
            // 
            // RemovalKey
            // 
            this.RemovalKey.ContextMenuStrip = this.StorageMenuOptions;
            this.RemovalKey.FormattingEnabled = true;
            this.RemovalKey.ItemHeight = 16;
            this.RemovalKey.Location = new System.Drawing.Point(4, 2);
            this.RemovalKey.Margin = new System.Windows.Forms.Padding(4);
            this.RemovalKey.Name = "RemovalKey";
            this.RemovalKey.Size = new System.Drawing.Size(349, 260);
            this.RemovalKey.TabIndex = 1;
            // 
            // MSIInstallers
            // 
            this.MSIInstallers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MSIInstallers.Controls.Add(this.listView1);
            this.MSIInstallers.Location = new System.Drawing.Point(349, 418);
            this.MSIInstallers.Margin = new System.Windows.Forms.Padding(4);
            this.MSIInstallers.Name = "MSIInstallers";
            this.MSIInstallers.Padding = new System.Windows.Forms.Padding(4);
            this.MSIInstallers.Size = new System.Drawing.Size(400, 357);
            this.MSIInstallers.TabIndex = 11;
            this.MSIInstallers.TabStop = false;
            this.MSIInstallers.Text = "Installers";
            this.MSIInstallers.Visible = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.Location = new System.Drawing.Point(7, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(384, 326);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // Viper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 790);
            this.Controls.Add(this.MSIInstallers);
            this.Controls.Add(this.DetectedVulnerabilities);
            this.Controls.Add(this.StorageBox);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.ConsoleContainer);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.Directory);
            this.Controls.Add(this.ProductList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Viper";
            this.Text = " VIPER 2.0";
            this.Load += new System.EventHandler(this.Viper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductList)).EndInit();
            this.StorageMenuOptions.ResumeLayout(false);
            this.ConsoleContainer.ResumeLayout(false);
            this.StorageBox.ResumeLayout(false);
            this.StorageBox.PerformLayout();
            this.DetectedVulnerabilities.ResumeLayout(false);
            this.VulnerabilityTabs.ResumeLayout(false);
            this.ThreatTab.ResumeLayout(false);
            this.RemovalKeyTab.ResumeLayout(false);
            this.MSIInstallers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProductList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identifier;
        private System.Windows.Forms.TreeView Directory;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.ContextMenuStrip StorageMenuOptions;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.GroupBox ConsoleContainer;
        private System.Windows.Forms.RichTextBox Console;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.GroupBox StorageBox;
        private System.Windows.Forms.Button AddVulnerabilityButton;
        private System.Windows.Forms.TextBox VulnerabilityTextBox;
        private System.Windows.Forms.ListBox VulnerabilityList;
        private System.Windows.Forms.GroupBox DetectedVulnerabilities;
        private System.Windows.Forms.ListBox DetectedVulnerabilitiesList;
        private System.Windows.Forms.Button PatchButton;
        private System.Windows.Forms.TabControl VulnerabilityTabs;
        private System.Windows.Forms.TabPage ThreatTab;
        private System.Windows.Forms.TabPage RemovalKeyTab;
        private System.Windows.Forms.ListBox RemovalKey;
        private System.Windows.Forms.GroupBox MSIInstallers;
        private System.Windows.Forms.ListView listView1;
    }
}

