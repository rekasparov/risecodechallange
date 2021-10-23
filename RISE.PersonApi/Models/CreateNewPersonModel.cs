using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.PersonApi.Models
{
    public class CreateNewPersonModel
    {
        public CreateNewPersonModel()
        {
            PersonContacts = new List<PersonContactModel>();
        }

        public PersonModel Person { get; set; }
        public List<PersonContactModel> PersonContacts { get; set; }

        public class PersonModel
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Surname { get; set; }
            [Required]
            public string Company { get; set; }
        }

        public class PersonContactModel
        {
            [Required]
            public string PhoneNumber { get; set; }
            [Required]
            public string EmailAddress { get; set; }
            [Required]
            public string Location { get; set; }
        }
    }
}
