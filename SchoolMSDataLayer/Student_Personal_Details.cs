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
    
    public partial class Student_Personal_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student_Personal_Details()
        {
            this.Student_Class_Details = new HashSet<Student_Class_Details>();
            this.Student_communcation_Address = new HashSet<Student_communcation_Address>();
            this.Student_Parent_Details = new HashSet<Student_Parent_Details>();
        }
    
        public long Student_ID { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string Mother_Tongue { get; set; }
        public string Email_ID { get; set; }
        public System.DateTime Date_Of_Join { get; set; }
        public System.DateTime Date_Of_Birth { get; set; }
        public int Aadhar_Number { get; set; }
        public bool Gender { get; set; }
        public bool Is_Login_Details_Sent { get; set; }
        public Nullable<int> SchoolID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Class_Details> Student_Class_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_communcation_Address> Student_communcation_Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Parent_Details> Student_Parent_Details { get; set; }
    }
}