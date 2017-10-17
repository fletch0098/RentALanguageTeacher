using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentALanguageTeacher.App_Code.Time
{
    public class TimeZoneDifference
    {
        public string CountryCode { get; set; }
        public string ZoneName { get; set; }
        public string Abbreviation { get; set; }
        public double TZOffset { get; set; }
        public string DST { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}