using JustMockingAround.Interfaces;
using JustMockingAround.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace JustMockingAround.Tests
{
    public class ProgramTestsBase
    {
        private IDependency _dependency;

        public IDependency Dependency
        {
            get
            {
                if (_dependency == null)
                {
                    _dependency = UnityCache.Resolve<IDependency>();
                }

                return _dependency;
            }
        }

        public ProgramTestsBase()
        {
            UnityCache.Register(Mock.Create<IDependency>());

            #region JustMock Full Required

            Mock.Arrange(() => Logger.Log(Arg.AnyString)).DoNothing();

            #endregion
        }
    }
}