using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStackDemo
{
    public class EntryService : Service
    {
        public object Post(Entry request)
        {
            var Session = base.SessionBag;
            var date = request.Time.Date;
            var trackedData = (TrackedData)Session[date.ToString()];
            if (trackedData == null)
                trackedData = new TrackedData { Goal = 300 };

            trackedData.Total += request.Amount;
            Session[date.ToString()] = trackedData;
            
            return new EntryResponse { Id = 1, Message = String.Format("{0} points added. Total: {1}", request.Amount, trackedData.Total)};
        }
    }

    public class TrackedData
    {
        public int Total { get; set; }
        public int Goal { get; set; }
    }
}