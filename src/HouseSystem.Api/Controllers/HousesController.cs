using HouseSystem.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseSystem.Api.Controllers;

[Route("api/houses")]
[ApiController]
public class HousesController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateHouse([FromBody] Models.HouseCreateDto houseCreateDto)
    {
        var createdHouse = new HouseDto
        {
            HouseId = Guid.NewGuid(),
            Address = houseCreateDto.Address,
            NumberOfRooms = houseCreateDto.NumberOfRooms,
            Price = (decimal)houseCreateDto.Price
        };
        return Ok(createdHouse);
    }

    [HttpGet]
    public IActionResult GetHouses()
    {
        var houses = new List<HouseDto>
        {
            new HouseDto
            {
                HouseId = Guid.NewGuid(),
                Address = "123 Main St",
                NumberOfRooms = 3,
                Price = 250000m
            },
            new HouseDto
            {
                HouseId = Guid.NewGuid(),
                Address = "456 Oak Ave",
                NumberOfRooms = 4,
                Price = 350000m
            }
        };
        return Ok(houses);
    }

}
