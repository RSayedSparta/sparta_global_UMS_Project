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
    
    public partial class Trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainer()
        {
            this.Cohorts = new HashSet<Cohort>();
        }
    
        public int trainerID { get; set; }
<<<<<<< HEAD
=======
        [Display(Name = "Name of Trainer")]
>>>>>>> 77241bcb475dd91532076b2ad600ce2649c3cdd0
        public string trainerName { get; set; }
        public int userID { get; set; }
        public int cohortID { get; set; }
    
        public virtual Cohort Cohort { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cohort> Cohorts { get; set; }
    }
}
