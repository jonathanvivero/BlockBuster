using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlockBuster.Shared.UI.ContextStartup
{
    public static class StartupAssemblyCollectorFacade
    {
        public static List<TInterface> GetAssembliesAlongApp<TInterface>(string contextPrefix, object[] paramList)
        {
            var interfaceType = typeof(TInterface);
            var assembliesCollection = LoadAssemblies(interfaceType, contextPrefix);
        
            var installers = assembliesCollection
                .Where(x => typeof(TInterface).IsAssignableFrom(x)
                    && !x.IsInterface
                    && !x.IsAbstract)
                .Select(s => Activator.CreateInstance(s, paramList))
            .Cast<TInterface>()
            .ToList();

            return installers;            
        }

        private static IEnumerable<Type> LoadAssemblies(Type interfaceType, string contextPrefix)
        {
            Func<Assembly, bool> asmFullNameStartWith = (w) =>
                string.IsNullOrEmpty(contextPrefix)
                ? true
                : w.FullName.StartsWith(contextPrefix);

            Func<AssemblyName, bool> asmNameStartWith = (w) =>
                string.IsNullOrEmpty(contextPrefix)
                ? true
                : w.FullName.StartsWith(contextPrefix);


            var assemblyList = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(asmFullNameStartWith)
                .Distinct();

            var allReferencedAssemblies = assemblyList
                .SelectMany(s => s.GetReferencedAssemblies())
                .Where(asmNameStartWith)
                .Select(s => Assembly.Load(s))
                .Union(assemblyList);

            var allAssemblies = AddUnloadedAssemblies(allReferencedAssemblies, contextPrefix);

            var allImplementers = allAssemblies
                .SelectMany(s => s.GetTypes())
                .Distinct()
                .Where(w => interfaceType.IsAssignableFrom(w)
                    && !w.IsInterface);

            return allImplementers;
        }

        private static IEnumerable<Assembly> AddUnloadedAssemblies(IEnumerable<Assembly> currentAssemblies, string context)
        {
            var names = currentAssemblies
                .Select(s => s.GetName().Name)
                .Distinct();

            var folder = new DirectoryInfo(AppContext.BaseDirectory);
            var prefiles = folder
                .GetFiles()
                .Where(w => w.Name.ToLower().EndsWith(".dll"))
                .ToList();

            if (!string.IsNullOrEmpty(context))
            {
                prefiles = prefiles
                    .Where(w => w.Name.StartsWith(context))
                    .ToList();
            }

            var filesLoadedAsAssembly = prefiles.Select(s => Assembly.LoadFrom(s.FullName));

            return currentAssemblies
                .Concat(filesLoadedAsAssembly)
                .Distinct();
        }

        

    }
}
