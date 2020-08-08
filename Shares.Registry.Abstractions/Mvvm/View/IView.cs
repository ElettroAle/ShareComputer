
using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Abstractions.Mvvm.View
{
    public interface IView<TModel> : IView
    {
        TModel Model { get; }
    }
    public interface IView
    {
        void Show();
    }
}
