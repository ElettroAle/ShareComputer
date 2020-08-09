using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Abstractions.Mvvm.View;
using Shares.Registry.Abstractions.Mvvm.ViewModel;
using Shares.Registry.Constants;
using Shares.Registry.Mvvm.Views;
using Shares.Registry.Views.Shares;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Shares.Registry.ViewModels.Shares
{
    public class ShareViewModel : IViewModel
    {
        public ShareViewModel(IContext context)
        {
            Context = context;
        }

        public IContext Context { get; }

        public void Dispose()
        {
            Context.Dispose();
        }

        public IView GetView(string action, params object[] args)
        {
            switch (action.ToLower())
            {
                case "shares":
#warning Registrare il context con autofac, selezionando li la concretizzazione
                    using (Context)
                    {
#warning Sostituire col nome del vero container
                        IContainer sharesContainer = Context.GetContainer("shares");
#warning prende le prime 100 shares per ora
                        IEnumerable<IItem> shares = sharesContainer.Take(1);
                        return new ShareView(shares);
                    }
                default:
                    return new NullView();

            }
        }
    }
}
