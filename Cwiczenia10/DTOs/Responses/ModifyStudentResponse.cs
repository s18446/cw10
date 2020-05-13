using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia10.DTOs.Responses
{
    public class ModifyStudentResponse
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IndexNumber { get; set; }

        public DateTime birthDate { get; set; }

        public int IdEnrollment { get; set; }
    }
}
