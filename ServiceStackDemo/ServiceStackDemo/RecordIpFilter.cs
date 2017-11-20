using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Web;
using ServiceStack.Caching;

namespace ServiceStackDemo
{
    public class RecordIpFilter : RequestFilterAttribute
    {
        public ICacheClient Cache { get; set; }

        public override void Execute(IRequest req, IResponse res, object requestDto)
        {
            Cache.Add("lastIP", req.UserHostAddress);
        }
    }

    public class LastIpFilter : ResponseFilterAttribute
    {
        public ICacheClient Cache { get; set; }

        public override void Execute(IRequest req, IResponse res, object responseDTO)
        {
            var status = responseDTO as StatusResponse;
            if(status != null)
            {
                status.Message += "Last IP: " + Cache.Get<string>("lastIP");
            }
        }
    }
}