using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

using System.ServiceProcess;

// El espacio de nombre es TestHost, no TestHostInstall
namespace BIM.TesHost
{
    [RunInstaller(true)]
    public partial class AppInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public AppInstaller()
        {
            InitializeComponent();

            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;

            service = new ServiceInstaller();
            service.ServiceName = "AppWindowsService";

            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
