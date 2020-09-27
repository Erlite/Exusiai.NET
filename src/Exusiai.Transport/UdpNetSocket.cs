using System.Net;

namespace Exusiai.Transport
{
    public class UdpNetSocket : NetSocket
    {
        public override void Dispose()
        {
            if (IsOpen())
            {
                Close();
            }
        }

        public override void BindSocket(EndPoint endpoint)
        {
            throw new System.NotImplementedException();
        }

        public override void Close()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsOpen()
        {
            throw new System.NotImplementedException();
        }

        public override EndPoint GetLocalEndpoint()
        {
            throw new System.NotImplementedException();
        }

        public override bool EnqueueOutgoingPacket(NetPacket packet)
        {
            throw new System.NotImplementedException();
        }

        public override bool TryDequeueIncomingPacket(out NetPacket packet)
        {
            throw new System.NotImplementedException();
        }

        public override bool Send(NetPacket packet)
        {
            throw new System.NotImplementedException();
        }

        public override int Receive(out NetPacket packet)
        {
            throw new System.NotImplementedException();
        }
    }
}