using System;
using System.Collections.Generic;

namespace Przewodnik.Utilities
{
    class EventQueueSection : IDisposable
    {
        private readonly Queue<ExitEventHandler> eventHandlerQueue = new Queue<ExitEventHandler>();

        public delegate void ExitEventHandler();

        internal int ItemCount
        {
            get
            {
                return this.eventHandlerQueue.Count;
            }
        }

        public void Enqueue(ExitEventHandler handler)
        {
            this.eventHandlerQueue.Enqueue(handler);
        }

        public void Dispose()
        {
            while (this.eventHandlerQueue.Count > 0)
            {
                var handler = this.eventHandlerQueue.Dequeue();
                handler();
            }
        }
    }
}
