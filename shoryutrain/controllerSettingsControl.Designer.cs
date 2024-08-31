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
            trackBarDeadZone = new TrackBar();
            label1 = new Label();
            defaultInputComboBox = new ComboBox();
            deadZoneTextBox = new TextBox();
            controllerSettingsApplyBtn = new Button();
            setDefaultControllerSettingsBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBarDeadZone).BeginInit();
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
            // trackBarDeadZone
            // 
            trackBarDeadZone.Location = new Point(144, 118);
            trackBarDeadZone.Maximum = 32767;
            trackBarDeadZone.Name = "trackBarDeadZone";
            trackBarDeadZone.Size = new Size(221, 45);
            trackBarDeadZone.SmallChange = 100;
            trackBarDeadZone.TabIndex = 9;
            trackBarDeadZone.TickFrequency = 1000;
            trackBarDeadZone.Scroll += trackBarDeadZone_Scroll;
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
            // defaultInputComboBox
            // 
            defaultInputComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            defaultInputComboBox.FormattingEnabled = true;
            defaultInputComboBox.Items.AddRange(new object[] { "XInput", "DirectInput" });
            defaultInputComboBox.Location = new Point(151, 175);
            defaultInputComboBox.Name = "defaultInputComboBox";
            defaultInputComboBox.Size = new Size(121, 23);
            defaultInputComboBox.TabIndex = 11;
            defaultInputComboBox.SelectedIndexChanged += defaultInputComboBox_SelectedIndexChanged;
            // 
            // deadZoneTextBox
            // 
            deadZoneTextBox.Location = new Point(371, 118);
            deadZoneTextBox.Name = "deadZoneTextBox";
            deadZoneTextBox.Size = new Size(100, 23);
            deadZoneTextBox.TabIndex = 12;
            deadZoneTextBox.TextChanged += deadZoneTextBox_TextChanged;
            // 
            // controllerSettingsApplyBtn
            // 
            controllerSettingsApplyBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            controllerSettingsApplyBtn.Location = new Point(595, 378);
            controllerSettingsApplyBtn.Name = "controllerSettingsApplyBtn";
            controllerSettingsApplyBtn.Size = new Size(82, 30);
            controllerSettingsApplyBtn.TabIndex = 13;
            controllerSettingsApplyBtn.Text = "Apply";
            controllerSettingsApplyBtn.UseVisualStyleBackColor = true;
            controllerSettingsApplyBtn.Click += controllerSettingsApplyBtn_Click;
            // 
            // setDefaultControllerSettingsBtn
            // 
            setDefaultControllerSettingsBtn.Location = new Point(507, 378);
            setDefaultControllerSettingsBtn.Name = "setDefaultControllerSettingsBtn";
            setDefaultControllerSettingsBtn.Size = new Size(82, 30);
            setDefaultControllerSettingsBtn.TabIndex = 14;
            setDefaultControllerSettingsBtn.Text = "Defaults";
            setDefaultControllerSettingsBtn.UseVisualStyleBackColor = true;
            // 
            // controllerSettingsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(setDefaultControllerSettingsBtn);
            Controls.Add(controllerSettingsApplyBtn);
            Controls.Add(deadZoneTextBox);
            Controls.Add(defaultInputComboBox);
            Controls.Add(label1);
            Controls.Add(trackBarDeadZone);
            Controls.Add(deadzoneLabel);
            Controls.Add(comboBox1);
            Controls.Add(controllerList);
            Controls.Add(controllerHeader);
            Name = "controllerSettingsControl";
            Size = new Size(680, 411);
            Load += controllerSettingsControl_Load;
            ((System.ComponentModel.ISupportInitialize)trackBarDeadZone).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label controllerHeader;
        private ComboBox comboBox1;
        private Label controllerList;
        private Label deadzoneLabel;
        private TrackBar trackBarDeadZone;
        private Label label1;
        private ComboBox defaultInputComboBox;
        private TextBox deadZoneTextBox;
        private Button controllerSettingsApplyBtn;
        private Button setDefaultControllerSettingsBtn;
    }
}
