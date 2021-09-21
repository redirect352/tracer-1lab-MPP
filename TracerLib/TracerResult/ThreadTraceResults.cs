using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib.TracerResult
{
    class ThreadTraceResults
    {
        private Stack<OneTraceResult> threadStack = null;
        private int time = 0;
        private int threadId = -1;

        public int Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        public int ThreadID
        {
            get
            {
                return threadId;
            }
            set
            {
                threadId = value;

            }

        }


        internal Stack<OneTraceResult> ThreadStack
        {
            get
            {
                return threadStack;
            }
            set
            {
                threadStack = value;

                foreach (OneTraceResult oneTraceResult in threadStack)
                {
                    if (oneTraceResult.id == 0)
                    {
                        time += oneTraceResult.MilliSeconds;
                    }

                }
            }

        }


    }
}
