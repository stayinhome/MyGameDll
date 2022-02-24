using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace MyGameDll.Controller
{
    public abstract class AbstractController
    {
        public Socket _ServerSocket = null;

        public AbstractController(Socket ServerSocket)
        {
            this._ServerSocket = ServerSocket;
        }

        public abstract void SendData();


        public abstract void ReceiveData(object data);

    }
}
