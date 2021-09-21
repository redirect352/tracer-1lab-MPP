using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerLib.TracerResult;

namespace TracerLib.Serialization
{
    interface ITraceResultSerializer
    {
        string Serialize(TraceResult traceResult);
    }
}
