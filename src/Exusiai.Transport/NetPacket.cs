using System.Net;

namespace Exusiai.Transport
{
    public struct NetPacket
    {
        /// <summary>
        /// The remote endpoint this packet comes from or is going to be sent to.
        /// </summary>
        public EndPoint RemoteEndpoint;

        /// <summary>
        /// The packet's payload to be sent.
        /// </summary>
        public byte[] Payload;
    }
}