namespace PBL3
{
    partial class FormChangePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChangePass));
            this.btnChange = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.txbOldPass = new System.Windows.Forms.TextBox();
            this.txbNewPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbConfirm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.btnChange, "btnChange");
            this.btnChange.Name = "btnChange";
            this.btnChange.UseCompatibleTextRendering = true;
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbUsername
            // 
            resources.ApplyResources(this.lbUsername, "lbUsername");
            this.lbUsername.Name = "lbUsername";
            // 
            // lbPassword
            // 
            resources.ApplyResources(this.lbPassword, "lbPassword");
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Click += new System.EventHandler(this.lbPassword_Click);
            // 
            // txbOldPass
            // 
            resources.ApplyResources(this.txbOldPass, "txbOldPass");
            this.txbOldPass.Name = "txbOldPass";
            // 
            // txbNewPass
            // 
            resources.ApplyResources(this.txbNewPass, "txbNewPass");
            this.txbNewPass.Name = "txbNewPass";
            this.txbNewPass.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.lbPassword_Click);
            // 
            // txbConfirm
            // 
            resources.ApplyResources(this.txbConfirm, "txbConfirm");
            this.txbConfirm.Name = "txbConfirm";
            this.txbConfirm.UseSystemPasswordChar = true;
            // 
            // FormChangePass
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txbConfirm);
            this.Controls.Add(this.txbNewPass);
            this.Controls.Add(this.txbOldPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnChange);
            this.Name = "FormChangePass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnChange;
        private Button btnExit;
        private Label lbUsername;
        private Label lbPassword;
        private TextBox txbOldPass;
        private TextBox txbNewPass;
        private Label label1;
        private TextBox txbConfirm;
    }
}