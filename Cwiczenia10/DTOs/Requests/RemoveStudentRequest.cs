using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia10.DTOs.Requests
{
    public class RemoveStudentRequest
    {
        [Required]
        public string IndexNumber { get; set; }
    }
}
