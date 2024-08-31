namespace shoryutrain
{
    partial class controllerSettingsControl
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
            controllerHeader = new Label();
            comboBox1 = new ComboBox();
            controllerList = new Label();
            deadzoneLabel = new Label();
            trackBar1 = new TrackBar();
            label1 = new Label();
            comboBox2 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // controllerHeader
            // 
            controllerHeader.AutoSize = true;
            controllerHeader.Font = new Font("Segoe UI", 24F);
            controllerHeader.Location = new Point(0, 0);
            controllerHeader.Name = "controllerHeader";
            controllerHeader.Size = new Size(162, 45);
            controllerHeader.TabIndex = 1;
            controllerHeader.Text = "Controller";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(96, 57);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(117, 23);
            comboBox1.TabIndex = 7;
            // 
            // controllerList
            // 
            controllerList.AutoSize = true;
            controllerList.Font = new Font("Segoe UI", 10F);
            controllerList.Location = new Point(3, 57);
            controllerList.Name = "controllerList";
            controllerList.Size = new Size(70, 19);
            controllerList.TabIndex = 6;
            controllerList.Text = "Controller";
            // 
            // deadzoneLabel
            // 
            deadzoneLabel.AutoSize = true;
            deadzoneLabel.Font = new Font("Segoe UI", 10F);
            deadzoneLabel.Location = new Point(3, 118);
            deadzoneLabel.Name = "deadzoneLabel";
            deadzoneLabel.Size = new Size(135, 19);
            deadzoneLabel.TabIndex = 8;
            deadzoneLabel.Text = "Controller Deadzone";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(144, 118);
            trackBar1.Maximum = 32767;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(250, 45);
            trackBar1.SmallChange = 100;
            trackBar1.TabIndex = 9;
            trackBar1.TickFrequency = 1000;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(3, 175);
            label1.Name = "label1";
            label1.Size = new Size(142, 19);
            label1.TabIndex = 10;
            label1.Text = "Default Input method";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "XInput", "DirectInput" });
            comboBox2.Location = new Point(151, 175);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 11;
            // 
            // controllerSettingsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBox2);
            Controls.Add(label1);
            Controls.Add(trackBar1);
            Controls.Add(deadzoneLabel);
            Controls.Add(comboBox1);
            Controls.Add(controllerList);
            Controls.Add(controllerHeader);
            Name = "controllerSettingsControl";
            Size = new Size(680, 411);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label controllerHeader;
        private ComboBox comboBox1;
        private Label controllerList;
        private Label deadzoneLabel;
        private TrackBar trackBar1;
        private Label label1;
        private ComboBox comboBox2;
    }
}
