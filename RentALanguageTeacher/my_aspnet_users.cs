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
    
    public partial class my_aspnet_users
    {
        public my_aspnet_users()
        {
            this.users = new HashSet<user>();
        }
    
        public int id { get; set; }
        public int applicationId { get; set; }
        public string name { get; set; }
        public bool isAnonymous { get; set; }
        public Nullable<System.DateTime> lastActivityDate { get; set; }
    
        public virtual ICollection<user> users { get; set; }
    }
}
