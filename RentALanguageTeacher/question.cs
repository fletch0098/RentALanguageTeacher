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
    
    public partial class question
    {
        public question()
        {
            this.answers = new HashSet<answer>();
            this.questionnaires = new HashSet<questionnaire>();
        }
    
        public int question_id { get; set; }
        public Nullable<int> question_type { get; set; }
        public string prompt_english { get; set; }
        public string prompt_spanish { get; set; }
        public Nullable<int> picture_id { get; set; }
        public Nullable<System.DateTime> time_stamp { get; set; }
        public Nullable<bool> include { get; set; }
        public Nullable<int> question_category_id { get; set; }
        public Nullable<int> weight { get; set; }
    
        public virtual ICollection<answer> answers { get; set; }
        public virtual picture picture { get; set; }
        public virtual questioncategory questioncategory { get; set; }
        public virtual questiontype questiontype { get; set; }
        public virtual ICollection<questionnaire> questionnaires { get; set; }
    }
}
