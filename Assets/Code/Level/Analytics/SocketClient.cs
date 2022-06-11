using System.Net;
using System.Net.Sockets;

namespace GraviddleSocketClient
{
    public class SocketClient
    {
        private readonly IPEndPoint _endPoint;
    
        public SocketClient(string address, int port)
        {
            _endPoint = new IPEndPoint(IPAddress.Parse(address), port); 
        }

        public async void Send(byte[] data)
        {
            var connectionWithServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await connectionWithServer.ConnectAsync(_endPoint);
            connectionWithServer.Send(data);
            connectionWithServer.Shutdown(SocketShutdown.Both);
            connectionWithServer.Close();
        }
    }
}