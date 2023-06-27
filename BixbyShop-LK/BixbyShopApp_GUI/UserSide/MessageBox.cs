using Serilog.Parsing;
using System;
namespace BixbyShopApp_GUI
{
    public partial class CustomMessageBox : MetroFramework.Forms.MetroForm
    {
        private string token;
        public CustomMessageBox(string token)
        {
            this.token = token;
            InitializeComponent();
            metroTile1.Text = token;
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(metroTile1.Text);
            MessageBox.Show("Copied!", "Copy Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
