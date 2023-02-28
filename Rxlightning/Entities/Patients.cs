using System;
using System.ComponentModel.DataAnnotations;
using Rxlightning.Validator;

namespace Rxlightning.Entities
{
    public class Patients
    {

        public string patientId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        [FirstLetterUpperCaseAttribute]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }


    }
}

