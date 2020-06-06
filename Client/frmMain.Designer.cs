namespace Client
{
    partial class frmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grbLogin = new System.Windows.Forms.GroupBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbUpload = new System.Windows.Forms.GroupBox();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.grbChat = new System.Windows.Forms.GroupBox();
            this.listViewMessage = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnJoin = new System.Windows.Forms.Button();
            this.txbNameChat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txbMessage = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.grbLogin.SuspendLayout();
            this.grbUpload.SuspendLayout();
            this.grbChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbPort);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txbIP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(652, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết nối";
            // 
            // txbPort
            // 
            this.txbPort.Location = new System.Drawing.Point(245, 30);
            this.txbPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(140, 22);
            this.txbPort.TabIndex = 11;
            this.txbPort.Text = "9999";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Port:";
            // 
            // txbIP
            // 
            this.txbIP.Location = new System.Drawing.Point(45, 30);
            this.txbIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(140, 22);
            this.txbIP.TabIndex = 9;
            this.txbIP.Text = "127.0.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "IP:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(505, 17);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(1);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(141, 48);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grbLogin
            // 
            this.grbLogin.Controls.Add(this.btnRegister);
            this.grbLogin.Controls.Add(this.btnLogin);
            this.grbLogin.Controls.Add(this.txbPass);
            this.grbLogin.Controls.Add(this.txbUsername);
            this.grbLogin.Controls.Add(this.label2);
            this.grbLogin.Controls.Add(this.label1);
            this.grbLogin.Enabled = false;
            this.grbLogin.Location = new System.Drawing.Point(16, 92);
            this.grbLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbLogin.Name = "grbLogin";
            this.grbLogin.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbLogin.Size = new System.Drawing.Size(652, 123);
            this.grbLogin.TabIndex = 1;
            this.grbLogin.TabStop = false;
            this.grbLogin.Text = "Đăng nhập";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(449, 64);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(1);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(141, 42);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(449, 21);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(1);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(141, 42);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txbPass
            // 
            this.txbPass.Location = new System.Drawing.Point(132, 74);
            this.txbPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbPass.Name = "txbPass";
            this.txbPass.Size = new System.Drawing.Size(253, 22);
            this.txbPass.TabIndex = 3;
            this.txbPass.UseSystemPasswordChar = true;
            // 
            // txbUsername
            // 
            this.txbUsername.Location = new System.Drawing.Point(132, 30);
            this.txbUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(253, 22);
            this.txbUsername.TabIndex = 2;
            this.txbUsername.TextChanged += new System.EventHandler(this.txbUsername_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập: ";
            // 
            // grbUpload
            // 
            this.grbUpload.Controls.Add(this.btnInfo);
            this.grbUpload.Controls.Add(this.btnChangePass);
            this.grbUpload.Controls.Add(this.btnDownload);
            this.grbUpload.Controls.Add(this.btnUpload);
            this.grbUpload.Enabled = false;
            this.grbUpload.Location = new System.Drawing.Point(16, 223);
            this.grbUpload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbUpload.Name = "grbUpload";
            this.grbUpload.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbUpload.Size = new System.Drawing.Size(652, 81);
            this.grbUpload.TabIndex = 2;
            this.grbUpload.TabStop = false;
            this.grbUpload.Text = "Upload / Download";
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(447, 21);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(1);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(141, 42);
            this.btnInfo.TabIndex = 13;
            this.btnInfo.Text = "Thông tin cá nhân";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Location = new System.Drawing.Point(303, 21);
            this.btnChangePass.Margin = new System.Windows.Forms.Padding(1);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(141, 42);
            this.btnChangePass.TabIndex = 12;
            this.btnChangePass.Text = "Đổi mật khẩu";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(159, 21);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(1);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(141, 42);
            this.btnDownload.TabIndex = 11;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(12, 21);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(1);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(141, 42);
            this.btnUpload.TabIndex = 10;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // grbChat
            // 
            this.grbChat.Controls.Add(this.listViewMessage);
            this.grbChat.Controls.Add(this.btnJoin);
            this.grbChat.Controls.Add(this.txbNameChat);
            this.grbChat.Controls.Add(this.label3);
            this.grbChat.Controls.Add(this.btnSend);
            this.grbChat.Controls.Add(this.txbMessage);
            this.grbChat.Enabled = false;
            this.grbChat.Location = new System.Drawing.Point(16, 311);
            this.grbChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbChat.Name = "grbChat";
            this.grbChat.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbChat.Size = new System.Drawing.Size(652, 471);
            this.grbChat.TabIndex = 3;
            this.grbChat.TabStop = false;
            this.grbChat.Text = "Chat";
            // 
            // listViewMessage
            // 
            this.listViewMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewMessage.HideSelection = false;
            this.listViewMessage.Location = new System.Drawing.Point(8, 62);
            this.listViewMessage.Margin = new System.Windows.Forms.Padding(1);
            this.listViewMessage.Name = "listViewMessage";
            this.listViewMessage.Size = new System.Drawing.Size(639, 351);
            this.listViewMessage.TabIndex = 13;
            this.listViewMessage.UseCompatibleStateImageBehavior = false;
            this.listViewMessage.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 235;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 240;
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(507, 17);
            this.btnJoin.Margin = new System.Windows.Forms.Padding(1);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(141, 42);
            this.btnJoin.TabIndex = 12;
            this.btnJoin.Text = "Tham gia";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // txbNameChat
            // 
            this.txbNameChat.Location = new System.Drawing.Point(45, 27);
            this.txbNameChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbNameChat.Name = "txbNameChat";
            this.txbNameChat.Size = new System.Drawing.Size(253, 22);
            this.txbNameChat.TabIndex = 8;
            this.txbNameChat.Text = "trang pham";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tên: ";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(507, 418);
            this.btnSend.Margin = new System.Windows.Forms.Padding(1);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(141, 48);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txbMessage
            // 
            this.txbMessage.Location = new System.Drawing.Point(8, 418);
            this.txbMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbMessage.Multiline = true;
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.Size = new System.Drawing.Size(492, 47);
            this.txbMessage.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 798);
            this.Controls.Add(this.grbChat);
            this.Controls.Add(this.grbUpload);
            this.Controls.Add(this.grbLogin);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbLogin.ResumeLayout(false);
            this.grbLogin.PerformLayout();
            this.grbUpload.ResumeLayout(false);
            this.grbChat.ResumeLayout(false);
            this.grbChat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grbLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txbPass;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbUpload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.GroupBox grbChat;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.TextBox txbNameChat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txbMessage;
        private System.Windows.Forms.ListView listViewMessage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInfo;
    }
}

