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
    
    public partial class account
    {
        public int member_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string account_status { get; set; }
        public Nullable<int> language_id { get; set; }
        public Nullable<System.DateTime> time_stamp { get; set; }
    
        public virtual accountstatu accountstatu { get; set; }
        public virtual language language { get; set; }
    }
}