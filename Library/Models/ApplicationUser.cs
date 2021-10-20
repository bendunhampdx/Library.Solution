using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Library.Models
{
  public class ApplicationUser : IdentityUser
  {
    public virtual Book Book {get; set;}
    public virtual ICollection<UserBooks> JoinUserBooks {get;}
  }
}