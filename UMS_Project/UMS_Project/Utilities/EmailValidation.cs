using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UMS_Project.Utilities
{
    public class EmailNotInDB : ValidationAttribute
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        public EmailNotInDB() : base("{0} is already associated to another user")
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = db.Users.SingleOrDefault(u => u.email == value.ToString());
           // var user = db.Users.SingleOrDefault(u => u.email == value.ToString());
            if (email == null)
                {
                    return ValidationResult.Success;

                }
                else
                {
                    return new ValidationResult("");
                }
        }
    }
}