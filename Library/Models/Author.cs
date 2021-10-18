using System.Collections.Generic;

namespace Library.Models
{
  public class Author
  {
    public Author()
    {
      this.JoinEntities = new HashSet<BookAuthors>();
    }

    public int AuthorId {get; set;}

    public string OwnerId { get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}

    public virtual ICollection<BookAuthors> JoinEntities {get; set;}
    public AuthorStatus Status { get; set; }

  }
  public enum AuthorStatus
  {
    Submitted,
    Approved,
    Rejected
  }
}