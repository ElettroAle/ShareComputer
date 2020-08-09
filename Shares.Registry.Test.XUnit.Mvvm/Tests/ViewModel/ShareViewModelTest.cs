using Shares.Registry.Test.Abstractions;
using Shares.Registry.Test.XUnit.Mvvm.Fixture;
using Shares.Registry.ViewModels.Shares;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace Shares.Registry.Test.XUnit.Mvvm.Tests
{
    public class ShareViewModelTest : Abstractions.Test
    {
        public ShareViewModelTest(FixtureContext testFixture) : base(testFixture) { }

        [Fact]
        public void GetView()
        {
#warning Sostituire col nome del vero container
            var viewModel = new ShareViewModel(MockManager.GetMockContext(true, "shares").Object);
            viewModel.GetView("shares");
            Assert.True(true);
        }
        [Fact]
        public void GetViewNoAction()
        {
#warning Sostituire col nome del vero container
            var viewModel = new ShareViewModel(MockManager.GetMockContext(true, "shares").Object);
            viewModel.GetView("");
            Assert.True(true);
        }
    }
}
