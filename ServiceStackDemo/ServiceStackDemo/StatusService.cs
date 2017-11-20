using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStackDemo
{
    public class StatusService : Service
    {
        public object Any(StatusQuery request)
        {
            //throw new NotImplementedException("This is a test");

            var Session = base.SessionBag;

            var date = request.Date.Date;
            var trackedData = (TrackedData)Session[date.ToString()];
            if (trackedData == null)
                trackedData = new TrackedData { Goal = 300, Total = 0 };

            return new StatusResponse { Goal = trackedData.Goal, Total = trackedData.Total, Message = "" };
            //return new StatusResponse { Goal = 300, Total = 100 };
        }
    }
}