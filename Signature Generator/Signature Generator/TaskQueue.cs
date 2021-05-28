using System;
using System.Collections.Generic;
using System.Threading;

namespace Signature_Generator
{
    class TaskQueue
    {
        private static readonly Queue<Action> taskQueue;
        private static bool done = false;
        static TaskQueue()
        {
            taskQueue = new();
        }

        public static void EnqueueTask(Action task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            lock (taskQueue)
            {
                taskQueue.Enqueue(task);
                Monitor.Pulse(taskQueue);
            }
        }
        public static Action DequeueTask()
        {
            lock (taskQueue)
            {
                while (taskQueue.Count == 0)
                {
                    if (done) return null;
                    Monitor.Wait(taskQueue);
                }
                return taskQueue.Dequeue();
            }
        }
        public static void Done()
        {
            lock (taskQueue)
            {
                done = true;
                Monitor.PulseAll(taskQueue);
            }
        }
    }
}
