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
    
    public partial class timeslot
    {
        public int timeslot_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> day { get; set; }
        public Nullable<System.DateTime> start { get; set; }
        public Nullable<System.DateTime> end { get; set; }
        public Nullable<bool> available { get; set; }
        public string notes { get; set; }
        public Nullable<System.DateTime> time_stamp { get; set; }
    
        public virtual weekday weekday { get; set; }
        public virtual user user { get; set; }
    }
}
