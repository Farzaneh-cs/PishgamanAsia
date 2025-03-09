using System.ComponentModel.DataAnnotations;

namespace Carpet.Domain.Staffs;

public class Staff
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string FatherName { get; set; }

    [Required]
    public string NationalCode { get; set; }

    [Required]
    public string MobileNumber { get; set; }
    
    [Required]
    public string FileName { get; set; }
    [Required]
    public byte[] FileContent { get; set; }
    private Staff() { }

    private Staff(string family,
                 string name,
                 string fatherName,
                 string mobile,
                 string nationalCode,
                 string filename,
                 byte[] image,
                 Guid userId)
    {
        FirstName = name;
        FatherName = fatherName;
        LastName = family;
        MobileNumber = mobile;
        NationalCode = nationalCode;
        FileName = filename;
        FileContent = image;
        UserId = userId;
    }

    public static Staff Create(string family,
                               string name,
                               string fatherName,
                               string mobile,
                               string nationalCode,
                                string filename,
                               byte[] image,
                               Guid userId)
        => new Staff(family, name, fatherName, mobile, nationalCode,filename,image, userId);

}
