using System.Collections.Generic;
using System.Threading.Tasks;

namespace Youtrack.Utilities
{
    public static class Tasks
    {
        public static Task<T> AwaitTask<T>(Task task)
        {
            Task[] tasks =
            {
                task
            };

            Task.WaitAll(tasks);
            return (Task<T>)task;
        }
    }
}
