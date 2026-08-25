using AutoMapper;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZeroHungerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly FoodItemService service;

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
        public IActionResult Add(FoodItemModel foodItem)
        {
            service.Add(foodItem);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, FoodItemModel foodItem)
        {
            service.Update(id, foodItem);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }

    }
}
