namespace shoryutrain
{
    partial class aboutSettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aboutSettingsControl));
            aboutHeader = new Label();
            pictureBox1 = new PictureBox();
            copyrightLabel = new Label();
            aboutTextfield = new LinkLabel();
            eggField = new TextBox();
            shoryukenSettingsBG = new PictureBox();
            logoProgramAboutBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shoryukenSettingsBG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoProgramAboutBox).BeginInit();
            SuspendLayout();
            // 
            // aboutHeader
            // 
            aboutHeader.AutoSize = true;
            aboutHeader.Font = new Font("Segoe UI", 24F);
            aboutHeader.Location = new Point(3, 0);
            aboutHeader.Name = "aboutHeader";
            aboutHeader.Size = new Size(108, 45);
            aboutHeader.TabIndex = 0;
            aboutHeader.Text = "About";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.ErrorImage = Properties.Resources.rootkittenError;
            pictureBox1.Image = Properties.Resources.WhiskerVisionOutline;
            pictureBox1.InitialImage = Properties.Resources.rootkittenError;
            pictureBox1.Location = new Point(3, 267);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(111, 111);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // copyrightLabel
            // 
            copyrightLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            copyrightLabel.AutoSize = true;
            copyrightLabel.Location = new Point(3, 381);
            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.Size = new Size(111, 15);
            copyrightLabel.TabIndex = 3;
            copyrightLabel.Text = "© rootkitten(); 2024";
            // 
            // aboutTextfield
            // 
            aboutTextfield.AutoSize = true;
            aboutTextfield.Font = new Font("Segoe UI", 12F);
            aboutTextfield.LinkArea = new LinkArea(119, 20);
            aboutTextfield.Location = new Point(3, 45);
            aboutTextfield.Name = "aboutTextfield";
            aboutTextfield.Size = new Size(406, 112);
            aboutTextfield.TabIndex = 4;
            aboutTextfield.TabStop = true;
            aboutTextfield.Text = resources.GetString("aboutTextfield.Text");
            aboutTextfield.UseCompatibleTextRendering = true;
            aboutTextfield.LinkClicked += aboutTextfield_LinkClicked;
            // 
            // eggField
            // 
            eggField.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            eggField.Location = new Point(574, 370);
            eggField.Name = "eggField";
            eggField.Size = new Size(105, 23);
            eggField.TabIndex = 6;
            eggField.TextChanged += eggField_TextChanged;
            // 
            // shoryukenSettingsBG
            // 
            shoryukenSettingsBG.BackColor = Color.FromArgb(0, 0, 0, 0);
            shoryukenSettingsBG.Dock = DockStyle.Right;
            shoryukenSettingsBG.Image = Properties.Resources.shryuTransparent;
            shoryukenSettingsBG.Location = new Point(508, 0);
            shoryukenSettingsBG.Name = "shoryukenSettingsBG";
            shoryukenSettingsBG.Size = new Size(171, 396);
            shoryukenSettingsBG.TabIndex = 7;
            shoryukenSettingsBG.TabStop = false;
            // 
            // logoProgramAboutBox
            // 
            logoProgramAboutBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            logoProgramAboutBox.BackColor = Color.Transparent;
            logoProgramAboutBox.BackgroundImageLayout = ImageLayout.None;
            logoProgramAboutBox.ErrorImage = Properties.Resources.rootkittenError;
            logoProgramAboutBox.Image = Properties.Resources.shryunotext;
            logoProgramAboutBox.InitialImage = Properties.Resources.rootkittenError;
            logoProgramAboutBox.Location = new Point(508, 0);
            logoProgramAboutBox.Name = "logoProgramAboutBox";
            logoProgramAboutBox.Size = new Size(171, 93);
            logoProgramAboutBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoProgramAboutBox.TabIndex = 5;
            logoProgramAboutBox.TabStop = false;
            // 
            // aboutSettingsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(eggField);
            Controls.Add(logoProgramAboutBox);
            Controls.Add(aboutTextfield);
            Controls.Add(copyrightLabel);
            Controls.Add(pictureBox1);
            Controls.Add(aboutHeader);
            Controls.Add(shoryukenSettingsBG);
            Name = "aboutSettingsControl";
            Size = new Size(679, 396);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)shoryukenSettingsBG).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoProgramAboutBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label aboutHeader;
        private PictureBox pictureBox1;
        private Label copyrightLabel;
        private LinkLabel aboutTextfield;
        private TextBox eggField;
        private PictureBox shoryukenSettingsBG;
        private PictureBox logoProgramAboutBox;
    }
}
