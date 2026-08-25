using AutoMapper;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ZeroHungerApi.Controllers
{
    public class AssignmentsController : Controller
    {

        private readonly IMapper mapper;
        private readonly AssignmentService service;

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return Ok(data);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var data = service.GetById(id);
            return Ok(data);
        }

        [HttpPost("Add")]
        public IActionResult Add(AssignmentModel Assignment)
        {
            service.Add(Assignment);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, AssignmentModel Assignment)
        {
            service.Update(id, Assignment);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }

        [HttpGet("GetByEmployeeId/{employeeId}")]
        public IActionResult GetByEmployeeId(int employeeId)
        {
            var data = service.GetByEmployeeId(employeeId);
            return Ok(data);
        }

        [HttpGet("GetByRequestId/{requestId}")]
        public IActionResult GetByRequestId(int requestId)
        {
            var data = service.GetByRequestId(requestId);

            if (data == null)
                return NotFound();

            return Ok(data);
        }


        [HttpPut("UpdateStatus/{id}/{status}")]
        public IActionResult UpdateStatus(int id, string status)
        {
            if (status == "Accepted" || status == "Cancelled" || status == "Collect" || status == "Distributed")
            {
                service.UpdateStatus(id, status);
                return Ok();
            }
            return BadRequest("Invalid status. Please use 'Accepted', 'Cancelled', 'Collect', or 'Distributed'.");
        }
    }
}
