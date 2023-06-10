using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks
{
    public class WorkerEvent : IWorker
    {
        ILogger Logger { get; }
        public WorkerEvent(ILogger logger)
        {
            Logger = logger;
        }

        public void Work(string message)
        {
            Logger.Event(message);
        }
    }

    public class WorkerError : IWorker
    {
        ILogger Logger { get; }
        public WorkerError(ILogger logger)
        {
            Logger = logger;
        }

        public void Work(string message)
        {
            Logger.Error(message);
        }
    }
}
