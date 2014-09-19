using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

using System.ServiceModel;
using PLD.Services;

namespace PLD.TesHost
{
    partial class AppWindowsServices : ServiceBase
    {
        //Se instancian los n servicios de la solución
        public ServiceHost serviceHost1 = null;

        public AppWindowsServices()
        {
            ServiceName = "AppWindowsService";
            //InitializeComponent();
        }

        public static void Main()
        {
            ServiceBase.Run(new AppWindowsServices());
        }

        protected override void OnStart(string[] args)
        {
            // se agregan en || los servicios de la solución: if (serviceHost1 != null || serviceHost2 != null ||...)
            if (serviceHost1 != null)
            {
                // se cierran los n servicios de la solución
                serviceHost1.Close();
            }
            // Se instancian y relacionan por tipo los n servicios de la solución
            serviceHost1 = new ServiceHost(typeof(ServiceDefinition));

            // Se abren los n servicios de la solución
            serviceHost1.Open();
        }

        protected override void OnStop()
        {
            // se agregan en || los servicios de la solución: if (serviceHost1 != null || serviceHost2 != null ||...)
            if (serviceHost1 != null)
            {
                // se cierran y asignan a nulo cada uno se los servicios de la solución
                serviceHost1.Close();
                serviceHost1 = null;
            }
        }
    }
}
