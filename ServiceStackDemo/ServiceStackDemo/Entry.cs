using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStackDemo
{
    [Route("/entry", "POST")]
    [Route("/entry/{Amount}/{Time}", "POST")] // Supports regular time format
    public class Entry : IReturn<EntryResponse>
    {
        public DateTime Time { get; set; }
        public int Amount { get; set; }
    }

    public class EntryResponse
    {
        public int Id { get; set; }
        public String Message { get; set; }
    }
}