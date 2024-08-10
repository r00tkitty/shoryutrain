namespace shoryutrain
{
    partial class streetFighterControl
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
            sfControllerHeader = new Label();
            SuspendLayout();
            // 
            // sfControllerHeader
            // 
            sfControllerHeader.AutoSize = true;
            sfControllerHeader.Font = new Font("Segoe UI", 24F);
            sfControllerHeader.Location = new Point(0, 0);
            sfControllerHeader.Name = "sfControllerHeader";
            sfControllerHeader.Size = new Size(212, 45);
            sfControllerHeader.TabIndex = 2;
            sfControllerHeader.Text = "Street Fighter";
            // 
            // streetFighterControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sfControllerHeader);
            Name = "streetFighterControl";
            Size = new Size(681, 591);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label sfControllerHeader;
    }
}
