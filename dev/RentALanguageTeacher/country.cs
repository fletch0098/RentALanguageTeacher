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
    
    public partial class country
    {
        public country()
        {
            this.zones = new HashSet<zone>();
            this.locations = new HashSet<location>();
        }
    
        public Nullable<int> country_id { get; set; }
        public string iso2 { get; set; }
        public string short_name { get; set; }
        public string long_name { get; set; }
        public string iso3 { get; set; }
        public string numcode { get; set; }
        public string un_member { get; set; }
        public string calling_code { get; set; }
        public string cctld { get; set; }
        public string spanish_name { get; set; }
    
        public virtual ICollection<zone> zones { get; set; }
        public virtual ICollection<location> locations { get; set; }
    }
}
