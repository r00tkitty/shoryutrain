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
            TreeNode treeNode1 = new TreeNode("Appearance");
            TreeNode treeNode2 = new TreeNode("Controller");
            TreeNode treeNode3 = new TreeNode("General", new TreeNode[] { treeNode1, treeNode2 });
            TreeNode treeNode4 = new TreeNode("Street Fighter");
            TreeNode treeNode5 = new TreeNode("Games", new TreeNode[] { treeNode4 });
            TreeNode treeNode6 = new TreeNode("About");
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
            treeNode1.Name = "interfaceSettingsCat";
            treeNode1.Text = "Appearance";
            treeNode2.Name = "controllerSettingsCat";
            treeNode2.Text = "Controller";
            treeNode3.Name = "generalSettingsCat";
            treeNode3.Text = "General";
            treeNode4.Name = "streetFighterCat";
            treeNode4.Text = "Street Fighter";
            treeNode5.Name = "gameSettingsCat";
            treeNode5.Text = "Games";
            treeNode6.Name = "aboutSettingsCat";
            treeNode6.Text = "About";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode3, treeNode5, treeNode6 });
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
            MaximizeBox = false;
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