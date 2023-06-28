namespace BixbyShopApp_GUI.UserSide
{
    partial class EmailVerificationForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            metroLabel1 = new MetroFramework.Controls.MetroLabel();
            metroLabel2 = new MetroFramework.Controls.MetroLabel();
            metroButton1 = new MetroFramework.Controls.MetroButton();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(159, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(350, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(159, 142);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(350, 27);
            textBox2.TabIndex = 1;
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel1.Location = new Point(23, 86);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new Size(67, 25);
            metroLabel1.TabIndex = 2;
            metroLabel1.Text = "Email : ";
            // 
            // metroLabel2
            // 
            metroLabel2.AutoSize = true;
            metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel2.Location = new Point(23, 142);
            metroLabel2.Name = "metroLabel2";
            metroLabel2.Size = new Size(66, 25);
            metroLabel2.TabIndex = 3;
            metroLabel2.Text = "Code : ";
            // 
            // metroButton1
            // 
            metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            metroButton1.Highlight = true;
            metroButton1.Location = new Point(23, 194);
            metroButton1.Name = "metroButton1";
            metroButton1.Size = new Size(94, 29);
            metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            metroButton1.TabIndex = 4;
            metroButton1.Text = "Submit";
            metroButton1.UseSelectable = true;
            metroButton1.UseStyleColors = true;
            metroButton1.Click += metroButton1_Click;
            // 
            // EmailVerificationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            ClientSize = new Size(920, 246);
            Controls.Add(metroButton1);
            Controls.Add(metroLabel2);
            Controls.Add(metroLabel1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "EmailVerificationForm";
            Resizable = false;
            Text = "EmailVerificationForm";
            Load += EmailVerificationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}