using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class frmChangePassword : Form
    {

        common common = new common();
        Socket client;
        Messages ms = null;

        public frmChangePassword(Socket _client, Messages _ms)
        {
            InitializeComponent();
            client = _client;
            ms = _ms;
        }

        private bool valid()
        {
            if (txbOldPass.Text == "" || txbNewPass.Text == "" || txbConfirm.Text == "")
            {
                MessageBox.Show("Mật khẩu không được để trống !!");

                return false;
            }

            if(txbOldPass.Text != ms.user.Password)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác");

                return false;
            }

            if (txbNewPass.Text != txbConfirm.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không chính xác");

                return false;
            }

            return true;

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                ms.user.Password = txbNewPass.Text;

                client.Send(common.Serialize(ms));

                this.Close();
            }
        }
    }
}
