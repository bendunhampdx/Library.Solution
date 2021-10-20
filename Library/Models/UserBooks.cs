
namespace Library.Models
{
  public class UserBooks
  {
    public int UserBooksId {get; set;}
    public int BookId {get; set;}

    public string UserId {get; set;}

    public virtual ApplicationUser User {get; set;}
    public virtual Book Book {get; set;}
  }
}