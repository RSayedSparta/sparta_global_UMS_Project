//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UMS_Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Trainers = new HashSet<Trainer>();
        }
    
        public int userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Nullable<int> age { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string upassword { get; set; }
        public string passwordSalt { get; set; }
        public string passwordHash { get; set; }
        public int roleID { get; set; }
        public int cohortID { get; set; }
    
        public virtual Cohort Cohort { get; set; }
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
