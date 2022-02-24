using MyGameDll.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TcpModel;

namespace MyGameDll.Controller
{
    public class ControllerManager
    {
        private static ControllerManager _instance = null;

        public static ControllerManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ControllerManager();
                }

                return _instance;
            }
        }

        private ControllerManager()
        {
            ControllerDic.Add(RequestTypeEnum.LoginReques, new LoginController());


        }

        private Dictionary<RequestTypeEnum, IBaseController> ControllerDic = new Dictionary<RequestTypeEnum, IBaseController>();

        public void HandleService(Socket ServerSocket, object data)
        {
            try
            {
                RequestResultDto tcpDataDto = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestResultDto>(data.ToString());
                RequestTypeEnum type = tcpDataDto.RequestType;
                if (ControllerDic.ContainsKey(type))
                {
                    ControllerDic[type].ReceiveData(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


    }
}
