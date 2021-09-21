using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib.TracerResult
{
    class OneTraceResult
    {

        private Stack<OneTraceResult> st = null;
        private long tickCount;
        private int milliSeconds;
        private string methodeName;
        private string className;

        public int id;

        public OneTraceResult()
        {


        }

        public OneTraceResult(string classname, string methode, int MsCount, long tick, int id1)
        {
            tickCount = tick;
            className = classname;
            milliSeconds = MsCount;
            methodeName = methode;
            id = id1;
        }

        public long TickCount
        {
            get
            {
                return tickCount;
            }
            set { }
        }

        public int MilliSeconds
        {
            get
            {
                return milliSeconds;
            }
            set { }
        }

        public string MethodeName
        {
            get
            {
                return methodeName;
            }
            set { }

        }

        public string ClassName
        {
            get
            {
                return className;
            }
            set { }

        }


    }
}
