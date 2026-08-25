using AutoMapper;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZeroHungerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly RestaurantService service;

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
        public IActionResult Add(RestaurantModel Restaurant)
        {
            service.Add(Restaurant);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, RestaurantModel Restaurant)
        {
            service.Update(id, Restaurant);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }

        [HttpGet("CollectionRequestByRestaurantId/{restaurantId}")]
        public IActionResult GetCollectionRequestsByRestaurantId(int restaurantId)
        {
            var data = service.GetCollectionRequestsByRestaurantId(restaurantId);
            return Ok(data);
        }

    }
}
