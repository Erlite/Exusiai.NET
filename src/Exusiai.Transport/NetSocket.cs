using System;
using System.Net;

namespace Exusiai.Transport
{
    /// <summary>
    /// Base class for sockets to be used as transport.
    /// The socket will be injected as an internal service by the service provider, and won't be accessible publicly. 
    /// </summary>
    public abstract class NetSocket : IDisposable
    {
        /// <summary>
        /// Dispose of the socket, closing it and releasing any unmanaged resource if required.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Binds the socket to an endpoint and opens it.
        /// </summary>
        /// <param name="endpoint"> The endpoint to bind the socket to. </param>
        /// <remarks> If the endpoint's port is zero, the method should automatically use an open port. </remarks>
        public abstract void BindSocket(EndPoint endpoint);

        /// <summary>
        /// Close the socket.
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// Whether or not the socket is currently bound to an endpoint.
        /// </summary>
        public abstract bool IsOpen();

        /// <summary>
        /// Returns the local endpoint (or null if not bound).
        /// </summary>
        public abstract EndPoint GetLocalEndpoint();
        
        /// <summary>
        /// Enqueue a packet to be sent by this socket.
        /// </summary>
        /// <remarks> Assumed to be thread safe. </remarks>
        /// <param name="packet"> The packet to send. </param>
        /// <returns> True if enqueued successfully. </returns>
        public abstract bool EnqueueOutgoingPacket(NetPacket packet); 

        /// <summary>
        /// Try to dequeue a packet that was received.
        /// </summary>
        /// <remarks> Assumed to be thread safe. </remarks>
        /// <param name="packet"> The packet that was received. </param>
        /// <returns> True if a packet dequeued, false if not. </returns>
        public abstract bool TryDequeueIncomingPacket(out NetPacket packet);

        /// <summary>
        /// Sends a packet through the socket.
        /// </summary>
        /// <param name="packet"> The packet to send. </param>
        /// <returns> True if the packet was sent successfully. </returns>
        public abstract bool Send(NetPacket packet);

        /// <summary>
        /// Receive a packet from the socket. 
        /// </summary>
        /// <param name="packet"> The packet that was received. </param>
        /// <remarks>
        /// This method is expected to be blocking until it receives something, as it should be ran in a multithreaded context.
        /// Set the socket to non-blocking at your own risk. 
        /// </remarks>
        /// <returns> The size of the payload received. </returns>
        public abstract int Receive(out NetPacket packet);
    }
}