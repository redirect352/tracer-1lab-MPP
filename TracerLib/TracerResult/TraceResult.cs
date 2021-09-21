using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib.TracerResult
{
    class TraceResult
    {
        private Dictionary<int, ThreadTraceResults> TraceResults = new Dictionary<int, ThreadTraceResults>();
        private Dictionary<int, OneTraceResult> LastChilds = new Dictionary<int, OneTraceResult>();

        public void Push(string classname, string methode, int MsCount, long tick, int id, int ThreadId)
        {

            OneTraceResult oneTraceResult = new OneTraceResult(classname, methode, MsCount, tick, id);
            if (!TraceResults.ContainsKey(ThreadId))
            {
                ThreadTraceResults threadTrace = new ThreadTraceResults();
                threadTrace.ThreadStack = new Stack<OneTraceResult>();
                TraceResults.Add(ThreadId, threadTrace);

            }
            TraceResults[ThreadId].ThreadStack.Push(oneTraceResult);
        }


        internal TraceResult Copy()
        {

            return this;
        }

    }
}
