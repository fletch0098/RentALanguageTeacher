using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentALanguageTeacher.App_Code.Time
{
    public class TimeDataJson
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string CountryCode { get; set; }
        public string ZoneName { get; set; }
        public string Abbreviation { get; set; }
        public double GMTOffset { get; set; }
        public string DST { get; set; }
        public double TimeStamp { get; set; }
        public DateTime CurrentTime { get; set; }

    }
}