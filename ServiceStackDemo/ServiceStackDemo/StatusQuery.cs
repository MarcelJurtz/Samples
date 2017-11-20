using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStackDemo
{
    [Route("/status")]
    //[Route("/status/{date}")]
    [Authenticate]
    [RequiredRole("User")]
    [RequiredPermission("GetStatus")]
    public class StatusQuery : IReturn<StatusResponse>
    {
        public DateTime Date { get; set; }
    }

    [LastIpFilter]
    public class StatusResponse
    {
        public int Total { get; set; }
        public int Goal { get; set; }
        public string Message { get; set; }
        public StatusResponse StatusResponseInfo { get; set; } // Gets automatically populated with exception data
    }
}