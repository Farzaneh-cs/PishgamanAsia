namespace Carpet.API.Controllers.Staffs;

public class StaffRequest
{
    public string Family { get; set; }
    public string? name { get; set; }
    public string fatherName { get; set; }
    public string mobile { get; set; }
    public string nationalCode { get; set; }
    public IFormFile image { get; set; }
}                