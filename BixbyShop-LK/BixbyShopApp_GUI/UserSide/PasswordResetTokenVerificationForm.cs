﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BixbyShopApp_GUI.UserSide
{
    public partial class PasswordResetTokenVerificationForm : MetroFramework.Forms.MetroForm
    {
        public PasswordResetTokenVerificationForm()
        {
            InitializeComponent();
        }

        private void PasswordResetTokenVerificationForm_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            String email = textBox1.Text;
            String code = textBox2.Text;
            String password = textBox3.Text;
            String con_password = textBox4.Text;
        }
    }
}
