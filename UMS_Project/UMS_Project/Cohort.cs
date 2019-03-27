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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Cohort
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cohort()
        {
            this.Trainers = new HashSet<Trainer>();
            this.Users = new HashSet<User>();
        }
        [Required]
        public int cohortID { get; set; }
        [Required]
        [DisplayName("Cohort Name")]
        public string cohortName { get; set; }
        [DisplayName("Start Date")]
        public Nullable<System.DateTime> startDate { get; set; }
        [DisplayName("End Date")]
        public Nullable<System.DateTime> endDate { get; set; }
        [DisplayName("Has TA")]
        public Nullable<bool> hasTA { get; set; }
        [Required]
        [DisplayName("Location")]
        public string clocation { get; set; }
        [DisplayName("Max Capacity")]
        public Nullable<int> maximumSeats { get; set; }
        [DisplayName("Min capacity")]
        public Nullable<int> minimumSeats { get; set; }
        [Required]
        public int streamID { get; set; }
    
        public virtual Stream Stream { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainer> Trainers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
