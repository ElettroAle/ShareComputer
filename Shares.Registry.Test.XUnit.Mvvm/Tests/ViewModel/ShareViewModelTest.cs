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
            var viewModel = new ShareViewModel(MockManager.GetContextMock(true, true).Object);
            viewModel.GetView("shares");
        }
        [Fact]
        public void GetViewNoAction()
        {
            var viewModel = new ShareViewModel(MockManager.GetContextMock(true, true).Object);
            viewModel.GetView("");
        }
    }
}
