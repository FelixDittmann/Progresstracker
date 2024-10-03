using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progresstracker.Netzwerk
{
    internal interface ISocket : IDisposable
    {
        bool IsConnected { get; }
        public void Connect(string adress, int port);
        public void Disconnect(string portId);

    }
}
