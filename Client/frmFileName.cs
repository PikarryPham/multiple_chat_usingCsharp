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
    public partial class frmFileName : Form
    {
        common common = new common();
        Socket client;
        Messages ms = null;
        string tail = ""; //định dạng file
        public frmFileName(Socket _client, Messages _ms)
        {
            InitializeComponent();
            client = _client;
            ms = _ms;
            txbFileName.Text = ms.fileName;
            tail = ms.fileName.Split('.')[1];
        }
        private bool valid()
        {
            string[] liststr;
            liststr = txbFileName.Text.Split('.');
            if(txbFileName.Text == "")
            {
                MessageBox.Show("Tên file không được để trống !!!");
                return false;
            }
            if(liststr[1] != tail)
            {
                MessageBox.Show("Định dạng file không chính xác !!!");
                return false;
            }
            return true;
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                ms.fileName = txbFileName.Text;
                client.Send(common.Serialize(ms));
                this.Close();
            }
            else
                return;
        }
    }
}
