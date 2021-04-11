using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.UI.ContextStartup
{
    public interface IStartupContextInstaller        
    {
        void InstallServices();
    }
}
