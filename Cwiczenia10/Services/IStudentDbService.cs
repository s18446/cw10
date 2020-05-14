using Cwiczenia10.DTOs.Requests;
using Cwiczenia10.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia10.Services
{
    public interface IStudentDbService
    {
        public List<Student> GetStudents();

        public ModifyStudentResponse ModifyStudent(ModifyStudentRequest request);

        public RemoveStudentResponse RemoveStudent(RemoveStudentRequest request);

        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request);

        public PromoteStudentResponse PromoteStudents(PromoteStudentRequest request);
    }
}
