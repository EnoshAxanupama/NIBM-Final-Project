using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BixbyShopApp_GUI
{
    public partial class DashBoard : Form
    {
        private void tokenSever(String token)
        {
            try
            {
                Properties.Settings.Default.TokenValue = token;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {

            }
        }
        private readonly String token;
        public DashBoard(String token)
        {
            InitializeComponent();
            this.token = token;
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tokenSever(null);
        }
    }
}
