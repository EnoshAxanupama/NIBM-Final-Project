namespace BixbyShopApp_GUI
{
    partial class UserForm
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
            metroPanel1 = new MetroFramework.Controls.MetroPanel();
            metroLabel1 = new MetroFramework.Controls.MetroLabel();
            Login = new MetroFramework.Controls.MetroButton();
            password = new TextBox();
            email = new TextBox();
            metroLabel3 = new MetroFramework.Controls.MetroLabel();
            metroLabel2 = new MetroFramework.Controls.MetroLabel();
            metroToggle1 = new MetroFramework.Controls.MetroToggle();
            metroLabel4 = new MetroFramework.Controls.MetroLabel();
            metroPanel2 = new MetroFramework.Controls.MetroPanel();
            metroLabel8 = new MetroFramework.Controls.MetroLabel();
            c_pass = new TextBox();
            metroLabel5 = new MetroFramework.Controls.MetroLabel();
            NewAccount = new MetroFramework.Controls.MetroButton();
            c_con_pass = new TextBox();
            c_email = new TextBox();
            metroLabel6 = new MetroFramework.Controls.MetroLabel();
            metroLabel7 = new MetroFramework.Controls.MetroLabel();
            metroPanel1.SuspendLayout();
            metroPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // metroPanel1
            // 
            metroPanel1.BackgroundImageLayout = ImageLayout.Center;
            metroPanel1.Controls.Add(metroLabel1);
            metroPanel1.Controls.Add(Login);
            metroPanel1.Controls.Add(password);
            metroPanel1.Controls.Add(email);
            metroPanel1.Controls.Add(metroLabel3);
            metroPanel1.Controls.Add(metroLabel2);
            metroPanel1.HorizontalScrollbarBarColor = true;
            metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            metroPanel1.HorizontalScrollbarSize = 10;
            metroPanel1.Location = new Point(23, 78);
            metroPanel1.Name = "metroPanel1";
            metroPanel1.Size = new Size(437, 412);
            metroPanel1.Style = MetroFramework.MetroColorStyle.Blue;
            metroPanel1.TabIndex = 0;
            metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroPanel1.UseStyleColors = true;
            metroPanel1.VerticalScrollbarBarColor = true;
            metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            metroLabel1.Location = new Point(21, 35);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new Size(97, 25);
            metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel1.TabIndex = 8;
            metroLabel1.Text = "UserLogin";
            metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroLabel1.UseStyleColors = true;
            // 
            // Login
            // 
            Login.FontSize = MetroFramework.MetroButtonSize.Medium;
            Login.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            Login.Highlight = true;
            Login.Location = new Point(21, 322);
            Login.Name = "Login";
            Login.Size = new Size(94, 29);
            Login.Style = MetroFramework.MetroColorStyle.Blue;
            Login.TabIndex = 7;
            Login.Text = "Login";
            Login.Theme = MetroFramework.MetroThemeStyle.Dark;
            Login.UseSelectable = true;
            Login.UseStyleColors = true;
            Login.Click += Login_Click;
            // 
            // password
            // 
            password.BackColor = SystemColors.WindowText;
            password.ForeColor = SystemColors.Info;
            password.Location = new Point(18, 252);
            password.Name = "password";
            password.Size = new Size(397, 27);
            password.TabIndex = 6;
            password.UseSystemPasswordChar = true;
            // 
            // email
            // 
            email.BackColor = SystemColors.WindowText;
            email.ForeColor = SystemColors.Info;
            email.Location = new Point(18, 150);
            email.Name = "email";
            email.Size = new Size(397, 27);
            email.TabIndex = 5;
            // 
            // metroLabel3
            // 
            metroLabel3.AutoSize = true;
            metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            metroLabel3.Location = new Point(18, 202);
            metroLabel3.Name = "metroLabel3";
            metroLabel3.Size = new Size(87, 25);
            metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel3.TabIndex = 4;
            metroLabel3.Text = "Password";
            metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroLabel3.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            metroLabel2.AutoSize = true;
            metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            metroLabel2.Location = new Point(18, 101);
            metroLabel2.Name = "metroLabel2";
            metroLabel2.Size = new Size(54, 25);
            metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel2.TabIndex = 3;
            metroLabel2.Text = "Email";
            metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroLabel2.UseStyleColors = true;
            // 
            // metroToggle1
            // 
            metroToggle1.AutoSize = true;
            metroToggle1.Location = new Point(268, 31);
            metroToggle1.Name = "metroToggle1";
            metroToggle1.Size = new Size(80, 24);
            metroToggle1.Style = MetroFramework.MetroColorStyle.Blue;
            metroToggle1.TabIndex = 1;
            metroToggle1.Text = "Off";
            metroToggle1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroToggle1.UseSelectable = true;
            metroToggle1.UseStyleColors = true;
            metroToggle1.CheckedChanged += metroToggle1_CheckedChanged;
            // 
            // metroLabel4
            // 
            metroLabel4.AutoSize = true;
            metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            metroLabel4.Location = new Point(156, 30);
            metroLabel4.Name = "metroLabel4";
            metroLabel4.Size = new Size(106, 25);
            metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel4.TabIndex = 8;
            metroLabel4.Text = "Dark Mode";
            metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroLabel4.UseStyleColors = true;
            // 
            // metroPanel2
            // 
            metroPanel2.BackgroundImageLayout = ImageLayout.Center;
            metroPanel2.Controls.Add(metroLabel8);
            metroPanel2.Controls.Add(c_pass);
            metroPanel2.Controls.Add(metroLabel5);
            metroPanel2.Controls.Add(NewAccount);
            metroPanel2.Controls.Add(c_con_pass);
            metroPanel2.Controls.Add(c_email);
            metroPanel2.Controls.Add(metroLabel6);
            metroPanel2.Controls.Add(metroLabel7);
            metroPanel2.HorizontalScrollbarBarColor = true;
            metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            metroPanel2.HorizontalScrollbarSize = 10;
            metroPanel2.Location = new Point(516, 78);
            metroPanel2.Name = "metroPanel2";
            metroPanel2.Size = new Size(788, 499);
            metroPanel2.Style = MetroFramework.MetroColorStyle.Blue;
            metroPanel2.TabIndex = 9;
            metroPanel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroPanel2.UseStyleColors = true;
            metroPanel2.VerticalScrollbarBarColor = true;
            metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel8
            // 
            metroLabel8.AutoSize = true;
            metroLabel8.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            metroLabel8.Location = new Point(18, 322);
            metroLabel8.Name = "metroLabel8";
            metroLabel8.Size = new Size(156, 25);
            metroLabel8.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel8.TabIndex = 10;
            metroLabel8.Text = "Confirm Password";
            metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroLabel8.UseStyleColors = true;
            // 
            // c_pass
            // 
            c_pass.BackColor = SystemColors.WindowText;
            c_pass.ForeColor = SystemColors.Info;
            c_pass.Location = new Point(21, 252);
            c_pass.Name = "c_pass";
            c_pass.Size = new Size(397, 27);
            c_pass.TabIndex = 9;
            c_pass.UseSystemPasswordChar = true;
            // 
            // metroLabel5
            // 
            metroLabel5.AutoSize = true;
            metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            metroLabel5.Location = new Point(21, 35);
            metroLabel5.Name = "metroLabel5";
            metroLabel5.Size = new Size(186, 25);
            metroLabel5.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel5.TabIndex = 8;
            metroLabel5.Text = "Create New Account";
            metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroLabel5.UseStyleColors = true;
            // 
            // NewAccount
            // 
            NewAccount.FontSize = MetroFramework.MetroButtonSize.Medium;
            NewAccount.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            NewAccount.Highlight = true;
            NewAccount.Location = new Point(21, 443);
            NewAccount.Name = "NewAccount";
            NewAccount.Size = new Size(234, 29);
            NewAccount.Style = MetroFramework.MetroColorStyle.Blue;
            NewAccount.TabIndex = 7;
            NewAccount.Text = "Create New Account";
            NewAccount.Theme = MetroFramework.MetroThemeStyle.Dark;
            NewAccount.UseSelectable = true;
            NewAccount.UseStyleColors = true;
            NewAccount.Click += NewAccount_Click;
            // 
            // c_con_pass
            // 
            c_con_pass.BackColor = SystemColors.WindowText;
            c_con_pass.ForeColor = SystemColors.Info;
            c_con_pass.Location = new Point(21, 367);
            c_con_pass.Name = "c_con_pass";
            c_con_pass.Size = new Size(397, 27);
            c_con_pass.TabIndex = 6;
            c_con_pass.UseSystemPasswordChar = true;
            // 
            // c_email
            // 
            c_email.BackColor = SystemColors.WindowText;
            c_email.ForeColor = SystemColors.Info;
            c_email.Location = new Point(18, 150);
            c_email.Name = "c_email";
            c_email.Size = new Size(397, 27);
            c_email.TabIndex = 5;
            // 
            // metroLabel6
            // 
            metroLabel6.AutoSize = true;
            metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            metroLabel6.Location = new Point(18, 202);
            metroLabel6.Name = "metroLabel6";
            metroLabel6.Size = new Size(87, 25);
            metroLabel6.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel6.TabIndex = 4;
            metroLabel6.Text = "Password";
            metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroLabel6.UseStyleColors = true;
            // 
            // metroLabel7
            // 
            metroLabel7.AutoSize = true;
            metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            metroLabel7.Location = new Point(18, 101);
            metroLabel7.Name = "metroLabel7";
            metroLabel7.Size = new Size(54, 25);
            metroLabel7.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel7.TabIndex = 3;
            metroLabel7.Text = "Email";
            metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroLabel7.UseStyleColors = true;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1327, 600);
            ControlBox = false;
            Controls.Add(metroPanel2);
            Controls.Add(metroLabel4);
            Controls.Add(metroToggle1);
            Controls.Add(metroPanel1);
            Name = "UserForm";
            Resizable = false;
            Text = "UserForm";
            Theme = MetroFramework.MetroThemeStyle.Dark;
            Load += UserForm_Load;
            metroPanel1.ResumeLayout(false);
            metroPanel1.PerformLayout();
            metroPanel2.ResumeLayout(false);
            metroPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton Login;
        private TextBox password;
        private TextBox email;
        private MetroFramework.Controls.MetroToggle metroToggle1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private TextBox c_pass;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton NewAccount;
        private TextBox c_con_pass;
        private TextBox c_email;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
    }
}