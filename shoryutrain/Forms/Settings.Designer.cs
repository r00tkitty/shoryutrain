namespace shoryutrain
{
    partial class Settings
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
            TreeNode treeNode7 = new TreeNode("Appearance");
            TreeNode treeNode8 = new TreeNode("Controller");
            TreeNode treeNode9 = new TreeNode("General", new TreeNode[] { treeNode7, treeNode8 });
            TreeNode treeNode10 = new TreeNode("Street Fighter");
            TreeNode treeNode11 = new TreeNode("Games", new TreeNode[] { treeNode10 });
            TreeNode treeNode12 = new TreeNode("About");
            treeView1 = new TreeView();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.BorderStyle = BorderStyle.FixedSingle;
            treeView1.Dock = DockStyle.Left;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeNode7.Name = "interfaceSettingsCat";
            treeNode7.Text = "Appearance";
            treeNode8.Name = "controllerSettingsCat";
            treeNode8.Text = "Controller";
            treeNode9.Name = "generalSettingsCat";
            treeNode9.Text = "General";
            treeNode10.Name = "streetFighterCat";
            treeNode10.Text = "Street Fighter";
            treeNode11.Name = "gameSettingsCat";
            treeNode11.Text = "Games";
            treeNode12.Name = "aboutSettingsCat";
            treeNode12.Text = "About";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode9, treeNode11, treeNode12 });
            treeView1.Size = new Size(269, 556);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(269, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(601, 556);
            panel1.TabIndex = 1;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 556);
            Controls.Add(panel1);
            Controls.Add(treeView1);
            Name = "Settings";
            Text = "Settings";
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private Button button1;
        private Button button2;
        private TabPage settingsTab1;
        private Label label1;
        private TrackBar deadZoneBar;
        private TreeView treeView1;
        private Panel panel1;
    }
}