using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;
using Server.Model;
namespace Client
{
    public partial class frmMain : Form
    {
        //init params
        IPEndPoint IP;
        Socket client;
        common common = new common();
        Messages ms = new Messages();


        public frmMain()
        {
            InitializeComponent();
            //tránh lỗi này "Cross-thread operation not valid: Control accessed from a thread other than the thread it was created on"
            //set method dưới để working

            CheckForIllegalCrossThreadCalls = false;

            ms.user = new User();

        }

        #region Hàm chức năng socket
        bool Connect()
        {


            IP = new IPEndPoint(IPAddress.Parse(txbIP.Text), Convert.ToInt32(txbPort.Text));
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);
                MessageBox.Show("Connect thành công");
            }
            catch
            {
                MessageBox.Show("Không kết nối được server");
                return false;
            }

            //tạo cái luồng để lắng nghe
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
            return true;
        }
        void Close()
        {
            client.Close();
        }

        void Send(string action)
        {
            ms.action = action;

            //add data
            ms.user.UserName = txbUsername.Text;
            ms.user.Password = txbPass.Text;
            ms.text = txbMessage.Text;
            ms.Uname = txbNameChat.Text;

            if (action == "upload")
            {
                string fileName = "";
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    openFileDialog.InitialDirectory = "";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string file in openFileDialog.FileNames)
                        {
                            fileName = Path.GetFileName(file);

                            ms.fileName = fileName;

                            //MessageBox.Show(ms.fileName);
                            ms.data = null;
                            ms.data = action == "upload" ? File.ReadAllBytes(file) : null;

                            //client.Send(common.Serialize(ms));
                            frmFileName frm = new frmFileName(client, ms);
                            frm.ShowDialog();
                            Thread.Sleep(1000);

                        }

                    }
                }

            }
            else if (action == "download")
            {
                string fileName = "";
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    openFileDialog.InitialDirectory = "";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string file in openFileDialog.FileNames)
                        {
                            fileName = Path.GetFileName(file);

                            ms.fileName = fileName;

                            //MessageBox.Show(ms.fileName);
                            ms.data = null;
                            ms.data = action == "download" ? null : File.ReadAllBytes(file);
                            client.Send(common.Serialize(ms));
                            
                            Thread.Sleep(1000);

                        }

                    }
                }
            }
            else 
            {
                client.Send(common.Serialize(ms));
            }

        }
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 1000];
                    client.Receive(data);

                    Messages _ms = new Messages();


                    _ms = (Messages)common.Deserialize(data);

                    switch (_ms.action)
                    {
                        case "login":
                            if (_ms.text == "success")
                            {
                                MessageBox.Show("Đăng nhập thành công!");
                                grbChat.Enabled = true;
                                grbUpload.Enabled = true;
                                btnLogin.Text = "Đăng xuất";

                                ms.user = _ms.user;
                            }
                            else if (_ms.text == "logged in")
                                MessageBox.Show("Bạn đã đăng nhập vào hệ thống rồi, vui lòng không đăng nhập lại !!!");
                            else
                                MessageBox.Show("Đăng nhập thất bại! Tài khoản " + _ms.user.UserName + " không tồn tại! ");

                            break;

                        case "register":
                            if (_ms.text == "success")
                                MessageBox.Show("Đăng ký tài khoản thành công!");
                            else if (_ms.text == "exited")
                                MessageBox.Show("Tài khoản đã tồn tại !");
                            else
                                MessageBox.Show("Đăng ký tài khoản thất bại !");
                            break;

                        case "change password":
                            if (_ms.text == "success")
                            {
                                grbUpload.Enabled = false;
                                grbChat.Enabled = false;
                                btnSend.Enabled = false;

                                MessageBox.Show("Đổi mật khẩu thành công!");
                                btnLogin.Text = "Đăng nhập";
                                btnJoin.Text = "Tham gia";
                            }
                            else if (_ms.text == "not existed")
                                MessageBox.Show("Tài khoản không tồn tại !");
                            else
                                MessageBox.Show("Đổi mật khẩu thất bại !");
                            break;

                        case "logout":
                            if (_ms.text == "success")
                            {
                                grbUpload.Enabled = false;
                                grbChat.Enabled = false;
                                btnLogin.Text = "Đăng nhập";
                            }
                            else
                                MessageBox.Show("Đã xảy ra lỗi, kiểm tra lại code trên server");
                            break;

                        case "join chat":
                            if (_ms.text == "success")
                            {
                                MessageBox.Show("Bạn đã tham gia chat all!");
                                btnSend.Enabled = true;

                                ms.user = new User();
                            }
                            else
                                MessageBox.Show("Tham gia chat all không thành công!");
                            break;

                        case "out chat":
                            if (_ms.text == "success")
                            {
                                MessageBox.Show("Bạn đã rời khỏi nhóm chat!");
                                btnSend.Enabled = false;
                            }
                            else
                                MessageBox.Show("Lỗi, xem lại code ở server!");
                            break;

                        case "chat":
                            string msg = _ms.Uname + ": " + _ms.text;
                            ShowMessage(msg, false);
                            break;

                        case "upload":
                            if (_ms.text == "success")
                                MessageBox.Show("file " + _ms.fileName + " upload thành công !");
                            else
                                MessageBox.Show("Kích thước file quá lớn !!!");
                            break;

                        case "download":
                            if (_ms.text == "success")
                            {
                                
                                File.WriteAllBytes(_ms.fileName, _ms.data);
                                MessageBox.Show("file " + _ms.fileName + " download thành công !");
                            }
                            else
                                MessageBox.Show("file không có trên server !");
                            break;

                        case "update info":
                            if (_ms.text == "success")
                            {
                                ms.user = _ms.user;
                                MessageBox.Show("Cập nhật thông tin thành công");
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật thông tin thất bại");
                            }
                            break;

                        default:
                            break;

                    }
                }
            }
            catch
            {
                Close();
            }
        }
        #endregion

        #region Hàm chức năng khác
        void ShowMessage(string s, bool b)
        {
            if (b)
            {
                ListViewItem ivi = new ListViewItem("");
                ivi.SubItems.Add(s);
                listViewMessage.Items.Add(ivi);
            }
            else
            {
                ListViewItem ivi = new ListViewItem(s);
                ivi.SubItems.Add("");
                listViewMessage.Items.Add(ivi);
            }
        }
        #endregion

        #region Hàm sự kiện
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txbMessage.Text != "")
            {
                Send("chat");
                ShowMessage(txbMessage.Text, true);
                txbMessage.Clear();
                txbMessage.Focus();
            }
            else
            {
                return;
            }

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (Connect())
                grbLogin.Enabled = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Đăng nhập")
            {
                Send("login");
            }
            else
            {
                listViewMessage.Clear();
                Send("logout");
            }

        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (btnJoin.Text == "Tham gia")
            {
                Send("join chat");
                btnJoin.Text = "Rời khỏi";
            }
            else
            {
                Send("out chat");
                btnJoin.Text = "Tham gia";
            }

        }

        private void txbUsername_TextChanged(object sender, EventArgs e)
        {
            txbNameChat.Text = txbUsername.Text;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Messages ms = new Messages();
            ms.action = "register";
            ms.user = new User();

            frmRegister frm = new frmRegister(client, ms);
            frm.Show();
        }


        private void btnChangePass_Click(object sender, EventArgs e)
        {

            ms.action = "change password";
            //ms.user = new User();
            //ms.user.UserName = txbUsername.Text;
            //ms.user.Password = txbPass.Text;

            frmChangePassword frm = new frmChangePassword(client, ms);
            frm.Show();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            Send("upload");
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Send("download");
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            ms.action = "update info";
            //ms.user = new User();
            //ms.user.UserName = txbUsername.Text;
            //ms.user.Password = txbPass.Text;

            frmProfile frm = new frmProfile(client, ms);
            frm.Show();
        }
        #endregion
    }
}
