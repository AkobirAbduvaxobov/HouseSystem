namespace HouseSystem.Api.Models;

public class HouseDto
{
    public Guid HouseId { get; set; }
    public string Address { get; set; }
    public int NumberOfRooms { get; set; }
    public decimal Price { get; set; }
}
