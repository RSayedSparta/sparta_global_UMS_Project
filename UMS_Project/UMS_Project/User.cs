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
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Trainers = new HashSet<Trainer>();
        }
    
        public int userID { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [Required]
        [DisplayName("Age")]
        public Nullable<int> age { get; set; }
        [Required]
        [DisplayName("Gender")]
        public string gender { get; set; }
        [Required]
        [DisplayName("Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+(@spartaglobal\.com)$", ErrorMessage = "Registration limited to 'spartaglobal.com'.")]
        public string email { get; set; }
        public string passwordSalt { get; set; }
        public string passwordHash { get; set; }
        [Required]
        public int roleID { get; set; }
        [Required]
        public int cohortID { get; set; }
        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[a-z])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Must be at least 8 characters and contain at least one lowercase letter, one uppercase letter and one number")]
        public string password { get; set; }
        public virtual Cohort Cohort { get; set; }
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
