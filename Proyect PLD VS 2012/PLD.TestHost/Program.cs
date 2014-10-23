using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using PLD.Services;

namespace PLD.TestHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("************************* PLD.Services Versión 0.1.0****************************");
                Console.WriteLine("Iniciando servicios...");
                Console.WriteLine();
                using (ServiceHost host1 = new ServiceHost(typeof(ServiceDefinition)))
                {
                    host1.Open();
                    Console.WriteLine("Servicio Iniciado!");
                    Console.WriteLine();
                   
                    using (ServiceHost host2 = new ServiceHost(typeof(ComunService)))
                    {
                        host2.Open();
                        Console.WriteLine("Servicio ComunService Iniciado!");
                        Console.WriteLine();
                        using (ServiceHost host3 = new ServiceHost(typeof(ClienteService)))
                        {
                            host3.Open();
                            Console.WriteLine("Servicio ClienteService Iniciado!");
                            Console.WriteLine();



                            Console.ReadKey();
                            host3.Close();
                            host2.Close();
                            host1.Close();
                        }
                        
                    }
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
