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
            Login = new MetroFramework.Controls.MetroButton();
            password_txt = new TextBox();
            metroLabel2 = new MetroFramework.Controls.MetroLabel();
            email_txt = new TextBox();
            metroLabel1 = new MetroFramework.Controls.MetroLabel();
            UserLogin = new MetroFramework.Controls.MetroLabel();
            metroPanel2 = new MetroFramework.Controls.MetroPanel();
            CreateAccount = new MetroFramework.Controls.MetroButton();
            sign_up_con_pass = new TextBox();
            metroLabel6 = new MetroFramework.Controls.MetroLabel();
            sign_up_pass = new TextBox();
            metroLabel3 = new MetroFramework.Controls.MetroLabel();
            sign_up_email = new TextBox();
            metroLabel4 = new MetroFramework.Controls.MetroLabel();
            metroLabel5 = new MetroFramework.Controls.MetroLabel();
            metroPanel1.SuspendLayout();
            metroPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // metroPanel1
            // 
            metroPanel1.Controls.Add(Login);
            metroPanel1.Controls.Add(password_txt);
            metroPanel1.Controls.Add(metroLabel2);
            metroPanel1.Controls.Add(email_txt);
            metroPanel1.Controls.Add(metroLabel1);
            metroPanel1.Controls.Add(UserLogin);
            metroPanel1.HorizontalScrollbarBarColor = true;
            metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            metroPanel1.HorizontalScrollbarSize = 10;
            metroPanel1.Location = new Point(23, 74);
            metroPanel1.Name = "metroPanel1";
            metroPanel1.Size = new Size(531, 372);
            metroPanel1.TabIndex = 0;
            metroPanel1.VerticalScrollbarBarColor = true;
            metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            metroPanel1.VerticalScrollbarSize = 10;
            // 
            // Login
            // 
            Login.Location = new Point(16, 272);
            Login.Name = "Login";
            Login.Size = new Size(170, 39);
            Login.TabIndex = 7;
            Login.Text = "Login";
            Login.UseSelectable = true;
            Login.Click += Login_Click;
            // 
            // password_txt
            // 
            password_txt.Location = new Point(16, 208);
            password_txt.Name = "password_txt";
            password_txt.Size = new Size(479, 27);
            password_txt.TabIndex = 6;
            password_txt.UseSystemPasswordChar = true;
            // 
            // metroLabel2
            // 
            metroLabel2.AutoSize = true;
            metroLabel2.Location = new Point(16, 161);
            metroLabel2.Name = "metroLabel2";
            metroLabel2.Size = new Size(66, 20);
            metroLabel2.TabIndex = 5;
            metroLabel2.Text = "Password";
            // 
            // email_txt
            // 
            email_txt.Location = new Point(16, 118);
            email_txt.Name = "email_txt";
            email_txt.Size = new Size(479, 27);
            email_txt.TabIndex = 4;
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.Location = new Point(16, 83);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new Size(42, 20);
            metroLabel1.TabIndex = 3;
            metroLabel1.Text = "Email";
            // 
            // UserLogin
            // 
            UserLogin.AutoSize = true;
            UserLogin.FontSize = MetroFramework.MetroLabelSize.Tall;
            UserLogin.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            UserLogin.Location = new Point(16, 17);
            UserLogin.Name = "UserLogin";
            UserLogin.Size = new Size(102, 25);
            UserLogin.TabIndex = 2;
            UserLogin.Text = "User Login";
            // 
            // metroPanel2
            // 
            metroPanel2.Controls.Add(CreateAccount);
            metroPanel2.Controls.Add(sign_up_con_pass);
            metroPanel2.Controls.Add(metroLabel6);
            metroPanel2.Controls.Add(sign_up_pass);
            metroPanel2.Controls.Add(metroLabel3);
            metroPanel2.Controls.Add(sign_up_email);
            metroPanel2.Controls.Add(metroLabel4);
            metroPanel2.Controls.Add(metroLabel5);
            metroPanel2.HorizontalScrollbarBarColor = true;
            metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            metroPanel2.HorizontalScrollbarSize = 10;
            metroPanel2.Location = new Point(635, 74);
            metroPanel2.Name = "metroPanel2";
            metroPanel2.Size = new Size(715, 399);
            metroPanel2.TabIndex = 1;
            metroPanel2.VerticalScrollbarBarColor = true;
            metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            metroPanel2.VerticalScrollbarSize = 10;
            // 
            // CreateAccount
            // 
            CreateAccount.Location = new Point(35, 342);
            CreateAccount.Name = "CreateAccount";
            CreateAccount.Size = new Size(170, 39);
            CreateAccount.TabIndex = 8;
            CreateAccount.Text = "Create New Account";
            CreateAccount.UseSelectable = true;
            CreateAccount.Click += CreateAccount_Click;
            // 
            // sign_up_con_pass
            // 
            sign_up_con_pass.Location = new Point(19, 284);
            sign_up_con_pass.Name = "sign_up_con_pass";
            sign_up_con_pass.Size = new Size(479, 27);
            sign_up_con_pass.TabIndex = 14;
            sign_up_con_pass.UseSystemPasswordChar = true;
            // 
            // metroLabel6
            // 
            metroLabel6.AutoSize = true;
            metroLabel6.Location = new Point(19, 241);
            metroLabel6.Name = "metroLabel6";
            metroLabel6.Size = new Size(119, 20);
            metroLabel6.TabIndex = 13;
            metroLabel6.Text = "Confirm Password";
            // 
            // sign_up_pass
            // 
            sign_up_pass.Location = new Point(19, 193);
            sign_up_pass.Name = "sign_up_pass";
            sign_up_pass.Size = new Size(479, 27);
            sign_up_pass.TabIndex = 12;
            sign_up_pass.UseSystemPasswordChar = true;
            // 
            // metroLabel3
            // 
            metroLabel3.AutoSize = true;
            metroLabel3.Location = new Point(19, 150);
            metroLabel3.Name = "metroLabel3";
            metroLabel3.Size = new Size(66, 20);
            metroLabel3.TabIndex = 11;
            metroLabel3.Text = "Password";
            // 
            // sign_up_email
            // 
            sign_up_email.Location = new Point(19, 103);
            sign_up_email.Name = "sign_up_email";
            sign_up_email.Size = new Size(479, 27);
            sign_up_email.TabIndex = 10;
            // 
            // metroLabel4
            // 
            metroLabel4.AutoSize = true;
            metroLabel4.Location = new Point(19, 67);
            metroLabel4.Name = "metroLabel4";
            metroLabel4.Size = new Size(42, 20);
            metroLabel4.TabIndex = 9;
            metroLabel4.Text = "Email";
            // 
            // metroLabel5
            // 
            metroLabel5.AutoSize = true;
            metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            metroLabel5.Location = new Point(19, 17);
            metroLabel5.Name = "metroLabel5";
            metroLabel5.Size = new Size(186, 25);
            metroLabel5.TabIndex = 8;
            metroLabel5.Text = "Create New Account";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1373, 517);
            Controls.Add(metroPanel2);
            Controls.Add(metroPanel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserForm";
            Text = "UserForm";
            TransparencyKey = Color.Empty;
            Load += Form1_Load;
            metroPanel1.ResumeLayout(false);
            metroPanel1.PerformLayout();
            metroPanel2.ResumeLayout(false);
            metroPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel UserLogin;
        private TextBox email_txt;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private TextBox password_txt;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton Login;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private TextBox sign_up_con_pass;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private TextBox sign_up_pass;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private TextBox sign_up_email;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton CreateAccount;
    }
}