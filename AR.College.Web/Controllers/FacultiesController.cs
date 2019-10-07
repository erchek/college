using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AR.College.Data.Models;
using AR.College.Business.Interface;

namespace AR.College.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultiesController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        // GET: api/Faculties
        [HttpGet]
        public async Task<IEnumerable<Faculty>> GetFaculties()
        {
            return await _facultyService.GetAllAsync();
        }

        // GET: api/Faculties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFaculty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var faculty = await _facultyService.GetAsync(id);

            if (faculty == null)
            {
                return NotFound();
            }

            return Ok(faculty);
        }

        // PUT: api/Faculties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaculty([FromRoute] int id, [FromBody] Faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faculty.Id)
            {
                return BadRequest();
            }

            bool isSuccess = await _facultyService.UpdateAsync(id, faculty);
            if (!isSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Faculties
        [HttpPost]
        public async Task<IActionResult> PostFaculty([FromBody] Faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            faculty = await _facultyService.AddAsync(faculty);

            return Ok(faculty);
        }

        // DELETE: api/Faculties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaculty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isSuccess = await _facultyService.DeleteAsync(id);
            if (!isSuccess)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}