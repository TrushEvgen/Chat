﻿using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(Chat));
            sh.Open();
            
            Console.WriteLine("Сервис запущен");
            Console.ReadKey();
            sh.Close();
        }
    }
}
