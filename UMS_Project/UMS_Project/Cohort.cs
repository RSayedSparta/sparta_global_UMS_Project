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
    using System.ComponentModel.DataAnnotations;

    public partial class Cohort
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public Cohort()
        {
            this.Trainers = new HashSet<Trainer>();
            this.Users = new HashSet<User>();
        }
<<<<<<< HEAD


        [Required]

        public int cohortID { get; set; }

        [Required]
        [DisplayName("Cohort Name")]

        public string cohortName { get; set; }
        [DisplayName("Start Date")]

=======
        [Required]
        [Display]
        public int cohortID { get; set; }
        public string cohortName { get; set; }
>>>>>>> 8782fcb4e2f6b414b5ac88797432f44f57d21607
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<bool> hasTA { get; set; }
        public string clocation { get; set; }
        public Nullable<int> maximumSeats { get; set; }
        public Nullable<int> minimumSeats { get; set; }
        public int streamID { get; set; }

        public virtual Stream Stream { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Trainer> Trainers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<User> Users { get; set; }
    }
}
