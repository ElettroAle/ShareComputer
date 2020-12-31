using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.EntryPoint.ConsoleApp.Abstractions
{
    public interface IApp
    {
        Task RunAsync(object[] args);
    }
}
