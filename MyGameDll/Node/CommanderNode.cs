
using MyGameDll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGameDll.Node
{
    class CommanderNode : AbstractNode
    {
        void Start()
        {
            NodeType = NodeEnum.Commander;
        }
    }
}
