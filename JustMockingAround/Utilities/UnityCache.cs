using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMockingAround.Utilities
{
    public static class UnityCache
    {
        private static UnityContainer Container = new UnityContainer();

        public static void Register<T>(T type)
        {
            Container.RegisterInstance<T>(type);
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}