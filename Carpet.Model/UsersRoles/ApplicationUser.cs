using Carpet.Domain.ServiceProviders;
using Microsoft.AspNetCore.Identity;

namespace Carpet.Domain.UsersRoles;

public class ApplicationUser : IdentityUser
{
    public Guid? ServiceCarpetId { get; set; }
    public virtual ServiceCarpet ServiceCarpet { get; set; }
  //  public virtual ApplicationRole Role { get; set; }
}

