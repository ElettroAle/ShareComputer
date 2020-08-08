using Shares.Registry.Abstractions.Mvvm.Model;
using Shares.Registry.Test.Abstractions;
using Shares.Registry.Test.XUnit.Mvvm.Fixture;
using Shares.Registry.Views.Shares;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace Shares.Registry.Test.XUnit.Mvvm.Tests
{
    public class ShareViewTest : Abstractions.Test
    {
        public ShareViewTest(FixtureContext testFixture) : base(testFixture) { }

        [Fact]
        public void ShowFullDb()
        {
            var view = new ShareView(new List<IItem>() { MockManager.GetMockItem(true).Object });
            view.Show();
        }
        [Fact]
        public void ShowEmptyDb() 
        { 
            var view = new ShareView(new List<IItem>() { MockManager.GetMockItem(false).Object });
            view.Show();
        }
    }
}
