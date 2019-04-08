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

        public Type ObjectType { get; private set; }

        public EmailNotInDB(Type type)
        {
            ObjectType = type;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (ObjectType == string)
            {
                
                var email = db.Users.FirstOrDefault(u => u.email == (string) value);

                if (email == null)
                {
                    return ValidationResult.Success;

                }
                else
                {
                    return new ValidationResult("email already exists");
                }
            }

            return new ValidationResult("Generic Validation Fail");
        }
    }
}