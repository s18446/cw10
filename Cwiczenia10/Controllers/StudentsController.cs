using Cwiczenia10.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia10.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentDbService _dbService;
        public StudentsController(IStudentDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            List<Student> response;
            try
            {
                response = _dbService.GetStudents();
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(response);
        }
    }
}
