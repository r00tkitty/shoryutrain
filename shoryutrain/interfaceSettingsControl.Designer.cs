namespace shoryutrain
{
    partial class interfaceSettingsControl
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
            appearanceHeader = new Label();
            lightsOutLabel = new Label();
            checkBox1 = new CheckBox();
            accentColorLabel = new Label();
            comboBox1 = new ComboBox();
            soundOnLabel = new Label();
            checkBox2 = new CheckBox();
            SuspendLayout();
            // 
            // appearanceHeader
            // 
            appearanceHeader.AutoSize = true;
            appearanceHeader.Font = new Font("Segoe UI", 24F);
            appearanceHeader.Location = new Point(0, 0);
            appearanceHeader.Name = "appearanceHeader";
            appearanceHeader.Size = new Size(189, 45);
            appearanceHeader.TabIndex = 1;
            appearanceHeader.Text = "Appearance";
            // 
            // lightsOutLabel
            // 
            lightsOutLabel.AutoSize = true;
            lightsOutLabel.Font = new Font("Segoe UI", 10F);
            lightsOutLabel.Location = new Point(3, 74);
            lightsOutLabel.Name = "lightsOutLabel";
            lightsOutLabel.Size = new Size(74, 19);
            lightsOutLabel.TabIndex = 2;
            lightsOutLabel.Text = "Lights Out";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(106, 75);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 3;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // accentColorLabel
            // 
            accentColorLabel.AutoSize = true;
            accentColorLabel.Font = new Font("Segoe UI", 10F);
            accentColorLabel.Location = new Point(3, 112);
            accentColorLabel.Name = "accentColorLabel";
            accentColorLabel.Size = new Size(87, 19);
            accentColorLabel.TabIndex = 4;
            accentColorLabel.Text = "Accent Color";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(96, 108);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(117, 23);
            comboBox1.TabIndex = 5;
            // 
            // soundOnLabel
            // 
            soundOnLabel.AutoSize = true;
            soundOnLabel.Font = new Font("Segoe UI", 10F);
            soundOnLabel.Location = new Point(3, 155);
            soundOnLabel.Name = "soundOnLabel";
            soundOnLabel.Size = new Size(68, 19);
            soundOnLabel.TabIndex = 6;
            soundOnLabel.Text = "Sound on";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(106, 156);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 7;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // interfaceSettingsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(checkBox2);
            Controls.Add(soundOnLabel);
            Controls.Add(comboBox1);
            Controls.Add(accentColorLabel);
            Controls.Add(checkBox1);
            Controls.Add(lightsOutLabel);
            Controls.Add(appearanceHeader);
            Name = "interfaceSettingsControl";
            Size = new Size(673, 493);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label appearanceHeader;
        private Label lightsOutLabel;
        private CheckBox checkBox1;
        private Label accentColorLabel;
        private ComboBox comboBox1;
        private Label soundOnLabel;
        private CheckBox checkBox2;
    }
}
