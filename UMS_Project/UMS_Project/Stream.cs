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

    public partial class Stream
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stream()
        {
            this.Cohorts = new HashSet<Cohort>();
        }

        public int streamID { get; set; }
        [Display(Name = "Stream Name")]
        public string streamName { get; set; }
        [Display(Name = "Specialization")]
        public string specialization { get; set; }
        [Display(Name = "Duration")]
        public string duration { get; set; }
        [Display(Name = "Curriculum")]
        public string curriculum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cohort> Cohorts { get; set; }
    }
}
