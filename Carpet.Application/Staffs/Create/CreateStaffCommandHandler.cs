using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Staffs;
using Carpet.Infrastructure.Staffs;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Carpet.Application.Staffs.Create;

public class CreateStaffCommandHandler : ICommandHandler<CreateStaffCommand, Guid>
{
    private readonly IStaffRepository _staffRepository;

    public CreateStaffCommandHandler(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }
    public async Task<Guid> Handle(CreateStaffCommand command, CancellationToken cancellationToken)
    {
  
        var file = command.image as IFormFile;
        if (file != null)
        {
            if (file.Length < 1 * 1024 * 1024 || file.Length > 2 * 1024 * 1024)
            {
                throw new ValidationException($"تصویر میبایست بین 1 تا 2 مگابایت باشد");
            }

        }
        var staffGuid =  Guid.Empty;
        using (var memoryStream = new MemoryStream())
        {
            var entity = _staffRepository.CheckIsUniqeNameAsync(command.family).Result;

            if (entity != null)
            {
                throw new ValidationException("نام خانوادگی تکراری است.");
            }

            await command.image.CopyToAsync(memoryStream);
 
            var staff = Staff.Create(command.family, command.name, command.fatherName,
                                  command.mobile, command.nationalCode, command.image.FileName, memoryStream.ToArray(),command.userId);
            staffGuid = _staffRepository.CreateAsync(staff);
        }
        return staffGuid;
    }
}
