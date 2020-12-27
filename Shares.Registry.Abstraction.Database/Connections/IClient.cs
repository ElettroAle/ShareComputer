
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shares.Registry.Abstraction.Database.Connections
{
    public interface IClient : IDataReader, IDataWriter
    {
        public IClient Open();
        public void Close();
        public bool IsOpen { get; }
    }
}
