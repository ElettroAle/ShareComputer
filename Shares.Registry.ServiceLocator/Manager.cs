using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Abstractions.Mvvm.ViewModel;
using Shares.Registry.Mvvm.Orchestration;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.ServiceLocator
{
    public class Manager
    {
        public IViewModel ViewModel { get; set; }
    }
}
