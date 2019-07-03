using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestRabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostName = "localhost";
            var userName = "admin";
            var password = "admin";


            var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
            {
                UserName = userName,
                Password = password,
                HostName = hostName

            };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            /*create Exchange*/
            //Console.WriteLine("Creating Exchange");
            // model.ExchangeDeclare("DemoExchange", ExchangeType.Direct);


            /*Create Queue*/
            // model.QueueDeclare("Demo-Queue", true, false, false, null);

            /*Queue Bindind*/
            //model.QueueBind("Demo-Queue", "DemoExchange", "demoKey");


            var properties = model.CreateBasicProperties();
            properties.Persistent = true;

            byte[] messageBuffer = Encoding.Default.GetBytes("Direct Message");
            model.BasicPublish("DemoExchange", "demoKey", properties, messageBuffer);

            Console.WriteLine("Message Sent");

            Console.ReadLine();





        }
    }
}
