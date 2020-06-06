using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class frmRegister : Form
    {
        common common = new common();
        Socket client;
        Messages ms = null;
        public frmRegister(Socket _client, Messages _ms)
        {
            InitializeComponent();
            client = _client;
            ms = _ms;
        }


        private bool valid()
        {
            if(txbUsername.Text == "" || txbPass.Text == "" || txbConfirm.Text == "")
            {
                MessageBox.Show("Tên đăng nhập, mật khẩu không được để trống !!");

                return false;
            }

            if(txbPass.Text != txbConfirm.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không chính xác");

                return false;
            }

            return true;

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                ms.user.UserName = txbUsername.Text;
                ms.user.Password = txbPass.Text;

                client.Send(common.Serialize(ms));

                this.Close();
            }
        }
    }
}
