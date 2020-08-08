using Shares.Registry.Mvvm.Orchestration;
using Shares.Registry.ServiceLocator;

using System;

namespace Shares.Registry
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            MvvmHandler mvvmHandler = new MvvmHandler();
            mvvmHandler.Handle(manager.ViewModel, "");
        }
    }
}
