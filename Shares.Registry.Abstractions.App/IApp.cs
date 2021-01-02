
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shares.Registry.Presentation.App
{
    public interface IApp
    {
        Task RunAsync(object[] args);
    }
}
