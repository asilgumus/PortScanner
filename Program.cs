using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace portscanner
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Scan();

        }

        static async void Scan()
        {
            Console.Write("write the domain (google.com): ");
            var domain = Console.ReadLine();

            var ip = Dns.GetHostEntry(domain).AddressList.First(a => a.AddressFamily == AddressFamily.InterNetwork);
            List<int> ports = new List<int>();

            for (int i = 0; i <= 65535; i++)
            {
                ports.Add(i);
                Console.WriteLine($"added port {i}");
            }
            List<int> openPorts = new List<int>();
            List<Task> tasks = new List<Task>();


            foreach (var port in ports)
            {
                tasks.Add(Task.Run(async () =>
                {
                    var client = new TcpClient();
                    var connectTask = client.ConnectAsync(ip, port);
                    var result = await Task.WhenAny(connectTask, Task.Delay(300));

                    if (result == connectTask && client.Connected)
                    {
                        Console.WriteLine($"open port detected: {port}");
                    }
                }));
            }
            await Task.WhenAll(tasks);

        }
    }
}
