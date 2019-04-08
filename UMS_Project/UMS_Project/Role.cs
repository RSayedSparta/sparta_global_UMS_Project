
namespace UMS_Project
{
   using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;



    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public Role()
        {
            this.Users = new HashSet<User>();
        }

        public int roleID { get; set; }

        [DisplayName("Role Name")]
        [Required]
        //[RegularExpression("^[A-Z]+", ErrorMessage = "Must have 1 capital letter")]
        [StringLength(50)]
<<<<<<< HEAD

=======
>>>>>>> 8c16366d8f5a3fc02e631b1170ea6317adf2d99b
        public string roleName { get; set; }
        [DisplayName("Role Description")]
        [Required]

        public string roleDescription { get; set; }
<<<<<<< HEAD

=======
>>>>>>> 8c16366d8f5a3fc02e631b1170ea6317adf2d99b
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<User> Users { get; set; }

    }

}


