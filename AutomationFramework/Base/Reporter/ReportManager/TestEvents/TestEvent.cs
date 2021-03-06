﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameWork.Reporter.TestEvents
{
    public class TestEvent
    {
        public string Name;
        public DateTime Started;
        public DateTime Finished;

        public double Duration
        {
            get
            {
                return (Finished - Started).TotalSeconds;
            }
        }

        public string DurationString
        {
            get
            {
                return (Finished - Started).ToString(@"hh\:mm\:ss\:fff");
            }
        }

        public TestEvent ()
        {
            Name = "";
            Started = default(DateTime);
            Finished = default(DateTime);
        }

        public TestEvent (string eventName = "", DateTime started = default(DateTime), DateTime finished = default(DateTime))
        {
            Name = eventName;
            Started = started;
            Finished = finished;
        }
    }
}
