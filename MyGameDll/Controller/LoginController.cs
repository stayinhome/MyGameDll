using MyGameDll.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TcpModel;

namespace MyGameDll.Controller
{
    public class LoginController : AbstractController
    {
        private string UserName = "admin";

        private string PassWorld = "1234";

        public LoginController(Socket ServerSocket) :base(ServerSocket)
        {
            
        }

        public override void ReceiveData(object data)
        {
            throw new NotImplementedException();
        }


        public override void SendData()
        {
            throw new NotImplementedException();
        }
    }
}