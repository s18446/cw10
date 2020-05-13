using Cwiczenia10.DTOs.Requests;
using Cwiczenia10.DTOs.Responses;
using Microsoft.EntityFrameworkCore;
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

        public ModifyStudentResponse ModifyStudent(ModifyStudentRequest request)
        {

            try
            {
                var student = _dbContext.Student.Where(s => s.IndexNumber == request.IndexNumber).Single();

                student.FirstName = request?.FirstName ?? student.FirstName;
                student.LastName = request?.LastName ?? student.LastName;
               // student.IdEnrollment = request?.IdEnrollment ?? student.IdEnrollment; ------ Nie mozna zmienic bo klucz obcy i wyrzuca wyjatek 
                student.BirthDate = request?.birthDate ?? student.BirthDate;
                student.Password = request?.password ?? student.Password;

                _dbContext.SaveChanges();
            }catch (Exception exc)
            {
                throw exc;
            }
          /*    var student = new Student
              {
                  FirstName = request.FirstName,
                  LastName = request.LastName,
                  IndexNumber = request.LastName,
                  IdEnrollment = request.IdEnrollment,
                  BirthDate = request.birthDate,
                  Password = request.password
              };

              _dbContext.Attach(student);
              _dbContext.Entry(student).State = EntityState.Modified;
              _dbContext.SaveChanges();
             */
             return new ModifyStudentResponse
              {
                  FirstName = request.FirstName,
                  LastName = request.LastName,
                  IndexNumber = request.LastName,
                  IdEnrollment = request.IdEnrollment,
                  birthDate = request.birthDate
              };     
        }

        public RemoveStudentResponse RemoveStudent(RemoveStudentRequest request)
        {
            RemoveStudentResponse response;
            try
            {
                var student = _dbContext.Student.Where(s => s.IndexNumber == request.IndexNumber).Single();
                Console.WriteLine(student.FirstName);
                response = new RemoveStudentResponse
                {
                    IndexNumber = student.IndexNumber
                };
                
                _dbContext.Student.Remove(student);
                _dbContext.SaveChanges();
              
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return response;        
        }
    }
}
