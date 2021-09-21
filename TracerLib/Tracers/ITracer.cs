﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerLib.TracerResult;


namespace TracerLib.Tracers
{
    public interface ITracer
    {
        // вызывается в начале замеряемого метода
        void StartTrace();

        // вызывается в конце замеряемого метода 
        void StopTrace();
        // получить результаты измерений  
        TraceResult GetTraceResult();
    }

}
