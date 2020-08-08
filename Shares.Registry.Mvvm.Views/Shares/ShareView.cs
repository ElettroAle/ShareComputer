using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Abstractions.Mvvm.View;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Views.Shares
{
    public class ShareView : IView<IEnumerable<IItem>>
    {
        public ShareView(IEnumerable<IItem> model) => Model = model;
        public IEnumerable<IItem> Model { get; }

        public void Show()
        {
            foreach (IItem item in Model)
            {
                Console.WriteLine($"{item.Container}: {item.Id}");
            }
        }
    }
}
