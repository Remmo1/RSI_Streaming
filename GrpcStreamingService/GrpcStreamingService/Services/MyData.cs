﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GrpcStreamingService.Services
{
    public class MyData
    {
        public static void Info()
        {
            Console.WriteLine("Maria Markowiak, 260417");
            Console.WriteLine("Remigiusz Pisarski, 260364");
            Console.WriteLine((DateTime.UtcNow).ToString("dd MMM, HH:mm:ss"));

            Console.WriteLine(Environment.Version.ToString());
            Console.WriteLine(Environment.UserName);
            Console.WriteLine(Environment.OSVersion);

            try
            {
                GetLocalIPAddress();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
