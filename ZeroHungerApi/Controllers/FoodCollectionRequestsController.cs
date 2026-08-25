using AutoMapper;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZeroHungerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCollectionRequestsController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly FoodCollectionRequestService service;

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
        public IActionResult Add(FoodCollectionRequestModel FoodCollectionRequest)
        {
            service.Add(FoodCollectionRequest);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, FoodCollectionRequestModel FoodCollectionRequest)
        {
            service.Update(id, FoodCollectionRequest);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }

        [HttpPut("{id}/{status}")]
        public IActionResult UpdateStatus(int id, string status)
        {
            if (status == "Accepted" || status == "Cancelled")
            {

                service.UpdateStatus(id, status);
                return Ok();
            }
            return BadRequest("Invalid status. Please use 'Accepted' or 'Cancelled'.");
        }


    }
}
