//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentALanguageTeacher
{
    using System;
    using System.Collections.Generic;
    
    public partial class weekday
    {
        public weekday()
        {
            this.timeslots = new HashSet<timeslot>();
        }
    
        public int day { get; set; }
        public string english_name { get; set; }
        public string spanish_name { get; set; }
    
        public virtual ICollection<timeslot> timeslots { get; set; }
    }
}
