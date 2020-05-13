using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia10.DTOs.Requests
{
    public class ModifyStudentRequest
    {
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        [Required]
        public string IndexNumber { get; set; }
       
        public DateTime birthDate { get; set; }
       
        public int IdEnrollment { get; set; }
        
        public string password { get; set; }

    }
}
