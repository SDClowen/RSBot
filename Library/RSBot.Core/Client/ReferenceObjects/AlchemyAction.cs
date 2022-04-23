using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.Core.Client.ReferenceObjects
{
    public enum AlchemyAction : byte
    {
        Cancel = 1,
        Fuse = 2,
        SocketCreate = 3, //for Socket
        SocketRemove = 4, //for Socket
    }

}
