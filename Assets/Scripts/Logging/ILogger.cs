using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface ILogger
    {
        public void LogError(string message);
        public void LogWarning(string message);
        public void LogInfo(string message);
    }
}
