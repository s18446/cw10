using Cwiczenia10.DTOs.Requests;
using Cwiczenia10.DTOs.Responses;
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

        [HttpPost("modify")]
        public IActionResult ModifyStudent(ModifyStudentRequest request)
        {
            ModifyStudentResponse response;

            try
            {
                
                response = _dbService.ModifyStudent(request);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(response);
        }

        [HttpPost("remove")]
        public IActionResult RemoveStudent(RemoveStudentRequest request)
        {
            RemoveStudentResponse response;
            try
            {
                response = _dbService.RemoveStudent(request);
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong");
            }

            return Ok(response);
           
        }
    }
}
