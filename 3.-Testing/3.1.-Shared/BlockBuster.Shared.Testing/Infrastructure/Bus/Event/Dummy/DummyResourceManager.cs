using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace BlockBuster.Shared.Testing.Infrastructure.Bus.Event.Dummy
{
    internal class DummyResourceManager: ResourceManager
    {
        public override string GetString(string name)
        {
            return string.Empty;
        }
    }
}
