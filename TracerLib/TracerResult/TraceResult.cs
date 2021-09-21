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


        public List<ThreadTraceResults> Threads
        {

            get
            {
                List<ThreadTraceResults> TraceList = new List<ThreadTraceResults>();



                var keys = TraceResults.Keys;
                foreach (int i in keys)
                {
                    ThreadTraceResults threadTraceResults = new ThreadTraceResults();

                    threadTraceResults.ThreadStack = BuildStack(TraceResults[i].ThreadStack);
                    threadTraceResults.ThreadID = i;
                    TraceList.Add(threadTraceResults);

                }

                return TraceList;
            }
        }


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



        private Stack<OneTraceResult> BuildStack(Stack<OneTraceResult> start)
        {
            Stack<OneTraceResult> result = new Stack<OneTraceResult>();

            Stack<OneTraceResult> tmp1 = new Stack<OneTraceResult>(start.Reverse());


            if (tmp1.Count <= 0)
            {
                return new Stack<OneTraceResult>();
            }

            result.Push(tmp1.Pop().Copy());

            while (tmp1.Count > 0)
            {
                OneTraceResult tmp = tmp1.Pop().Copy();
                if (tmp.id == 0)
                {
                    result.Push(tmp);
                    continue;
                }
                else
                {
                    result.Peek().PushChild(tmp);

                }
            }
            return result;
        }



        internal TraceResult Copy()
        {
            TraceResult newTrace = new TraceResult();
            foreach (int k in this.TraceResults.Keys)
            {
                newTrace.TraceResults.Add(k, this.TraceResults[k].Copy());
            }
            return newTrace;
        }

    }
}
