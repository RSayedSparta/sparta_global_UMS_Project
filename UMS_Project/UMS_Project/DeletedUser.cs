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
<<<<<<< HEAD
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

=======
    
>>>>>>> 8c16366d8f5a3fc02e631b1170ea6317adf2d99b
    public partial class DeletedUser
    {
        public int id { get; set; }
        public Nullable<int> userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Nullable<int> age { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string passwordSalt { get; set; }
        public string passwordHash { get; set; }
        public Nullable<int> roleID { get; set; }
        public Nullable<int> cohortID { get; set; }
<<<<<<< HEAD
        [NotMapped]
        public string password { get; set; }
=======
>>>>>>> 8c16366d8f5a3fc02e631b1170ea6317adf2d99b
    }
}
