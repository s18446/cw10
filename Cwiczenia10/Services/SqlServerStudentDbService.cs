using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia10.Services
{
    public class SqlServerStudentDbService : IStudentDbService
    {
        s18446Context _dbContext;

        public SqlServerStudentDbService(s18446Context dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Student> GetStudents()
        {
            return _dbContext.Student.ToList();         
        }
    }
}
