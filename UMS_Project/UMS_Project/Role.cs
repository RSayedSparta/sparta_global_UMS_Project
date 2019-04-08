
namespace UMS_Project
{
   using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
=======


>>>>>>> 8c16366d8f5a3fc02e631b1170ea6317adf2d99b
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
<<<<<<< HEAD
=======
        //[RegularExpression("^[A-Z]+", ErrorMessage = "Must have 1 capital letter")]
>>>>>>> 8c16366d8f5a3fc02e631b1170ea6317adf2d99b
        [StringLength(50)]
        public string roleName { get; set; }
        [DisplayName("Role Description")]
        [Required]
        public string roleDescription { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }

    }

}


