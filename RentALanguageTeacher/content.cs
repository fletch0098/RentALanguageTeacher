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
    
    public partial class content
    {
        public content()
        {
            this.contentmarkups = new HashSet<contentmarkup>();
        }
    
        public int content_id { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public Nullable<int> author_user_id { get; set; }
        public string image_url { get; set; }
        public System.DateTime createdate { get; set; }
    
        public virtual user user { get; set; }
        public virtual contentcategory contentcategory { get; set; }
        public virtual ICollection<contentmarkup> contentmarkups { get; set; }
    }
}