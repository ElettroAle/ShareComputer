using Shares.Registry.Abstractions.Mvvm.View;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Abstractions.Mvvm.ViewModel
{
    public interface IViewModel : IDisposable
    {
        IView GetView(string action, params object[] args);
    }
}
