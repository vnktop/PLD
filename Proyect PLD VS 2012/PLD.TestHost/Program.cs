﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using BIM.Services;

namespace PLD.TestHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("*************************BIM.PLD.Services Versión 0.1.0****************************");
                Console.WriteLine("Iniciando servicios...");
                Console.WriteLine();
                using (ServiceHost host1 = new ServiceHost(typeof(ServiceDefinition)))
                {
                    host1.Open();
                    Console.WriteLine("Servicio Iniciado!");
                    Console.WriteLine();
                    Console.ReadKey();
                    host1.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al iniciar servicios:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("*****************************************************************");
                Console.WriteLine();
                Console.WriteLine("Presione cualquier tecla para terminar...");
                Console.ReadKey();
            }
        }
    }
}
