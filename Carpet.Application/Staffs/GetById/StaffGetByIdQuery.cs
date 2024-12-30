using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Staffs;

namespace Carpet.Application.Staffs.GetById;

public record StaffGetByIdQuery(Guid Id):IQuery<Staff>;

