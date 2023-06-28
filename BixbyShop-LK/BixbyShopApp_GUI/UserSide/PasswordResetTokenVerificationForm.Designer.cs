namespace BixbyShopApp_GUI.UserSide
{
    partial class PasswordResetTokenVerificationForm
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
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            metroLabel1 = new MetroFramework.Controls.MetroLabel();
            metroLabel2 = new MetroFramework.Controls.MetroLabel();
            metroLabel3 = new MetroFramework.Controls.MetroLabel();
            metroLabel4 = new MetroFramework.Controls.MetroLabel();
            metroButton1 = new MetroFramework.Controls.MetroButton();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(200, 147);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(350, 27);
            textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(200, 91);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(350, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(200, 205);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(514, 27);
            textBox3.TabIndex = 5;
            textBox3.UseSystemPasswordChar = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(200, 259);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(514, 27);
            textBox4.TabIndex = 4;
            textBox4.UseSystemPasswordChar = true;
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel1.Location = new Point(23, 205);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new Size(82, 25);
            metroLabel1.TabIndex = 6;
            metroLabel1.Text = "Password";
            // 
            // metroLabel2
            // 
            metroLabel2.AutoSize = true;
            metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel2.Location = new Point(23, 261);
            metroLabel2.Name = "metroLabel2";
            metroLabel2.Size = new Size(148, 25);
            metroLabel2.TabIndex = 7;
            metroLabel2.Text = "Confirm Password";
            // 
            // metroLabel3
            // 
            metroLabel3.AutoSize = true;
            metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel3.Location = new Point(23, 154);
            metroLabel3.Name = "metroLabel3";
            metroLabel3.Size = new Size(52, 25);
            metroLabel3.TabIndex = 8;
            metroLabel3.Text = "Code";
            // 
            // metroLabel4
            // 
            metroLabel4.AutoSize = true;
            metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel4.Location = new Point(23, 98);
            metroLabel4.Name = "metroLabel4";
            metroLabel4.Size = new Size(53, 25);
            metroLabel4.TabIndex = 9;
            metroLabel4.Text = "Email";
            // 
            // metroButton1
            // 
            metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            metroButton1.Highlight = true;
            metroButton1.Location = new Point(23, 306);
            metroButton1.Name = "metroButton1";
            metroButton1.Size = new Size(94, 29);
            metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            metroButton1.TabIndex = 10;
            metroButton1.Text = "Submit";
            metroButton1.UseSelectable = true;
            metroButton1.UseStyleColors = true;
            metroButton1.Click += metroButton1_Click;
            // 
            // PasswordResetTokenVerificationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 358);
            Controls.Add(metroButton1);
            Controls.Add(metroLabel4);
            Controls.Add(metroLabel3);
            Controls.Add(metroLabel2);
            Controls.Add(metroLabel1);
            Controls.Add(textBox3);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "PasswordResetTokenVerificationForm";
            Text = "PasswordResetTokenVerificationForm";
            Load += PasswordResetTokenVerificationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}