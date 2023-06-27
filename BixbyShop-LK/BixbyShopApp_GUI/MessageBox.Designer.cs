namespace BixbyShopApp_GUI
{
    partial class CustomMessageBox
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
            metroTile1 = new MetroFramework.Controls.MetroTile();
            metroButton1 = new MetroFramework.Controls.MetroButton();
            SuspendLayout();
            // 
            // metroTile1
            // 
            metroTile1.ActiveControl = null;
            metroTile1.Location = new Point(36, 73);
            metroTile1.Name = "metroTile1";
            metroTile1.Size = new Size(967, 117);
            metroTile1.Style = MetroFramework.MetroColorStyle.Blue;
            metroTile1.TabIndex = 0;
            metroTile1.TextAlign = ContentAlignment.MiddleCenter;
            metroTile1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroTile1.UseSelectable = true;
            // 
            // metroButton1
            // 
            metroButton1.Highlight = true;
            metroButton1.Location = new Point(36, 225);
            metroButton1.Name = "metroButton1";
            metroButton1.Size = new Size(163, 29);
            metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            metroButton1.TabIndex = 1;
            metroButton1.Text = "Copy";
            metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroButton1.UseSelectable = true;
            metroButton1.UseStyleColors = true;
            metroButton1.Click += metroButton1_Click;
            // 
            // CustomMessageBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            ClientSize = new Size(1044, 277);
            ControlBox = false;
            Controls.Add(metroButton1);
            Controls.Add(metroTile1);
            Name = "CustomMessageBox";
            Resizable = false;
            Text = "MessageBox";
            Theme = MetroFramework.MetroThemeStyle.Dark;
            Load += MessageBox_Load;
            ResumeLayout(false);
        }

        #endregion

        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}