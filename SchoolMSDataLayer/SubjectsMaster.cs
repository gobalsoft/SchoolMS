//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolMSDataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubjectsMaster
    {
        public int SubjectID { get; set; }
        public string Subjectcode { get; set; }
        public string Subjectname { get; set; }
        public int Schoolid { get; set; }
        public Nullable<int> Category_id { get; set; }
    
        public virtual Subject_Category Subject_Category { get; set; }
    }
}
