using System;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace GraviddleSocketClient
{
    public class GraviddleClient
    {
        private readonly SocketClient _socketClient = new SocketClient("192.168.1.105", 8080);

        public void SendDataForAnalytics(DataForAnalytics dataForAnalytics)
        {
            #if  UNITY_EDITOR
            return;
            #endif
            
            try
            {
                string serializedData = JsonConvert.SerializeObject(dataForAnalytics);
                var command = new Command(serializedData);
                string json = JsonConvert.SerializeObject(command);
                byte[] data = Encoding.Unicode.GetBytes(json);
    
                _socketClient.Send(data);
            }
            catch (Exception exception)
            {
                Debug.Log(exception.Message);
            }
        }
    }
}