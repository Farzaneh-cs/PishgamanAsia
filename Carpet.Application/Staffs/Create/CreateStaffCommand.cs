using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Staffs;
using Microsoft.AspNetCore.Http;

namespace Carpet.Application.Staffs.Create;

public record CreateStaffCommand(string family,
                 string name,
                 string fatherName,
                 string mobile,
                 string nationalCode,
                 IFormFile image,
                 Guid userId) :ICommand<Guid>;
