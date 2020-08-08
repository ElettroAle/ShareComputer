using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Abstractions.Mvvm.View;
using Shares.Registry.Abstractions.Mvvm.ViewModel;
using Shares.Registry.ViewModels.Shares;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Mvvm.Orchestration
{
    public class MvvmHandler
    {
        // Scrivere meglio
        public void Handle(IViewModel viewModel, string action)
        {
            IView view = viewModel.GetView(action);
            view.Show();
        }
    }
}
