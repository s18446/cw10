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

        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request)
        {
            EnrollStudentResponse response = new EnrollStudentResponse();



            var studies = _dbContext.Studies
                                    .Where(s => s.Name.Equals(request.Studies))
                                    .Single();

            var enrollment = _dbContext.Enrollment
                                        .Where(e => e.IdStudy == studies.IdStudy && e.Semester == 1)
                                        .SingleOrDefault();

            int idEnrollment;
            if (enrollment == null)
            {
                idEnrollment = _dbContext.Enrollment.Count();
                var e = new Enrollment
                {
                    IdEnrollment = idEnrollment,
                    Semester = 1,
                    IdStudy = studies.IdStudy,
                    StartDate = DateTime.Now
                };

                _dbContext.Enrollment.Add(e);
                _dbContext.SaveChanges();
            }
            else
            {
                idEnrollment = enrollment.IdEnrollment;
            }

            var student = new Student
            {
                IndexNumber = request.IndexNumber,
                IdEnrollment = idEnrollment,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.birthDate             
            };
            _dbContext.Student.Add(student);
            _dbContext.SaveChanges();
            response = new EnrollStudentResponse
            {
                LastName = student.LastName,
                Semester = enrollment.Semester,
                StartDate = enrollment.StartDate
            };
            return response;
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
