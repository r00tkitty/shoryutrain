namespace shoryutrain
{
    partial class Form1
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
            ToolStripMenuItem inputHandlerSelector;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            xinputMenuItem = new ToolStripMenuItem();
            directInputMenuItem = new ToolStripMenuItem();
            buttonUpLeft = new Button();
            buttonUp = new Button();
            buttonUpRight = new Button();
            buttonLeft = new Button();
            buttonNeutral = new Button();
            buttonRight = new Button();
            buttonDownLeft = new Button();
            buttonDown = new Button();
            buttonDownRight = new Button();
            menuStrip1 = new MenuStrip();
            gameTypeSelector = new ToolStripMenuItem();
            streetFighterToolStripMenuItem = new ToolStripMenuItem();
            About = new ToolStripMenuItem();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            connectedControllerName = new TextBox();
            inputHandlerSelector = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // inputHandlerSelector
            // 
            inputHandlerSelector.DropDownItems.AddRange(new ToolStripItem[] { xinputMenuItem, directInputMenuItem });
            inputHandlerSelector.Name = "inputHandlerSelector";
            inputHandlerSelector.Size = new Size(72, 20);
            inputHandlerSelector.Text = "Controller";
            inputHandlerSelector.Click += toolStripMenuItem1_Click;
            // 
            // xinputMenuItem
            // 
            xinputMenuItem.Checked = true;
            xinputMenuItem.CheckState = CheckState.Checked;
            xinputMenuItem.Name = "xinputMenuItem";
            xinputMenuItem.Size = new Size(133, 22);
            xinputMenuItem.Text = "Xinput";
            xinputMenuItem.Click += xinputMenuItem_Click;
            // 
            // directInputMenuItem
            // 
            directInputMenuItem.Name = "directInputMenuItem";
            directInputMenuItem.Size = new Size(133, 22);
            directInputMenuItem.Text = "DirectInput";
            directInputMenuItem.Click += directInputMenuItem_Click;
            // 
            // buttonUpLeft
            // 
            buttonUpLeft.Font = new Font("Segoe UI", 40F);
            buttonUpLeft.Location = new Point(13, 27);
            buttonUpLeft.Margin = new Padding(4, 3, 4, 3);
            buttonUpLeft.Name = "buttonUpLeft";
            buttonUpLeft.Size = new Size(100, 100);
            buttonUpLeft.TabIndex = 0;
            buttonUpLeft.Text = "🢄";
            buttonUpLeft.UseVisualStyleBackColor = true;
            // 
            // buttonUp
            // 
            buttonUp.Font = new Font("Segoe UI", 40F);
            buttonUp.Location = new Point(119, 27);
            buttonUp.Margin = new Padding(4, 3, 4, 3);
            buttonUp.Name = "buttonUp";
            buttonUp.Size = new Size(100, 100);
            buttonUp.TabIndex = 1;
            buttonUp.Text = "🢁";
            buttonUp.TextAlign = ContentAlignment.TopCenter;
            buttonUp.UseVisualStyleBackColor = true;
            // 
            // buttonUpRight
            // 
            buttonUpRight.Font = new Font("Segoe UI", 40F);
            buttonUpRight.Location = new Point(225, 27);
            buttonUpRight.Margin = new Padding(4, 3, 4, 3);
            buttonUpRight.Name = "buttonUpRight";
            buttonUpRight.Size = new Size(100, 100);
            buttonUpRight.TabIndex = 2;
            buttonUpRight.Text = "🢅";
            buttonUpRight.UseVisualStyleBackColor = true;
            // 
            // buttonLeft
            // 
            buttonLeft.Font = new Font("Segoe UI", 40F);
            buttonLeft.Location = new Point(13, 133);
            buttonLeft.Margin = new Padding(4, 3, 4, 3);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(100, 100);
            buttonLeft.TabIndex = 3;
            buttonLeft.Text = "🢀";
            buttonLeft.UseVisualStyleBackColor = true;
            // 
            // buttonNeutral
            // 
            buttonNeutral.Font = new Font("Calibri", 39.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonNeutral.Location = new Point(119, 133);
            buttonNeutral.Margin = new Padding(4, 3, 4, 3);
            buttonNeutral.Name = "buttonNeutral";
            buttonNeutral.Size = new Size(100, 100);
            buttonNeutral.TabIndex = 4;
            buttonNeutral.Text = "Ⓝ";
            buttonNeutral.UseVisualStyleBackColor = true;
            // 
            // buttonRight
            // 
            buttonRight.Font = new Font("Segoe UI", 40F);
            buttonRight.Location = new Point(225, 133);
            buttonRight.Margin = new Padding(4, 3, 4, 3);
            buttonRight.Name = "buttonRight";
            buttonRight.Size = new Size(100, 100);
            buttonRight.TabIndex = 5;
            buttonRight.Text = "🢂";
            buttonRight.UseVisualStyleBackColor = true;
            // 
            // buttonDownLeft
            // 
            buttonDownLeft.Font = new Font("Segoe UI", 40F);
            buttonDownLeft.Location = new Point(13, 239);
            buttonDownLeft.Margin = new Padding(4, 3, 4, 3);
            buttonDownLeft.Name = "buttonDownLeft";
            buttonDownLeft.Size = new Size(100, 100);
            buttonDownLeft.TabIndex = 6;
            buttonDownLeft.Text = "🢇";
            buttonDownLeft.UseVisualStyleBackColor = true;
            // 
            // buttonDown
            // 
            buttonDown.BackgroundImageLayout = ImageLayout.None;
            buttonDown.Font = new Font("Segoe UI", 40F);
            buttonDown.ImageAlign = ContentAlignment.BottomCenter;
            buttonDown.Location = new Point(119, 239);
            buttonDown.Margin = new Padding(4, 3, 4, 3);
            buttonDown.Name = "buttonDown";
            buttonDown.Size = new Size(100, 100);
            buttonDown.TabIndex = 7;
            buttonDown.Text = "🢃";
            buttonDown.TextAlign = ContentAlignment.BottomCenter;
            buttonDown.UseVisualStyleBackColor = true;
            // 
            // buttonDownRight
            // 
            buttonDownRight.BackgroundImageLayout = ImageLayout.None;
            buttonDownRight.Font = new Font("Segoe UI", 40F);
            buttonDownRight.Location = new Point(225, 239);
            buttonDownRight.Margin = new Padding(4, 3, 4, 3);
            buttonDownRight.Name = "buttonDownRight";
            buttonDownRight.Size = new Size(100, 100);
            buttonDownRight.TabIndex = 8;
            buttonDownRight.Text = "🢆";
            buttonDownRight.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { inputHandlerSelector, gameTypeSelector, About });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(718, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameTypeSelector
            // 
            gameTypeSelector.DropDownItems.AddRange(new ToolStripItem[] { streetFighterToolStripMenuItem });
            gameTypeSelector.Name = "gameTypeSelector";
            gameTypeSelector.Size = new Size(50, 20);
            gameTypeSelector.Text = "Game";
            // 
            // streetFighterToolStripMenuItem
            // 
            streetFighterToolStripMenuItem.Name = "streetFighterToolStripMenuItem";
            streetFighterToolStripMenuItem.Size = new Size(144, 22);
            streetFighterToolStripMenuItem.Text = "Street Fighter";
            // 
            // About
            // 
            About.DisplayStyle = ToolStripItemDisplayStyle.Text;
            About.Name = "About";
            About.Size = new Size(52, 20);
            About.Text = "About";
            About.Click += About_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Right;
            button1.Location = new Point(469, 96);
            button1.Name = "button1";
            button1.Size = new Size(75, 75);
            button1.TabIndex = 10;
            button1.Text = "LP";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Right;
            button2.Location = new Point(550, 96);
            button2.Name = "button2";
            button2.Size = new Size(75, 75);
            button2.TabIndex = 11;
            button2.Text = "MP";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Right;
            button3.Location = new Point(631, 96);
            button3.Name = "button3";
            button3.Size = new Size(75, 75);
            button3.TabIndex = 12;
            button3.Text = "HP";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Right;
            button4.Location = new Point(469, 177);
            button4.Name = "button4";
            button4.Size = new Size(75, 75);
            button4.TabIndex = 13;
            button4.Text = "LK";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Right;
            button5.Location = new Point(550, 177);
            button5.Name = "button5";
            button5.Size = new Size(75, 75);
            button5.TabIndex = 14;
            button5.Text = "MK";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Right;
            button6.Location = new Point(631, 177);
            button6.Name = "button6";
            button6.Size = new Size(75, 75);
            button6.TabIndex = 15;
            button6.Text = "HK";
            button6.UseVisualStyleBackColor = true;
            // 
            // connectedControllerName
            // 
            connectedControllerName.BorderStyle = BorderStyle.FixedSingle;
            connectedControllerName.Location = new Point(13, 359);
            connectedControllerName.Name = "connectedControllerName";
            connectedControllerName.ReadOnly = true;
            connectedControllerName.Size = new Size(312, 23);
            connectedControllerName.TabIndex = 16;
            connectedControllerName.TextChanged += connectedControllerName_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 394);
            Controls.Add(connectedControllerName);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(buttonDownRight);
            Controls.Add(buttonDown);
            Controls.Add(buttonDownLeft);
            Controls.Add(buttonRight);
            Controls.Add(buttonNeutral);
            Controls.Add(buttonLeft);
            Controls.Add(buttonUpRight);
            Controls.Add(buttonUp);
            Controls.Add(buttonUpLeft);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            RightToLeft = RightToLeft.No;
            Text = "Shoryutrain";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonUpLeft;
        private Button buttonUp;
        private Button buttonUpRight;
        private Button buttonLeft;
        private Button buttonNeutral;
        private Button buttonRight;
        private Button buttonDownLeft;
        private Button buttonDown;
        private Button buttonDownRight;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem inputHandlerSelector;
        private ToolStripMenuItem xinputMenuItem;
        private ToolStripMenuItem directInputMenuItem;
        private ToolStripMenuItem gameTypeSelector;
        private ToolStripMenuItem streetFighterToolStripMenuItem;
        private ToolStripMenuItem About;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private TextBox connectedControllerName;
    }
}
