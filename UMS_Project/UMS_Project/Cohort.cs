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
           // this.Trainers = new HashSet<Trainer>();
            this.Users = new HashSet<User>();
        }
<<<<<<< HEAD



        [Required]
=======
    
>>>>>>> a1ddc96b764c56f5c92aa02b74de337f1a601bac
        public int cohortID { get; set; }
        public string cohortName { get; set; }
<<<<<<< HEAD
        [Required]
        [Display]
        [DisplayName("Start Date")]
=======
>>>>>>> a1ddc96b764c56f5c92aa02b74de337f1a601bac
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<bool> hasTA { get; set; }
        public string clocation { get; set; }
        public Nullable<int> maximumSeats { get; set; }
        public Nullable<int> minimumSeats { get; set; }
        public int streamID { get; set; }
        public string trainer { get; set; }
    
        public virtual Stream Stream { get; set; }
<<<<<<< HEAD

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Trainer> Trainers { get; set; }

=======
       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual Trainer Trainers { get; set; }
>>>>>>> a1ddc96b764c56f5c92aa02b74de337f1a601bac
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<User> Users { get; set; }
    }
}
