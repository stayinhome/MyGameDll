using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TcpModel;

namespace MyGameDll.Interface
{
    public interface IBaseController
    {
        void SendData();


        void ReceiveData(object data);

    }
}
