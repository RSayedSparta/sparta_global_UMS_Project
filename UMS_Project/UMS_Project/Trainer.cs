//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

//------------------------------------------------------------------------------

// <auto-generated>

//     This code was generated from a template.

//

//     Manual changes to this file may cause unexpected behavior in your application.

//     Manual changes to this file will be overwritten if the code is regenerated.

// </auto-generated>

//------------------------------------------------------------------------------





namespace UMS_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Trainer
    {
        public int trainerID { get; set; }
        [Required]
        [DisplayName("Trainer Name")]
        public string trainerName { get; set; }
        [Required]
        public int userID { get; set; }
        [Required]
        public int cohortID { get; set; }

        public virtual Cohort Cohort { get; set; }
        public virtual User User { get; set; }

    }

}
