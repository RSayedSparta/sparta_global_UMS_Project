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
    
    public partial class Cohort
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cohort()
        {
            this.Trainers = new HashSet<Trainer>();
        }
    
        public int cohortID { get; set; }
        [required]
        public string cohortName { get; set; }
        [required]
        public Nullable<System.DateTime> startDate { get; set; }
        [required]
        public Nullable<System.DateTime> endDate { get; set; }
        [required]
        public Nullable<bool> hasTA { get; set; }
        [required]
        public Nullable<int> trainerName { get; set; }
        public int streamID { get; set; }
    
        [required]
        public virtual Stream Stream { get; set; }
        [required]
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainer> Trainers { get; set; }

        private class requiredAttribute : Attribute
        {
        }
    }
}
