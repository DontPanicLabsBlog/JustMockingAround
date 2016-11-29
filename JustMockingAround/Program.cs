using JustMockingAround.Interfaces;
using JustMockingAround.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMockingAround
{
    public class Program
    {
        private IDependency _dependency;

        private IDependency Dependency
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

        public void DoStuffWithBytes(byte[] bytes)
        {
            var timestamp = DateTime.UtcNow;

            Dependency.SaveData(bytes, timestamp);

            Logger.Log("Saved the bytes!");
        }

        public int CalculateResultAndAdd10(int total)
        {
            var result = DoStuffInternal(total);

            result += 10;

            return result;
        }

        internal int DoStuffInternal(int total)
        {
            if (total < 10)
            {
                return Dependency.GetCalculation1(total);
            }

            return Dependency.GetCalculation2(total);
        }
    }
}