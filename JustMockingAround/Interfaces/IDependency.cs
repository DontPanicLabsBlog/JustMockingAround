using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMockingAround.Interfaces
{
    public interface IDependency
    {
        void SaveData(byte[] bytes, DateTime timestamp);

        int GetCalculation1(int total);

        int GetCalculation2(int total);
    }
}