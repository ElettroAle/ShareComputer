using Shares.Registry.Mvvm.Orchestration;
using Shares.Registry.Test.Abstractions;
using Shares.Registry.Test.XUnit.Mvvm.Fixture;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace Shares.Registry.Test.XUnit.Mvvm.Tests
{
    public class MvvmHandlerTest : Abstractions.Test
    {
        public MvvmHandlerTest(FixtureContext testFixture) : base(testFixture) { }

        [Fact]
        public void Handle()
        {
            MvvmHandler mvvmHandler = new MvvmHandler();
            mvvmHandler.Handle(MockManager.GetViewModelMock().Object, "");
            Assert.True(true);
        }
    }
}
