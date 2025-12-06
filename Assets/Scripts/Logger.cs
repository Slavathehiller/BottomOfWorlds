using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ILogger = Assets.Scripts.Interfaces.ILogger;

namespace Assets.Scripts
{
    public class Logger : ILogger
    {
        public void LogError(string message)
        {
            Debug.LogError(message);
        }

        public void LogWarning(string message)
        {
            Debug.LogWarning(message);
        }

        public void LogInfo(string message)
        {
            Debug.Log(message);
        }
    }
}
