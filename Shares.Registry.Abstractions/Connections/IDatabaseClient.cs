using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shares.Registry.Abstractions.Connections
{
    public interface IDatabaseClient : IDisposable
    {
        public IDatabaseClient Open();
        public void Close();
        public bool IsOpen { get; }
    }
}
