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
    public partial class frmProfile : Form
    {
        common common = new common();
        Socket client;
        Messages ms = null;
        public frmProfile(Socket _client, Messages _ms)
        {
            InitializeComponent();
            
            client = _client;
            ms = _ms;
            Init();
        }

        private void Init()
        {
            txbName.Text = ms.user.Name;
            dtpDayOfBirth.Value = ms.user.DayOfBirth != null ? (DateTime)ms.user.DayOfBirth : DateTime.Now;
            txbNote.Text = ms.user.Note;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ms.user.Name = txbName.Text;
            ms.user.Note = txbNote.Text;
            ms.user.DayOfBirth = dtpDayOfBirth.Value;

            client.Send(common.Serialize(ms));

            this.Close();
        }
    }
}
