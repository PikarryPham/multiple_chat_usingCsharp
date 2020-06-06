using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server.Model;
namespace Server
{
    class Program
    {

        ChatSocketDbContext db = new ChatSocketDbContext();

        common common = new common();

        IPEndPoint IP;
        Socket server;
        List<Socket> list_client = new List<Socket>();  //danh sách các client đã connect
        List<Socket> list_client_login = new List<Socket>();    // danh sách các client đã login <= đã connect
        List<Socket> list_client_chat = new List<Socket>();     // danh sách các client đã join chat <= đã login

        #region Hàm socket của server
        //init server
        void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);

            Thread listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        list_client.Add(client);

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }

        void Send(Socket client, Messages ms)
        {
            if (client != null)
                client.Send(common.Serialize(ms));
        }

        void Receive(object obj)
        {
            Socket client = obj as Socket;

            try
            {
                Messages ms = new Messages();
                User temp = null;

                while (true)
                {
                    byte[] data = new byte[common.buffer];
                    int rec = client.Receive(data);

                    ms = (Messages)common.Deserialize(data);

                    switch (ms.action)
                    {
                        case "login":
                            temp = db.Users.Where(e => e.UserName == ms.user.UserName && e.Password == ms.user.Password).SingleOrDefault();
                            if (temp != null)
                            {
                                if (!list_client_login.Contains(client))
                                {
                                    list_client_login.Add(client);

                                    Console.WriteLine((ms.Uname == "" ? ms.user.UserName : ms.Uname) + " dang nhap thanh cong");

                                    //thay đổi trang thái thành công và gửi lại client thông báo
                                    ms.text = "success";
                                    ms.user = temp;
                                    Send(client, ms);
                                }
                                else
                                {
                                    ms.text = "logged in";
                                    Send(client, ms);
                                }

                            }
                            else
                            {
                                Console.WriteLine("dang nhap that bai !;  Tai khoan" + ms.user.UserName + " khong ton tai !");

                                //thay đổi trang thái thất bại và gửi lại client thông báo
                                ms.text = "failure";
                                Send(client, ms);
                            }
                            break;

                        case "register":
                            temp = db.Users.Where(e => e.UserName == ms.user.UserName).SingleOrDefault();
                            if (temp == null)
                            {
                                try
                                {
                                    ms.user.Name = "";
                                    ms.user.Note = "";
                                    ms.user.DayOfBirth = DateTime.Now.Date;
                                    db.Users.Add(ms.user);
                                    db.SaveChanges();

                                    Console.WriteLine("Tai khoan moi duoc dang ky: " + ms.user.UserName);

                                    //thay đổi trang thái thành công và gửi lại client thông báo
                                    ms.text = "success";
                                    Send(client, ms);
                                }
                                catch
                                {
                                    //thay đổi trang thái thất bại và gửi lại client thông báo
                                    ms.text = "failure";
                                    Send(client, ms);
                                }

                            }
                            else
                            {
                                //thay đổi trang thái tồn tại và gửi lại client thông báo
                                ms.text = "existed";
                                Send(client, ms);
                            }
                            break;

                        case "change password":
                            temp = db.Users.Where(e => e.UserName == ms.user.UserName).SingleOrDefault();
                            if (temp != null)
                            {
                                try
                                {
                                    temp.Password = ms.user.Password;
                                    db.SaveChanges();

                                    Console.WriteLine("Tai khoan: " + ms.user.UserName + " doi mat khau thanh cong");
                                    Console.WriteLine("=> tu dong dang xuat !!");

                                    //xóa khỏi list chat
                                    if (list_client_chat.Contains(client))
                                        list_client_chat.Remove(client);

                                    //xóa khỏi list login
                                    if (list_client_login.Contains(client))
                                        list_client_login.Remove(client);

                                    //thay đổi trang thái thất bại và gửi lại client thông báo
                                    ms.text = "success";
                                    Send(client, ms);
                                }
                                catch
                                {
                                    Console.WriteLine("Tai khoan: " + ms.user.UserName + " doi mat khau khong thanh cong");

                                    //thay đổi trang thái thất bại và gửi lại client thông báo
                                    ms.text = "failure";
                                    Send(client, ms);
                                }

                            }
                            else
                            {
                                Console.WriteLine("Tai khoan: " + ms.user.UserName + " Khong ton tai");

                                //thay đổi trang thái không tồn tại và gửi lại client thông báo
                                ms.text = "not exited";
                                Send(client, ms);
                            }
                            break;

                        case "logout":
                            try
                            {
                                //xóa khỏi list chat
                                if (list_client_chat.Contains(client))
                                    list_client_chat.Remove(client);

                                //xóa khỏi list login
                                if (list_client_login.Contains(client))
                                    list_client_login.Remove(client);

                                Console.WriteLine("Tai khoan: " + ms.user.UserName + " da dang xuat!");

                                //thay đổi trang thái thất bại và gửi lại client thông báo
                                ms.text = "success";
                                Send(client, ms);
                            }
                            catch
                            {
                                //thay đổi trang thái thất bại và gửi lại client thông báo
                                ms.text = "failure";
                                Send(client, ms);
                            }
                            break;

                        case "join chat":
                            if (!list_client_chat.Contains(client) && list_client_login.Contains(client))
                            {
                                list_client_chat.Add(client);
                                Console.WriteLine(ms.user.UserName + " da tham gia chat voi ten la: " + ms.Uname);

                                //thay đổi trang thái thành công và gửi lại client thông báo
                                ms.text = "success";
                                Send(client, ms);
                            }
                            else
                            {
                                //thay đổi trang thái thất bại và gửi lại client thông báo
                                ms.text = "failure";
                                Send(client, ms);
                            }
                            break;

                        case "out chat":
                            try
                            {
                                if (list_client_chat.Contains(client) && list_client_login.Contains(client))
                                {
                                    list_client_chat.Remove(client);

                                    Console.WriteLine(ms.user.UserName + " da thoat nhom chat");

                                    //thay đổi trang thái thành công và gửi lại client thông báo
                                    ms.text = "success";
                                    Send(client, ms);
                                }
                            }
                            catch
                            {
                                //thay đổi trang thái thất bại và gửi lại client thông báo
                                ms.text = "failure";
                                Send(client, ms);
                            }
                            break;

                        case "chat":
                            foreach (Socket item in list_client_chat)
                            {
                                if (item != null && item != client)
                                    Send(item, ms);
                            }
                            break;
                        case "upload":
                            try
                            {
                                File.WriteAllBytes(ms.fileName, ms.data);
                                Console.WriteLine(ms.user.UserName + " da upload file: " + ms.fileName);

                                //thay đổi trang thái thất bại và gửi lại client thông báo
                                ms.text = "success";
                                ms.data = null;
                                Send(client, ms);
                            }
                            catch
                            {
                                Console.WriteLine(ms.fileName + " co kich thuoc qua lon !!");

                                //thay đổi trang thái thất bại và gửi lại client thông báo
                                ms.text = "failure";
                                ms.data = null;
                                Send(client, ms);
                            }
                            break;

                        case "download":
                            try
                            {
                                ms.data = File.ReadAllBytes(ms.fileName);

                                //thay đổi trang thái thất bại và gửi lại client thông báo
                                ms.text = "success";
                                Send(client, ms);
                            }
                            catch
                            {
                                Console.WriteLine(ms.fileName + " File khong ton tai tren server !!");

                                //thay đổi trang thái thất bại và gửi lại client thông báo
                                ms.text = "failure";
                                ms.data = null;
                                Send(client, ms);
                            }
                            break;

                        case "update info":
                            temp = db.Users.Where(e => e.UserName == ms.user.UserName).SingleOrDefault();
                            if (temp != null)
                            {
                                try
                                {
                                    temp.Name = ms.user.Name;
                                    temp.Note = ms.user.Note;
                                    temp.DayOfBirth = ms.user.DayOfBirth;
                                    db.SaveChanges();

                                    Console.WriteLine("Tai khoan: " + ms.user.UserName + " cap nhat thong tin thanh cong");


                                    //thay đổi trang thái thành công và gửi lại client thông báo
                                    ms.text = "success";
                                    ms.user = temp;
                                    Send(client, ms);
                                }
                                catch
                                {
                                    Console.WriteLine("Tai khoan: " + ms.user.UserName + " cap nhat thong tin khong thanh cong");

                                    //thay đổi trang thái thất bại và gửi lại client thông báo
                                    ms.text = "failure";
                                    Send(client, ms);
                                }

                            }
                            else
                            {
                                Console.WriteLine("Tai khoan: " + ms.user.UserName + " Khong ton tai");

                                //thay đổi trang thái không tồn tại và gửi lại client thông báo
                                ms.text = "not existed";
                                Send(client, ms);
                            }
                            break;

                        default:
                            break;
                    }

                }
            }
            catch
            {
                Console.WriteLine("da xay ra loi khi nhan data tu client, dong ket noi client");
                list_client.Remove(client);
                list_client_login.Remove(client);
                list_client_chat.Remove(client);
                client.Close();
            }
        }


        void Close()
        {
            server.Close();
        }
        #endregion

        #region linh tinh
        void abc()
        {
            User a = db.Users.Where(e => e.UserName == "hhuhu" && e.Password == "ddd").SingleOrDefault();
        }
        #endregion

        static void Main(string[] args)
        {

            Program server = new Program();

            //vớ vẩn
            server.abc();

            //main
            server.Connect();
            Console.WriteLine("server is listening on 127.0.0.1 and port 9999");
            Console.WriteLine("server is running... ");
            Console.ReadKey();
            server.Close();
        }
    }
}
