using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
  public class LibraryContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Book> Books {get; set;}
    public DbSet<Author> Authors {get; set;}

    public DbSet<BookAuthors> BookAuthors {get;set;}
    public DbSet<UserBooks> UserBooks {get; set;}

    public DbSet<ApplicationUser> ApplicationUsers {get; set;}

    public LibraryContext(DbContextOptions options) : base(options) {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}